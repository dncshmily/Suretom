using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.DataPlatformModel.StoneToRockService
{
    /// <summary>
    /// 试卷保存结果
    /// </summary>
    public class PaperSaveResultInfo
    {
        /// <summary>
        /// Rock中试卷Guid
        /// </summary>
        public string PaperGuid { get; set; }

        /// <summary>
        /// Rock中保存的试题
        /// </summary>
        public List<ItemSaveResultInfo> ItemList { get; set; }
    }

    /// <summary>
    /// 试题保存结果
    /// </summary>
    public class ItemSaveResultInfo
    {
        /// <summary>
        /// Rock中试题的Guid
        /// </summary>
        public string ItemGuid { get; set; }

        /// <summary>
        /// 题号
        /// </summary>
        public int ItemNumber { get; set; }
    }
}