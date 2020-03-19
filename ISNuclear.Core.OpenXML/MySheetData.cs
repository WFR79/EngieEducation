using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using System.Diagnostics;

namespace ISNuclear.OpenXML
{
    public static class MySheetData
    {
        public static Cell GetCellByReference(this SheetData data, string cell)
        {
            return data.Descendants<Cell>().FirstOrDefault(c => c.CellReference != null 
                                                                && c.CellReference.HasValue 
                                                                && c.CellReference.Value == cell);
        }

        private static void Log(log4net.ILog logger, Stopwatch sw)
        {
            if (logger != null)
            {
                logger.Info(sw.ElapsedMilliseconds);
                sw.Restart();
            }
        }

        public static Cell InsertCell(this SheetData data, WorkbookPart book, string columnName, 
                                      uint rowIndex, string text, 
                                      CellValues dataType = CellValues.SharedString, string formula = null, 
                                      bool isPercentage = false, log4net.ILog logger = null, 
                                      Stopwatch sw = null)
        {
            var currentCell = data.GetCell(rowIndex, columnName);
            //Log(logger, sw);
            var shareStringPart = dataType == CellValues.SharedString ? GetSharedStringTablePart(book) : null;
            //Log(logger, sw);
            var index = dataType == CellValues.SharedString 
                ? shareStringPart.InsertSharedStringItem(text).ToString() : text;
            //Log(logger, sw);
            var x = currentCell.StyleIndex != null 
                ? currentCell.StyleIndex : dataType == CellValues.Number 
                    ? isPercentage ? book.GetPercentageStyleIndex() 
                    : book.GetDoubleStyleIndex() 
                : null;
            //Log(logger, sw);
            currentCell.CellFormula = !string.IsNullOrWhiteSpace(formula) ? new CellFormula(formula) : null;
            //Log(logger, sw);
            currentCell.CellValue = new CellValue(dataType == CellValues.Number ? index.Replace(',', '.') 
                                                                                : index);
            //Log(logger, sw);
            currentCell.DataType = dataType != CellValues.Number ? new EnumValue<CellValues>(dataType) : null;
            //Log(logger, sw);
            currentCell.StyleIndex = x;
            //Log(logger, sw);
            return currentCell;
        }

        private static SharedStringTablePart GetSharedStringTablePart(WorkbookPart book)
        {
            return book.GetPartsOfType<SharedStringTablePart>().FirstOrDefault() 
                ?? book.AddNewPart<SharedStringTablePart>();
        }

        public static Cell GetCell(this SheetData data, uint rowIndex, string columnName)
        {
            var row = data.GetRow(rowIndex);
            var cellReference = columnName + rowIndex;
            var cells = row.Elements<Cell>();
            var refCell = cells.GetRefCell(cellReference);
            return cells.GetCell(cellReference) 
                ?? row.InsertBefore(new Cell() { CellReference = cellReference }, refCell);
        }

        public static Cell SetCellBackgroundColor(this SheetData data, WorkbookPart book, string columnName, 
                                                  uint startRow, HexBinaryValue color)
        {
            var row = data.GetRow(startRow);
            var cellReference = columnName + startRow;
            var cells = row.Elements<Cell>();
            var refCell = cells.GetRefCell(cellReference);
            var currentCell = cells.GetCell(cellReference) ?? row.InsertBefore(new Cell(), refCell);   

            var x = book.GetStyleIndex(color);
            currentCell.CellReference = cellReference;
            currentCell.StyleIndex = x;
            return currentCell;
        }

        private static Row GetRow(this SheetData data, uint startRow)
        {
            return data.Elements<Row>().FirstOrDefault(r => r.RowIndex == startRow) 
                ?? data.AppendChild(new Row() { RowIndex = startRow });
        }

        private static Cell GetCell(this IEnumerable<Cell> cells, string cellReference)
        {
            return cells.FirstOrDefault(c => c.CellReference.Value == cellReference);
        }

        private static Cell GetRefCell(this IEnumerable<Cell> cells, string cellReference)
        {
            var cellReferenceIndex = cellReference.GetColumnIndex();
            foreach (var cell in cells)
            {
                var cellIndex = cell.GetColumnIndex();
                if (cellIndex > cellReferenceIndex) { return cell; }
            }
            return null;
        }
    }
}
