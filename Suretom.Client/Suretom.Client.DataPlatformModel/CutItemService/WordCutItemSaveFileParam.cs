using Suretom.Client.DataPlatformModel.TransferItemTraceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.DataPlatformModel.CutItemService
{
    /// <summary>
    /// 保存文件参数
    /// </summary>
    public class WordCutItemSaveFileParam
    {
        /// <summary>
        /// 切题Guid
        /// </summary>
        public string CutResultGuid { get; set; } = string.Empty;

        /// <summary>
        /// 试题文件类型，枚举：Word,PageImg,Html
        /// </summary>
        public ItemFileTypeEnum FileType { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 文件内容类型，必须有值，枚举：Content,Answer,Analysis
        /// </summary>
        public ItemFileContentTypeEnum ContentType { get; set; } = ItemFileContentTypeEnum.Content;

        /// <summary>
        /// 图片序号，非必须，当fileType=PageImg时，必须有值，且不能为默认值-1
        /// </summary>
        public int ImageIndex { get; set; } = -1;

        /// <summary>
        /// 是否保存成功
        /// </summary>
        public bool IsSaveSuccess { get; set; } = false;

        /// <summary>
        /// 失败时的消息
        /// </summary>
        public string Messge { get; set; } = string.Empty;
    }
}