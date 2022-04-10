using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBClient.ViewModel
{
    public class ImageWidth
    {
        /// <summary>
        /// 所有图片最大宽度
        /// </summary>
        public double MaxImgWidth { get; set; } = 0d; 
        /// <summary>
        /// 错题题干图片最大宽度
        /// </summary>
        public double MaxContentImageWidth { get; set; } = 0d;
        /// <summary>
        /// 错题答案图片最大宽度
        /// </summary>
        public double MaxAnswerImageWidth { get; set; } = 0d;
        /// <summary>
        /// 错题我的作答图片最大宽度
        /// </summary>
        public double MaxMyAnswerImageWidth { get; set; } = 0d;
        /// <summary>
        /// 推荐练习题干图片最大宽度
        /// </summary>
        public double MaxPracticeContentWidth { get; set; } = 0d;
        /// <summary>
        /// 推荐联系答案图片最大宽度
        /// </summary>
        public double MaxPracticeAnswerWidth { get; set; } = 0d;

    }
}
