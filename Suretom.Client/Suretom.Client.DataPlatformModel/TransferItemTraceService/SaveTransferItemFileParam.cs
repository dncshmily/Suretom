using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.DataPlatformModel.TransferItemTraceService
{
    /// <summary>
    /// 保存文件的参数
    /// </summary>
    public class SaveTransferItemFileParam
    {
        /// <summary>
        /// 转录试题记录Guid
        /// </summary>
        public string TransferItemTraceGuid { get; set; }

        /// <summary>
        /// 转录试题记录版本
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 试题文件结构，枚举：Structure,Two,Full
        /// </summary>
        public ItemFileStuctEnum StructType { get; set; }

        /// <summary>
        /// 试题文件类型，枚举：Word,PageImg,Html
        /// </summary>
        public ItemFileTypeEnum FileType { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 转录试题结构Guid, 非必须，当structureType=Structure时，必须有值
        /// </summary>
        public string TransferItemStructureGuid { get; set; } = string.Empty;

        /// <summary>
        /// 文件内容类型，非必须，当structureType=Two时，必须有值，枚举：Content,Answer
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