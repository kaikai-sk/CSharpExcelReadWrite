using System;
using System.Collections;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ImageFlash
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

        //圆形展开
        private void menuCircularDevelopment_Click(object sender, RoutedEventArgs e)
        {
            //创建椭圆图形，但不显示
            EllipseGeometry ellipse = new EllipseGeometry();
            //image的宽、高不要设为自动
            double cx = this.image.Width / 2;
            double cy = this.image.Height / 2;
            //创建中心点,RadiusX和radiusY默认为0，表示是一个圆形
            ellipse.Center = new Point(cx, cy);
            //用ellipse对图片剪裁,开始的剪裁区域是0
            this.image.Clip = ellipse;
            //在指定的时间内使用线性内插对两个目标值之间的double属性值进行动画处理
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;//从中心点
            da.To = Math.Max(cx * 2, cy * 2);
            da.Duration = new Duration(TimeSpan.Parse("0:0:6"));//动画时间
            //将动画应用到指定的依赖属性，该动画在呈现下一帧时使用
            ellipse.BeginAnimation(EllipseGeometry.RadiusXProperty, da);
            ellipse.BeginAnimation(EllipseGeometry.RadiusYProperty, da);
        }

        /// <summary>
        /// 随即方块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private int rs;//正方形边长
        private int x;//图片x方向剪裁数
        private int y;//图片y方向剪裁数
        private int count;//计数变量
        private int total;//剪裁图片的正方形总数
        //定时器
        private DispatcherTimer timer = new DispatcherTimer();
        //可组合由弧、曲线、椭圆、直线和矩形合成的复杂形状。 
        private PathGeometry pg = new PathGeometry(); 
        //正方形图形
        private RectangleGeometry rg = new RectangleGeometry();
        private int[,] xy;//二维数组存正方形的x、y坐标
        private Random rdx = new Random();//产生随机数
        private Hashtable rd = new Hashtable();//哈希表存放对应xy数组的行数，随机数，对应剪裁正方形的（x、y坐标）
        private void menuShuffleBlock_Click(object sender, RoutedEventArgs e)
        {
            ///计算可以裁剪多少个方块
            ///

            //初始化变量值，方块的边长为rs
            rs = 30;
            //计数变量初值=0
            //坐标系：image的左上角为坐标原点，image上边为X轴，正方向向右。image左边为Y轴，正方向向下
            count = 0;
            rd.Clear();
            pg.Clear();
            //取x方向剪裁的整数大者。image的宽、高不要设为自动
            x = (int)Math.Ceiling(this.image.Width / rs);
            //取y方向剪裁的整数大者
            y = (int)Math.Ceiling(this.image.Height / rs);
            total = x * y;//剪裁总数

            //创建小方块数组，并为数组填充值
            xy = new int[total, 2];
            getxy();
            //得到随机数列，存入哈希表rb中
            random();

            ///定时器的相关操作
            //设置时间间隔为10ms
            timer.Interval = TimeSpan.FromMilliseconds(10);
            //定时访问事件为timerTick
            timer.Tick += new EventHandler(timerTick);
            //定时器使能
            timer.IsEnabled = true;
            //启动定时器
            timer.Start();
        }

        /// <summary>
        /// 定时访问事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timerTick(object sender, EventArgs e)
        {
            if (count == total)
            {
                timer.Stop();
                return;
            }
            //定义剪裁正方形位置
            rg.Rect = new Rect(xy[(int)rd[count], 0], xy[(int)rd[count], 1], rs, rs);
            //相加组合几何图形，没有转换。 
            //将正方形小块合并到大的不规则图形pg当中
            pg = Geometry.Combine(pg, rg, GeometryCombineMode.Union, null);
            //裁剪出不规则图形pg
            this.image.Clip = pg;//用组合图形剪裁图片
            count++;
        }

        /// <summary>
        /// 为保存下方块数组填充值（即每个小方块的坐标）
        /// </summary>
        void getxy()
        {
            int h = 0;
            for (int i = 0; i <= y - 1; i++)
            {
                for (int j = 0; j <= x - 1; j++)
                {
                    xy[h, 0] = j * rs;//从左到右取剪裁正方形x、y坐标存数组
                    xy[h, 1] = i * rs;
                    h++;
                }
            }
        }

        /// <summary>
        /// 产生随机数序列，联通关键字编号一同存入哈希表rb
        /// </summary>
        void random()
        {
            //编号从0开始
            int j = 0;
            //产生0-total之间的随机数，对应剪裁正方形x、y坐标
            while (rd.Count < total)
            {
                int rdv = rdx.Next(0, total);
                //如果哈希表中不存在此随机数
                if (!rd.ContainsValue(rdv))
                {
                    //哈希表添加元素，数据元素由关键字（编号）和随机数组成
                    rd.Add(j, rdv);
                    j++;
                }
            }
        }

        //打开图像文件
        private void menuOpen_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\users\\shankai\\";
            ////设置文件滤镜
            openFileDialog.Filter = "图像文件|*.jpg;*.bmp;*.png;*.gif;*.jpeg";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //此处做你想做的事 ...=openFileDialog1.FileName; 
                image.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
            }
        }

        //交错扫描******************************
        private DispatcherTimer timer1 = new DispatcherTimer();//定时器
        private int again;//用于横向扫描计数
        private void menuInterlaceSacn_Click(object sender, RoutedEventArgs e)
        {
            //初始化
            //y=0；开始扫描y坐标，扫描矩形高度rs，again标志初值，count计数
            y = 0;
            rs = 3;
            again = -1;
            count = 0;
            //清空不规则图形
            pg.Clear();
            //上下水平扫描线，矩形的宽度
            x = (int)this.image.Width;
            //纵向扫描线总数
            total = (int)Math.Ceiling(this.image.Height / (rs + 1));

            ///定时器操作
            //时间间隔100ms
            timer1.Interval = TimeSpan.FromMilliseconds(100);
            //交错扫描的定时访问函数
            timer1.Tick += new EventHandler(timer1Tick);
            //启动定时器
            timer1.Start();
        }
        /// <summary>
        /// 交错扫描的定时访问函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer1Tick(object sender, EventArgs e)
        {
            //total==0是做横向扫描的初始化
            if (total == 0)
            {
                total = -1;
                //横向扫描裁剪矩形宽度为x，Y坐标值为y
                x = 5;
                y = 0;
                //横向扫描裁剪矩形高
                rs = (int)this.image.Height;
                //横向清除最大裁剪数（矩形个数）
                again = (int)Math.Ceiling(this.image.Width / x);
            }
            if (again == 0)
            {
                timer1.Stop();
                return;
            }
            //total>0时进行水平扫描，扫描的矩形宽度是x（图片宽度），
            //高度rs(3)，矩形的位置坐标（左上角顶点坐标）x是0始终不变，
            //y不断增加
            if (total > 0)
            {
                //定义剪裁矩形位置
                rg.Rect = new Rect(0, y, x, rs);
                //1是矩形之间的间隔
                y = y + rs + 1;
                total--;
            }
            //纵向扫描
            else
            {
                rg.Rect = new Rect(y, 0, x, rs);
                y = y + x;
                again--;
            }
            //相加组合几何图形，没有转换。 
            pg = Geometry.Combine(pg, rg, GeometryCombineMode.Union, null);
            this.image.Clip = pg;//用组合图形剪裁图片
        }

        //水帘******************************
        private DispatcherTimer timer2 = new DispatcherTimer();//定时器
        private void menuWaterCurtain_Click(object sender, RoutedEventArgs e)
        {
            // 水帘线矩形最大高度不超过图片高度的1/3
            y = (int)this.image.Height / 3;
            //水帘线矩形宽
            x = 2;
            //图形组合清空
            pg.Clear();
            //水帘下降计数变量
            count = 0;
            //同时从左到右，从右到左产生水帘线计数判断值是图片宽度的一半
            rs = (int)this.image.Width / 2;
            total = (int)this.image.Height;
            //水帘线布满之后用again做滚动矩形下降计数
            again = -1;
            //计时器相关
            timer2.Interval = TimeSpan.FromMilliseconds(100);
            timer2.Tick += new EventHandler(timer2Tick);
            timer2.IsEnabled = true;
            timer2.Start();
        }
        /// <summary>
        /// 水帘效果定时访问程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer2Tick(object sender, EventArgs e)
        {
            //如果水帘线下降超过了图片高度
            if (count > total)
            {
                //滚动矩形前的初始化操作
                count = total;
                x = (int)this.image.Width;
                again = 0;
                rs = 10;
            }
            if (again > total)
            {
                timer2.Stop();
                return;
            }
            //水帘操作
            if (count < total)
            {
                //分别从左到右，从右到左生成整排水帘线，4是矩形之间的间隔
                for (int i = 0; i <= rs; i = i + 4)
                {
                    //生成水帘线，从左到右，高度随机
                    rg.Rect = new Rect(i, count, x, rdx.Next(0, y));//定义剪裁矩形位置
                    //组合成水帘
                    pg = Geometry.Combine(pg, rg, GeometryCombineMode.Union, null);//相加组合几何图形，没有转换。
                    //生成水帘线，从右到左，高度随机
                    rg.Rect = new Rect(rs * 2 - i, count, x, rdx.Next(0, y));
                    //组合成水帘
                    pg = Geometry.Combine(pg, rg, GeometryCombineMode.Union, null);
                }
                count = count + y / 3;
            }
            //矩形开始滚动
            else
            {
                //定义剪裁矩形位置
                rg.Rect = new Rect(0, again, x, rs);
                //相加组合几何图形，没有转换。
                pg = Geometry.Combine(pg, rg, GeometryCombineMode.Union, null);
                //没有间隔
                again = again + rs;
            }
            this.image.Clip = pg;//用组合图形剪裁图片
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            //退出当前进程
            Application.Current.Shutdown();
        }
    }
}
