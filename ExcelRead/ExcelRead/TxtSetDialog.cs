using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelRead
{
    public partial class TxtSetDialog : Form
    {
        //返回默认文档路径
        public string docPosition
        {
            get { return txtPosition.Text.Trim(); }
        }


        public TxtSetDialog()
        {
            InitializeComponent();
        }

        private void TxtSetDialog_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //显示浏览文件夹对话框
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                //返回选中的文件夹路径
                txtPosition.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //暂时隐藏当前对话框
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPosition.Text = "";
            this.Hide();
        }
    }
}
