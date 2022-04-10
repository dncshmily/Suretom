using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.DataPlatformModel.StoneToRockService
{
    public class UpdateEsDataResultInfo
    {
        /// <summary>
        /// 试题Guid
        /// </summary>
        public string ItemGuid { get; set; }

        /// <summary>
        /// 是否更新成功
        /// </summary>
        public bool IsSuccess { get; set; }
    }
}