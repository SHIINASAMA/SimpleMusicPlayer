using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.IO;
using Id3Lib;
using Mp3Lib;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.Diagnostics;
using System.Threading;

namespace SimpleMusicPlayer
{
    public partial class MyMainWindow : Skin_Mac
    {
        //播放模式
        enum PlayMode
        {
            ListLoop,       //列表循环
            Random,         //随机播放
            OneLoop         //单曲循环
        };

        //工作者线程
        Thread Worker;

        //任务栏按钮
        ThumbnailToolBarButton thumbnailToolBarButton1 = new ThumbnailToolBarButton(Properties.Resources.Last, "上一首");
        ThumbnailToolBarButton thumbnailToolBarButton2 = new ThumbnailToolBarButton(Properties.Resources.Play, "播放");
        ThumbnailToolBarButton thumbnailToolBarButton3 = new ThumbnailToolBarButton(Properties.Resources.Next, "下一首");

        public NAudioPlayer.NAudioPlayer player = new NAudioPlayer.NAudioPlayer();

        //标识符
        public string PlayingList = "默认列表";
        public string PlayingMusic = "Null";
        public int PlayingIndex = -1;

        PlayMode Mode = PlayMode.ListLoop;

        //类初始化
        public MyMainWindow()
        {
            InitializeComponent();

            //必要的默认列表
            this.ListListBox.Items.Add(new CCWin.SkinControl.SkinListBoxItem("默认列表"));

            //设置气泡
            ToolTip tip = new ToolTip();
            tip.ToolTipTitle = "播放模式";
            tip.SetToolTip(this.pictureBox5, "列表循环");

            //初始化线程
            Worker = new Thread(WorkFunc);
            Worker.IsBackground = true;
            Worker.Start();
        }

        //添加列表按钮
        private void button1_Click(object sender, EventArgs e)
        {
            AddListForm form = new AddListForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                foreach (CCWin.SkinControl.SkinListBoxItem item in this.ListListBox.Items)
                {
                    if (item.ToString() == form.ListName)
                    {
                        MyMessageBox myMessageBox = new MyMessageBox("列表“" + form.ListName + "”已经存在！", "提示");
                        myMessageBox.ShowDialog();
                        return;
                    }
                }

                File.Create("Data/" + form.ListName + ".list");
                this.ListListBox.Items.Add(new CCWin.SkinControl.SkinListBoxItem(form.ListName));
            }
        }

        //删除列表按钮
        private void button2_Click(object sender, EventArgs e)
        {
            int index = this.ListListBox.SelectedIndex;
            if (index == -1)
                return;

            if (this.ListListBox.SelectedItem.ToString() == "默认列表")
            {
                MyMessageBox myMessageBox = new MyMessageBox("不能删除默认列表！", "提示");
                myMessageBox.ShowDialog();
                return;
            }

            File.Delete("Data/" + this.ListListBox.SelectedItem.ToString() + ".list");
            this.ListListBox.Items.RemoveAt(index);
        }

        //添加歌曲按钮
        private void button3_Click(object sender, EventArgs e)
        {
            MyMessageBox myMessageBox = new MyMessageBox("这将把歌曲添加到“" + this.PlayingList + "”列表中", "提示");
            myMessageBox.ShowDialog();

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "MP3文件|*.mp3|WAV文件|*.wav";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foreach (string temp in dlg.FileNames)
                {
                    this.MusicListBox.Items.Add(new CCWin.SkinControl.SkinListBoxItem(temp));
                }
            }

        }

        //初始化加载列表
        private void MyMainWindow_Load(object sender, EventArgs e)
        {
            if (!File.Exists("Data/默认列表.list"))
            {
                StreamWriter writer = new StreamWriter("Data/默认列表.list", false);
                writer.Dispose();
                writer.Close();
                GC.Collect();
                MyMessageBox myMessageBox = new MyMessageBox("默认列表文件丢失，已重置.", "警告");
                myMessageBox.ShowDialog();
            }
            StreamReader reader = new StreamReader("Data/默认列表.list", Encoding.UTF8);
            while (true)
            {
                string temp = reader.ReadLine();
                if (temp == null)
                {
                    break;
                }
                else
                {
                    this.MusicListBox.Items.Add(new CCWin.SkinControl.SkinListBoxItem(temp));
                }
            }

            DirectoryInfo directoryInfo = new DirectoryInfo("Data");
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            foreach (FileInfo temp in fileInfo)
            {
                if (temp.Name != "默认列表.list")
                {
                    this.ListListBox.Items.Add(new CCWin.SkinControl.SkinListBoxItem(Path.GetFileNameWithoutExtension(temp.FullName)));
                }
            }
        }

        //选择列表事件
        private void ListListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //切换列表            
            int index = this.ListListBox.SelectedIndex;
            if (index == -1)
                return;

            if (PlayingList == this.ListListBox.SelectedItem.ToString())
                return;

            StreamWriter writer = new StreamWriter("Data/" + this.PlayingList + ".list", false);
            foreach (CCWin.SkinControl.SkinListBoxItem item in this.MusicListBox.Items)
            {
                writer.WriteLine(item.ToString());
            }
            writer.Dispose();
            writer.Close();
            GC.Collect();

            this.PlayingList = this.ListListBox.SelectedItem.ToString();
            this.label2.Text = this.PlayingList;
            this.MusicListBox.Items.Clear();
            StreamReader reader = new StreamReader("Data/" + this.PlayingList + ".list", Encoding.UTF8);
            while (true)
            {
                string temp = reader.ReadLine();
                if (temp == null)
                {
                    break;
                }

                this.MusicListBox.Items.Add(new CCWin.SkinControl.SkinListBoxItem(temp));
            }
            reader.Dispose();
            writer.Close();
            GC.Collect();
        }

        //退出保存事件
        private void MyMainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter writer = new StreamWriter("Data/" + this.PlayingList + ".list", false);
            foreach (CCWin.SkinControl.SkinListBoxItem item in this.MusicListBox.Items)
            {
                writer.WriteLine(item.ToString());
            }
            writer.Dispose();
            writer.Close();
            GC.Collect();
        }

        //选择播放音乐事件
        private void MusicListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //双击播放
            int index = this.MusicListBox.SelectedIndex;
            if (index == -1)
                return;

            if (!File.Exists(this.MusicListBox.SelectedItem.ToString()))
            {
                if (index == this.MusicListBox.Items.Count - 1)
                    index = 0;

                MyMessageBox myMessageBox = new MyMessageBox("文件“" + this.MusicListBox.SelectedItem.ToString() + "”丢失，已帮您移除出列表。", "提示");
                myMessageBox.ShowDialog();
                this.MusicListBox.Items.RemoveAt(index);
            }

            player.Init(this.MusicListBox.SelectedItem.ToString());
            LoadMusicInfo(this.MusicListBox.SelectedItem.ToString());
            player.Play();
            this.PlayingMusic = player.SongName;

            this.pictureBox3.Image = Properties.Resources.播放器_暂停_44;
            this.thumbnailToolBarButton2.Icon = Properties.Resources.Pause;
            this.thumbnailToolBarButton2.Tooltip = "暂停";
            this.PlayingIndex = index;
        }

        //播放按钮
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (PlayingMusic == "Null")
                return;

            if (player.IsPlaying == true)
            {
                player.Pause();
                this.pictureBox3.Image = Properties.Resources.播放器_播放_44;
                this.thumbnailToolBarButton2.Icon = Properties.Resources.Play;
                this.thumbnailToolBarButton2.Tooltip = "播放";
            }
            else
            {
                player.Play();
                this.pictureBox3.Image = Properties.Resources.播放器_暂停_44;
                this.thumbnailToolBarButton2.Icon = Properties.Resources.Pause;
                this.thumbnailToolBarButton2.Tooltip = "暂停";
            }
        }

        #region 任务栏模块
        private void MyMainWindow_Shown(object sender, EventArgs e)
        {
            thumbnailToolBarButton1.Enabled = true;
            thumbnailToolBarButton2.Enabled = true;
            thumbnailToolBarButton3.Enabled = true;

            thumbnailToolBarButton1.Click += ThumbnailToolBarButton1_Click;
            thumbnailToolBarButton2.Click += ThumbnailToolBarButton2_Click;
            thumbnailToolBarButton3.Click += ThumbnailToolBarButton3_Click;

            Size size = this.AlbumPicture.Size;
            size.Width -= 1;

            TaskbarManager.Instance.ThumbnailToolBars.AddButtons(this.Handle, thumbnailToolBarButton1, thumbnailToolBarButton2, thumbnailToolBarButton3);
            TaskbarManager.Instance.TabbedThumbnail.SetThumbnailClip(this.Handle, new Rectangle(this.AlbumPicture.Location, size));
        }

        private void ThumbnailToolBarButton1_Click(object sender, ThumbnailButtonClickedEventArgs e)
        {
            pictureBox1_Click(sender, e);
        }

        private void ThumbnailToolBarButton2_Click(object sender, ThumbnailButtonClickedEventArgs e)
        {
            pictureBox3_Click(sender, e);
        }

        private void ThumbnailToolBarButton3_Click(object sender, ThumbnailButtonClickedEventArgs e)
        {
            pictureBox2_Click(sender, e);
        }

        #endregion

        //上一曲按钮
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int index = this.MusicListBox.SelectedIndex;
            if (index == -1)
                return;

            //如已经是第一列，则转到最后一列
            if (index == 0)
                index = this.MusicListBox.Items.Count - 1;
            else
                index -= 1;

            PlayingIndex = index;

            if (!File.Exists(this.MusicListBox.Items[index].ToString()))
            {
                if (index == this.MusicListBox.Items.Count - 1)
                    index = 0;

                MyMessageBox myMessageBox = new MyMessageBox("文件“" + this.MusicListBox.Items[index].ToString() + "”丢失，已帮您移除出列表。", "提示");
                myMessageBox.ShowDialog();
                this.MusicListBox.Items.RemoveAt(index);
            }

            player.Init(this.MusicListBox.Items[index].ToString());
            LoadMusicInfo(this.MusicListBox.Items[index].ToString());
            player.Play();
            this.PlayingMusic = player.SongName;

            this.pictureBox3.Image = Properties.Resources.播放器_暂停_44;
            this.thumbnailToolBarButton2.Icon = Properties.Resources.Pause;
            this.thumbnailToolBarButton2.Tooltip = "暂停";

            this.MusicListBox.SelectedIndex = PlayingIndex;
        }

        //下一曲按钮
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int index = this.MusicListBox.SelectedIndex;
            if (index == -1)
                return;

            //如已经是最后一列，则转到第一列
            if (index == this.MusicListBox.Items.Count - 1)
                index = 0;
            else
                index += 1;

            PlayingIndex = index;

            if (!File.Exists(this.MusicListBox.Items[index].ToString()))
            {
                if (index == this.MusicListBox.Items.Count - 1)
                    index = 0;                

                MyMessageBox myMessageBox = new MyMessageBox("文件“" + this.MusicListBox.Items[index].ToString() + "”丢失，已帮您移除出列表。", "提示");
                myMessageBox.ShowDialog();
                this.MusicListBox.Items.RemoveAt(index);
            }

            player.Init(this.MusicListBox.Items[index].ToString());
            LoadMusicInfo(this.MusicListBox.Items[index].ToString());
            player.Play();
            this.PlayingMusic = player.SongName;

            this.pictureBox3.Image = Properties.Resources.播放器_暂停_44;
            this.thumbnailToolBarButton2.Icon = Properties.Resources.Pause;
            this.thumbnailToolBarButton2.Tooltip = "暂停";

            this.MusicListBox.SelectedIndex = PlayingIndex;
        }

        //删除歌曲按钮
        private void button6_Click(object sender, EventArgs e)
        {
            int index = this.MusicListBox.SelectedIndex;
            if (index == -1)
            {
                return;
            }

            if (this.MusicListBox.SelectedItem.ToString() == this.PlayingMusic)
            {
                if (index == this.MusicListBox.Items.Count - 1)
                {
                    this.MusicListBox.Items.RemoveAt(index);
                    if (index > 0)
                    {
                        if (!File.Exists(this.MusicListBox.Items[index - 1].ToString()))
                        {
                            this.MusicListBox.Items.RemoveAt(index);

                            MyMessageBox myMessageBox = new MyMessageBox("文件“" + this.MusicListBox.Items[index - 1].ToString() + "”丢失，已帮您移除出列表。", "提示");
                            myMessageBox.ShowDialog();
                        }

                        player.Init(this.MusicListBox.Items[index - 1].ToString());
                        LoadMusicInfo(this.MusicListBox.Items[index - 1].ToString());
                        player.Play();
                        this.PlayingMusic = player.SongName;

                        this.pictureBox3.Image = Properties.Resources.播放器_暂停_44;
                        this.thumbnailToolBarButton2.Icon = Properties.Resources.Pause;
                        this.thumbnailToolBarButton2.Tooltip = "暂停";
                        this.PlayingIndex = index;
                        this.MusicListBox.SelectedIndex = index - 1;
                    }
                    else
                    {
                        player.Pause();
                        this.PlayingMusic = "Null";
                        this.PlayingIndex = -1;
                        this.AlbumPicture.Image = Properties.Resources.唱片CD;
                        this.Singer.Text = "Singer";
                        this.SongName.Text = "SongName";
                        GC.Collect();
                    }
                }
            }
        }

        //上移歌曲按钮
        private void button4_Click(object sender, EventArgs e)
        {
            int index = this.MusicListBox.SelectedIndex;
            if (index <= 0)
                return;

            CCWin.SkinControl.SkinListBoxItem item = new CCWin.SkinControl.SkinListBoxItem(this.MusicListBox.SelectedItem.ToString());
            this.MusicListBox.Items.RemoveAt(index);
            this.MusicListBox.Items.Insert(index - 1, item);
            this.MusicListBox.SelectedIndex = index - 1;
        }

        //下移歌曲按钮
        private void button5_Click(object sender, EventArgs e)
        {
            int index = this.MusicListBox.SelectedIndex;
            if (index == this.MusicListBox.Items.Count - 1 ||
                index == -1)
                return;

            CCWin.SkinControl.SkinListBoxItem item = new CCWin.SkinControl.SkinListBoxItem(this.MusicListBox.SelectedItem.ToString());
            this.MusicListBox.Items.RemoveAt(index);
            this.MusicListBox.Items.Insert(index + 1, item);
            this.MusicListBox.SelectedIndex = index + 1;
        }

        //控制音量
        private void gmTrackBar2_ValueChanged(object sender, EventArgs e)
        {
            float temp = this.gmTrackBar2.Value;
            temp /= 100;
            player.Volume = temp;
        }

        //加载歌曲信息
        private void LoadMusicInfo(string MusicName)
        {
            Mp3File mp3File = new Mp3File(MusicName);
            TagHandler handler = mp3File.TagHandler;

            //展示歌手信息
            if (handler.Artist != null)
            {
                if (handler.Artist.Length > 15)
                {
                    this.Singer.Text = handler.Artist.Substring(0, 15) + "...";
                }
                else
                {
                    this.Singer.Text = handler.Artist;
                }
            }
            else
            {
                this.Singer.Text = "未知歌手";
            }

            //展示歌曲名称
            if (handler.Title != null)
            {
                if (handler.Title.Length > 15)
                {
                    this.SongName.Text = handler.Title.Substring(0, 15) + "...";
                }
                else
                {
                    this.SongName.Text = handler.Title;
                }
            }
            else
            {
                this.SongName.Text = "未知";
            }

            //展示歌曲专辑封面
            if (handler.Picture != null)
            {
                this.AlbumPicture.Image = handler.Picture;
            }
            else
            {
                this.AlbumPicture.Image = Properties.Resources.唱片CD;
            }

            //展示歌曲总时长
            this.AllTime.Text = this.player.TotalTime.Minutes + ":" + this.player.TotalTime.Seconds;

            //进度条参数
            this.gmTrackBar1.Maximum = (int)this.player.TotalTime.TotalSeconds;

            //回收内存
            GC.Collect();
        }

        //将要定位的位置
        private TimeSpan time;
        private bool IsDowm;
        //调整歌曲进度
        private void gmTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (PlayingMusic == "Null")
                return;

            GC.Collect();
            time = new TimeSpan(0, this.gmTrackBar1.Value / 60, this.gmTrackBar1.Value % 60);
            this.NowPos.Text = this.gmTrackBar1.Value / 60 + ":" + this.gmTrackBar1.Value % 60;
        }
        private void gmTrackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            if (PlayingMusic == "Null")
                return;

            this.player.CurrentTime = time;
            this.gmTrackBar1.Value = (int)time.TotalSeconds;
            GC.Collect();
            IsDowm = false;
        }
        private void gmTrackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            IsDowm = true;
        }

        //工作者线程
        private void WorkFunc()
        {
            while (true)
            {
                //防止抢占CPU时间过长造成线程假死
                Thread.Sleep(1);

                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        if (PlayingMusic == "Null")
                            return;

                        //如果进度条被按下，则将控制权交给用户
                        if (!IsDowm)
                        {
                            this.gmTrackBar1.Value = (int)this.player.CurrentTime.TotalSeconds;
                            this.NowPos.Text = this.player.CurrentTime.Minutes + ":" + this.player.CurrentTime.Seconds;
                        }
                    }));
                }

                //判断歌曲是否播放完成
                try
                {
                    if (this.NowPos.Text == this.AllTime.Text && this.PlayingMusic != "Null")
                    {
                        //播放完成选择接下来播放的歌曲
                        switch (Mode)
                        {
                            //列表循环
                            case PlayMode.ListLoop:
                                int index = this.PlayingIndex;
                                //如果已经是末尾
                                if (index == this.MusicListBox.Items.Count - 1)
                                {
                                    index = 0;
                                }
                                else
                                {
                                    index++;
                                }

                                if (!File.Exists(this.MusicListBox.Items[index].ToString()))
                                {
                                    if (index == this.MusicListBox.Items.Count - 1)
                                        index = 0;

                                    MyMessageBox myMessageBox = new MyMessageBox("文件“" + this.MusicListBox.SelectedItem.ToString() + "”丢失，已帮您移除出列表。", "提示");
                                    myMessageBox.ShowDialog();
                                    this.MusicListBox.Items.RemoveAt(index);
                                }

                                if (this.InvokeRequired)
                                {
                                    this.BeginInvoke(new MethodInvoker(() =>
                                    {
                                        player.Init(this.MusicListBox.Items[index].ToString());
                                        LoadMusicInfo(this.MusicListBox.Items[index].ToString());
                                        player.Play();
                                        this.PlayingMusic = player.SongName;
                                    }));
                                }
                                break;
                            case PlayMode.OneLoop:
                                player.CurrentTime = TimeSpan.Zero;
                                break;
                            case PlayMode.Random:
                                if (this.InvokeRequired)
                                {
                                    this.BeginInvoke(new MethodInvoker(() =>
                                    {
                                        int RandNum = new Random().Next(0, this.MusicListBox.Items.Count - 1);
                                        player.Init(this.MusicListBox.Items[RandNum].ToString());
                                        LoadMusicInfo(this.MusicListBox.Items[RandNum].ToString());
                                        player.Play();
                                        this.PlayingMusic = player.SongName;
                                    }));
                                }
                                break;
                        }
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        //更改播放模式
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case PlayMode.ListLoop:
                    Mode = PlayMode.OneLoop;
                    ToolTip tip1 = new ToolTip();
                    tip1.ToolTipTitle = "播放模式";
                    tip1.SetToolTip(this.pictureBox5, "单曲循环");
                    this.pictureBox5.Image = Properties.Resources.单次循环;
                    break;
                case PlayMode.OneLoop:
                    Mode = PlayMode.Random;
                    ToolTip tip2 = new ToolTip();
                    tip2.ToolTipTitle = "播放模式";
                    tip2.SetToolTip(this.pictureBox5, "随机播放");
                    this.pictureBox5.Image = Properties.Resources.随机;
                    break;
                case PlayMode.Random:
                    Mode = PlayMode.ListLoop;
                    ToolTip tip3 = new ToolTip();
                    tip3.ToolTipTitle = "播放模式";
                    tip3.SetToolTip(this.pictureBox5, "列表循环");
                    this.pictureBox5.Image = Properties.Resources.列表循环;
                    break;
                default:
                    break;

            }
        }

    }
}
