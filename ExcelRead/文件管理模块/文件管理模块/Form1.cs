using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using System.Diagnostics;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;

namespace 文件管理模块
{
    public partial class Form1 : Form
    {
        //存放选择文件的路径
        public static string Allpath = "";
        //记录选择的项
        public static ArrayList list = new ArrayList();
        //记录选择的文件名及路径
        public static string strFullName = "";

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 将指定路径下的文件及文件夹显示在列表视图控件中
        /// </summary>
        /// <param name="path"></param>
        /// <param name="imgList"></param>
        /// <param name="lv"></param>
        /// <param name="intFlag"></param>
        public void GetPath(string path, ImageList imgList, ListView lv, int intFlag)
        {
            string pp = "";
            string uu = "";
            try
            {
                if (intFlag == 0)
                {
                    if (Allpath != path)
                    {
                        lv.Items.Clear();
                        Allpath = path;
                        GetListViewItem(Allpath, imgList, lv);
                    }
                }
                else
                {
                    uu = Allpath + path;
                    if (Directory.Exists(uu))
                    {
                        Allpath = Allpath + path + "\\";
                        pp = Allpath.Substring(0, Allpath.Length - 1);
                        lv.Items.Clear();
                        GetListViewItem(pp, imgList, lv);
                    }
                    else
                    {
                        //如果不是完整路径，先转换为完整路径再打开
                        if (path.IndexOf("\\") == -1)
                        {
                            uu = Allpath + path;
                            System.Diagnostics.Process.Start(uu);
                        }
                        else
                            //如果是完整路径则直接打开
                            System.Diagnostics.Process.Start(path);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 动态获取指定路径下所有文件及图标
        /// </summary>
        /// <param name="path"></param>
        /// <param name="imgList"></param>
        /// <param name="lv"></param>
        public void GetListViewItem(string path, ImageList imgList, ListView lv)
        {
            lv.Items.Clear();
            SHFILEINFO shfi = new SHFILEINFO();
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                for (int i = 0; i < dirs.Length; i++)
                {
                    string[] info = new string[4];
                    DirectoryInfo dir = new DirectoryInfo(dirs[i]);
                    if (dir.Name == "RECYCLE" || dir.Name == "RECYCLED"
                        || dir.Name == "Recyced" ||
                        dir.Name == "System Volume Information")
                    { }
                    else
                    {
                        //获得图标
                        SHGetFileInfo(dirs[i], (uint)0x80, ref shfi,
                            (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                            (uint)(0x100 | 0x400));
                        imgList.Images.Add(dir.Name, (Icon)Icon.FromHandle(shfi.hIcon).Clone());
                        info[0] = dir.Name;
                        info[1] = "";
                        info[2] = "文件夹";
                        info[3] = dir.LastWriteTime.ToString();
                        ListViewItem item = new ListViewItem(info, dir.Name);
                        //item.ImageIndex = i;
                        lv.Items.Add(item);
                        DestroyIcon(shfi.hIcon);
                    }
                }
                for (int i = 0; i < files.Length; i++)
                {
                    string[] info = new string[5];
                    FileInfo fi = new FileInfo(files[i]);
                    string fileType = fi.Name.Substring(fi.Name.LastIndexOf(".") + 1,
                        fi.Name.Length - fi.Name.LastIndexOf(".") - 1);
                    string newType = fileType.ToLower();
                    if (newType == "sys" || newType == "ini" || newType == "bin" ||
                        newType == "log" || newType == "com" || newType == "bat" || newType == "db")
                    { }
                    else
                    {
                        SHGetFileInfo(files[i], (uint)0x80, ref shfi,
                            (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                        imgList.Images.Add(fi.Name, (Icon)Icon.FromHandle(shfi.hIcon).Clone());
                        info[0] = fi.Name;
                        double dbLength = fi.Length / 1024;
                        if (dbLength < 1024)
                        {
                            info[1] = dbLength.ToString("0.00") + " KB";
                        }
                        else
                        {
                            info[1] = Convert.ToDouble(dbLength / 1024).ToString("0.00") + " MB";
                        }
                        info[2] = fi.Extension.ToString();
                        info[3] = fi.LastWriteTime.ToString();
                        info[4] = fi.IsReadOnly.ToString();
                        ListViewItem item = new ListViewItem(info, fi.Name);

                        lv.Items.Add(item);
                        DestroyIcon(shfi.hIcon);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// 利用该函数获取文件或文件夹图标
        /// </summary>
        /// <param name="pszPath"></param>
        /// <param name="dwFileAttribute"></param>
        /// <param name="Psfi"></param>
        /// <param name="cbSizeFileInfo"></param>
        /// <param name="Flags"></param>
        /// <returns></returns>
        [DllImport("shell32.dll", EntryPoint = "SHGetFileInfo")]
        public static extern IntPtr SHGetFileInfo(string pszPath,//指定的文件名
                uint dwFileAttribute,//文件属性
                ref SHFILEINFO Psfi,//记录类型，返回获得的文件信息
                uint cbSizeFileInfo,//psfi的比特值
                uint Flags//指明需要返回的文件信息标识符
                );
        [DllImport("User32.dll", EntryPoint = "DestroyIcon")]
        public static extern int DestroyIcon(IntPtr hIcon);

        private void Form1_Load(object sender, EventArgs e)
        {
            //获取本地磁盘目录
            string[] strDrives = Environment.GetLogicalDrives();
            tvLook.BeginUpdate();//树状视图开始更新
            //利用循环像树状视图控件中添加本地磁盘目录
            foreach (string strDrive in strDrives)
            {
                TreeNode tnMyDrives = new TreeNode(strDrive);
                tvLook.Nodes.Add(tnMyDrives);
            }
            tvLook.EndUpdate();//树状视图结束更新
        }

        private void tvLook_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GetPath(e.Node.FullPath, imageList1, lvInfo, 0);
        }

        //双击文件夹，显示该文件夹中的所有子文件夹及文件
        private void lvInfo_DoubleClick(object sender, EventArgs e)
        {
            GetPath(lvInfo.SelectedItems[0].Text, imageList1, lvInfo, 1);
        }

        /// <summary>
        /// 实现返回上一级目录功能
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="imageList"></param>
        public void backPath(ListView lv, ImageList imageList)
        {
            //怕端是否是顶级路径
            if (Allpath.Length != 3)
            {
                string newPath = Allpath.Remove(Allpath.LastIndexOf("\\")).
                    Remove(Allpath.Remove(Allpath.LastIndexOf("\\")).LastIndexOf("\\")) + "\\";
                lv.Items.Clear();
                GetListViewItem(newPath, imageList1, lv);
                Allpath = newPath;
            }
        }

        /// <summary>
        /// 单击返回上一层工具按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBackUp_Click(object sender, EventArgs e)
        {
            backPath(lvInfo, imageList1);
        }

        /// <summary>
        /// 根据文件夹或文件名，进行搜索
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="strName"></param>
        public void SearchFile(ListView lv, string strName)
        {
            try
            {
                //创建DirectoryInfo对象实例
                DirectoryInfo dir = new DirectoryInfo(Allpath);
                FileSystemInfo[] files = dir.GetFileSystemInfos();
                //都单个的FileSystemInfo对象进行判断，如果是文件夹则进行递归操作
                foreach (FileSystemInfo FSInfo in files)
                {
                    FileInfo file = FSInfo as FileInfo;
                    //判断是不是文件
                    if (file != null)
                    {
                        //如果是文件，向列表是图控件中添加信息
                        if (file.Name.IndexOf(strName) != -1)
                        {
                            string[] info = new string[5];
                            info[0] = Allpath + file.Name;
                            double dbLength = file.Length / 1024;
                            if (dbLength < 1024)
                            {
                                info[1] = dbLength.ToString("0.00") + " KB";
                            }
                            else
                            {
                                info[1] = Convert.ToDouble(dbLength / 1024).ToString("0.00") + " MB";
                            }
                            info[2] = file.Extension.ToString();
                            info[3] = file.LastWriteTime.ToString();
                            info[4] = file.IsReadOnly.ToString();
                            ListViewItem item = new ListViewItem(info, Convert.ToString(Allpath + file.Name).
                                Remove(0, 3));
                            lv.Items.Add(item);
                        }
                    }
                    else//文件夹
                    {
                        if (FSInfo.Name.IndexOf(strName) != -1)
                        {
                            string[] info = new string[4];
                            info[0] = Allpath + FSInfo.Name;
                            info[1] = "";
                            info[2] = "文件夹";
                            info[3] = FSInfo.LastWriteTime.ToString();
                            ListViewItem item = new ListViewItem(info,
                                Allpath + FSInfo.Name);
                            lv.Items.Add(item);
                        }
                        Allpath += FSInfo.Name + "\\";
                        //当目录不存在的时候，再返回上一层目录
                        while (!Directory.Exists(Allpath))
                        {
                            string strNewPath = Allpath.Substring(0,
                                Allpath.LastIndexOf("\\"));
                            Allpath = Directory.GetParent(strNewPath.Substring(0,
                                strNewPath.LastIndexOf("\\"))).FullName + "\\" +
                                FSInfo.Name + "\\";
                        }
                        //递归搜索
                        SearchFile(lv, strName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// 搜索文件或文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSearch_Click(object sender, EventArgs e)
        {
            lvInfo.Items.Clear();
            if (toolFindFileName.Text != "")
            {
                SearchFile(lvInfo, toolFindFileName.Text.Trim());
            }
            else
            {
                MessageBox.Show("搜索的关键字不能为空", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 创建文件（夹）
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="imagelist"></param>
        /// <param name="strName"></param>
        /// <param name="intFlag"></param>
        public void NewFile(ListView lv, ImageList imagelist, string strName, int intFlag)
        {
            string strPath = Allpath + strName;
            if (intFlag == 0)
            {
                //新建文件
                File.Create(strPath);
            }
            else if (intFlag == 1)
            {
                //新建文件夹
                Directory.CreateDirectory(strPath);
            }
            //动态获得指定路径下的文件和图标
            GetListViewItem(Allpath, imagelist, lv);
        }

        /// <summary>
        /// 新建文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuNewFile_Click(object sender, EventArgs e)
        {
            NewFile(lvInfo, imageList1, DateTime.Now.ToString("yyyymmddhhmmss") + ".txt", 0);
        }
        /// <summary>
        /// 新建文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuNewDirectory_Click(object sender, EventArgs e)
        {
            NewFile(lvInfo, imageList1, DateTime.Now.ToString("yyyymmddhhmmss") + ".txt", 1);
        }

        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuReName_Click(object sender, EventArgs e)
        {
            //判断是否选择文件或文件夹
            if (lvInfo.SelectedItems.Count != 0)
            {
                //重命名当前选项
                lvInfo.SelectedItems[0].BeginEdit();
            }
        }

        /// <summary>
        /// 判断是否选择了文件或文件夹
        /// </summary>
        private void IsSelectFile()
        {
            //如果没有选择，显示提示信息
            if (lvInfo.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择文件", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                strFullName = Allpath;
                list = getFiles(lvInfo);
            }
        }

        /// <summary>
        /// 吧选择的文件或文件夹添加到动态数组中
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        private ArrayList getFiles(ListView lv)
        {
            ArrayList list = new ArrayList();
            foreach (object objFile in lv.SelectedItems)
            {
                string strFile = objFile.ToString();
                string strFileName = strFile.Substring(strFile.IndexOf("{") + 1,
                    strFile.LastIndexOf("}") - strFile.IndexOf("{") - 1);
                //吧选择的文件或文件夹添加到动态数组中
                list.Add(strFileName);
            }
            return list;
        }

        /// <summary>
        /// 动态复制或剪切当前选择的文件夹
        /// </summary>
        /// <param name="Ddir"></param>
        /// <param name="Sdir"></param>
        /// <param name="intflag"></param>
        public void CopyDir(string Ddir, string Sdir, int intflag)
        {
            DirectoryInfo dir = new DirectoryInfo(Sdir);
            string sBuDir = Ddir;
            try
            {
                if (!dir.Exists)
                {
                    //如果文件夹不存在就返回
                    return;
                }
                DirectoryInfo dirD = dir as DirectoryInfo;
                //如果给定的参数不是文件夹就退出
                string upDir = Directory.GetParent(Ddir).FullName;
                if (dirD == null)
                {
                    //如果为空，创建文件夹并退出
                    Directory.CreateDirectory(upDir + "\\" + dirD.Name);
                    return;
                }
                else
                {
                    Directory.CreateDirectory(upDir + "\\" + dirD.Name);
                }
                sBuDir = upDir + "\\" + dirD.Name + "\\";
                //获取文件夹中的所有文件和文件夹
                FileSystemInfo[] files = dirD.GetFileSystemInfos();
                //对单个的FileSystemInfo进行判断，如果是文件夹则进行递归操作
                foreach (FileSystemInfo Fsys in files)
                {
                    FileInfo file = Fsys as FileInfo;
                    //判断是不是文件
                    if (file != null)
                    {
                        //获取文件所在的原始路径
                        FileInfo SFInfo = new FileInfo(file.DirectoryName + "\\" + file.Name);
                        //将文件复制到指定的路径中
                        SFInfo.CopyTo(sBuDir + "\\" + file.Name, true);
                    }
                    else
                    {
                        //获取当前搜索到的文件夹名称
                        string pp = Fsys.Name;
                        //文件夹的话，递归
                        CopyDir(sBuDir + Fsys.ToString(), Sdir + "\\" + Fsys.ToString(), intflag);
                    }
                    if (intflag == 1)
                    {
                        Directory.Delete(Sdir, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "对不起，复制文件失败");
            }
        }

        public void CopyFile(ListView lv, ImageList imagelist, ArrayList list, string strPath,
            string strNewPath, int intflag)
        {
            try
            {
                //利用循环得到动态数组中的文件
                foreach (object objFile in list)
                {
                    string strFile = objFile.ToString();
                    //旧文件路径及名称
                    string oldFile = strPath + strFile;
                    //新文件路径及名称
                    string newFile = strNewPath + strFile;
                    if (File.Exists(oldFile))
                    {
                        if (!Directory.Exists(newFile))
                        {
                            //判断是否存在新文件名，如果不存在则创建
                            Directory.CreateDirectory(strNewPath);
                        }
                        if(intflag==0)
                        {
                            //复制文件
                            File.Copy(oldFile, newFile);
                        }
                        else if(intflag==1)
                        {
                            File.Move(oldFile, newFile);
                        }
                    }
                }
                GetListViewItem(Allpath, imagelist, lv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        //标志是否剪切文件
        private bool blCut = false;
        //标志是否复制文件
        private bool blCopy = false;

        private void menuCut_Click(object sender, EventArgs e)
        {
            //剪切变量为1
            blCut = true;
            //粘帖命令可用
            menuPaste.Enabled = true;
            //不能复制
            blCopy = false;
            //判断是否选择了文件
            IsSelectFile();
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            //可以复制
            blCopy = true;
            //粘帖命令可用
            menuPaste.Enabled = true;
            //不能剪切
            blCut = false;
            //判断是否选择了文件
            IsSelectFile();
        }

        private void menuPaste_Click(object sender, EventArgs e)
        {
            //复制
            if(blCopy==true)
            {
                CopyFile(lvInfo, imageList1, list,
                    strFullName, Allpath, 0);
                for (int i = 0; i < list.Count; i++)
                {
                    CopyDir(Allpath + list[i].ToString(), strFullName + list[i].ToString(), 0);
                }
            }
            //剪切
            else if(blCut==true)
            {
                CopyFile(lvInfo, imageList1, list,
                   strFullName, Allpath, 1);
                for (int i = 0; i < list.Count; i++)
                {
                    CopyDir(Allpath + list[i].ToString(), strFullName + list[i].ToString(), 1);
                }
                blCut = false;
                menuPaste.Enabled = false;
            }
            else
            {
                MessageBox.Show("没有需要粘贴的内容","提示",MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public void DeleteFile(ListView lv,ImageList imagelist)
        {
            foreach (object objFile in lv.SelectedItems)
            {
                string strFile = objFile.ToString();
                string strFullFile = Allpath + strFile.Substring(strFile.IndexOf("{") + 1,
                    strFile.LastIndexOf("}") - strFile.IndexOf("{") - 1);
                if(File.Exists(strFullFile))
                {
                    //删除文件
                    File.Delete(strFullFile);
                }
                else if(Directory.Exists(strFullFile))
                {
                    Directory.Delete(strFullFile, true);
                }
            }
            GetListViewItem(Allpath, imagelist, lv);
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteFile(lvInfo,imageList1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvInfo.View = View.Tile;
        }

        private void 图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvInfo.View = View.LargeIcon;
        }

        private void 列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvInfo.View = View.List;
        }

        private void 详细资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvInfo.View = View.Details;
        }

        private void menuClearRubbish_Click(object sender, EventArgs e)
        {
            try
            {
                //执行批处理文件
                Process.Start(Application.StartupPath + "\\" + "clear.bat");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 动态压缩文件
        /// </summary>
        /// <param name="FileToZip">源文件</param>
        /// <param name="ZipedFile">目的文件</param>
        /// <returns></returns>
        private bool ZipFile(string FileToZip,string ZipedFile)
        {
            //判断是否选择了额压缩文件
            if(!File.Exists(FileToZip))
            {
                throw new FileNotFoundException("指定要压缩的文件：" +
                    FileToZip + " 不存在！");
            }
            //定义数据流对象实例
            FileStream ZipFile = null;
            //定义压缩文件输出流实例
            ZipOutputStream ZipStream = null;
            //定义压缩文件对象实例
            ZipEntry zipEntry = null;
            //用于判断是否压缩成功
            bool res = true;
            try
            {
                //打开源文件
                ZipFile = File.OpenRead(FileToZip);
                byte[] buffer = new byte[ZipFile.Length];
                ZipFile.Read(buffer, 0, buffer.Length);//读取源文件
                ZipFile.Close();
                //创建压缩文件
                ZipFile = File.Create(ZipedFile);
                ZipStream = new ZipOutputStream(ZipFile);
                zipEntry = new ZipEntry(Path.GetFileName(FileToZip));
                ZipStream.PutNextEntry(zipEntry);
                ZipStream.SetLevel(6);
                //向压缩文件中添加内容
                ZipStream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
                res = false;
            }
            finally
            {
                if(zipEntry!=null)
                {
                    zipEntry = null;
                }
                if(ZipStream!=null)
                {
                    ZipStream.Finish();
                    ZipStream.Close();
                }
                if(ZipFile!=null)
                {
                    ZipFile.Close();
                    ZipFile = null;
                }
                GC.Collect();
                GC.Collect(1);
            }
            return res;
        }

        /// <summary>
        /// 压缩目录
        /// </summary>
        /// <param name="folderToZip"></param>
        /// <param name="zipedFile"></param>
        /// <returns></returns>
        private bool ZipFileDictory(string folderToZip, string zipedFile)
        {
            bool res;
            if (!Directory.Exists(folderToZip))
            {
                return false;
            }
            ZipOutputStream ZOPStrem = new ZipOutputStream(
                File.Create(zipedFile));
            ZOPStrem.SetLevel(6);
            res = ZipFileDictory(folderToZip, ZOPStrem,"");
            ZOPStrem.Finish();
            ZOPStrem.Close();
            return res;
        }

        /// <summary>
        /// 递归压缩目录
        /// </summary>
        /// <param name="folderToZip"></param>
        /// <param name="ZOPStream"></param>
        /// <param name="parentFolderName"></param>
        /// <returns></returns>
        private bool ZipFileDictory(string folderToZip,ZipOutputStream ZOPStream,
            string parentFolderName)
        {
            bool res = true;
            string[] folders, filenames;
            ZipEntry entry = null;
            FileStream fs = null;
            Crc32 crc = new Crc32();
            try
            {
                //加上“/”才会当成是文件夹的创建
                entry = new ZipEntry(Path.Combine(parentFolderName, Path.GetFileName(
                    folderToZip) + "/"));
                ZOPStream.PutNextEntry(entry);
                ZOPStream.Flush();
                filenames = Directory.GetFiles(folderToZip);
                foreach (string file in filenames)
                {
                    //打开要压缩文件
                    fs = File.OpenRead(file);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    entry = new ZipEntry(Path.Combine(
                        parentFolderName, Path.GetFileName(folderToZip) + "/" +
                        Path.GetFileName(file)));
                    entry.DateTime = DateTime.Now;
                    entry.Size = fs.Length;
                    fs.Close();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    ZOPStream.PutNextEntry(entry);
                    ZOPStream.Write(buffer, 0, buffer.Length);
                }
            }
            catch
            {
                res = false;
            }
            finally
            {
                if(fs!=null)
                {
                    fs.Close();
                    fs = null;
                }
                if(entry!=null)
                {
                    entry = null;
                }
                GC.Collect();
                GC.Collect(1);
            }
            folders = Directory.GetDirectories(folderToZip);
            foreach (string folder in folders)
            {
                if(!ZipFileDictory(folder,ZOPStream,
                    Path.Combine(parentFolderName,Path.GetFileName(folderToZip))))
                {
                    return false;
                }
            }
            return res;
        }

        private void menuCompress_Click(object sender, EventArgs e)
        {
            try
            {
                //压缩文件类型
                saveFileDialog.Filter = "*.rar|*.rar";
                if(saveFileDialog.ShowDialog()==DialogResult.OK)
                {
                    if(list.Count>0)
                    {
                        string strNewPath = DateTime.Now.ToString(
                            "yyyymmddhhmmss");
                        //复制文件
                        CopyFile(lvInfo, imageList1, list, Allpath,
                            Allpath + strNewPath + "\\", 0);
                        for (int i = 0; i < list.Count; i++)
                        {
                            CopyDir(Allpath + strNewPath + "\\" + list[i].ToString(),
                                Allpath + list[i].ToString(), 0);
                        }
                        //压缩文件或文件夹
                        ZipFileDictory(strNewPath, saveFileDialog.FileName);
                        Directory.Delete(Allpath + strNewPath, true);
                        MessageBox.Show("已成功压缩文件");
                    }
                    else if(lvInfo.SelectedIndices.Count > 0)
                    {
                        ZipFileDictory(lvInfo.SelectedItems[0].Text,
                            saveFileDialog.FileName);
                        MessageBox.Show("已成功压缩文件");
                    }
                }
            }
            catch
            { }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UnZip(string fileToUpZip,string zipedFolder)
        {
            if(!File.Exists(Allpath+fileToUpZip))
            {
                return;
            }
            if(!Directory.Exists(zipedFolder))
            {
                //创建解压后的文件夹
                Directory.CreateDirectory(zipedFolder);
            }
            ZipInputStream ZIPStream = null;
            ZipEntry theEntry = null;
            //解压后的文件名
            string fileName;
            //文件流对象
            FileStream streamWriter = null;
            try
            {
                ZIPStream = new ZipInputStream(File.OpenRead(Allpath + fileToUpZip));
                while((theEntry=ZIPStream.GetNextEntry())!=null)
                {
                    if (theEntry.Name!=string.Empty)
                    {
                        fileName = Path.Combine(zipedFolder, theEntry.Name);
                        //判断路径是否是文件夹
                        if (fileName.EndsWith("/") || fileName.EndsWith("\\"))
                        {
                            Directory.CreateDirectory(fileName);
                            continue;
                        }
                        //创建解压后的文件
                        streamWriter = File.Create(fileName);
                        int size = 2048;
                        byte[] data = new byte[size];
                        while(true)
                        {
                            //读取压缩文件内容
                            size = ZIPStream.Read(data, 0, data.Length);
                            if(size>0)
                            {
                                //想解压的文件中写入内容
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if(streamWriter!=null)
                {
                    streamWriter.Close();
                    streamWriter = null;
                }
                if(theEntry!=null)
                {
                    theEntry = null;
                }
                if(ZIPStream!=null)
                {
                    ZIPStream.Close();
                    ZIPStream = null;
                }
                GC.Collect();
                GC.Collect(1);
            }
        }

        private void menuUnZip_Click(object sender, EventArgs e)
        {
            try
            {
                //文件打开对话框
                folderBrowserDialog.ShowDialog();
                if (lvInfo.SelectedIndices.Count > 0)
                {
                    FileInfo fInfo = new FileInfo(
                        Allpath + lvInfo.SelectedItems[0].Text);
                    if (fInfo.Exists && (fInfo.Extension.ToLower() == ".rar" ||
                        fInfo.Extension.ToLower() == ".zip"))
                    {
                        //解压文件
                        UnZip(lvInfo.SelectedItems[0].Text, 
                            folderBrowserDialog.SelectedPath);
                        MessageBox.Show("解压文件成功");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
