using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using System.Text.RegularExpressions;

namespace ISNuclear.OpenXML
{
    public static class MyCell
    {
        private static uint[] _builtInDateTimeNumberFormatIDs = new uint[] { 14, 15, 16, 17, 18, 19, 20, 21, 22, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 45, 46, 47, 50, 51, 52, 53, 54, 55, 56, 57, 58 };
        private static Dictionary<uint, NumberingFormat> _builtInDateTimeNumberFormats = _builtInDateTimeNumberFormatIDs.ToDictionary(id => id, id => new NumberingFormat { NumberFormatId = id });
        private static Regex _dateTimeFormatRegex = new Regex(@"((?=([^[]*\[[^[\]]*\])*([^[]*[ymdhs]+[^\]]*))|.*\[(h|mm|ss)\].*)", RegexOptions.Compiled);

        private static Dictionary<uint, NumberingFormat> GetDateTimeCellFormats(WorkbookPart book)
        {
            var dateNumberFormats = book.WorkbookStylesPart.Stylesheet.NumberingFormats
                .Descendants<NumberingFormat>()
                .Where(nf => _dateTimeFormatRegex.Match(nf.FormatCode.Value).Success)
                .ToDictionary(nf => nf.NumberFormatId.Value);

            var cellFormats = book.WorkbookStylesPart.Stylesheet.CellFormats.Descendants<CellFormat>();

            var dateCellFormats = new Dictionary<uint, NumberingFormat>();
            uint styleIndex = 0;
            foreach (var cellFormat in cellFormats)
            {
                if (cellFormat.ApplyNumberFormat != null && cellFormat.ApplyNumberFormat.Value)
                {
                    if (dateNumberFormats.TryGetValue(cellFormat.NumberFormatId.Value, out NumberingFormat format))
                    {
                        dateCellFormats.Add(styleIndex, format);
                    }
                    else if (_builtInDateTimeNumberFormats.TryGetValue(cellFormat.NumberFormatId.Value, out NumberingFormat format2))
                    {
                        dateCellFormats.Add(styleIndex, format2);
                    }
                }

                styleIndex++;
            }

            return dateCellFormats;
        }

        private static bool IsDateTimeCell(this Cell cell, WorkbookPart book)
        {
            if (cell.StyleIndex == null) { return false; }
            var dateTimeCellFormats = GetDateTimeCellFormats(book);
            return dateTimeCellFormats.ContainsKey(cell.StyleIndex);
        }

        public static string GetText(this Cell c, WorkbookPart book)
        {
            if (c == null || c.CellValue == null) { return ""; }
            if (c.DataType == null && !string.IsNullOrEmpty(c.CellValue.Text))
            {
                if (IsDateTimeCell(c, book) && double.TryParse(c.CellValue.Text, out double temp2))
                {
                    try { return DateTime.FromOADate(temp2).ToString(); }
                    catch (Exception ex) { }
                }
                return c.CellValue.Text;
            }
            if (c.DataType != null && c.DataType.Value != CellValues.SharedString) { return c.CellValue.Text; }
            int.TryParse(c.CellValue.Text, out int temp);
            var text = book.GetSharedStringItemById(temp);
            return text;
        }

        public static int? GetColumnIndex(this Cell c) => (c == null || string.IsNullOrEmpty(c.CellReference) || !c.CellReference.HasValue) ? (int?)null : c.CellReference.Value.GetColumnIndex();

        public static int GetColumnIndex(this string c)
        {
            string columnReference = Regex.Replace(c.ToUpper(), @"[\d]", string.Empty);

            int columnNumber = -1;
            int mulitplier = 1;

            foreach (char ch in columnReference.ToCharArray().Reverse())
            {
                columnNumber += mulitplier * (ch - 64);
                mulitplier = mulitplier * 26;
            }

            return columnNumber + 1;
        }

        public static string GetColumnName(this uint c)
        {
            var dividend = c;
            string columnName = String.Empty;
            uint modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (dividend - modulo) / 26;
            }

            return columnName;
        }
    }
}
