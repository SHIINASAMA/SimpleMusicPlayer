using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace SimpleMusicPlayer
{
    public partial class MyMessageBox : Skin_Mac
    {
        public MyMessageBox(string Message,string Title)
        {
            InitializeComponent();

            this.Text = Title;
            this.textBox1.Text = Message;
        }

        private void MyMessageBox_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
