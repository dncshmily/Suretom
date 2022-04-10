using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class StudentInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public StudentInfo()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string No { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string IdCard { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string PassWord { get; set; }=string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ClassName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; } = string.Empty;
    }
}
