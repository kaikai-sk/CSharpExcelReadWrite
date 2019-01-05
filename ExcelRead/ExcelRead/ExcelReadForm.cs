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


namespace ExcelRead
{
    public partial class ExcelReadForm : Form
    {
        //要添加的列名称
        public string ColumnName
        { set; get; }
        //是否有多张表单
        public bool isHaveManySheet
        {
            set;
            get;
        }
        //要打开的文件名
        public string fileName
        {
            set;
            get;
        }
        //打开的文件的表单树木
        public int sheetNum
        {
            set; get;
        }

        /// <summary>
        /// 打开Excel文件
        /// </summary>
        /// <param name="frmExcel">数据显示到哪个对话框？？？？？</param>
        private void OpenExcel(string fileName, string sheetNum)
        {
            //"[Sheet1$]"
            DataSet ds = GetExcelData(fileName, sheetNum);
            this.dGViewExcel.DataSource = ds;
            this.dGViewExcel.DataMember = sheetNum;

            #region MyRegion
            //for (int count = 0; (count <= (this.dGViewExcel.Rows.Count - 1)); count++)
            //{
            //    this.dGViewExcel.Rows[count].HeaderCell.Value = (count + 1).ToString();
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

        public ExcelReadForm()
        {
            InitializeComponent();
            dGViewExcel.SelectionMode = DataGridViewSelectionMode.FullRowSelect | DataGridViewSelectionMode.RowHeaderSelect;
        }


        public ExcelReadForm(int rows) : this()
        {
            dGViewExcel.ColumnCount = 4;
            dGViewExcel.ColumnHeadersVisible = true;
            //设置表头风格
            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dGViewExcel.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            //设置表头名称
            dGViewExcel.Columns[0].Name = "A";
            dGViewExcel.Columns[1].Name = "B";
            dGViewExcel.Columns[2].Name = "C";
            dGViewExcel.Columns[3].Name = "D";
            //默认添加几行
            for (int i = 0; i < rows; i++)
            {
                string[] row = new string[] { i.ToString(), i.ToString(), i.ToString(), i.ToString() };
                dGViewExcel.Rows.Add(row);
            }
        }

        private void dGViewExcel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 相应“保存”按钮，将datagridview中的数据保存到excel中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSaveExcel_Click(object sender, EventArgs e)
        {
            setExcel(this.dGViewExcel, "");
        }

        //private string fileName;
        /// <summary>
        /// 读入Excel的数据 在DataGridView中显示
        /// </summary>
        /// <param name="dgv">显示内容的DataGridView的名称</param>
        public void setExcel(DataGridView dgv, string name)
        {
            //总可见列数，总可见行数
            int colCount = dgv.Columns.GetColumnCount(DataGridViewElementStates.Visible);
            int rowCount = dgv.Rows.GetRowCount(DataGridViewElementStates.Visible);
            //dataGridView 没有数据提示
            if (dgv.Rows.Count == 0 || rowCount == 0)
            {
                MessageBox.Show("表中没有数据", "提示");
            }
            else
            {
                //选择创建文件的路径
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "excel files(*.xls)|*.xls";
                save.Title = "请选择要导出数据的位置";
                //默认文件名是程序员指定的字符串+当前日期
                save.FileName = name + DateTime.Now.ToLongDateString();
                if (save.ShowDialog() == DialogResult.OK)
                {
                    string fileName = save.FileName;
                    // 创建Excel对象
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    if (excel == null)
                    {
                        MessageBox.Show("Excel无法启动", "提示");
                        return;
                    }
                    //创建Excel工作薄
                    Microsoft.Office.Interop.Excel.Workbook excelBook = excel.Workbooks.Add(true);
                    //创建表
                    Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets[1];
                    //生成字段名称
                    int k = 0;
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        //不导出隐藏的列
                        if (dgv.Columns[i].Visible)
                        {
                            excel.Cells[1, k + 1] = dgv.Columns[i].HeaderText;
                            k++;
                        }
                    }
                    //填充数据
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        k = 0;
                        for (int j = 0; j < dgv.ColumnCount; j++)
                        {
                            if (dgv.Columns[j].Visible)  //不导出隐藏的列
                            {
                                if (dgv[j, i].ValueType == typeof(string))
                                {
                                    if (dgv[j, i].Value != null)
                                    {
                                        excel.Cells[i + 2, k + 1] = "" + dgv[j, i].Value.ToString();
                                    }
                                }
                                else
                                {
                                    if (dgv[j, i].Value != null)
                                    {
                                        excel.Cells[i + 2, k + 1] = dgv[j, i].Value.ToString();
                                    }

                                }
                            }
                            k++;
                        }
                    }
                    try
                    {
                        excelBook.Saved = true;
                        excelBook.SaveCopyAs(fileName);
                        MessageBox.Show("文件保存成功！", "提示信息");
                    }
                    catch
                    {
                        MessageBox.Show("导出失败，文件可能正在使用中", "提示");
                    }
                }
            }
        }

        //添加一行
        private void menuAddRow_Click(object sender, EventArgs e)
        {
            if (dGViewExcel.Columns.Count > 0)
            {
                this.dGViewExcel.Rows.Add();
            }
            else
            {
                ShowWarningMessageBox("现在表格中一列也没有！必须先添加列");
            }
        }

        //添加一列
        private void menuAddCol_Click(object sender, EventArgs e)
        {
            ColumnAddForm frmAdd = new ColumnAddForm();
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = frmAdd.ColumnName;
                if (column != null)
                {
                    this.dGViewExcel.Columns.Add(column);
                }
            }
        }

        //删除选中行
        private void menuDeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (dGViewExcel.Rows.Count > 0)
                {
                    dGViewExcel.Rows.RemoveAt(dGViewExcel.SelectedCells[0].RowIndex);
                    //dGViewExcel.Rows.RemoveAt(dGViewExcel.SelectedRows[i - 1].Index);
                }
                else
                {
                    ShowWarningMessageBox("一行数据都没有了");
                }
            }
            catch (Exception ex)
            {
                ShowWarningMessageBox(ex.Message);
            }
        }

        //删除一列
        private void menuDeleteCol_Click(object sender, EventArgs e)
        {
            try
            {
                if (dGViewExcel.ColumnCount > 0)
                {
                    dGViewExcel.Columns.RemoveAt(dGViewExcel.SelectedCells[0].ColumnIndex);
                }
                else
                {
                    ShowWarningMessageBox("所有的列都已经删除");
                }
            }
            catch (Exception ex)
            {
                ShowWarningMessageBox(ex.Message);
            }
        }

        //显示警告对话框
        public void ShowWarningMessageBox(String str)
        {
            MessageBox.Show(str, "警告", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 但是显示窗体的时候表格自适应大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelReadForm_Load(object sender, EventArgs e)
        {
            DGViewHeightAdapt();
            if (this.isHaveManySheet == true)
            {
                this.menuChangeSheet.Enabled = true;
            }
            else
            {
                this.menuChangeSheet.Enabled = false;
            }
        }

        //datagridview的行高自适应窗体大小
        private void DGViewHeightAdapt()
        {
            for (int i = 0; i < dGViewExcel.Rows.Count; i++)
            {
                dGViewExcel.Rows[i].Height = (dGViewExcel.Height / dGViewExcel.Rows.Count);
            }
        }

        /// <summary>
        /// 窗体大小变化时，表格自动调整大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelReadForm_Resize(object sender, EventArgs e)
        {
            DGViewHeightAdapt();
        }

        /// <summary>
        /// 拦截关闭，提示是否保存文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelReadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("您可能做过修改，并未为保存文件，您确定要退出吗？",
                "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                return;
            }
            else
            {
                setExcel(this.dGViewExcel, "");
            }
        }

        private void menuChangeSheet_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            for (int i = 1; i <= this.sheetNum; i++)
            {
                list.Add(i.ToString());
            }
            ChangeSheetForm frmChange = new ChangeSheetForm(list.ToArray());
            if (frmChange.ShowDialog() == DialogResult.OK)
            {
                OpenExcel(this.fileName, string.Format("[Sheet{0}$]", frmChange.SheetNum.SelectedItem));
            }
        }

        private void menuModifyColumnName_Click(object sender, EventArgs e)
        {
            int index = dGViewExcel.SelectedCells[0].ColumnIndex;
            ChangeHeaderName(index);
        }

        private void ChangeHeaderName(int index)
        {
            string newName;
            ChangeHeaderNameForm frmNew = new ChangeHeaderNameForm();
            if (frmNew.ShowDialog() == DialogResult.OK)
            {
                newName = frmNew.strNewName.Text.Trim();
                this.dGViewExcel.Columns[index].HeaderText = newName;
            }
        }

        private void dGViewExcel_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.ColumnIndex;
            ChangeHeaderName(index);
        }

        //横向求平均数菜单响应函数
        private void menuHoriAvg_Click(object sender, EventArgs e)
        {
            double sum = 0;
            if (HoriSum(out sum))
            {
                double avg = sum / dGViewExcel.SelectedCells.Count;
                //当前选中行的行号
                int row = this.dGViewExcel.SelectedCells[0].RowIndex;
                DealRowRes(avg, row, "平均数");
            }
        }
        //横向求和菜单响应函数
        private void menuHoriSum_Click(object sender, EventArgs e)
        {
            //获得横向的和
            double sum;
            if (HoriSum(out sum))
            {
                //当前选中行的行号
                int row = this.dGViewExcel.SelectedCells[0].RowIndex;
                //将结果显示
                DealRowRes(sum, row, "和");
            }
        }


        //显示行结果
        private void DealRowRes(double avg, int row, string colName)
        {
            //如果结果行存在
            if (dGViewExcel.Columns.Contains(colName))
            {
                if (MessageBox.Show("您的文件中有一个名为：" + colName + "的列,是否是存放结果的列？", "提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    int col = dGViewExcel.Columns[colName].Index;
                    dGViewExcel.Rows[row].Cells[col].Value = avg;
                }
                else
                {
                    MessageBox.Show("请修改您的列名称");
                }
            }
            else
            {
                AddColumnSetValue(row, avg.ToString(), colName);
            }
        }



        //添加一列，并制定单元格的内容
        private bool AddColumnSetValue(int row, string value, string colName)
        {
            DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
            //列名称
            acCode.Name = colName;
            acCode.DataPropertyName = "sum";
            //标题文本
            acCode.HeaderText = colName;
            dGViewExcel.Columns.Add(acCode);
            dGViewExcel.Rows[row].Cells[dGViewExcel.Columns[colName].Index].Value = value;
            return true;
        }

        private void menuVerticalSum_Click(object sender, EventArgs e)
        {
            try
            {
                verticalSumAndAvg();
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// 纵向求和,和平均值，并显示在表格最后一行，并且高亮显示
        /// </summary>
        /// <param name="sum">输出型参数，获得和</param>
        /// <returns>成功，true；失败，false</returns>
        private bool verticalSumAndAvg()
        {
            try
            {
                double sum = 0;
                Dictionary<int, double> dicSum = new Dictionary<int, double>();
                for (int i = 0; i < dGViewExcel.Columns.Count; i++)
                {
                    double temp = 0;
                    if (double.TryParse(dGViewExcel.Rows[0].Cells[i].Value.ToString(), out temp))
                    {
                        for (int j = 0; j < dGViewExcel.Rows.Count - 1; j++)
                        {
                            double.TryParse(dGViewExcel.Rows[j].Cells[i].Value.ToString(), out temp);
                            sum += temp;
                        }
                        dicSum.Add(i, sum);
                    }
                }
                int rowCount = dGViewExcel.Rows.Count - 1;

                int index = dGViewExcel.Rows.Add();
                foreach (KeyValuePair<int, double> kv in dicSum)
                {
                    dGViewExcel.Rows[index].Cells[kv.Key].Value = kv.Value;
                }
                dGViewExcel.Rows[index].Selected = true;
                index = dGViewExcel.Rows.Add();
                foreach (KeyValuePair<int, double> kv in dicSum)
                {
                    dGViewExcel.Rows[index].Cells[kv.Key].Value = kv.Value / rowCount;
                }
                index = dGViewExcel.Rows.Add();
                return true;
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(ex.Message + ex.StackTrace);
                return false;
            }
        }

        //横向求和
        private bool HoriSum(out double sum)
        {
            sum = 0;
            int selectedCellCount = dGViewExcel.GetCellCount(DataGridViewElementStates.Selected);
            try
            {
                if (isSameRow())
                {
                    for (int i = 0; i < selectedCellCount; i++)
                    {
                        sum += double.Parse(dGViewExcel.SelectedCells[i].Value.ToString());
                    }
                    return true;
                }
                else
                {
                    ShowErrorMessageBox("所选行存在问题");
                    return false;
                }
            }
            catch (Exception)
            {
                ShowErrorMessageBox("所选数据有的不是实数数据");
                return false;
            }
        }


        /// <summary>
        /// 判断所选中的单元格是否在同一行，列明不为“和”
        /// </summary>
        /// <returns></returns>
        private bool isSameRow()
        {
            int selectedCellCount = dGViewExcel.GetCellCount(DataGridViewElementStates.Selected);
            int rowNum = dGViewExcel.SelectedCells[0].RowIndex;
            if (dGViewExcel.Columns[(dGViewExcel.SelectedCells[0].ColumnIndex)].Name.Equals("和"))
            {
                ShowErrorMessageBox("您选中的行所对应的列中包含“和”列");
                return false;
            }
            for (int i = 1; i < selectedCellCount; i++)
            {
                int rowIndex = dGViewExcel.SelectedCells[i].RowIndex;
                if (rowIndex != rowNum)
                {
                    ShowErrorMessageBox("您选中的数据不再同一行");
                    return false;
                }
                if (dGViewExcel.Columns[(dGViewExcel.SelectedCells[i].ColumnIndex)].Name.Equals("和"))
                {
                    ShowErrorMessageBox("您选中的行所对应的列中包含“和”列");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 显示错误消息框
        /// </summary>
        /// <param name="str">消息框正文内容</param>
        public void ShowErrorMessageBox(string str)
        {
            MessageBox.Show(str, "错误", MessageBoxButtons.OK
                , MessageBoxIcon.Error);
        }




    }
}
