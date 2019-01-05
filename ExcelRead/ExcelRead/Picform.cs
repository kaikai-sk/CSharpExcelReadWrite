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
    public partial class Picform : Form
    {
        //picturebox控件属性
        public PictureBox PicBox
        {
            get { return this.pictureBox1; }
            set { this.pictureBox1 = value; }
        }
        //所打开的图像的路径
        public string PicName { set; get; }
        //要天加在图像中的文字
        public string strAddToPic { set; get; }
        private Font _font;
        public Font font
        {
            set
            {
                this._font = value;
            }
            get
            {
                if(_font==null)
                {
                    return new Font("宋体", 20, FontStyle.Italic);
                }
                return _font;
            }
        }
        private Color _color;
        public Color color
        {
            set
            {
                this._color = value;
            }
            get
            {
                if(this._color==null)
                {
                    this._color = Color.Red;
                }
                return _color;
            }
        }

        //旋转角度
        private static int _rotateAngle = 0;



        public Image GetSourceImg(string filename)
        {
            Image img;
            img = Bitmap.FromFile(filename);
            return img;
        }

        public Image RotateImg(string filename, int angle)
        {
            return RotateImg(GetSourceImg(filename), angle);
        }

        /// <summary>  
        /// 以逆时针为方向对图像进行旋转  
        /// </summary>  
        /// <param name="b">位图流</param>  
        /// <param name="angle">旋转角度[0,360](前台给的)</param>  
        /// <returns></returns>  
        public Image RotateImg(Image b, int angle)
        {
            angle = angle % 360;
            //弧度转换  
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //原图的宽和高  
            int w = b.Width;
            int h = b.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));

            //目标位图  
            Bitmap dsImage = new Bitmap(W, H);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage);
            //差补模式为双线性插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            //平滑模式为抗锯齿的呈现
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //计算偏移量  
            Point Offset = new Point((W - w) / 2, (H - h) / 2);
            //构造图像显示区域：让图像的中心与窗口的中心点一致  
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);
            //恢复图像在水平和垂直方向的平移  
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);
            //重至绘图的所有变换  
            g.ResetTransform();
            g.Save();
            g.Dispose();
            //保存旋转后的图片  
            b.Dispose();
            dsImage.Save("FocusPoint.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            return dsImage;
        }

        public Picform()
        {
            InitializeComponent();
        }

        private void Picform_Load(object sender, EventArgs e)
        {
            this.Controls.Add(this.pictureBox1);
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            string myname;
            //设置打开图像的类型
            openFileDialog.Filter = "*.jpg,*.jpeg,*.bmp,*.jif,*.ico,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            openFileDialog.ShowDialog();    //“打开”对话框
            myname = openFileDialog.FileName;
            pictureBox1.Image = Image.FromFile(myname);  //显示打开图像
            this.PicName = myname;
        }

        private void menuEnlarge_Click(object sender, EventArgs e)
        {
            EnLarge(0.2);
        }

        /// <summary>
        /// pciturebox控件放大
        /// </summary>
        /// <param name="rate">放大比例，0-1之间</param>
        private void EnLarge(double rate)
        {
            //当图像的宽度值大于窗体宽度时，就不能再放大了
            if (pictureBox1.Width < this.Width)
            {
                pictureBox1.Width = Convert.ToInt32(pictureBox1.Width * (1 + rate));
                pictureBox1.Height = Convert.ToInt32(pictureBox1.Height * (1 + rate));
            }
            else
            {
                trackBarLarge.Value = 0;
                MessageBox.Show(this, "图像已是最大，不能再放大了！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void menuShrink_Click(object sender, EventArgs e)
        {
            Shrink(0.2);
        }

        private void Shrink(double rate)
        {
            //当图像的宽度值小于0时，就不能再缩小了
            if (pictureBox1.Width > 100)
            {
                pictureBox1.Width = Convert.ToInt32(pictureBox1.Width * Math.Abs(1 - rate));
                pictureBox1.Height = Convert.ToInt32(pictureBox1.Height * Math.Abs(1 - rate));
            }
            else
            {
                trackBarShrink.Value = 0;
                MessageBox.Show(this, "图像已是最小，不能再缩小了！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void trackBarLarge_Scroll(object sender, EventArgs e)
        {
            EnLarge(Math.Abs(trackBarLarge.Value) / 100.0);
        }

        private void trackBarShrink_Scroll(object sender, EventArgs e)
        {
            Shrink(Math.Abs(trackBarShrink.Value) / 100.0);
        }

        private void menuRotate_Click(object sender, EventArgs e)
        {
            if (_rotateAngle < 180)
            {
                _rotateAngle += 10;
                int angle = _rotateAngle;
                this.pictureBox1.Image = RotateImg(PicName, angle);
            }
        }

        /// <summary>
        /// 设置添加到图片上的文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSetStrAddToPic_Click(object sender, EventArgs e)
        {
            DocForm doc = new DocForm();
            if(doc.ShowDialog()==DialogResult.OK)
            {
                this.strAddToPic = doc.TxtSource.Text;
                this.font = doc.font;
                this.color = doc.color;
            }
        }

        /// <summary>
        /// 双击时在图片中添加文字
        /// </summary>
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.pictureBox1.Image.Width < 1)
            {//基本的判断还是要的
                return;
            }
            //要进行处理的图片对象
            Graphics gra = Graphics.FromImage(this.pictureBox1.Image);
            //初始化画笔
            SolidBrush brush = new SolidBrush(Color.Red);
            gra.DrawString(this.strAddToPic,this.font, brush, e.X,
                e.Y);//处理图片
            //对显示图片的容器里面的内容进行刷新，以便及时显示添加的文字
            this.pictureBox1.Refresh();
        }

        /// <summary>
        /// 保存图像文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSavePic_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PnG Image|*.png|Wmf  Image|*.wmf";
            saveFileDialog.FilterIndex = 0;
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("没有预览图片");
            }
            else if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Save(saveFileDialog.FileName, 
                        System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
    }
}
