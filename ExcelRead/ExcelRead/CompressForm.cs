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
    public partial class CompressForm : Form
    {
        /// <summary>
        /// 两个属性，原地址和目的地址
        /// </summary>
        public string TxtSource
        {
            get { return this.txtSource.Text.Trim(); }
            set { this.txtSource.Text = value; }
        }
        public string TxtDest
        {
            get { return this.txtDest.Text.Trim(); }
            set { this.txtDest.Text = value; }
        }

        public CompressForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnBrowseDest_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                txtSource.Text = openFileDialog.FileName;
                txtDest.Text = openFileDialog.FileName + ".gz";
            }
        }

        private void btnBorwseSource_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDest.Text = saveFileDialog.FileName;
            }
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDest_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
