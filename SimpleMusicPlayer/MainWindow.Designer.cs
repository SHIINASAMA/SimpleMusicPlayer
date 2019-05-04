using System;
using System.Diagnostics;

namespace SimpleMusicPlayer
{
    partial class MyMainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            try
            {
                base.Dispose(disposing);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyMainWindow));
            this.AlbumPicture = new System.Windows.Forms.PictureBox();
            this.ListListBox = new CCWin.SkinControl.SkinListBox();
            this.gmTrackBar1 = new Gdu.WinFormUI.GMTrackBar();
            this.MainBar = new CCWin.SkinControl.SkinPanel();
            this.gmTrackBar2 = new Gdu.WinFormUI.GMTrackBar();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.AllTime = new System.Windows.Forms.Label();
            this.NowPos = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.Singer = new System.Windows.Forms.Label();
            this.SongName = new System.Windows.Forms.Label();
            this.MusicListBox = new CCWin.SkinControl.SkinListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumPicture)).BeginInit();
            this.MainBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.skinPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AlbumPicture
            // 
            this.AlbumPicture.BackColor = System.Drawing.Color.White;
            this.AlbumPicture.Image = global::SimpleMusicPlayer.Properties.Resources.唱片CD;
            this.AlbumPicture.Location = new System.Drawing.Point(7, 237);
            this.AlbumPicture.Name = "AlbumPicture";
            this.AlbumPicture.Size = new System.Drawing.Size(183, 182);
            this.AlbumPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AlbumPicture.TabIndex = 0;
            this.AlbumPicture.TabStop = false;
            // 
            // ListListBox
            // 
            this.ListListBox.Back = null;
            this.ListListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ListListBox.FormattingEnabled = true;
            this.ListListBox.ItemBorderVisble = false;
            this.ListListBox.Location = new System.Drawing.Point(7, 60);
            this.ListListBox.Name = "ListListBox";
            this.ListListBox.Size = new System.Drawing.Size(183, 173);
            this.ListListBox.TabIndex = 1;
            this.ListListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListListBox_MouseDoubleClick);
            // 
            // gmTrackBar1
            // 
            this.gmTrackBar1.Location = new System.Drawing.Point(233, 18);
            this.gmTrackBar1.Name = "gmTrackBar1";
            this.gmTrackBar1.Size = new System.Drawing.Size(450, 24);
            this.gmTrackBar1.TabIndex = 0;
            this.gmTrackBar1.XTheme = null;
            this.gmTrackBar1.ValueChanged += new System.EventHandler(this.gmTrackBar1_ValueChanged);
            this.gmTrackBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gmTrackBar1_MouseDown);
            this.gmTrackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gmTrackBar1_MouseUp);
            // 
            // MainBar
            // 
            this.MainBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainBar.BackColor = System.Drawing.Color.White;
            this.MainBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(126)))), ((int)(((byte)(168)))));
            this.MainBar.Controls.Add(this.gmTrackBar2);
            this.MainBar.Controls.Add(this.pictureBox5);
            this.MainBar.Controls.Add(this.pictureBox4);
            this.MainBar.Controls.Add(this.AllTime);
            this.MainBar.Controls.Add(this.NowPos);
            this.MainBar.Controls.Add(this.pictureBox2);
            this.MainBar.Controls.Add(this.pictureBox3);
            this.MainBar.Controls.Add(this.pictureBox1);
            this.MainBar.Controls.Add(this.gmTrackBar1);
            this.MainBar.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.MainBar.DownBack = null;
            this.MainBar.Location = new System.Drawing.Point(0, 484);
            this.MainBar.MouseBack = null;
            this.MainBar.Name = "MainBar";
            this.MainBar.NormlBack = null;
            this.MainBar.Size = new System.Drawing.Size(1012, 64);
            this.MainBar.TabIndex = 2;
            // 
            // gmTrackBar2
            // 
            this.gmTrackBar2.Location = new System.Drawing.Point(761, 18);
            this.gmTrackBar2.Maximum = 100;
            this.gmTrackBar2.Name = "gmTrackBar2";
            this.gmTrackBar2.Size = new System.Drawing.Size(184, 24);
            this.gmTrackBar2.TabIndex = 5;
            this.gmTrackBar2.Value = 40;
            this.gmTrackBar2.XTheme = null;
            this.gmTrackBar2.ValueChanged += new System.EventHandler(this.gmTrackBar2_ValueChanged);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::SimpleMusicPlayer.Properties.Resources.列表循环;
            this.pictureBox5.Location = new System.Drawing.Point(951, 10);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(54, 42);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::SimpleMusicPlayer.Properties.Resources.声音;
            this.pictureBox4.Location = new System.Drawing.Point(727, 18);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(27, 27);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // AllTime
            // 
            this.AllTime.AutoSize = true;
            this.AllTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AllTime.Location = new System.Drawing.Point(689, 22);
            this.AllTime.Name = "AllTime";
            this.AllTime.Size = new System.Drawing.Size(32, 16);
            this.AllTime.TabIndex = 2;
            this.AllTime.Text = "0:0";
            // 
            // NowPos
            // 
            this.NowPos.AutoSize = true;
            this.NowPos.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NowPos.Location = new System.Drawing.Point(195, 22);
            this.NowPos.Name = "NowPos";
            this.NowPos.Size = new System.Drawing.Size(32, 16);
            this.NowPos.TabIndex = 2;
            this.NowPos.Text = "0:0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SimpleMusicPlayer.Properties.Resources.播放器_下一集_44;
            this.pictureBox2.Location = new System.Drawing.Point(131, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SimpleMusicPlayer.Properties.Resources.播放器_播放_44;
            this.pictureBox3.Location = new System.Drawing.Point(67, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(58, 58);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SimpleMusicPlayer.Properties.Resources.播放器_上一集_44;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.White;
            this.skinPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(126)))), ((int)(((byte)(168)))));
            this.skinPanel1.Controls.Add(this.Singer);
            this.skinPanel1.Controls.Add(this.SongName);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(7, 422);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(183, 58);
            this.skinPanel1.TabIndex = 3;
            // 
            // Singer
            // 
            this.Singer.AutoSize = true;
            this.Singer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Singer.Location = new System.Drawing.Point(4, 32);
            this.Singer.Name = "Singer";
            this.Singer.Size = new System.Drawing.Size(41, 12);
            this.Singer.TabIndex = 1;
            this.Singer.Text = "Singer";
            // 
            // SongName
            // 
            this.SongName.AutoSize = true;
            this.SongName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SongName.Location = new System.Drawing.Point(1, 12);
            this.SongName.Name = "SongName";
            this.SongName.Size = new System.Drawing.Size(80, 16);
            this.SongName.TabIndex = 1;
            this.SongName.Text = "SongName";
            // 
            // MusicListBox
            // 
            this.MusicListBox.Back = null;
            this.MusicListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MusicListBox.FormattingEnabled = true;
            this.MusicListBox.Location = new System.Drawing.Point(196, 60);
            this.MusicListBox.Name = "MusicListBox";
            this.MusicListBox.Size = new System.Drawing.Size(763, 420);
            this.MusicListBox.TabIndex = 4;
            this.MusicListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MusicListBox_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(965, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "添加列表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(965, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "删除列表";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(965, 143);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 35);
            this.button3.TabIndex = 5;
            this.button3.Text = "添加歌曲";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(965, 184);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 35);
            this.button4.TabIndex = 5;
            this.button4.Text = "上移歌曲";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(965, 225);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 35);
            this.button5.TabIndex = 5;
            this.button5.Text = "下移歌曲";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(965, 266);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 35);
            this.button6.TabIndex = 5;
            this.button6.Text = "删除歌曲";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "双击列表切换播放歌单，当前歌单：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(277, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "默认列表";
            // 
            // MyMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 548);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AlbumPicture);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MusicListBox);
            this.Controls.Add(this.skinPanel1);
            this.Controls.Add(this.MainBar);
            this.Controls.Add(this.ListListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1012, 548);
            this.MinimumSize = new System.Drawing.Size(1012, 548);
            this.Name = "MyMainWindow";
            this.Text = "播放器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyMainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MyMainWindow_Load);
            this.Shown += new System.EventHandler(this.MyMainWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.AlbumPicture)).EndInit();
            this.MainBar.ResumeLayout(false);
            this.MainBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AlbumPicture;
        private CCWin.SkinControl.SkinListBox ListListBox;
        private Gdu.WinFormUI.GMTrackBar gmTrackBar1;
        private CCWin.SkinControl.SkinPanel MainBar;
        private System.Windows.Forms.Label AllTime;
        private System.Windows.Forms.Label NowPos;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private System.Windows.Forms.Label Singer;
        private System.Windows.Forms.Label SongName;
        private Gdu.WinFormUI.GMTrackBar gmTrackBar2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private CCWin.SkinControl.SkinListBox MusicListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

