namespace ExcelRead
{
    partial class Picform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEnlarge = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShrink = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSetStrAddToPic = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.trackBarLarge = new System.Windows.Forms.TrackBar();
            this.trackBarShrink = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuSavePic = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarShrink)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(562, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.menuSavePic});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.文件ToolStripMenuItem.Text = "图像文件";
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(152, 22);
            this.menuOpen.Text = "打开";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEnlarge,
            this.menuShrink,
            this.menuRotate});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.编辑ToolStripMenuItem.Text = "图像编辑";
            // 
            // menuEnlarge
            // 
            this.menuEnlarge.Name = "menuEnlarge";
            this.menuEnlarge.Size = new System.Drawing.Size(100, 22);
            this.menuEnlarge.Text = "放大";
            this.menuEnlarge.Click += new System.EventHandler(this.menuEnlarge_Click);
            // 
            // menuShrink
            // 
            this.menuShrink.Name = "menuShrink";
            this.menuShrink.Size = new System.Drawing.Size(100, 22);
            this.menuShrink.Text = "缩小";
            this.menuShrink.Click += new System.EventHandler(this.menuShrink_Click);
            // 
            // menuRotate
            // 
            this.menuRotate.Name = "menuRotate";
            this.menuRotate.Size = new System.Drawing.Size(100, 22);
            this.menuRotate.Text = "旋转";
            this.menuRotate.Click += new System.EventHandler(this.menuRotate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip;
            this.pictureBox1.Location = new System.Drawing.Point(0, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(562, 301);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSetStrAddToPic});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(197, 26);
            // 
            // menuSetStrAddToPic
            // 
            this.menuSetStrAddToPic.Name = "menuSetStrAddToPic";
            this.menuSetStrAddToPic.Size = new System.Drawing.Size(196, 22);
            this.menuSetStrAddToPic.Text = "设置添加到图片的文字";
            this.menuSetStrAddToPic.Click += new System.EventHandler(this.menuSetStrAddToPic_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // trackBarLarge
            // 
            this.trackBarLarge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trackBarLarge.Location = new System.Drawing.Point(69, 350);
            this.trackBarLarge.Maximum = 100;
            this.trackBarLarge.Name = "trackBarLarge";
            this.trackBarLarge.Size = new System.Drawing.Size(493, 45);
            this.trackBarLarge.TabIndex = 2;
            this.trackBarLarge.Scroll += new System.EventHandler(this.trackBarLarge_Scroll);
            // 
            // trackBarShrink
            // 
            this.trackBarShrink.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trackBarShrink.Location = new System.Drawing.Point(69, 404);
            this.trackBarShrink.Maximum = 100;
            this.trackBarShrink.Name = "trackBarShrink";
            this.trackBarShrink.Size = new System.Drawing.Size(486, 45);
            this.trackBarShrink.TabIndex = 2;
            this.trackBarShrink.Scroll += new System.EventHandler(this.trackBarShrink_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "放大";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "缩小";
            // 
            // menuSavePic
            // 
            this.menuSavePic.Name = "menuSavePic";
            this.menuSavePic.Size = new System.Drawing.Size(152, 22);
            this.menuSavePic.Text = "保存";
            this.menuSavePic.Click += new System.EventHandler(this.menuSavePic_Click);
            // 
            // Picform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 452);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarShrink);
            this.Controls.Add(this.trackBarLarge);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(578, 491);
            this.MinimumSize = new System.Drawing.Size(578, 491);
            this.Name = "Picform";
            this.Text = "Picform";
            this.Load += new System.EventHandler(this.Picform_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarShrink)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuEnlarge;
        private System.Windows.Forms.ToolStripMenuItem menuShrink;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TrackBar trackBarLarge;
        private System.Windows.Forms.TrackBar trackBarShrink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem menuRotate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuSetStrAddToPic;
        private System.Windows.Forms.ToolStripMenuItem menuSavePic;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}