using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.DataPlatformModel.CutItemService
{
    /// <summary>
    /// 保存Word切题数据后的返回结果，用于图片上传
    ///
    /// Date: 2019-08-21
    /// Author: 赫刘甲
    /// </summary>
    public class WordCutItemSaveDataResult
    {
        /// <summary>
        /// 资源试卷Guid
        /// </summary>
        public string ResourcePaperGuid { get; set; }

        /// <summary>
        /// 保存后Guid与题目序号的关系列表
        /// </summary>
        public List<GuidRelation> GuidRelationList { get; set; } = new List<GuidRelation>();

        /// <summary>
        /// 保存后Guid与题目序号的关系
        ///
        /// </summary>
        public class GuidRelation
        {
            /// <summary>
            /// CutResultGuid
            /// </summary>
            public string Guid { get; set; }

            /// <summary>
            /// 题号
            /// </summary>
            public int ItemNumber { get; set; }
        }
    }
}