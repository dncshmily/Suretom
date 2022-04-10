using PdfFileWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBClient.ViewModel
{
    public class PdfPageRuntime
    {
        /// <summary>
        /// 页对象
        /// </summary>
        public PdfPage Page { get; set; }
        /// <summary>
        /// 页内容
        /// </summary>
        public PdfContents Contents { get; set; }
        /// <summary>
        /// 页面剩余高度
        /// </summary>
        public double BodyRemainHeight { get; set; }

        /// <summary>
        /// 左右栏
        /// 0=左栏
        /// 1=右栏
        /// </summary>
        public int LeftRight { get; set; } = 0;

        /// <summary>
        /// 原点X值
        /// </summary>
        public double OriginX { get; set; } = 10;

        /// <summary>
        /// 试题开始位置
        /// 页内试题开始位置
        /// 主要是双栏时，右栏顶部开始位置
        /// </summary>
        public double ItemStartTop { get; set; }
        /// <summary>
        /// 页索引
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageNumber { get; set; } = 0;
    }
}
