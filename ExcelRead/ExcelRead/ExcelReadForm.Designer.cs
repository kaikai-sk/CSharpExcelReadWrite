namespace ExcelRead
{
    partial class ExcelReadForm
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
            this.menuSaveExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.excel编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddRow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddCol = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteCol = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChangeSheet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dGViewExcel = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuModifyColumnName = new System.Windows.Forms.ToolStripMenuItem();
            this.横向ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHoriSum = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHoriAvg = new System.Windows.Forms.ToolStripMenuItem();
            this.纵向ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVerticalSumAvg = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGViewExcel)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.excel编辑ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(548, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSaveExcel});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.文件ToolStripMenuItem.Text = "Excel文件";
            // 
            // menuSaveExcel
            // 
            this.menuSaveExcel.Name = "menuSaveExcel";
            this.menuSaveExcel.Size = new System.Drawing.Size(100, 22);
            this.menuSaveExcel.Text = "保存";
            this.menuSaveExcel.Click += new System.EventHandler(this.menuSaveExcel_Click);
            // 
            // excel编辑ToolStripMenuItem
            // 
            this.excel编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.excel编辑ToolStripMenuItem.Name = "excel编辑ToolStripMenuItem";
            this.excel编辑ToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.excel编辑ToolStripMenuItem.Text = "Excel编辑";
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddRow,
            this.menuAddCol});
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.添加ToolStripMenuItem.Text = "添加";
            // 
            // menuAddRow
            // 
            this.menuAddRow.Name = "menuAddRow";
            this.menuAddRow.Size = new System.Drawing.Size(88, 22);
            this.menuAddRow.Text = "行";
            this.menuAddRow.Click += new System.EventHandler(this.menuAddRow_Click);
            // 
            // menuAddCol
            // 
            this.menuAddCol.Name = "menuAddCol";
            this.menuAddCol.Size = new System.Drawing.Size(88, 22);
            this.menuAddCol.Text = "列";
            this.menuAddCol.Click += new System.EventHandler(this.menuAddCol_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDeleteRow,
            this.menuDeleteCol});
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // menuDeleteRow
            // 
            this.menuDeleteRow.Name = "menuDeleteRow";
            this.menuDeleteRow.Size = new System.Drawing.Size(88, 22);
            this.menuDeleteRow.Text = "行";
            this.menuDeleteRow.Click += new System.EventHandler(this.menuDeleteRow_Click);
            // 
            // menuDeleteCol
            // 
            this.menuDeleteCol.Name = "menuDeleteCol";
            this.menuDeleteCol.Size = new System.Drawing.Size(88, 22);
            this.menuDeleteCol.Text = "列";
            this.menuDeleteCol.Click += new System.EventHandler(this.menuDeleteCol_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuChangeSheet});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // menuChangeSheet
            // 
            this.menuChangeSheet.Name = "menuChangeSheet";
            this.menuChangeSheet.Size = new System.Drawing.Size(124, 22);
            this.menuChangeSheet.Text = "切换表单";
            this.menuChangeSheet.Click += new System.EventHandler(this.menuChangeSheet_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(548, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // dGViewExcel
            // 
            this.dGViewExcel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGViewExcel.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dGViewExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGViewExcel.ContextMenuStrip = this.contextMenuStrip;
            this.dGViewExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGViewExcel.Location = new System.Drawing.Point(0, 50);
            this.dGViewExcel.Name = "dGViewExcel";
            this.dGViewExcel.RowTemplate.Height = 23;
            this.dGViewExcel.Size = new System.Drawing.Size(548, 289);
            this.dGViewExcel.TabIndex = 2;
            this.dGViewExcel.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dGViewExcel_ColumnHeaderMouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuModifyColumnName,
            this.横向ToolStripMenuItem,
            this.纵向ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 92);
            // 
            // menuModifyColumnName
            // 
            this.menuModifyColumnName.Name = "menuModifyColumnName";
            this.menuModifyColumnName.Size = new System.Drawing.Size(152, 22);
            this.menuModifyColumnName.Text = "修改列名";
            this.menuModifyColumnName.Click += new System.EventHandler(this.menuModifyColumnName_Click);
            // 
            // 横向ToolStripMenuItem
            // 
            this.横向ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHoriSum,
            this.menuHoriAvg});
            this.横向ToolStripMenuItem.Name = "横向ToolStripMenuItem";
            this.横向ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.横向ToolStripMenuItem.Text = "横向";
            // 
            // menuHoriSum
            // 
            this.menuHoriSum.Name = "menuHoriSum";
            this.menuHoriSum.Size = new System.Drawing.Size(112, 22);
            this.menuHoriSum.Text = "求和";
            this.menuHoriSum.Click += new System.EventHandler(this.menuHoriSum_Click);
            // 
            // menuHoriAvg
            // 
            this.menuHoriAvg.Name = "menuHoriAvg";
            this.menuHoriAvg.Size = new System.Drawing.Size(112, 22);
            this.menuHoriAvg.Text = "求平均";
            this.menuHoriAvg.Click += new System.EventHandler(this.menuHoriAvg_Click);
            // 
            // 纵向ToolStripMenuItem
            // 
            this.纵向ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuVerticalSumAvg});
            this.纵向ToolStripMenuItem.Name = "纵向ToolStripMenuItem";
            this.纵向ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.纵向ToolStripMenuItem.Text = "纵向";
            // 
            // menuVerticalSumAvg
            // 
            this.menuVerticalSumAvg.Name = "menuVerticalSumAvg";
            this.menuVerticalSumAvg.Size = new System.Drawing.Size(152, 22);
            this.menuVerticalSumAvg.Text = "求和/平均";
            this.menuVerticalSumAvg.Click += new System.EventHandler(this.menuVerticalSum_Click);
            // 
            // ExcelReadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 339);
            this.Controls.Add(this.dGViewExcel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ExcelReadForm";
            this.Text = "ExcelRead";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExcelReadForm_FormClosing);
            this.Load += new System.EventHandler(this.ExcelReadForm_Load);
            this.Resize += new System.EventHandler(this.ExcelReadForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGViewExcel)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.DataGridView dGViewExcel;
        private System.Windows.Forms.ToolStripMenuItem menuSaveExcel;
        private System.Windows.Forms.ToolStripMenuItem excel编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAddRow;
        private System.Windows.Forms.ToolStripMenuItem menuAddCol;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteRow;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteCol;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuChangeSheet;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuModifyColumnName;
        private System.Windows.Forms.ToolStripMenuItem 横向ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuHoriSum;
        private System.Windows.Forms.ToolStripMenuItem menuHoriAvg;
        private System.Windows.Forms.ToolStripMenuItem 纵向ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuVerticalSumAvg;
    }
}