using System;
using System.Drawing;
using System.Windows.Forms;

namespace CTXMapDownloader
{
    public partial class FormMain : Form
    {
        public static FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
        public static FormMain Instance;

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        private bool buttonDownload = true;

        public FormMain()
        {
            Instance = this;
            InitializeComponent();
            InitializeStaticComponents();
            Config.Initialize();
        }

        private static void InitializeStaticComponents()
        {
            folderBrowser.ShowNewFolderButton = false;
            folderBrowser.Description = "Укажите папку с Counter-Strike Global Offensive";
        }

        private void buttonExit_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }

        private void buttonExit_MouseEnter( object sender, EventArgs e )
        {
            buttonExit.BackColor = Color.Teal;
        }

        private void buttonExit_MouseLeave( object sender, EventArgs e )
        {
            buttonExit.BackColor = Color.SlateGray;
        }

        private void buttonConn_MouseEnter( object sender, EventArgs e )
        {
            buttonConn.BackColor = Color.Teal;
        }

        private void buttonConn_MouseLeave( object sender, EventArgs e )
        {
            buttonConn.BackColor = Color.SlateGray;
        }

        private void buttonConn_Click( object sender, EventArgs e )
        {
            if ( buttonDownload )
            {
                if ( !Config.IsGameFolderValid() )
                    return;

                buttonDownload = false;
                labelButtonConn.Text = "CANCEL";
                panelStatus.Width = 0;
                labelStatus.Text = "Подключение...";

                Downloader.Download( textBoxAddress.Text, Download_OnError, Download_OnStart, Download_OnFinished );
            }
            else
            {
                buttonDownload = true;
                labelButtonConn.Text = "DOWNLOAD";
                labelStatus.Text = "";

                Downloader.Cancel();
            }
        }

        private void Download_OnError( string err )
        {
            BeginInvoke( new MethodInvoker( delegate
            {
                buttonDownload = true;
                labelButtonConn.Text = "DOWNLOAD";
                buttonConn.Enabled = true;
                labelStatus.Text = err;
            } ) );
        }

        private void Download_OnStart()
        {
            BeginInvoke( new MethodInvoker( delegate
            {
                buttonDownload = true;
                labelButtonConn.Text = "DOWNLOAD";
                buttonConn.Enabled = false;
            } ) );
        }

        private void Download_OnFinished()
        {
            BeginInvoke( new MethodInvoker( delegate
            {
                buttonDownload = true;
                labelButtonConn.Text = "DOWNLOAD";
                buttonConn.Enabled = true;
                panelStatus.Width = this.Width - panelStatus.Location.X * 2;
                labelStatus.Text = "Завершено.";
            } ) );
        }

        protected override void WndProc( ref Message m )
        {
            base.WndProc( ref m );
            if ( m.Msg == WM_NCHITTEST )
                m.Result = ( IntPtr )( HT_CAPTION );
        }

        private void timer_Tick( object sender, EventArgs e )
        {
            if ( !Downloader.downloading )
                return;

            double perc = Downloader.bytesIn / Downloader.bytesTotal * 100.0;
            double mBytesIn = Downloader.bytesIn / 1048576;
            double mBytesTotal = Downloader.bytesTotal / 1048576;

            panelStatus.Size = new Size( ( int )( 4.87 * perc ), 24 );

            labelStatus.Text = "[ "+ ( Downloader.mapNumber + 1 ) + " / " + Downloader.mapList.Count + " ] " + Downloader.mapList[ Downloader.mapNumber ]+"\n" +
            "скачено " + Math.Round( mBytesIn, 2 ) + " / " + Math.Round( mBytesTotal, 2 ) + " Mb\n" +
            "";
        }
    }
}
