using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Suretom.Client.DataPlatformModel.ResourcePaperService.ResourcePaper;

namespace Suretom.Client.DataPlatformModel.CutItemService
{
    /// <summary>
    /// 用于Word切题
    ///
    /// Date: 2019-09-10
    /// Author: 赫刘甲
    /// </summary>
    public class ResourceItemForWordCutInfo
    {
        /// <summary>
        ///ResourceItemGuid
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

    /// <summary>
    ///
    /// </summary>
    public class CutResourceWordItemInfo
    {
        /// <summary>
        ///Guid
        /// </summary>
        public string ResourcePaperGuid { get; set; }

        /// <summary>
        /// 试卷WordUrl
        /// </summary>
        public string ResourcePaperFileUrl { get; set; }

        /// <summary>
        /// 试题列表
        /// </summary>
        public List<ResourceItem> ResourceItemList { get; set; }
    }
}