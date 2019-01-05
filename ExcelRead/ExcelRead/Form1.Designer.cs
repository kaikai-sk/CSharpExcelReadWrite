namespace ExcelRead
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGZ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenVedio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenGZ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPicOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSendMail = new System.Windows.Forms.ToolStripMenuItem();
            this.用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRegiste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCurUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuComponent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSecondClock = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPicVisual = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripForm1 = new System.Windows.Forms.ToolStrip();
            this.toolOpenExcel = new System.Windows.Forms.ToolStripButton();
            this.toolNewExcel = new System.Windows.Forms.ToolStripButton();
            this.toolOpenVedio = new System.Windows.Forms.ToolStripButton();
            this.toolopenTxt = new System.Windows.Forms.ToolStripButton();
            this.toolNewTxt = new System.Windows.Forms.ToolStripButton();
            this.toolSendMail = new System.Windows.Forms.ToolStripButton();
            this.toolSecondClock = new System.Windows.Forms.ToolStripButton();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.iconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuExtit = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuFileManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStripForm1.SuspendLayout();
            this.iconMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuNet,
            this.用户ToolStripMenuItem,
            this.menuComponent});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(930, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuOpenFile});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(44, 21);
            this.menuFile.Text = "文件";
            // 
            // menuNew
            // 
            this.menuNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewExcel,
            this.menuNewTxt,
            this.menuGZ});
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(100, 22);
            this.menuNew.Text = "新建";
            // 
            // menuNewExcel
            // 
            this.menuNewExcel.Image = ((System.Drawing.Image)(resources.GetObject("menuNewExcel.Image")));
            this.menuNewExcel.Name = "menuNewExcel";
            this.menuNewExcel.Size = new System.Drawing.Size(140, 22);
            this.menuNewExcel.Text = "Excel文件";
            this.menuNewExcel.Click += new System.EventHandler(this.menuNewExcel_Click);
            // 
            // menuNewTxt
            // 
            this.menuNewTxt.Image = ((System.Drawing.Image)(resources.GetObject("menuNewTxt.Image")));
            this.menuNewTxt.Name = "menuNewTxt";
            this.menuNewTxt.Size = new System.Drawing.Size(140, 22);
            this.menuNewTxt.Text = "文本文件";
            this.menuNewTxt.Click += new System.EventHandler(this.menuNewTxt_Click);
            // 
            // menuGZ
            // 
            this.menuGZ.Name = "menuGZ";
            this.menuGZ.Size = new System.Drawing.Size(140, 22);
            this.menuGZ.Text = "GZ压缩文件";
            this.menuGZ.Click += new System.EventHandler(this.menuGZ_Click);
            // 
            // menuOpenFile
            // 
            this.menuOpenFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenExcel,
            this.menuOpenVedio,
            this.menuOpenTxt,
            this.menuOpenGZ,
            this.menuPicOpen});
            this.menuOpenFile.Name = "menuOpenFile";
            this.menuOpenFile.Size = new System.Drawing.Size(100, 22);
            this.menuOpenFile.Text = "打开";
            // 
            // menuOpenExcel
            // 
            this.menuOpenExcel.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenExcel.Image")));
            this.menuOpenExcel.Name = "menuOpenExcel";
            this.menuOpenExcel.Size = new System.Drawing.Size(129, 22);
            this.menuOpenExcel.Text = "Excel文件";
            this.menuOpenExcel.Click += new System.EventHandler(this.menuOpenExcel_Click);
            // 
            // menuOpenVedio
            // 
            this.menuOpenVedio.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenVedio.Image")));
            this.menuOpenVedio.Name = "menuOpenVedio";
            this.menuOpenVedio.Size = new System.Drawing.Size(129, 22);
            this.menuOpenVedio.Text = "视频文件";
            this.menuOpenVedio.Click += new System.EventHandler(this.menuOpenVedio_Click);
            // 
            // menuOpenTxt
            // 
            this.menuOpenTxt.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenTxt.Image")));
            this.menuOpenTxt.Name = "menuOpenTxt";
            this.menuOpenTxt.Size = new System.Drawing.Size(129, 22);
            this.menuOpenTxt.Text = "文本文件";
            this.menuOpenTxt.Click += new System.EventHandler(this.menuOpenTxt_Click);
            // 
            // menuOpenGZ
            // 
            this.menuOpenGZ.Name = "menuOpenGZ";
            this.menuOpenGZ.Size = new System.Drawing.Size(129, 22);
            this.menuOpenGZ.Text = "GZ文件";
            this.menuOpenGZ.Click += new System.EventHandler(this.menuOpenGZ_Click);
            // 
            // menuPicOpen
            // 
            this.menuPicOpen.Name = "menuPicOpen";
            this.menuPicOpen.Size = new System.Drawing.Size(129, 22);
            this.menuPicOpen.Text = "图像文件";
            this.menuPicOpen.Click += new System.EventHandler(this.menuPicOpen_Click);
            // 
            // menuNet
            // 
            this.menuNet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSendMail});
            this.menuNet.Name = "menuNet";
            this.menuNet.Size = new System.Drawing.Size(68, 21);
            this.menuNet.Text = "网络功能";
            // 
            // menuSendMail
            // 
            this.menuSendMail.Image = ((System.Drawing.Image)(resources.GetObject("menuSendMail.Image")));
            this.menuSendMail.Name = "menuSendMail";
            this.menuSendMail.Size = new System.Drawing.Size(124, 22);
            this.menuSendMail.Text = "发送邮件";
            this.menuSendMail.Click += new System.EventHandler(this.menuSendMail_Click);
            // 
            // 用户ToolStripMenuItem
            // 
            this.用户ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogin,
            this.menuRegiste,
            this.menuCurUser,
            this.menuLogout});
            this.用户ToolStripMenuItem.Name = "用户ToolStripMenuItem";
            this.用户ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.用户ToolStripMenuItem.Text = "用户";
            // 
            // menuLogin
            // 
            this.menuLogin.Image = ((System.Drawing.Image)(resources.GetObject("menuLogin.Image")));
            this.menuLogin.Name = "menuLogin";
            this.menuLogin.Size = new System.Drawing.Size(124, 22);
            this.menuLogin.Text = "登录";
            this.menuLogin.Click += new System.EventHandler(this.menuLogin_Click);
            // 
            // menuRegiste
            // 
            this.menuRegiste.Image = ((System.Drawing.Image)(resources.GetObject("menuRegiste.Image")));
            this.menuRegiste.Name = "menuRegiste";
            this.menuRegiste.Size = new System.Drawing.Size(124, 22);
            this.menuRegiste.Text = "注册";
            this.menuRegiste.Click += new System.EventHandler(this.menuRegiste_Click);
            // 
            // menuCurUser
            // 
            this.menuCurUser.Name = "menuCurUser";
            this.menuCurUser.Size = new System.Drawing.Size(124, 22);
            this.menuCurUser.Text = "当前用户";
            this.menuCurUser.Click += new System.EventHandler(this.menuCurUser_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(124, 22);
            this.menuLogout.Text = "注销";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // menuComponent
            // 
            this.menuComponent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSecondClock,
            this.menuPicVisual,
            this.menuFileManage});
            this.menuComponent.Name = "menuComponent";
            this.menuComponent.Size = new System.Drawing.Size(56, 21);
            this.menuComponent.Text = "小组件";
            // 
            // menuSecondClock
            // 
            this.menuSecondClock.Image = ((System.Drawing.Image)(resources.GetObject("menuSecondClock.Image")));
            this.menuSecondClock.Name = "menuSecondClock";
            this.menuSecondClock.Size = new System.Drawing.Size(152, 22);
            this.menuSecondClock.Text = "秒表";
            this.menuSecondClock.Click += new System.EventHandler(this.menuSecondClock_Click);
            // 
            // menuPicVisual
            // 
            this.menuPicVisual.Name = "menuPicVisual";
            this.menuPicVisual.Size = new System.Drawing.Size(152, 22);
            this.menuPicVisual.Text = "图像显示效果";
            this.menuPicVisual.Click += new System.EventHandler(this.menuPicVisual_Click);
            // 
            // toolStripForm1
            // 
            this.toolStripForm1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpenExcel,
            this.toolNewExcel,
            this.toolOpenVedio,
            this.toolopenTxt,
            this.toolNewTxt,
            this.toolSendMail,
            this.toolSecondClock});
            this.toolStripForm1.Location = new System.Drawing.Point(0, 25);
            this.toolStripForm1.Name = "toolStripForm1";
            this.toolStripForm1.Size = new System.Drawing.Size(930, 25);
            this.toolStripForm1.TabIndex = 1;
            this.toolStripForm1.Text = "toolStrip1";
            // 
            // toolOpenExcel
            // 
            this.toolOpenExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolOpenExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolOpenExcel.Image")));
            this.toolOpenExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOpenExcel.Name = "toolOpenExcel";
            this.toolOpenExcel.Size = new System.Drawing.Size(23, 22);
            this.toolOpenExcel.Text = "打开Excel文件";
            this.toolOpenExcel.Click += new System.EventHandler(this.menuOpenExcel_Click);
            // 
            // toolNewExcel
            // 
            this.toolNewExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNewExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolNewExcel.Image")));
            this.toolNewExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNewExcel.Name = "toolNewExcel";
            this.toolNewExcel.Size = new System.Drawing.Size(23, 22);
            this.toolNewExcel.Text = "新建Excel文件";
            this.toolNewExcel.Click += new System.EventHandler(this.menuNewExcel_Click);
            // 
            // toolOpenVedio
            // 
            this.toolOpenVedio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolOpenVedio.Image = ((System.Drawing.Image)(resources.GetObject("toolOpenVedio.Image")));
            this.toolOpenVedio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOpenVedio.Name = "toolOpenVedio";
            this.toolOpenVedio.Size = new System.Drawing.Size(23, 22);
            this.toolOpenVedio.Text = "打开视频文件";
            this.toolOpenVedio.Click += new System.EventHandler(this.menuOpenVedio_Click);
            // 
            // toolopenTxt
            // 
            this.toolopenTxt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolopenTxt.Image = ((System.Drawing.Image)(resources.GetObject("toolopenTxt.Image")));
            this.toolopenTxt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolopenTxt.Name = "toolopenTxt";
            this.toolopenTxt.Size = new System.Drawing.Size(23, 22);
            this.toolopenTxt.Text = "打开文本文件";
            this.toolopenTxt.Click += new System.EventHandler(this.menuOpenTxt_Click);
            // 
            // toolNewTxt
            // 
            this.toolNewTxt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNewTxt.Image = ((System.Drawing.Image)(resources.GetObject("toolNewTxt.Image")));
            this.toolNewTxt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNewTxt.Name = "toolNewTxt";
            this.toolNewTxt.Size = new System.Drawing.Size(23, 22);
            this.toolNewTxt.Text = "新建文本文件";
            this.toolNewTxt.Click += new System.EventHandler(this.menuNewTxt_Click);
            // 
            // toolSendMail
            // 
            this.toolSendMail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSendMail.Image = ((System.Drawing.Image)(resources.GetObject("toolSendMail.Image")));
            this.toolSendMail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSendMail.Name = "toolSendMail";
            this.toolSendMail.Size = new System.Drawing.Size(23, 22);
            this.toolSendMail.Text = "发送邮件";
            this.toolSendMail.Click += new System.EventHandler(this.menuSendMail_Click);
            // 
            // toolSecondClock
            // 
            this.toolSecondClock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSecondClock.Image = ((System.Drawing.Image)(resources.GetObject("toolSecondClock.Image")));
            this.toolSecondClock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSecondClock.Name = "toolSecondClock";
            this.toolSecondClock.Size = new System.Drawing.Size(23, 22);
            this.toolSecondClock.Text = "秒表";
            this.toolSecondClock.Click += new System.EventHandler(this.menuSecondClock_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.iconMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // iconMenuStrip
            // 
            this.iconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExtit});
            this.iconMenuStrip.Name = "iconMenuStrip";
            this.iconMenuStrip.Size = new System.Drawing.Size(101, 26);
            // 
            // menuExtit
            // 
            this.menuExtit.Name = "menuExtit";
            this.menuExtit.Size = new System.Drawing.Size(100, 22);
            this.menuExtit.Text = "退出";
            this.menuExtit.Click += new System.EventHandler(this.menuExtit_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // menuFileManage
            // 
            this.menuFileManage.Name = "menuFileManage";
            this.menuFileManage.Size = new System.Drawing.Size(152, 22);
            this.menuFileManage.Text = "文件管理模块";
            this.menuFileManage.Click += new System.EventHandler(this.menuFileManage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(930, 458);
            this.Controls.Add(this.toolStripForm1);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "文件读写主对话框";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStripForm1.ResumeLayout(false);
            this.toolStripForm1.PerformLayout();
            this.iconMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuOpenFile;
        private System.Windows.Forms.ToolStrip toolStripForm1;
        private System.Windows.Forms.ToolStripButton toolOpenExcel;
        private System.Windows.Forms.ToolStripMenuItem menuOpenExcel;
        private System.Windows.Forms.ToolStripMenuItem menuNewExcel;
        private System.Windows.Forms.ToolStripMenuItem menuNet;
        private System.Windows.Forms.ToolStripMenuItem menuSendMail;
        private System.Windows.Forms.ToolStripMenuItem menuOpenVedio;
        private System.Windows.Forms.ToolStripMenuItem 用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLogin;
        private System.Windows.Forms.ToolStripMenuItem menuNewTxt;
        private System.Windows.Forms.ToolStripMenuItem menuOpenTxt;
        private System.Windows.Forms.ToolStripMenuItem menuComponent;
        private System.Windows.Forms.ToolStripMenuItem menuSecondClock;
        private System.Windows.Forms.ToolStripMenuItem menuRegiste;
        private System.Windows.Forms.ToolStripButton toolNewExcel;
        private System.Windows.Forms.ToolStripButton toolOpenVedio;
        private System.Windows.Forms.ToolStripButton toolopenTxt;
        private System.Windows.Forms.ToolStripButton toolNewTxt;
        private System.Windows.Forms.ToolStripButton toolSendMail;
        private System.Windows.Forms.ToolStripButton toolSecondClock;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip iconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuExtit;
        private System.Windows.Forms.ToolStripMenuItem menuCurUser;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuGZ;
        private System.Windows.Forms.ToolStripMenuItem menuOpenGZ;
        private System.Windows.Forms.ToolStripMenuItem menuPicOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem menuPicVisual;
        private System.Windows.Forms.ToolStripMenuItem menuFileManage;
    }
}

