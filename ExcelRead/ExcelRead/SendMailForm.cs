using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelRead
{
    public partial class SendMailForm : Form
    {
        public SendMailForm()
        {
            InitializeComponent();
        }

        private void SendMailForm_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "18186482897@163.com";
            txtPassword.Text = "19950502shan";
            txtReceive.Text = "1431173103@qq.com";
            txtSubject.Text = "你好";
            txtBody.Text = "c#网络编程";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //发件人和收件人的地址
            MailAddress from = new MailAddress(txtUserName.Text);
            MailAddress to = new MailAddress(txtReceive.Text);
            MailMessage message = new MailMessage(from, to);
            //主题
            message.Subject = txtSubject.Text.Trim();
            //主题的编码方式
            message.SubjectEncoding = Encoding.UTF8;
            //邮件内容
            message.Body = txtBody.Text;
            //邮件内容的编码方式
            message.BodyEncoding = Encoding.UTF8;
            //添加附件
            if(File.Exists(txtFujianPath.Text))
            {
                //MIME Type，即资源的媒体类型
                //指定数据为纯文本格式
                ContentType ct = new ContentType(MediaTypeNames.Text.Plain);
                //创建附件对象
                Attachment item = new Attachment(txtFujianPath.Text,
                    MediaTypeNames.Text.Plain);
                //给邮件添加附件
                message.Attachments.Add(item);
            }
            try
            {
                SmtpClient client = new SmtpClient("smtp." + from.Host);
                SendMail(client, from, txtPassword.Text, to, message);
                MessageBox.Show("发送成功！！！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "发送失败");
                return;
            }
        }

        /// <summary>
        /// 根据指定的参数发送邮件
        /// </summary>
        /// <param name="client"></param>
        /// <param name="from"></param>
        /// <param name="password"></param>
        /// <param name="to"></param>
        /// <param name="message"></param>
        private void SendMail(SmtpClient client, MailAddress from,
            string password, MailAddress to, MailMessage message)
        {
            //不使用默认凭证
            client.UseDefaultCredentials = false;
            //指定用户名和密码
            client.Credentials = new NetworkCredential(from.Address, password);
            //邮件通过网络发送到服务器
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "发送邮件是失败");
            }
            finally
            {
                //及时释放占用的资源
                message.Dispose();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                txtFujianPath.Text = openFileDialog.FileName;
            }
        }
    }
}
