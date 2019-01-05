namespace ExcelRead
{
    partial class DocForm
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
            this.txtSource = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSetFont = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetColor = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSource.Location = new System.Drawing.Point(0, 0);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(540, 427);
            this.txtSource.TabIndex = 1;
            this.txtSource.Text = "";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSetFont,
            this.menuSetColor});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(125, 48);
            // 
            // menuSetFont
            // 
            this.menuSetFont.Name = "menuSetFont";
            this.menuSetFont.Size = new System.Drawing.Size(124, 22);
            this.menuSetFont.Text = "设置字体";
            this.menuSetFont.Click += new System.EventHandler(this.menuSetFont_Click);
            // 
            // menuSetColor
            // 
            this.menuSetColor.Name = "menuSetColor";
            this.menuSetColor.Size = new System.Drawing.Size(124, 22);
            this.menuSetColor.Text = "设置颜色";
            this.menuSetColor.Click += new System.EventHandler(this.menuSetColor_Click);
            // 
            // DocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 427);
            this.Controls.Add(this.txtSource);
            this.Name = "DocForm";
            this.Text = "DocForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocForm_FormClosing);
            this.Load += new System.EventHandler(this.DocForm_Load);
            this.Leave += new System.EventHandler(this.DocForm_Leave);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuSetFont;
        private System.Windows.Forms.ToolStripMenuItem menuSetColor;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}