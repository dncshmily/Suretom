using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.DataPlatformModel.TransferItemTraceService
{
    /// <summary>
    /// 试题文件结构：结构化，题干和答案，完整试题
    /// </summary>
    public enum ItemFileStuctEnum
    {
        /// <summary>
        /// 结构化
        /// </summary>
        [Description("结构化")]
        Structure,

        /// <summary>
        /// 题干和答案
        /// </summary>
        [Description("题干和答案")]
        Two,

        /// <summary>
        /// 完整试题
        /// </summary>
        [Description("完整试题")]
        Full,
    }

    /// <summary>
    /// 试题文件类型：Word,大图，Html
    /// </summary>
    public enum ItemFileTypeEnum
    {
        /// <summary>
        /// Word
        /// </summary>
        [Description("Word")]
        Word,

        /// <summary>
        /// 整页图片
        /// </summary>
        [Description("整页图片")]
        PageImg,

        /// <summary>
        /// Html
        /// </summary>
        [Description("Html")]
        Html,
    }

    /// <summary>
    /// 试题文件内容类型：题干，答案
    /// </summary>
    public enum ItemFileContentTypeEnum
    {
        /// <summary>
        /// 题干
        /// </summary>
        [Description("题干")]
        Content,

        /// <summary>
        /// 答案
        /// </summary>
        [Description("答案")]
        Answer,

        /// <summary>
        /// 答案
        /// </summary>
        [Description("解析")]
        Analysis,
    }
}