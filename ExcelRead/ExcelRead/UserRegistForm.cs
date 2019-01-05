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
    public partial class UserRegistForm : Form
    {
        //用户名
        public string UserName
        {
            set { this.txtName.Text = value; }
            get { return this.txtName.Text.Trim(); }
        }
        //密码
        public String Password
        {
            set { this.txtPwd.Text = value; }
            get { return this.txtPwd.Text.Trim(); }
        }
        //确认密码
        public string OkPassword
        {
            set { this.txtOKPwd.Text = value; }
            get { return this.txtOKPwd.Text.Trim(); }
        }

        public UserRegistForm()
        {
            InitializeComponent();
            //画验证码
            DrawVerificationCode();
        }

        //点击更换验证码
        private void pbVerificationCode_Click(object sender, EventArgs e)
        {
            //画验证码
            DrawVerificationCode();
        }

        /// <summary>
        /// //画验证码
        /// </summary>
        private void DrawVerificationCode()
        {
            Random r = new Random();
            string str = null;
            for (int i = 0; i < 5; i++)
            {
                int rNum = r.Next(0, 10);
                str += rNum;
            }
            //MessageBox.Show(str);
            //创建GDI对象
            Bitmap bmp = new Bitmap(120, 30);
            Graphics g = Graphics.FromImage(bmp);

            for (int i = 0; i < 5; i++)
            {
                Point p = new Point(i * 20, 0);
                string[] fonts = { "微软雅黑", "宋体", "仿宋", "华文行楷", "隶书" };
                Color[] colors = { Color.Blue, Color.Brown, Color.Chocolate, Color.DarkOrange, Color.Red };
                g.DrawString(str[i].ToString(),
                    new Font(fonts[r.Next(0, 5)], 20, FontStyle.Bold),
                    new SolidBrush(colors[r.Next(0, 5)]),
                    p);
            }

            //画一些杂乱的线条
            for (int i = 0; i < 15; i++)
            {
                Point p1 = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                Point p2 = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                g.DrawLine(new Pen(Brushes.Green), p1, p2);
            }

            //画一些杂乱的点
            for (int i = 0; i < 500; i++)
            {
                Point p = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                bmp.SetPixel(p.X, p.Y, Color.Black);
            }
            //将图片镶嵌到picturebox种
            pbVerificationCode.Image = bmp;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserRegistForm_Load(object sender, EventArgs e)
        {

        }
    }
}
