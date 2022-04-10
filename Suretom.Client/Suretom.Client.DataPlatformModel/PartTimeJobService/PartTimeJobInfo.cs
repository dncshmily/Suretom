using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.DataPlatformModel.PartTimeJobService
{
    /// <summary>
    /// 兼职任务信息
    /// </summary>
    public class PartTimeJobInfo
    {
        /// <summary>
        /// 兼职任务Guid
        /// </summary>
        public string TaskPoolGuid { get; set; } = string.Empty;

        /// <summary>
        /// 资源试卷Guid
        /// </summary>
        public string ResourcePaperGuid { get; set; } = string.Empty;

        /// <summary>
        /// 兼职任务处理Guid
        /// </summary>
        public string TaskProcessGuid { get; set; } = string.Empty;

        /// <summary>
        /// 教学科目
        /// </summary>
        public string TeachSubject { get; set; } = string.Empty;

        /// <summary>
        /// 切割流转方式
        /// </summary>
        public CutFlowType CutFlowType { get; set; } = CutFlowType.图片;
    }

    /// <summary>
    /// 切割流转方式
    /// </summary>
    public enum CutFlowType
    {
        图片 = 100,
        Word = 200
    }

    /// <summary>
    /// 文件错误
    /// </summary>
    public enum CutFileErrorType
    {
        标注错误 = 1,
        结构错误 = 2,
        文件错误 = 3
    }

    /// <summary>
    /// 兼职任务类型
    /// </summary>
    public enum PartTimeTaskType
    {
        /// <summary>
        /// 切割任务
        /// </summary>
        Cut = 100,

        /// <summary>
        /// 标注任务
        /// </summary>
        Mark = 200,

        /// <summary>
        /// 检查任务
        /// </summary>
        Check = 300
    }
}