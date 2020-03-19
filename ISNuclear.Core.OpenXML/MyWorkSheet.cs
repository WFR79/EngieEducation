using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System.Diagnostics;

namespace ISNuclear.OpenXML
{
    public static class MyWorkSheet
    {
        #region "Methods"
        #region "Public"
        public static Cell InsertCell(this Worksheet sheet, WorkbookPart book, string columnName, 
                                      uint rowIndex, string text, 
                                      CellValues dataType = CellValues.SharedString, string formula = null, 
                                      bool isPercentage = false)
        {
            var sheetData = sheet.GetFirstChild<SheetData>();
            var cell = sheetData.InsertCell(book, columnName, rowIndex, text, dataType, formula, isPercentage);
            return cell;
        }

        public static Cell InsertMergeCell(this Worksheet sheet, WorkbookPart book, string startColumnName, 
                                           uint startRowIndex, string end, string text)
        {
            var sheetData = sheet.GetFirstChild<SheetData>();
            return sheet.InsertMergeCell(book, sheetData, startColumnName, startRowIndex, end, text);
        }

        public static Cell InsertMergeCell(this Worksheet sheet, WorkbookPart book, SheetData sheetData, 
                                           string startColumnName, uint startRowIndex, string end, string text, 
                                           log4net.ILog logger = null)
        {
            var sw = new Stopwatch();
            //if (logger != null) { sw.Start(); }
            var cell = sheetData.InsertCell(book, startColumnName, startRowIndex, text, logger: logger, sw: sw);
            //Log(logger, sw);
            var firstMergeCells = GetMergeCells(sheet, sheetData);
            //Log(logger, sw);
            var reference = string.Format("{0}{1}:{2}", startColumnName, startRowIndex, end);
            //Log(logger, sw);
            var mergeCell = firstMergeCells.Elements<MergeCell>()
                                           .FirstOrDefault(m => m.Reference.Value == reference);
            //Log(logger, sw);
            if (mergeCell == null) { firstMergeCells.Append(new MergeCell() { Reference = reference }); }
            //if (logger != null)
            //{
            //    logger.Info(sw.ElapsedMilliseconds);
            //    sw.Stop();
            //}
            return cell;
        }

        private static void Log(log4net.ILog logger, Stopwatch sw)
        {
            if (logger != null)
            {
                logger.Info(sw.ElapsedMilliseconds);
                sw.Restart();
            }
        }
        #endregion

        #region "Private"
        private static MergeCells GetMergeCells(Worksheet sheet, SheetData data)
        {
            return sheet.Elements<MergeCells>().FirstOrDefault() ?? sheet.InsertAfter(new MergeCells(), data);
        }
        #endregion

        public static void FitAllColumnsOnOnePage(this Worksheet sheet, string codeName)
        {
            sheet.SetPageSetUpProperties(codeName);
            var pageSetup = sheet.GetPageSetup();
            if (pageSetup != null)
            {
                pageSetup.RemoveFitToHeight();
                pageSetup.RemoveScale();
                pageSetup.AddFitToWidth();
            }
        }

        public static PageSetup GetPageSetup(this Worksheet sheet)
        {
            var pageSetup = sheet.Elements<PageSetup>();
            return pageSetup == null ? null : pageSetup.FirstOrDefault();
        }

        public static void RemoveFitToWidth(this Worksheet sheet)
        {
            var pageSetup = sheet.Elements<PageSetup>();
            if (pageSetup == null) { return; }
            pageSetup.FirstOrDefault().RemoveFitToWidth();
        }

        public static void RemoveScale(this Worksheet sheet)
        {
            var pageSetup = sheet.Elements<PageSetup>();
            if (pageSetup == null) { return; }
            pageSetup.FirstOrDefault().RemoveScale();
        }

        public static Cell SetCellBackgroundColor(this Worksheet sheet, WorkbookPart book, string columnName, 
                                                  uint startRow, HexBinaryValue color)
        {
            var sheetData = sheet.GetFirstChild<SheetData>();
            var cell = sheetData.SetCellBackgroundColor(book, columnName, startRow, color);
            return cell;
        }

        public static bool SetConditionalFormatting(this Worksheet sheet, WorkbookPart book, string columnName, 
                                                    uint startRow, 
                                                    Func<ConditionalFormatting, bool> isConditionalFormatting, 
                                                    Func<WorkbookPart, uint, ConditionalFormatting> CreateConditionalFormatting)
        {
            var conditionalFormattings = sheet.Elements<ConditionalFormatting>();
            ConditionalFormatting conditionalFormatting = null;
            for (int x = 0; x < conditionalFormattings.Count(); x++)
            {
                var currentConditionalFormatting = conditionalFormattings.ElementAt(x);
                var cfRules = currentConditionalFormatting.Elements<ConditionalFormattingRule>();
                if (isConditionalFormatting(currentConditionalFormatting)) 
                { 
                    conditionalFormatting = currentConditionalFormatting ;
                    break;
                }
            }
            if (conditionalFormatting == null)
            {
                conditionalFormatting = sheet.InsertAfter(CreateConditionalFormatting(book, startRow), conditionalFormattings.Count() > 0 ? (OpenXmlElement)conditionalFormattings.Last() : sheet.Elements<MergeCells>().First());
            }

            var sqref = conditionalFormatting.SequenceOfReferences;
            var cellReference = columnName + startRow;
            if (!sqref.Items.Any(s => s.Value == cellReference)) 
            {
                sqref.Items.Add(cellReference);
            }
            return true;
        }

        public static void SetPageSetUpProperties(this Worksheet sheet, string codeName)
        {
            var sheetPr = sheet.SheetProperties 
                ?? sheet.InsertAt(new SheetProperties(), 0);
            sheetPr.CodeName = codeName;
            sheetPr.SetPageSetUpProperties();
        }
        #endregion
    }
}
