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
    public partial class ProgressBarForm : Form
    {
        /// <summary>
        /// 两个私有控件的属性
        /// </summary>
        public ProgressBar MyProgressBar
        {
            set
            {
                this.progressBar = value;
            }
            get
            {
                return this.progressBar;
            }
        }
        public TextBox TxtLog
        {
            set
            {
                this.txtLog = value;
            }
            get
            {
                return this.txtLog;
            }
        }


        public ProgressBarForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置日志输出类
        /// 可以在文本框中输入过程日志。
        /// </summary>
        /// <param name="v"></param>
        public void output(string v)
        {
            //如果日志信息长度超过100行，则自动清空
            if (txtLog.GetLineFromCharIndex(txtLog.Text.Length) > 100)
            {
                txtLog.Text = "";
            }
            //添加日志
            txtLog.AppendText(DateTime.Now.ToString("HH:mm:ss ") + v + "\r\n");
        }

        private void ProgressBarForm_Load(object sender, EventArgs e)
        {

        }
    }
}
