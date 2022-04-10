using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.DataToolsModel
{
    /// <summary>
    /// 学校基础基类DTO
    /// </summary>
    public class SchoolBaseDTO
    {
        /// <summary>
        /// 学校guid
        /// </summary>
        public string SchoolGuid { get; set; } = string.Empty;

        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName { get; set; } = string.Empty;

        /// <summary>
        /// 组织代码
        /// </summary>
        public string SchoolCode { get; set; } = string.Empty;

        /// <summary>
        /// 学校类别
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 学校等级
        /// </summary>
        public string Level { get; set; } = string.Empty;

        /// <summary>
        /// 学段
        /// </summary>
        public string SchoolPeriod { get; set; } = string.Empty;

        /// <summary>
        /// 学段名称
        /// </summary>
        public string SchoolPeriodName { get; set; } = string.Empty;

        /// <summary>
        /// 考区
        /// </summary>
        public string ExamArea { get; set; } = string.Empty;

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; } = 0;

        /// <summary>
        /// 省份编码
        /// </summary>
        public string ProvinceCode { get; set; } = string.Empty;

        /// <summary>
        /// 市编码
        /// </summary>
        public string CityCode { get; set; } = string.Empty;

        /// <summary>
        /// 县区编码
        /// </summary>
        public string CountryCode { get; set; } = string.Empty;

        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; } = string.Empty;

        /// <summary>
        /// logo key
        /// </summary>
        public string Logo { get; set; } = string.Empty;

        /// <summary>
        /// 业务区域
        /// </summary>
        public string FirstRegion { get; set; } = string.Empty;

        /// <summary>
        /// 业务区域
        /// </summary>
        public string SecondRegion { get; set; } = string.Empty;
    }
}