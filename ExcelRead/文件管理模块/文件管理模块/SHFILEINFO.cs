using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace 文件管理模块
{
    public struct SHFILEINFO
    {
        public IntPtr hIcon;//文件的图标句柄
        public IntPtr iIcon;//图标的系统索引号
        public uint dwAttributes;//文件的属性值
        //MarshalAs属性指示如何在托管代码和非托管代码之间封送数据。
        //ByValTStr 用于在结构中出现的内联定长字符数组
        //应始终使用 MarshalAsAttribute.SizeConst 字段来指示数组的大小。
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;//文件的显示名
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;//文件的类型名
    }


}
