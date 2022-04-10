using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBClient.ViewModel
{
    public enum ItemImageType
    {
        /// <summary>
        /// 原题题干图片
        /// </summary>
        OrginContent = 0,
        /// <summary>
        /// 原题参考答案解析
        /// </summary>
        OrginAnswer = 1,
        /// <summary>
        /// 我的作答
        /// </summary>
        MyAnswer = 2,
        /// <summary>
        /// 推荐题题干
        /// </summary>
        RecommendContent = 3,
        /// <summary>
        /// 推荐题参考答案解析
        /// </summary>
        RecommendAnswer = 4
    }
}
