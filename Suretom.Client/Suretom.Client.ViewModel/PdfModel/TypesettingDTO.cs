using PdfFileWriter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTBClient.ViewModel
{
    public class TypesettingDTO
    {
        #region 字体
        public PdfFont FangSongNormal { get; set; }
        public PdfFont FangSongBold { get; set; }
        public PdfFont HeiTiNormal { get; set; }
        public PdfFont HeiTiBold { get; set; }
        public PdfFont FangSongItalic { get; set; }
        public PdfFont FangSongBoldItalic { get; set; }
        public PdfFont SongBold { get; set; }
        public PdfFont SongNormal { get; set; }
        #endregion

        public PdfTilingPattern WaterMark { get; set; }
        public double ContentFontSize { get; set; }
        //排版过程中表格分页的页数记录
        public int tablePage { get; set; } = 0;
        /// <summary>
        /// PDF文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// PDF Document
        /// </summary>
        public PdfDocument Document { get; set; }

        /// <summary>
        /// PDF排版过程对象列表
        /// </summary>
        public List<PdfPageRuntime> PdfPageRuntimeList { get; set; }

        /// <summary>
        /// 试题开始位置
        /// </summary>
        public double StartTop { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPageNumber { get; set; }
        /// <summary>
        /// 目录页索引
        /// Created By Tmw 2019.1.4
        /// </summary>
        public int DirIndex { get; set; }
        /// <summary>
        /// 是否左右留白不同
        /// </summary>
        public bool IsMarginDifferent { get; set; }
        /// <summary>
        /// 获取当前PDFContents
        /// </summary>
        /// <returns></returns>
        public PdfPageRuntime GetCurrentPdfPageRuntime()
        {
            return PdfPageRuntimeList.Last();
        }

        /// <summary>
        /// 获取当前PDFContents
        /// </summary>
        /// <returns></returns>
        public PdfContents GetCurrentContents()
        {
            return PdfPageRuntimeList.Last().Contents;
        }

        /// <summary>
        /// 获取当前BodyRemainHeight
        /// </summary>
        /// <returns></returns>
        public double GetCurrentBodyRemainHeight()
        {
            return PdfPageRuntimeList.Last().BodyRemainHeight;
        }

        /// <summary>
        /// 获取当前BodyRemainHeight
        /// </summary>
        /// <returns></returns>
        public void SetCurrentBodyRemainHeight(double value)
        {
            PdfPageRuntimeList.Last().BodyRemainHeight = value;
        }

        /// <summary>
        /// 新试题开始排版时
        /// 双栏排版时，试题超过两页必须
        /// </summary>
        public void ResetFirstPage()
        {
            PdfPageRuntimeList.RemoveRange(0, PdfPageRuntimeList.Count - 1);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fileName"></param>
        public TypesettingDTO(string fileName)
        {
            FileName = fileName;
            // Step 1: Create empty document
            // Arguments: page width: 210”, page height: 297”, Unit of measure: mm
            // Return value: PdfDocument main class
            Document = new PdfDocument(PaperType.A4, false, UnitOfMeasure.mm, fileName);

            CurrentPageNumber = 0;
            PdfPageRuntimeList = new List<PdfPageRuntime>();

            // 字体
            String FontName1 = "仿宋";
            String FontName2 = "黑体";
            String FontName3 = "宋体";
            FangSongNormal = PdfFont.CreatePdfFont(Document, FontName1, FontStyle.Regular, true);
            FangSongBold = PdfFont.CreatePdfFont(Document, FontName1, FontStyle.Bold, true);
            HeiTiNormal = PdfFont.CreatePdfFont(Document, FontName2, FontStyle.Regular, true);
            HeiTiBold = PdfFont.CreatePdfFont(Document, FontName2, FontStyle.Bold, true);
            SongNormal = PdfFont.CreatePdfFont(Document, FontName3, FontStyle.Regular, true);
            SongBold = PdfFont.CreatePdfFont(Document, FontName3, FontStyle.Bold, true);
            FangSongItalic = PdfFont.CreatePdfFont(Document, FontName1, FontStyle.Italic, true);
            FangSongBoldItalic = PdfFont.CreatePdfFont(Document, FontName1, FontStyle.Bold, true);

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pdfStream"></param>
        public TypesettingDTO(System.IO.Stream pdfStream, PaperType paperType, bool isMarginDifferent = true)
        {
            // Step 1: Create empty document
            // Arguments: page width: 210”, page height: 297”, Unit of measure: mm
            // Return value: PdfDocument main class
            Document = new PdfDocument(paperType, false, UnitOfMeasure.mm, pdfStream);
            IsMarginDifferent = isMarginDifferent;
            CurrentPageNumber = 0;
            PdfPageRuntimeList = new List<PdfPageRuntime>();

            // 字体
            String FontName1 = "仿宋";
            String FontName2 = "黑体";
            String FontName3 = "宋体";
            FangSongNormal = PdfFont.CreatePdfFont(Document, FontName1, FontStyle.Regular, true);
            FangSongBold = PdfFont.CreatePdfFont(Document, FontName1, FontStyle.Bold, true);
            HeiTiNormal = PdfFont.CreatePdfFont(Document, FontName2, FontStyle.Regular, true);
            HeiTiBold = PdfFont.CreatePdfFont(Document, FontName2, FontStyle.Bold, true);
            SongNormal = PdfFont.CreatePdfFont(Document, FontName3, FontStyle.Regular, true);
            SongBold = PdfFont.CreatePdfFont(Document, FontName3, FontStyle.Bold, true);
            FangSongItalic = PdfFont.CreatePdfFont(Document, FontName1, FontStyle.Italic, true);
            FangSongBoldItalic = PdfFont.CreatePdfFont(Document, FontName1, FontStyle.Bold, true);
            switch (paperType)
            {
                case PaperType.A4:
                    ContentFontSize = 12.0;
                    break;
                case PaperType.B5:
                    ContentFontSize = 10.0;
                    break;
                default:
                    ContentFontSize = 12.0;
                    break;
            }
        }

        public void NewPage()
        {
            CurrentPageNumber++;
            PdfPageRuntime PageRuntime = new PdfPageRuntime()
            {
                Page = new PdfPage(Document)
            };
            PageRuntime.Contents = new PdfContents(PageRuntime.Page);
            PageRuntime.PageIndex = PdfPageRuntimeList.Count;
            if (CurrentPageNumber % 2 != 0)
            {
                PageRuntime.OriginX = IsMarginDifferent ? 15 : 10;
            }
            else
            {
                PageRuntime.OriginX = IsMarginDifferent ? 5 : 10;
            }
            PdfPageRuntimeList.Add(PageRuntime);
        }

        /// <summary>
        /// 使用右栏
        /// </summary>
        public void UseRightColumn(ProductLayoutData layoutData, double originX)
        {
            var Last = PdfPageRuntimeList.Last();
            Last.LeftRight = 1;
            Last.BodyRemainHeight = layoutData.PageHeight - layoutData.PageHeaderHeight - layoutData.PageFooterHeight;
            Last.BodyRemainHeight = Last.ItemStartTop > 0 ? Last.ItemStartTop : Last.BodyRemainHeight;
            Last.OriginX = originX;
        }
        /// <summary>
        /// 使用右栏
        /// </summary>
        public void UseRightColumnProduct(ProductLayoutData layoutData, double originX)
        {
            var Last = PdfPageRuntimeList.Last();
            Last.LeftRight = 1;
            Last.BodyRemainHeight = layoutData.PageHeight - layoutData.PageHeaderHeight - layoutData.PageFooterHeight;
            Last.BodyRemainHeight = Last.ItemStartTop > 0 ? Last.ItemStartTop : Last.BodyRemainHeight;
            Last.OriginX = originX;
        }
    }
}
