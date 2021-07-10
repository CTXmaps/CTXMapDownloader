using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.ComponentModel;

namespace CTXMapDownloader
{
    public static class Downloader
    {
        public const string REGEX_IP = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
        public const int PORT = 21123;

        private static readonly HttpClient httpClient = new HttpClient();

        private static Action<string> OnErrorCallback;
        private static Action OnFinishedCallback;
        private static Uri uri;
        public static List<string> mapList = new List<string>();
        public static int mapNumber = 0;
        public static double bytesIn;
        public static double bytesTotal;
        public static bool downloading;

        public static async void Download( string ip, Action<string> OnError, Action OnStart, Action OnFinished )
        {
            if ( downloading )
                return;

            OnErrorCallback = OnError;
            OnFinishedCallback = OnFinished;

            await Task.Factory.StartNew( async () =>
            {
                ip = ip.Trim();

                if ( String.IsNullOrWhiteSpace( ip ) || !Regex.IsMatch( ip, REGEX_IP ) )
                {
                    OnErrorCallback( "Неверный ip адрес" );
                    return;
                }

                uri = new Uri( "http://" + ip + ":" + PORT + "/csgo/maps" );

                mapList.Clear();
                mapNumber = 0;

                try
                {
                    string body = await httpClient.GetStringAsync( uri );

                    int start = 0;
                    while ( body.IndexOf( ".bsp", start + 1 ) != -1 )
                    {
                        start = body.IndexOf( ".bsp", start + 1 );

                        int i = start;
                        while ( body[i] != '\"' )
                        {
                            i--;
                        }

                        string mapName = body.Substring( i + 1, start - i + 3 );

                        bool exists = false;
                        foreach ( string map in mapList )
                        {
                            if ( mapName.Contains( map ) )
                            {
                                exists = true;
                                break;
                            }
                        }

                        if ( !exists )
                            mapList.Add( mapName );
                    }

                }
                catch( HttpRequestException e )
                {
                    OnErrorCallback( "Ошибка подключения" );
                    return;
                }

                if ( mapList.Count == 0 )
                {
                    OnErrorCallback( "Список карт не найден" );
                    return;
                }

                OnStart();
                SetNextFileForDownload();

            } );
        }

        private static void SetNextFileForDownload()
        {
            downloading = true;

            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadProgressChanged += DownloadProgressChanged;
                webClient.DownloadFileCompleted += DownloadFileCompleted;
                webClient.DownloadFileAsync( new Uri( uri.OriginalString + "/" + mapList[mapNumber] ), Config.gamePath + "\\csgo\\maps\\" + mapList[mapNumber] );
            }
            catch ( WebException e )
            {
                OnErrorCallback( "Ошибка подключения" );
                return;
            }
            catch ( Exception e )
            {
                OnErrorCallback( "Ошибка подключения" );
                return;
            }
        }

        private static void DownloadProgressChanged( object sender, DownloadProgressChangedEventArgs e )
        {
            bytesIn = e.BytesReceived;
            bytesTotal = e.TotalBytesToReceive;
        }

        private static void DownloadFileCompleted( object sender, AsyncCompletedEventArgs e )
        {
            if ( mapNumber < mapList.Count - 1 )
            {
                mapNumber++;
                SetNextFileForDownload();
            }
            else
            {
                downloading = false;
                OnFinishedCallback();
            }
        }

        public static void Cancel()
        {
            httpClient.CancelPendingRequests();
        }
    }
}
