using System;
using System.Collections.Generic;
using System.Text;

namespace Suretom.Client.DataToolsModel
{
    public class ExamAreaJsonItem
    {
        public string Code;
        public string Name;
        public string Content;
    }

    public class DictContentListDto
    {
        public string guid { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        public string content { get; set; } = string.Empty;
    }

    public class ResourcePaperDataTypeDto
    {
        public string PaperName { get; set; } = string.Empty;
        public string SubjectGuid { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string GradeGuid { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string GradeCode { get; set; } = string.Empty;
        public string ExamTypeGuid { get; set; } = string.Empty;
        public string ExamType { get; set; } = string.Empty;
        public string ProvinceCode { get; set; } = string.Empty;
        public string ProvinceName { get; set; } = string.Empty;
        public string OwnerSchoolGuid { get; set; } = string.Empty;
        public string ProvideUserGuid { get; set; } = string.Empty;
    }
}