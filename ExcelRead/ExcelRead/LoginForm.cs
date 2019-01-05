using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ExcelRead
{
    public partial class LoginForm : Form
    {
        private Dictionary<string, string> _dicNameCode = new Dictionary<string, string>();

        //用户名；编辑框的属性
        public string UserName
        {
            get { return this.cboUserName.Text.Trim(); }
        }
        //密码；密码编辑框的属性
        public String PassWord
        {
            set { this.txtPwd.Text = value; }
            get { return this.txtPwd.Text.Trim(); }
        }
        public CheckBox CkRememberNameCode
        {
            get
            {
                return ckRememberNameCode;
            }

            set
            {
                ckRememberNameCode = value;
            }
        }
        /// <summary>
        /// 用户名密码配置文件的内容
        /// </summary>
        public Dictionary<string, string> DicNameCode
        {
            get
            {
                return _dicNameCode;
            }

            set
            {
                _dicNameCode = value;
            }
        }
        


        public LoginForm()
        {
            InitializeComponent();
        }

        //登录按钮
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        //当按下取消键的时候；用户名和密码清空
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtPwd.Text = "";
            this.cboUserName.Text = "";
        }

        //退出的时候关闭对话框
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //从xml文件中读取用户名和密码
            GetNameAndPwdFromXML();
            this.cboUserName.Items.AddRange(DicNameCode.Keys.ToArray());
            this.cboUserName.SelectedIndex = 0;
            if(this.cboUserName.Text!=null && this.cboUserName.Text!="")
            {
                this.txtPwd.Text = DicNameCode[cboUserName.Text];
            }
        }

        //向xml文件中添加一个用户
        public void WriteNameCodeToXml(string name, string pwd)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..\..\UserList.xml");
            XmlNode rootNode = xmlDoc.SelectSingleNode("UserList");
            XmlElement xe = xmlDoc.CreateElement("User");
            XmlElement nameNode = xmlDoc.CreateElement("Name");
            nameNode.InnerText = name;
            XmlElement codeNode = xmlDoc.CreateElement("Pwd");
            codeNode.InnerText = pwd;
            xe.AppendChild(nameNode);
            xe.AppendChild(codeNode);
            rootNode.AppendChild(xe);
            xmlDoc.Save(@"..\..\UserList.xml");
        }

        /// <summary>
        /// 从xml文件中得到用户名和密码
        /// </summary>
        public void GetNameAndPwdFromXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\UserList.xml");
            XmlNodeList nodeList=null;
            if (doc!=null)
            {
                if (doc.SelectSingleNode("UserList") != null)
                {
                    nodeList = doc.SelectSingleNode("UserList").ChildNodes;
                }
            }
            foreach (XmlNode node in nodeList)
            {
                if (node.FirstChild != null && node.LastChild != null)
                {
                    DicNameCode.Add(node.FirstChild.InnerText, node.LastChild.InnerText);
                }
            }
        }

        private void cboUserName_DrawItem(object sender, DrawItemEventArgs e)
        {
            //获取表示所绘项的矩形
            Rectangle r = e.Bounds;
            Size imageSize = imageList.ImageSize;
            Font fn = null;
            //如果所绘项的索引大于0
            if (e.Index >= 0)
            {
                fn = (Font)this.cboUserName.Font;
                string s = (string)cboUserName.Items[e.Index];
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                //如果鼠标选中在这项上
                if ((e.State & DrawItemState.Selected) != 0)
                {
                    //画条目背景
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), r);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), r);
                }
                //绘制图像
                imageList.Draw(e.Graphics, r.Right - imageSize.Width, r.Bottom - imageSize.Height, 0);
                //显示字符串
                e.Graphics.DrawString(s, fn, new SolidBrush(Color.Black), r.Left + imageSize.Width, r.Top + 1);
                //显示取得焦点时的虚线框
                e.DrawFocusRectangle();
            }
        }

        private void cboUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtPwd.Text = DicNameCode[cboUserName.Text];
            
        }

        private void cboUserName_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
    }
}
