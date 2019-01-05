using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SecondClock
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rb1_Click(object sender, RoutedEventArgs e)
        {
            //得到文本域中的数值，并转换成double类型
            double js = double.Parse(this.textBlock.Text);
            if (js < 999.5)
            {
                js = js + 0.1;
            }
            //取整数部分,舍去小数
            int js1 = (int)System.Math.Floor(js);
            //控制显示格式；例如：003.1
            if (js1 < 10)
            {
                this.textBlock.Text = "00" + js.ToString();
                if (js == System.Math.Floor(js))
                {
                    //例如：1.0
                    this.textBlock.Text = this.textBlock.Text + ".0";
                }
                return;
            }
            //控制显示格式：例如：017.1
            if (js1 < 100)
            {
                this.textBlock.Text = "0" + js.ToString();
                if (js == System.Math.Floor(js))
                {
                    //例如：17.0
                    this.textBlock.Text = this.textBlock.Text + ".0";
                }
            }

        }

        private void rb2_Click(object sender, RoutedEventArgs e)
        {
            this.textBlock.Text = "000.0";
        }
    }
}
