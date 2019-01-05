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
    public partial class DocForm : Form
    {
        //文本编辑框的属性
        public RichTextBox TxtSource
        {
            set { txtSource = value; }
            get { return txtSource; }
        }
        //字体属性
        public Font font { set; get; }
        //字体颜色属性
        public Color color { set; get; }


        public DocForm()
        {
            InitializeComponent();
        }

        private void DocForm_Load(object sender, EventArgs e)
        {

        }

        private void menuSetFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                this.TxtSource.SelectionFont = fontDialog.Font;
                this.font= fontDialog.Font;
            }
        }

        private void menuSetColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.TxtSource.SelectionColor = colorDialog.Color;
                this.color= colorDialog.Color;
            }
        }

        private void DocForm_Leave(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void DocForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
