using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.DataPlatformModel.CutItemService
{
    /// <summary>
    /// 图片切题后的列表，用于Word切题
    ///
    /// Date: 2019-09-10
    /// Author: 赫刘甲
    /// </summary>
    public class CutResultForWordCutInfo
    {
        /// <summary>
        /// CutResultGuid
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// 资源试卷Guid
        /// </summary>
        public string ResourcePaperGuid { get; set; }

        /// <summary>
        /// 题号
        /// </summary>
        public string ItemNumber { get; set; }

        /// <summary>
        /// 题型Guid
        /// </summary>
        public string ItemTypeGuid { get; set; }

        /// <summary>
        /// 题型名称
        /// </summary>
        public string ItemTypeName { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        public string Subject { get; set; }
    }
}