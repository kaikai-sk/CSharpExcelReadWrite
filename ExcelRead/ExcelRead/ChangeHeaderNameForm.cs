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
    public partial class ChangeHeaderNameForm : Form
    {
        //文本框属性
        public TextBox strNewName
        {
            set { this.txtNewName = value; }
            get { return this.txtNewName; }
        }

        public ChangeHeaderNameForm()
        {
            InitializeComponent();
        }

        private void ChangeHeaderNameForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
