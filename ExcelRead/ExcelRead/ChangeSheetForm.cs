using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelRead
{
    public partial class ChangeSheetForm : Form
    {
        public ComboBox SheetNum
        {
            set { this.cboSheetNum = value; }
            get { return this.cboSheetNum; }
        }

        public ChangeSheetForm()
        {
            InitializeComponent();
        }

        public ChangeSheetForm(string []a):this()
        {
            this.cboSheetNum.Items.AddRange(a);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
