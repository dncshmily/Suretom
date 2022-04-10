using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBClient.ViewModel
{
    public class ExamView
    {
        /// <summary>r
        /// 考试名称
        /// </summary>
        public string Name { set; get; } = string.Empty;

        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName { set; get; } = string.Empty;

        /// <summary>
        /// 年级
        /// </summary>
        public string GradeName { set; get; } = string.Empty;

        /// <summary>
        /// 班级
        /// </summary>
        public string ClassName { set; get; } = string.Empty;
        /// <summary>
        /// office站班级
        /// </summary>
        public string ClassCode { set; get; } = string.Empty;

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { set; get; } = string.Empty;

        /// <summary>
        /// 科目名称
        /// </summary>
        public string Subject { set; get; } = string.Empty;

        /// <summary>
        /// 考试时间
        /// </summary>
        public DateTime ExanTime { set; get; } = DateTime.Now;
    }
}

