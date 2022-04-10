using CTBClient.ViewModel.PdfTypesetting;
using MyOA.URIResource;
using PdfFileWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBClient.ViewModel
{
    public class ProductLayoutData
    {
        #region 尺寸
        /// <summary>
        /// 页宽
        /// </summary>
        public double PageWidth { get; set; }

        /// <summary>
        /// 页高
        /// </summary>
        public double PageHeight { get; set; }

        /// <summary>
        /// 页眉高度
        /// </summary>
        public double PageHeaderHeight { get; set; }

        /// <summary>
        /// 页脚高度
        /// </summary>
        public double PageFooterHeight { get; set; }

        /// <summary>
        /// 宽留白
        /// </summary>
        public double WideMargin { get; set; }
        /// <summary>
        /// 窄留白
        /// </summary>
        public double NarrowMargin { get; set; }
        /// <summary>
        /// 图表区域宽度
        /// </summary>
        public double ChartWidth { get; set; }
        #endregion

        #region 基础数据
        /// <summary>
        /// 学生Guid
        /// </summary>
        public string StudentGuid { get; set; } = string.Empty;

        /// <summary>
        /// 交付科目guid
        /// </summary>
        public string DeliverySubjectGuid { get; set; } = string.Empty;

        /// <summary>
        /// 交付科目guid
        /// </summary>
        public string WorkSheetName { get; set; } = string.Empty;

        /// <summary>
        /// 推题方式 100：按题推题 200：按知识点推题
        /// </summary>
        public int RecommendType { get; set; } = 100;

        /// <summary>
        /// 交付科目生产目录
        /// </summary>
        public string SubjectDirectory { get; set; } = string.Empty;

        /// <summary>
        /// 排版配置
        /// </summary>
        public TypesettingConfigDTO TypesettingConfigDTO { get; set; } = new TypesettingConfigDTO();

        /// <summary>
        /// 封面配置
        /// </summary>
        public CoverImageConfig CoverImageConfig { get; set; }

        /// <summary>
        /// 分析报告总页数
        /// </summary>
        public int ReportPageCount { get; set; }

        /// <summary>
        /// 错题及推荐题总页数
        /// </summary>
        public int ItemPageCount { get; set; }

        /// <summary>
        /// pdf总页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 每张图片的尺寸
        /// </summary>
        public List<CutImage> CutImageList { get; set; } = new List<CutImage>();

        /// <summary>
        /// 考试信息
        /// </summary>
        public ExamView Exam { get; set; } = new ExamView();

        /// <summary>
        /// 个人报表数据
        /// </summary>
        public PersonalityReportDTO ReportData { get; set; } = new PersonalityReportDTO();

        /// <summary>
        /// 错题数据
        /// </summary>
        public List<KnowledgeItemDTO> ErrorData { get; set; } = new List<KnowledgeItemDTO>();

        /// <summary>
        /// 每个试题排版的元素
        /// </summary>
        public Dictionary<string, List<LayoutSectionData>> LayoutSectionData { get; set; } = new Dictionary<string, List<LayoutSectionData>>();

        /// <summary>
        /// 试题列表
        /// </summary>
        public List<ItemDTO> Items { get; set; } = new List<ItemDTO>();

        /// <summary>
        /// 推荐题
        /// </summary>
        public List<ItemDTO> RecommendItems { get; set; } = new List<ItemDTO>();
        #endregion

        #region 内容宽度
        /// <summary>
        /// 左栏宽度
        /// 左右宽度不同时使用
        /// </summary>
        public double LeftColumnWidth { get; set; }

        /// <summary>
        /// 右栏宽度
        /// 左右宽度不同时使用
        /// </summary>
        public double RightColumnWidth { get; set; }

        #endregion

        #region 获取试题数据结果

        /// <summary>
        /// 获取试题数据是否成功
        /// </summary>
        public bool Status { get; set; } = true;

        /// <summary>
        /// 获取试题数据返回消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 纸张类型
        /// </summary>
        public PdfFileWriter.PaperType paperType { get; set; }
        #endregion

        public ProductLayoutData()
        {
            PageWidth = 210;
            PageHeight = 297;
            PageHeaderHeight = 15;
            PageFooterHeight = 15;

            WideMargin = 15;
            NarrowMargin = 10;
        }

        public ProductLayoutData(PaperType paperType, bool isMarginDifferent = true)
        {
            switch (paperType)
            {
                case PaperType.Letter:
                    break;
                case PaperType.Legal:
                    break;
                case PaperType.A3:
                    PageWidth = 297;
                    PageHeight = 420;
                    ChartWidth = 250;
                    break;
                case PaperType.A4:
                    PageWidth = 210;
                    PageHeight = 297;
                    ChartWidth = 170;
                    break;
                case PaperType.A5:
                    PageWidth = 148;
                    PageHeight = 210;
                    ChartWidth = 108;
                    break;
                case PaperType.B5:
                    PageWidth = 176;
                    PageHeight = 250;
                    ChartWidth = 150;
                    break;
                default:
                    PageWidth = 210;
                    PageHeight = 297;
                    ChartWidth = 170;
                    break;
            }
            PageHeaderHeight = 20;
            PageFooterHeight = 20;
            if (isMarginDifferent)
            {
                WideMargin = 15;
                NarrowMargin = 5;
            }
            else
            {
                WideMargin = 10;
                NarrowMargin = 10;
            }
            this.paperType = paperType;
        }

        /// <summary>
        /// 获取内容区宽度
        /// </summary>
        /// <returns></returns>
        public double GetContentWidth()
        {
            return PageWidth - NarrowMargin - WideMargin;
        }
    }
}
