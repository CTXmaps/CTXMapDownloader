
namespace CTXMapDownloader
{
	public partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.textBoxAddress = new System.Windows.Forms.TextBox();
			this.labelStatus = new System.Windows.Forms.Label();
			this.buttonExit = new System.Windows.Forms.Panel();
			this.labelExit = new System.Windows.Forms.Label();
			this.buttonConn = new System.Windows.Forms.Panel();
			this.labelButtonConn = new System.Windows.Forms.Label();
			this.labelAddress = new System.Windows.Forms.Label();
			this.panelStatus = new System.Windows.Forms.Panel();
			this.labelPath = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.buttonExit.SuspendLayout();
			this.buttonConn.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxAddress
			// 
			this.textBoxAddress.BackColor = System.Drawing.Color.SlateGray;
			this.textBoxAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxAddress.Location = new System.Drawing.Point(166, 88);
			this.textBoxAddress.Name = "textBoxAddress";
			this.textBoxAddress.Size = new System.Drawing.Size(180, 20);
			this.textBoxAddress.TabIndex = 1;
			this.textBoxAddress.Text = "192.168.1.35";
			// 
			// labelStatus
			// 
			this.labelStatus.Enabled = false;
			this.labelStatus.Location = new System.Drawing.Point(148, 180);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(216, 67);
			this.labelStatus.TabIndex = 2;
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// buttonExit
			// 
			this.buttonExit.BackColor = System.Drawing.Color.SlateGray;
			this.buttonExit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.buttonExit.Controls.Add(this.labelExit);
			this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonExit.Location = new System.Drawing.Point(476, 12);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(24, 24);
			this.buttonExit.TabIndex = 4;
			this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
			this.buttonExit.MouseEnter += new System.EventHandler(this.buttonExit_MouseEnter);
			this.buttonExit.MouseLeave += new System.EventHandler(this.buttonExit_MouseLeave);
			// 
			// labelExit
			// 
			this.labelExit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelExit.Enabled = false;
			this.labelExit.Location = new System.Drawing.Point(0, 0);
			this.labelExit.Margin = new System.Windows.Forms.Padding(0);
			this.labelExit.Name = "labelExit";
			this.labelExit.Size = new System.Drawing.Size(22, 22);
			this.labelExit.TabIndex = 0;
			this.labelExit.Text = "X";
			this.labelExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonConn
			// 
			this.buttonConn.BackColor = System.Drawing.Color.SlateGray;
			this.buttonConn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.buttonConn.Controls.Add(this.labelButtonConn);
			this.buttonConn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonConn.Location = new System.Drawing.Point(166, 127);
			this.buttonConn.Name = "buttonConn";
			this.buttonConn.Size = new System.Drawing.Size(180, 37);
			this.buttonConn.TabIndex = 5;
			this.buttonConn.Click += new System.EventHandler(this.buttonConn_Click);
			this.buttonConn.MouseEnter += new System.EventHandler(this.buttonConn_MouseEnter);
			this.buttonConn.MouseLeave += new System.EventHandler(this.buttonConn_MouseLeave);
			// 
			// labelButtonConn
			// 
			this.labelButtonConn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelButtonConn.Enabled = false;
			this.labelButtonConn.Location = new System.Drawing.Point(0, 0);
			this.labelButtonConn.Margin = new System.Windows.Forms.Padding(0);
			this.labelButtonConn.Name = "labelButtonConn";
			this.labelButtonConn.Size = new System.Drawing.Size(178, 35);
			this.labelButtonConn.TabIndex = 0;
			this.labelButtonConn.Text = "DOWNLOAD";
			this.labelButtonConn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelAddress
			// 
			this.labelAddress.AutoSize = true;
			this.labelAddress.Location = new System.Drawing.Point(145, 90);
			this.labelAddress.Name = "labelAddress";
			this.labelAddress.Size = new System.Drawing.Size(15, 13);
			this.labelAddress.TabIndex = 6;
			this.labelAddress.Text = "ip";
			// 
			// panelStatus
			// 
			this.panelStatus.BackColor = System.Drawing.Color.Teal;
			this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelStatus.Enabled = false;
			this.panelStatus.Location = new System.Drawing.Point(12, 223);
			this.panelStatus.Name = "panelStatus";
			this.panelStatus.Size = new System.Drawing.Size(0, 24);
			this.panelStatus.TabIndex = 7;
			// 
			// labelPath
			// 
			this.labelPath.AutoSize = true;
			this.labelPath.Location = new System.Drawing.Point(9, 9);
			this.labelPath.Name = "labelPath";
			this.labelPath.Size = new System.Drawing.Size(0, 13);
			this.labelPath.TabIndex = 8;
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.SlateGray;
			this.ClientSize = new System.Drawing.Size(512, 256);
			this.ControlBox = false;
			this.Controls.Add(this.labelPath);
			this.Controls.Add(this.panelStatus);
			this.Controls.Add(this.labelAddress);
			this.Controls.Add(this.buttonConn);
			this.Controls.Add(this.buttonExit);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.textBoxAddress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "";
			this.buttonExit.ResumeLayout(false);
			this.buttonConn.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Panel buttonExit;
        private System.Windows.Forms.Label labelExit;
        private System.Windows.Forms.Panel buttonConn;
        private System.Windows.Forms.Label labelButtonConn;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Panel panelStatus;
		private System.Windows.Forms.Label labelPath;
		private System.Windows.Forms.Timer timer;
	}
}

