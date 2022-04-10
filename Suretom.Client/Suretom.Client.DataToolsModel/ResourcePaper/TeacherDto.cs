using System;
using System.Collections.Generic;
using System.Text;

namespace Suretom.Client.DataToolsModel
{
    public class TeacherDto
    {
        /// <summary>
        /// Guid
        /// </summary>
        public string Guid { get; set; } = string.Empty;

        /// <summary>
        /// 学校guid
        /// </summary>
        public string SchoolGuid { get; set; } = string.Empty;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Telephone { get; set; } = string.Empty;
    }
}