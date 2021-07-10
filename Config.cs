using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Windows.Forms;

namespace CTXMapDownloader
{
    public static class Config
    {
        public const string FILE_NAME = "settings.cfg";
        public const string PARAM_GAMEPATH = "gamepath";
        public const string CSGO_FOLDER = "Counter-Strike Global Offensive";

        public static List<string> lines = new List<string>();
        public static string gamePath;

        public static void Initialize()
        {
            if ( !File.Exists( FILE_NAME ) )
            {
                File.Create( FILE_NAME ).Close();
            }

            foreach ( string line in File.ReadLines( FILE_NAME ) )
                lines.Add( line );

            string path = GetString( PARAM_GAMEPATH );

            if ( path != null && File.Exists( path + "\\csgo.exe" ) )
            {
                SetGameFolder( path );
                return;
            }

            SearchForGamePath();
        }

        public static void SetString( string name, string value )
        {
            if ( lines.Count == 0 )
            {
                lines.Add( name + " = " + value );
            }
            else
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    string replaced = Regex.Replace( lines[i], @"\s+|\u0022+", "" );

                    int pos = replaced.IndexOf( '=' );
                    if (pos == -1)
                        continue;

                    if (replaced.Substring( 0, pos ).Equals( name ))
                    {
                        lines.RemoveAt( i );
                        lines.Insert( i, name + " = " + value );
                    }
                }
            }
            File.WriteAllLines( FILE_NAME, lines );
        }

        public static string GetString( string name )
        {
            if ( lines.Count == 0 )
                return null;

            for ( int i = 0; i < lines.Count; i++ )
            {
                string replaced = Regex.Replace( lines[ i ], @"\s+|\u0022+", "" );

                int pos = replaced.IndexOf( '=' );
                if ( pos == -1 )
                    continue;


                if ( replaced.Substring( 0, pos ).Equals( name ) )
                    return replaced.Substring( pos + 1 );
            }
            return null;
        }

        private static void SearchForGamePath()
        {
            string steamPath = ( string )Registry.GetValue( "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Valve\\Steam", "InstallPath", String.Empty );
            if ( steamPath == String.Empty )
            {
                SetGameFolderManual();
                return;
            }

            if ( File.Exists( steamPath + "\\steamapps\\common\\Counter-Strike Global Offensive\\csgo.exe" ) )
            {
                SetGameFolder( steamPath + "\\steamapps\\common\\Counter-Strike Global Offensive" );
                return;
            }

            string libFile = steamPath + "\\steamapps\\libraryfolders.vdf";
            if ( !File.Exists( libFile ) )
            {
                SetGameFolderManual();
                return;
            }

            string cont = Regex.Replace( File.ReadAllText( libFile ), @"\u0022+", "" );

            foreach ( string entry in cont.Split( null ) )
            {
                if ( !String.IsNullOrWhiteSpace( entry ) && entry.Contains( "\\\\" ) )
                {
                    string dir = entry.Replace( "\\\\", "\\" );

                    if ( File.Exists( dir + "\\steamapps\\common\\Counter-Strike Global Offensive\\csgo.exe" ) )
                    {
                        SetGameFolder( dir + "\\steamapps\\common\\Counter-Strike Global Offensive" );
                        return;
                    }
                }
            }

            SetGameFolderManual();
            return;
        }

        private static void SetGameFolderManual()
        {
            DialogResult result = FormMain.folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = FormMain.folderBrowser.SelectedPath;

                int pos = path.IndexOf( CSGO_FOLDER );
                if ( pos == -1 )
                {
                    return;
                }

                path = path.Substring( 0, pos + CSGO_FOLDER.Length );

                if ( !File.Exists( path + "\\csgo.exe" ) )
                {
                    return;
                }

                SetGameFolder( path );
            }
        }

        private static void SetGameFolder( string path )
        {
            gamePath = path;
            SetString( PARAM_GAMEPATH, gamePath );
        }

        public static bool IsGameFolderValid()
        {
            if ( File.Exists( gamePath + "\\csgo.exe" ) )
            {
                return true;
            }

            SetGameFolderManual();
            return false;
        }
    }
}
