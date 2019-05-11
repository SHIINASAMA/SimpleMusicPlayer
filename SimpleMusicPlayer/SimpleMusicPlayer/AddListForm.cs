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
    public partial class AddListForm : Skin_Mac
    {
        private string listName;
        public string ListName
        {
            get
            {
                return listName;
            }
        }

        public AddListForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text.Trim()))
            {
                MyMessageBox myMessageBox = new MyMessageBox("文本不能为空！", "警告");
                myMessageBox.ShowDialog();
                return;
            }

            this.listName = this.textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
