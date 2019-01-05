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
    public partial class VedioReadForm : Form
    {
        public VedioReadForm()
        {
            InitializeComponent();

            //以无窗口模式呈现视频
            player.windowlessVideo = true;
            //不显示player的控制界面
            player.uiMode = "none";
            //打开媒体文件时自动开始播放
            player.settings.autoStart = true;
            //自动缩放视频
            player.stretchToFit = true;
            //关闭player的快捷菜单
            player.enableContextMenu = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDlg.FileName;
                lstSongs.Items.Add(file);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            //获得播放列表的媒体个数
            int count = lstSongs.Items.Count;
            //随机选择某个媒体箱进行播放
            player.URL = lstSongs.Items[r.Next(0, count)].ToString();
        }

        private void btnCoontinue_Click(object sender, EventArgs e)
        {
            if (player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                //如果当前正在播放，则暂停
                player.Ctlcontrols.pause();
                btnCoontinue.Text = "继续";
            }
            else
            {
                //如果当前是暂停状态，则继续播放
                player.Ctlcontrols.play();
                btnCoontinue.Text = "暂停";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //停止播放
            player.Ctlcontrols.stop();
        }

        private void lstSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //播放从列表中选中的媒体
            player.URL = lstSongs.Text;
        }
    }
}
