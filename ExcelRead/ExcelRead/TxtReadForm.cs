using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelRead
{
    public partial class TxtReadForm : Form
    {
        //窗体计数器，对已经创建的“文档”窗体进行计数
        private int wCount = 0;
        //打开或保存文档时的默认位置
        private string initialPos = "";
        //文档窗体对象
        private DocForm doc;
        //单身模式
        static TxtReadForm mySelf = null;


        private TxtReadForm()
        {
            InitializeComponent();
        }

        public static TxtReadForm GetInstance()
        {
            if (mySelf == null)
            {
                mySelf = new TxtReadForm();
            }
            return mySelf;
        }

        private void NewFile_Click(object sender, EventArgs e)
        {
            if (doc != null)
            {
                doc.Close();
            }
            //窗体记录数++
            wCount++;
            //创建文档窗体对象
            doc = new DocForm();
            //设置主窗口为文档窗体的父窗口
            doc.MdiParent = this;
            //设置文档窗体的标题
            doc.Text = "文档" + wCount;
            //显示文档窗体
            doc.Show();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (doc != null)
            {
                doc.Close();
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RichTextBoxStreamType fileType;
                    //判断文档类型
                    switch (openFileDialog.FilterIndex)
                    {
                        case 1:
                            fileType = RichTextBoxStreamType.PlainText; break;
                        case 2:
                            fileType = RichTextBoxStreamType.RichText; break;
                        default:
                            fileType = RichTextBoxStreamType.UnicodePlainText; break;
                    }
                    wCount++;
                    doc = new DocForm();
                    doc.MdiParent = this;
                    doc.Text = openFileDialog.FileName;
                    doc.TxtSource.LoadFile(openFileDialog.FileName, fileType);
                    doc.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace, "错误");
                }

            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RichTextBoxStreamType fileType;
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1://文本文件
                            //用空格代替对象链接与嵌入 (OLE) 对象的纯文本流。
                            fileType = RichTextBoxStreamType.PlainText;
                            break;
                        case 2://rtf文件
                            //RTF 格式流。
                            fileType = RichTextBoxStreamType.RichText;
                            break;
                        default://
                            //包含用空格代替对象链接与嵌入(OLE) 对象的文本流。该文本采用 Unicode 编码。
                            fileType = RichTextBoxStreamType.UnicodePlainText;
                            break;
                    }
                    //把文本编辑框中的文本输出并保存
                    doc.TxtSource.SaveFile(saveFileDialog.FileName,
                        fileType);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message+ex.StackTrace,"错误");
                }
            }
        }

        private void closeFile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }

        private void fontMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK && doc != null)
            {
                doc.TxtSource.SelectionFont = fontDialog.Font;
            }
        }

        private void ColorMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK && doc != null)
            {
                doc.TxtSource.SelectionColor = colorDialog.Color;
            }
        }

        private void optionMenuItem_Click(object sender, EventArgs e)
        {
            //创建选项设置对话框对象
            TxtSetDialog dlg = new TxtSetDialog();
            //显示“选项设置”对话框
            dlg.ShowDialog();
            //获得已经设置的默认文档位置
            initialPos = dlg.docPosition;
            //关闭“选项设置对话框”
            dlg.Close();
            //设置打开对话框的默认文件夹
            openFileDialog.InitialDirectory = initialPos;
            //设置保存对话框的默认路径
            saveFileDialog.InitialDirectory = initialPos;
        }

        private void TxtReadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mySelf = null;
        }

        private void TxtReadForm_Load(object sender, EventArgs e)
        {
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|RTF文件|*.rtf|所有文件(*.*)|*.*";
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|RTF文件|*.rtf|所有文件(*.*)|*.*";
            //初始化插件程序
            MakeBtnByDll();
        }

        //初始化插件程序
        private void MakeBtnByDll()
        {
            //1. 加载正在运行的程序集的物理路径
            string assPath = this.GetType().Assembly.Location;
            // 2. 获取程序集所在的文件夹，并转换成程序及文件夹的路径
            string strDirPath = Path.GetDirectoryName(assPath) + "\\plug";
            // 3.扫描文件夹里面的所有程序及文件
            string[] strDllPaths = Directory.GetFiles(strDirPath);
            //4. 边里所有的程序集文件路径，并加载程序集到内存中
            foreach (string strDll in strDllPaths)
            {
                //4.1 根据路径加载程序集文件到内存中
                Assembly ass = Assembly.LoadFrom(strDll);
                // 4.2 判断程序集中是否有插件类，
                // 4.2.1 获得插件程序集里面共有得类
                Type[] types = ass.GetExportedTypes();
                //重要：获取插件接口类型对象
                Type plugType = typeof(IPlug);
                //4.2.2 循环遍历插件程序集里面的类型，判断是否实现了插件记事本接口
                foreach (Type t in types)
                {
                    //判断t是否实现了Iplug接口
                    if (plugType.IsAssignableFrom(t))
                    {
                        //4.3 创建插件按钮
                        ToolStripMenuItem menuItem = new ToolStripMenuItem(t.Name);
                        this.menuPlug.DropDownItems.Add(menuItem);
                        //为所有的按钮点击事件绑定同一个方法
                        menuItem.Click += menuItem_Click;

                        //重要：根据插件类型，创建插件类对象，并转换成接口对象统一调用
                        IPlug plugObj = Activator.CreateInstance(t) as IPlug;
                        //将接口对象存入按钮的tag属性
                        menuItem.Tag = plugObj;
                    }
                }
            }
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            //从菜单项中取出对应的插件对象
            IPlug iplug = menuItem.Tag as IPlug;
            //调用对象的处理文字方法，并重新设置给文本框
            doc.TxtSource.Text = iplug.ProcessText(doc.TxtSource.Text);
        }

        //另存为Word文档
        private void menuSaveAsWord_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Word文件(*.doc)|*.doc";
            if(saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                if (!File.Exists(saveFileDialog.FileName))
                {
                    CreateWord(saveFileDialog.FileName);
                }
                SaveWord(saveFileDialog.FileName);
            }
        }

        //创建Word文件
        public void CreateWord(string fileName)
        {
            Microsoft.Office.Interop.Word.Application wordApp;       //声明word应用程序变量
            Document worddoc;          //声明word文档变量   
                                       //初始化变量
            object Nothing = Missing.Value;                       //COM调用时用于占位
            object format = WdSaveFormat.wdFormatDocument; //Word文档的保存格式
            wordApp = new Microsoft.Office.Interop.Word.Application();              //声明一个wordAPP对象
            worddoc = wordApp.Documents.Add(ref Nothing, ref Nothing,
                ref Nothing, ref Nothing);

            //向文档中写入内容
            string wordstr = "";
            worddoc.Paragraphs.Last.Range.Text = wordstr;

            //保存文档
            object path = fileName;       //设置文件保存路劲
            worddoc.SaveAs(ref path, ref format, ref Nothing, ref Nothing,
                ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                ref Nothing, ref Nothing, ref Nothing, ref Nothing);

            //关闭文档
            worddoc.Close(ref Nothing, ref Nothing, ref Nothing);  //关闭worddoc文档对象
            wordApp.Quit(ref Nothing, ref Nothing, ref Nothing);   //关闭wordApp组对象
            //MessageBox.Show("文档创建成功!");
        }

        //保存richTextBox数据到已经存在的word文档中。
        //先打开word文档，全选word文档中的数据，然后全选richTextBox中的数据并复制，粘贴到word文档中，最后保存word文档，并关闭文档
        public void SaveWord(string fileName)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = null;
            object missing = System.Reflection.Missing.Value;
            object File = fileName;
            object readOnly = false;
            object isVisible = true;
            try
            {
                doc = app.Documents.Open(ref File, ref missing, ref readOnly,
                 ref missing, ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref isVisible, ref missing,
                 ref missing, ref missing, ref missing);

                doc.ActiveWindow.Selection.WholeStory();//全选
                this.doc.TxtSource.SelectAll();
                Clipboard.SetData(DataFormats.Rtf, this.doc.TxtSource.SelectedRtf);//复制RTF数据到剪贴板
                doc.ActiveWindow.Selection.Paste();
                //doc.Paragraphs.Last.Range.Text = richTextBox1.Text;//word文档赋值数据，不带格式
                doc.Save();
                MessageBox.Show("文件保存成功");
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    doc = null;
                }

                if (app != null)
                {
                    app.Quit(ref missing, ref missing, ref missing);
                    app = null;
                }
            }
        }
    }
}
