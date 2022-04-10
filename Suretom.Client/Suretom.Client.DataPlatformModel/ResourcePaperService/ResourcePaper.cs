using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.DataPlatformModel.ResourcePaperService
{
    /// <summary>
    /// 资源试卷
    ///
    /// Date: 2019-08-20
    /// Author: 赫刘甲
    /// </summary>
    public class ResourcePaper
    {
        /// <summary>
        /// 资源试卷Guid
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// 试卷名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 科目，可能为大科目，如:理科综合
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 年级
        /// </summary>
        public string Grade { get; set; }

        /// <summary>
        /// 试卷来源：100：阅卷系统同步 200：手动上传试卷 300：组卷网试卷 400：第三方导入
        /// </summary>
        public int SourceType { get; set; }

        /// <summary>
        /// Word文件
        /// </summary>
        public List<WordFile> WordFiles { get; set; } = new List<WordFile>();

        /// <summary>
        /// 教学科目列表
        /// </summary>
        public List<string> TeachingSubjectList { get; set; }

        /// <summary>
        /// 所有的题型列表
        /// </summary>
        public List<ItemTypeInfo> AllItemTypeList { get; set; } = new List<ItemTypeInfo>();

        /// <summary>
        /// 资源试题列表， 即试卷结构
        /// </summary>
        public List<ResourceItem> ResouceItemList { get; set; } = new List<ResourceItem>();

        #region 子结构

        /// <summary>
        /// Word信息
        /// </summary>
        public class WordFile
        {
            /// <summary>
            /// Word文件Guid
            /// </summary>
            public string Guid { get; set; }

            /// <summary>
            /// Word文件名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 100:答案 200：题干
            /// </summary>
            public string Category { get; set; }

            /// <summary>
            /// 文件来源: office 上传补传
            /// </summary>
            public string Source { get; set; }

            /// <summary>
            /// 排序字段
            /// </summary>
            public int Sort { get; set; }

            /// <summary>
            /// Word文件地址
            /// </summary>
            public string Url { get; set; }

            /// <summary>
            /// Word文件路径
            /// </summary>
            public string WordPath { get; set; } = string.Empty;

            public string Ext { get; set; } = string.Empty;
        }

        /// <summary>
        /// 题型信息
        /// </summary>
        public class ItemTypeInfo
        {
            /// <summary>
            /// 题型Guid
            /// </summary>
            public string Guid { get; set; } = string.Empty;

            /// <summary>
            /// 题型名称
            /// </summary>
            public string Name { get; set; } = string.Empty;

            /// <summary>
            /// 教学科目
            /// </summary>
            public string Subject { get; set; } = string.Empty;
        }

        /// <summary>
        /// 资源试题
        ///
        /// Date: 2019-09-10
        /// Author: 赫刘甲
        /// </summary>
        public class ResourceItem
        {
            /// <summary>
            ///ResourceItemGuid
            /// </summary>
            public string Guid { get; set; }

            /// <summary>
            /// 题号
            /// </summary>
            public string ItemNumber { get; set; }

            /// <summary>
            /// 阅卷题号
            /// </summary>
            public string OfficeItemNumber { get; set; }

            /// <summary>
            /// 题型Guid
            /// </summary>
            public string ItemTypeGuid { get; set; }

            /// <summary>
            /// 考试类型Guid
            /// </summary>
            public string ExamTypeGuid { get; set; }

            /// <summary>
            /// 题型名称
            /// </summary>
            public string ItemTypeName { get; set; }

            /// <summary>
            /// 科目
            /// </summary>
            public string Subject { get; set; }

            /// <summary>
            /// 是否有Word,true有,false无
            /// </summary>
            public bool IsHaveWord { get; set; } = false;

            /// <summary>
            /// 分值
            /// </summary>
            public float Score { get; set; }
        }

        #endregion
    }
}