using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.DataPlatformModel.PartTimeJobService
{
    /// <summary>
    /// 兼职审核不通过的批注、或任务异常的备注信息
    /// </summary>
    public class PartTimeProcessRemarkInfo
    {
        public string TasKProcessGuid { get; set; } = string.Empty;
        public string Remark { get; set; } = string.Empty;
        public DateTime OccuredTime { get; set; }
    }
}