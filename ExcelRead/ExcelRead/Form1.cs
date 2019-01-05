using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace ExcelRead
{
    public partial class Form1 : Form
    {
        public String CurUser
        {
            set;
            get;
        }

        //记事本对话框
        TxtReadForm frmTxt = null;
        //秒表进程
        Process secondClockProcess = null;
        //图像效果进程
        Process picVisusalProcess = null;

        public Form1()
        {
            InitializeComponent();
            this.notifyIcon.Text = "单凯ExcelRead";
        }

        /// <summary>
        /// 打开excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuOpenExcel_Click(object sender, EventArgs e)
        {
            ExcelReadForm frmExcel = new ExcelReadForm();
            frmExcel.MdiParent = this;

            OpenFileDialog filedialog = new OpenFileDialog();
            string FileName = "";
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                FileName = filedialog.FileName;

                //先判断工作表中有几个sheet
                System.Data.DataTable dt = GetExcelDataTable(FileName);
                if (dt.Rows.Count > 1)
                {
                    string str = string.Format("您所打开的工作簿中共有{0}张表，我们为您打开了第一张",
                        dt.Rows.Count);
                    MessageBox.Show(str, "提醒", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                frmExcel.fileName = FileName;
                frmExcel.isHaveManySheet = true;
                frmExcel.sheetNum = dt.Rows.Count;
                //打开excel文件
                OpenExcel(frmExcel, FileName, "[Sheet1$]");

                frmExcel.Show();
            }
        }

        /// <summary>
        /// 打开Excel文件
        /// </summary>
        /// <param name="frmExcel">数据显示到哪个对话框？？？？？</param>
        private void OpenExcel(ExcelReadForm frmExcel, string fileName, string sheetNum)
        {
            //"[Sheet1$]"
            DataSet ds = GetExcelData(fileName, sheetNum);
            frmExcel.dGViewExcel.DataSource = ds;
            frmExcel.dGViewExcel.DataMember = sheetNum;

            #region MyRegion
            //for (int count = 0; (count <= (frmExcel.dGViewExcel.Rows.Count - 1)); count++)
            //{
            //    frmExcel.dGViewExcel.Rows[count].HeaderCell.Value = (count + 1).ToString();
            //} 
            #endregion
        }

        /// <summary>
        /// 获得excel文件中的的某张表的数据集
        /// </summary>
        /// <param name="str">excel文件的路径</param>
        /// <param name="sheetNum">表单编号</param>
        /// <returns></returns>
        private DataSet GetExcelData(string str, string sheetNum)
        {
            string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + str + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = "SELECT * FROM " + sheetNum;
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            DataSet myDataSet = new DataSet();
            myCommand.Fill(myDataSet, sheetNum);
            myConn.Close();
            return myDataSet;
        }

        private System.Data.DataTable GetExcelDataTable(string fileName)
        {
            string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
            OleDbConnection myConn = new OleDbConnection(strCon);
            myConn.Open();
            System.Data.DataTable tb = myConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            return tb;
        }


        /// <summary>
        /// 新建一个excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuNewExcel_Click(object sender, EventArgs e)
        {
            ExcelReadForm frmExceel = new ExcelReadForm(5);
            frmExceel.MdiParent = this;
            frmExceel.Show();
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSendMail_Click(object sender, EventArgs e)
        {
            SendMailForm frmSend = new SendMailForm();
            frmSend.Show();
        }

        /// <summary>
        /// 打开视频文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuOpenVedio_Click(object sender, EventArgs e)
        {
            VedioReadForm frmVedio = new VedioReadForm();
            frmVedio.MdiParent = this;
            frmVedio.Show();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuLogin_Click(object sender, EventArgs e)
        {
            LoginForm frmLogin = new LoginForm();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                string userName = frmLogin.UserName;
                string password = frmLogin.PassWord;
                string MiPwd = Encryption_Decryption.MingToMi(password);
                string sql = string.Format("select count(*) from [tb_User] where name='{0}'and pwd='{1}'",
                    userName, MiPwd);
                SqlConnection connection = ConnDataBase.connection;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    //执行查询语句，发挥匹配的行数
                    int num = (int)command.ExecuteScalar();
                    if (num > 0)
                    {
                        frmLogin.Close();
                        //获得相应权限
                        HavePermission();
                        //保存到当前用户
                        CurUser = userName;
                        if (!frmLogin.DicNameCode.ContainsKey(frmLogin.UserName)
                            && frmLogin.CkRememberNameCode.Checked == true)
                        {
                            frmLogin.WriteNameCodeToXml(frmLogin.UserName, frmLogin.PassWord);
                        }
                        MessageBox.Show("恭喜您，成功登录", "信息提示",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        frmLogin.PassWord = "";
                        MessageBox.Show("您输入的用户名或密码错误！", "登录失败",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        /***********************************权限管理******************************************/
        /// <summary>
        /// 有会员权限
        /// </summary>
        private void HavePermission()
        {
            //会员权限，可以新建文件，打开excel文件
            this.menuNew.Enabled = true;
            this.menuOpenExcel.Enabled = true;
            this.menuNet.Enabled = true;
            this.menuComponent.Enabled = true;
            this.toolStripForm1.Enabled = true;
            this.menuFile.Enabled = true;
        }
        /// <summary>
        /// 没有会员权限
        /// </summary>
        private void HaveNotPermission()
        {
            //没有会员权限，不可以新建文件，不可以打开excel文件
            this.menuNew.Enabled = false;
            this.menuOpenExcel.Enabled = false;
            this.menuNet.Enabled = false;
            this.menuComponent.Enabled = false;
            this.toolStripForm1.Enabled = false;
            this.menuFile.Enabled = false;
        }


        private void menuNewTxt_Click(object sender, EventArgs e)
        {
            CreateNotepad();
        }

        private void menuOpenTxt_Click(object sender, EventArgs e)
        {
            CreateNotepad();
        }

        //调用记事本对话框
        private void CreateNotepad()
        {
            frmTxt = TxtReadForm.GetInstance();
            frmTxt.Show();
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            #region MyRegion
            ////主窗体退出前释放资源
            //if (frmTxt != null)
            //{
            //    frmTxt.Close();
            //}
            ////退出前前置关闭秒表程序
            //if (secondClockProcess != null)
            //{
            //    Process[] p = Process.GetProcessesByName(
            //        @"..\..\..\SecondClock\SecondClock\bin\debug\SecondClock.exe");
            //    p[0].Kill();
            //    MessageBox.Show("进程关闭成功！");
            //} 
            #endregion
        }

        /******************************************小组件*******************************************/
        /// <summary>
        /// 小组件中的秒表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSecondClock_Click(object sender, EventArgs e)
        {
            if (secondClockProcess == null)
            {
                //调用已经写好的秒表程序
                secondClockProcess = Process.Start(
                    @"..\..\..\SecondClock\SecondClock\bin\debug\SecondClock.exe");
            }
        }
        /// <summary>
        /// 图像效果显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuPicVisual_Click(object sender, EventArgs e)
        {
            //调用已经写好的图像显示效果程序
            picVisusalProcess = Process.Start(
                @"..\..\..\ImageFlash\ImageFlash\bin\debug\ImageFlash.exe");
        }

        //文件管理进程
        Process fileManageProcess;
        //文件管理模块
        private void menuFileManage_Click(object sender, EventArgs e)
        {
            fileManageProcess = Process.Start(
                @"..\..\..\文件管理模块\文件管理模块\bin\debug\文件管理模块.exe");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //没有权限
            HaveNotPermission();
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuRegiste_Click(object sender, EventArgs e)
        {
            UserRegistForm frmReg = new UserRegistForm();
            if (frmReg.ShowDialog() == DialogResult.OK)
            {
                if (frmReg.Password != frmReg.OkPassword)
                {
                    ShowWarningMessageBox("密码填写错误");
                    frmReg.Password = "";
                    frmReg.OkPassword = "";
                    return;
                }
                else if (frmReg.UserName == "")
                {
                    ShowWarningMessageBox("用户名不能为空");
                }
                else
                {
                    string strMi = Encryption_Decryption.MingToMi(frmReg.OkPassword);
                    string userName = frmReg.UserName;
                    //经用户添加到数据库中
                    if (AddUserToDB(userName, strMi))
                    {
                        MessageBox.Show("注册用户成功", "恭喜");
                        //为新用户赋予相应权限
                        HavePermission();
                    }
                }

            }

        }

        /// <summary>
        /// 添加用户到数据库
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="strMi">密码</param>
        /// <returns></returns>
        private bool AddUserToDB(string userName, string strMi)
        {
            SqlConnection connection = ConnDataBase.connection;
            try
            {
                string sql = string.Format("select max(id) from tb_user");
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                //执行查询，并返回由查询返回的结果集中的第一行的第一列。
                int num = -1;
                string strTemp = (string)command.ExecuteScalar();
                if (strTemp == null)
                {
                    return false;
                }
                num = int.Parse(strTemp);
                if (num < 0)
                {
                    return false;
                }
                sql = string.Format("insert into tb_User(id,name,pwd) values('{0}','{1}','{2}')",
                    num + 1, userName, strMi);
                command = new SqlCommand(sql, connection);
                //返回搜影响的行数
                int count = command.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        //显示警告对话框
        public void ShowWarningMessageBox(String str)
        {
            MessageBox.Show(str, "警告", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //主窗体退出前释放资源
                if (frmTxt != null)
                {
                    frmTxt.Close();
                }
                //退出前前置关闭秒表程序
                //如果秒表程序没有退出
                if (secondClockProcess != null && secondClockProcess.HasExited == false)
                {
                    secondClockProcess.Kill();
                }
                if (picVisusalProcess != null && picVisusalProcess.HasExited == false)
                {
                    picVisusalProcess.Kill();
                }
                if (fileManageProcess != null && fileManageProcess.HasExited == false)
                {
                    fileManageProcess.Kill();
                }
            }
            catch (Exception ex)
            {
                ShowWarningMessageBox(ex.Message + ex.StackTrace);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //当窗口最小化的时候
            if (WindowState == FormWindowState.Minimized)
            {
                //窗体隐藏
                this.Hide();
                //最小化图标可见
                this.notifyIcon.Visible = true;
                ///在任务栏中将气球状提示显示一段指定的时间。
                ///显示30ms
                ///显示标题
                ///显示文本
                ///信息图标
                this.notifyIcon.ShowBalloonTip(3000,
                    "单凯", "单凯ExcelRead", ToolTipIcon.Info);
                this.notifyIcon.Text = "单凯ExcelRead";
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //窗口显示
            this.Visible = true;
            //窗口状态正常
            this.WindowState = FormWindowState.Normal;
            //最小化图标不显示
            this.notifyIcon.Visible = false;
        }

        private void menuExtit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出吗？", "提示",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void menuCurUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.CurUser, "当前用户名", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            this.CurUser = "";
            HaveNotPermission();
        }

        //压缩进度条线程
        Thread progressThread;
        //当前是否退出
        bool isExit = false;
        ProgressBarForm frmBar;

        /******************************压缩和解压缩菜单项***********************************/
        /// <summary>
        /// 添加压缩文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuGZ_Click(object sender, EventArgs e)
        {
            CompressForm frmCompress = new CompressForm();
            if (frmCompress.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = frmCompress.TxtSource;
                string destPath = frmCompress.TxtDest;

                frmBar = new ProgressBarForm();
                frmBar.MyProgressBar.Minimum = 0;
                frmBar.MyProgressBar.Maximum = 100;
                frmBar.MyProgressBar.Value = 0;

                //进度条显示线程
                progressThread = new Thread(dispayProgress);
                progressThread.IsBackground = true;
                progressThread.Start();

                if (CompressFile(sourcePath, destPath))
                {
                    //标志进度条显示线程退出
                    isExit = true;
                    progressThread = null;
                    frmBar.Dispose();

                    MessageBox.Show("文件压缩成功");
                }

                isExit = false;
            }
        }
        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuOpenGZ_Click(object sender, EventArgs e)
        {
            DeCompressForm frmCompress = new DeCompressForm();
            if (frmCompress.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = frmCompress.TxtSource;
                string destPath = frmCompress.TxtDest;

                //进度条控件的相关设置
                frmBar = new ProgressBarForm();
                frmBar.MyProgressBar.Minimum = 0;
                frmBar.MyProgressBar.Maximum = 100;
                frmBar.MyProgressBar.Value = 0;

                //进度条显示线程
                progressThread = new Thread(dispayProgress);
                progressThread.IsBackground = true;
                progressThread.Start();

        
               

                if (CompressFile(sourcePath, destPath))
                {
                    //标志进度条显示线程退出
                    isExit = true;
                    progressThread = null;
                    frmBar.Dispose();

                    MessageBox.Show("文件解压缩成功");
                }
                isExit = false;
            }
        }

        /// <summary>
        /// 显示进度条对话框
        /// </summary>
        private void dispayProgress()
        {
            if (frmBar != null)
            {
                while (!isExit)
                {
                    frmBar.Show();
                    if (frmBar.MyProgressBar.Value < 95)
                    {
                        frmBar.output("处理中....."+ frmBar.MyProgressBar.Value.ToString()+"/100");
                        frmBar.MyProgressBar.Value += 5;
                        frmBar.MyProgressBar.Invalidate();
                    }
                }
                frmBar.MyProgressBar.Value = frmBar.MyProgressBar.Maximum;
                return;
            }
            return;
        }

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="path">源地址</param>
        /// <param name="dest">目的地址</param>
        /// <returns></returns>
        private bool CompressFile(string path, string dest)
        {
            try
            {
                if (File.Exists(path))
                {
                    FileStream sourceFile = File.OpenRead(path);

                    FileStream destinationFile = File.Create(dest);
                    byte[] buffer = new byte[sourceFile.Length];
                    sourceFile.Read(buffer, 0, buffer.Length);
                    using (GZipStream output = new GZipStream(destinationFile, CompressionMode.Compress))
                    {
                        output.Write(buffer, 0, buffer.Length);
                    }
                    //关闭文件
                    sourceFile.Close();
                    destinationFile.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ShowWarningMessageBox(ex.Message + ex.StackTrace);
                return false;
            }
        }

        private bool DeCompress(string path, string dest)
        {
            try
            {
                FileStream sourceFile = File.OpenRead(path);
                FileStream destinationFile = File.Create(dest);
                //因为压缩文件大小未知，使用任意大小的缓冲区
                byte[] buffer = new byte[4096];
                int n;
                using (GZipStream input = new GZipStream(sourceFile,
                    CompressionMode.Decompress))
                {
                    n = input.Read(buffer, 0, buffer.Length);
                    destinationFile.Write(buffer, 0, n);
                }
                return true;
            }
            catch (Exception ex)
            {
                ShowWarningMessageBox(ex.Message + ex.StackTrace);
                return false;
            }

        }

        private void menuPicOpen_Click(object sender, EventArgs e)
        {
            string myname;
            //设置打开图像的类型
            openFileDialog.Filter = "*.jpg,*.jpeg,*.bmp,*.jif,*.ico,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            //“打开”对话框
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                myname = openFileDialog.FileName;
                Picform frmPic = new Picform();
                frmPic.MdiParent = this;
                frmPic.PicBox.Image = Image.FromFile(myname);  //显示打开图像
                frmPic.PicName = myname;
                frmPic.Show();
            }
        }


    }
}
