using CTBClient.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBClient.ViewModel
{
    public class LayoutSectionData
    {
        /// <summary>
        /// 元素类型
        /// </summary>
        public ElementType ElementType { get; set; }
        /// <summary>
        /// 图片类型
        /// </summary>
        public ItemImageType ImageType { get; set; }
        /// <summary>
        /// 所在文档的部分分类
        /// </summary>
        public LayoutPart LayoutPart { get; set; }
        /// <summary>
        /// Label内容
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 图片Id
        /// </summary>
        public string ImageId { get; set; }
        /// <summary>
        /// 试题索引
        /// </summary>
        public int ItemIndex { get; set; }
        /// <summary>
        /// 问题索引
        /// </summary>
        public int QuestionIndex { get; set; }
        /// <summary>
        /// 图片索引
        /// </summary>
        public int ImageIndex { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string ImageSrc { get; set; }
        /// <summary>
        /// 图片原始宽度
        /// </summary>
        public double ImageNaturalWidth { get; set; }
        /// <summary>
        /// 图片原始高度
        /// </summary>
        public double ImageNaturalHeight { get; set; }
        /// <summary>
        /// 图片宽度
        /// </summary>
        public double ImageWidth { get; set; }
        /// <summary>
        /// 图片高度
        /// </summary>
        public double ImageHeight { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// 分辨率
        /// </summary>
        public double Resolution { get; set; }

        /// <summary>
        /// 0原题，1推荐题
        /// </summary>
        public string ItemType { get; set; }
        /// <summary>
        /// 题目Guid
        /// </summary>
        public string ItemGuid { get; set; }

        public string pdfFont { get; set; } = "HeiTiBold";
        /// <summary>
        /// 字体大小
        /// </summary>
        public double fontSize { get; set; } = 0;
    }
}
