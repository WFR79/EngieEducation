using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;

namespace ISNuclear.OpenXML
{
    public static class MyBook
    {
        #region "Fields"
        private static Dictionary<uint, UInt32Value> _builtInStyleIndexes = new Dictionary<uint, UInt32Value>();
        private static Dictionary<string, UInt32Value> _differentialFormats = new Dictionary<string, UInt32Value>();
        private static Dictionary<string, UInt32Value> _fills = new Dictionary<string, UInt32Value>();
        private static Dictionary<string, UInt32Value> _styleIndexes = new Dictionary<string, UInt32Value>();
        #endregion 
        public static WorksheetPart CreateWorkSheet(this WorkbookPart book, string name, bool hidden = false)
        {
            var workBookSheets = book.Workbook.Elements<Sheets>();
            var sheet = workBookSheets.Count() > 0 
                ? workBookSheets.ElementAt(0) : book.Workbook.AppendChild(new Sheets());
            var sheets = sheet.Elements<Sheet>();
            var currentSheet = sheets.Count() > 0 ? sheets.FirstOrDefault(s => s.Name == name) : null;
            if (currentSheet != null)
            {
                if (hidden) { currentSheet.State = SheetStateValues.Hidden; }
                var currentPart = book.WorksheetParts
                                      .FirstOrDefault(p => book.GetIdOfPart(p) == currentSheet.Id);
                if (currentPart != null) { return currentPart; }
            }
            var part = book.AddNewPart<WorksheetPart>();
            part.Worksheet = new Worksheet(new SheetData());
            if (currentSheet != null) 
            { 
                currentSheet.Id = book.GetIdOfPart(part); 
            }
            sheet.Append(currentSheet ?? (currentSheet = new Sheet() { Id = book.GetIdOfPart(part), SheetId = new UInt32Value(UInt32.Parse((sheet.Elements<Sheet>().Count() + 1).ToString())), Name = name })); 
            currentSheet.State = hidden ? SheetStateValues.Hidden : SheetStateValues.Visible;
            return part;
        }

        public static string GetSharedStringItemById(this WorkbookPart book, int id)
        {
            var text = book.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
            return text != null ? text.InnerText : "";
        }

        public static Sheet GetSheetByWorkSheet(this WorkbookPart book, WorksheetPart sheet)
        {
            return book.Workbook.Sheets.Elements<Sheet>()
                       .FirstOrDefault(s => s.Id.HasValue && s.Id.Value == book.GetIdOfPart(sheet));
        }

        public static Sheet GetSheetByName(this WorkbookPart book, string name)
        {
            return book.Workbook.Sheets.Elements<Sheet>()
                       .FirstOrDefault(s => s.Name.HasValue && s.Name.Value.ToLower() == name.ToLower());
        }

        public static string GetCellText(this WorkbookPart book, Cell c) => c != null ? c.GetText(book) : string.Empty;

        public static Stylesheet GetStyleSheet (this WorkbookPart book) 
        {
            if (book.WorkbookStylesPart == null || book.WorkbookStylesPart.Stylesheet == null)
            {
                var sp = book.AddNewPart<WorkbookStylesPart>();
                sp.Stylesheet = new Stylesheet
                {
                    Fonts = new Fonts(new Font()
                    {
                        FontSize = new FontSize() { Val = 11 },
                        FontName = new FontName() { Val = "Calibri" },
                        FontFamilyNumbering = new FontFamilyNumbering() { Val = 2 },
                        FontScheme = new FontScheme() { Val = new EnumValue<FontSchemeValues>(FontSchemeValues.Minor) }
                    }),
                    Fills = new Fills(new Fill() { PatternFill = new PatternFill() { PatternType = PatternValues.None } },
                                      new Fill() { PatternFill = new PatternFill() { PatternType = PatternValues.Gray125 } }) { Count = 2 },
                    Borders = new Borders(new Border()
                                            {
                                                LeftBorder = new LeftBorder(),
                                                RightBorder = new RightBorder(),
                                                TopBorder = new TopBorder(),
                                                BottomBorder = new BottomBorder(),
                                                DiagonalBorder = new DiagonalBorder()
                                            }),
                    CellFormats = new CellFormats(new CellFormat
                    {
                        NumberFormatId = 0,
                        FontId = 0,
                        FillId = 0,
                        BorderId = 0,
                        FormatId = 0
                    })
                };
            }

            return book.WorkbookStylesPart.Stylesheet;
        }

        public static UInt32Value GetDoubleStyleIndex(this WorkbookPart book) { return book.GetBuiltInStyleIndex(1); }

        public static UInt32Value GetPercentageStyleIndex(this WorkbookPart book) 
        { return book.GetBuiltInStyleIndex(9); }

        private static UInt32Value GetBuiltInStyleIndex(this WorkbookPart book, UInt32Value numberFormatId)
        {
            try { return _builtInStyleIndexes[numberFormatId.Value]; }
            catch (KeyNotFoundException ex)
            {
                var stylesheet = book.GetStyleSheet();
                var numberingFormats = stylesheet.CellFormats.Elements<CellFormat>().ToList();
                foreach (var numberingFormat in numberingFormats)
                {
                    if (numberingFormat.NumberFormatId.Value == numberFormatId.Value)
                    {
                        return (uint)numberingFormats.IndexOf(numberingFormat);
                    }
                }

                var cellFormat = new CellFormat
                {
                    NumberFormatId = numberFormatId,
                    FontId = 0,
                    FillId = 0,
                    BorderId = 0,
                    FormatId = 0,
                    ApplyNumberFormat = BooleanValue.FromBoolean(true)
                };
                stylesheet.CellFormats.Append(cellFormat);
                stylesheet.CellFormats.Count = (uint)stylesheet.CellFormats.ChildElements.Count;
                var value = (uint)stylesheet.CellFormats.Count() - 1;
                _builtInStyleIndexes.Add(numberFormatId.Value, value);
                return value;
            }
        }

        public static UInt32Value GetStyleIndex(this WorkbookPart book, HexBinaryValue bgColor)
        {
            try { return _styleIndexes[bgColor.Value]; }
            catch (KeyNotFoundException ex)
            {
                var stylesheet = book.GetStyleSheet();
                var fill = stylesheet.GetFill(bgColor);
                var formats = stylesheet.CellFormats.Elements<CellFormat>();
                for (int x = 0; x < formats.Count(); x++)
                {
                    if (formats.ElementAt(x).FillId.Value == fill.Value) 
                    { 
                        return new UInt32Value((uint)x); 
                    }
                }
                var cellFormat = new CellFormat
                {
                    NumberFormatId = 0,
                    FontId = 0,
                    FillId = fill,
                    BorderId = 0,
                    FormatId = 0,
                    ApplyFill = BooleanValue.FromBoolean(true)
                };
                stylesheet.CellFormats.Append(cellFormat);
                stylesheet.CellFormats.Count = UInt32Value.FromUInt32((uint)stylesheet.CellFormats.ChildElements.Count);
                var value = new UInt32Value((uint)stylesheet.CellFormats.Count() - 1);
                _styleIndexes.Add(bgColor.Value, value);
                return value;
            }
        }

        public static UInt32Value GetFill(this Stylesheet stylesheet, HexBinaryValue bgColor)
        {
            try { return _fills[bgColor.Value]; }
            catch (KeyNotFoundException ex)
            {
                var fills = stylesheet.Fills.Elements<Fill>();
                for (int x = 0; x < fills.Count(); x++)
                {
                    var currentFill = fills.ElementAt(x).Elements<PatternFill>().Where(p => p.PatternType == PatternValues.Solid);
                    if (currentFill != null && currentFill.Count() > 0)
                    {
                        var patternFill = currentFill.First();
                        var backgroundColor = patternFill.Elements<ForegroundColor>();
                        for (int y = 0; y < backgroundColor.Count(); y++)
                        {
                            var color = backgroundColor.ElementAt(y);
                            if (color != null && color.Rgb != null && color.Rgb.Value == bgColor.Value) { return (uint)x; }
                        }
                    }
                }

                var fill = new Fill(new PatternFill(new ForegroundColor() { Rgb = bgColor }, new BackgroundColor() { Auto = true }) { PatternType = PatternValues.Solid });
                stylesheet.Fills.Append(fill);
                stylesheet.Fills.Count = UInt32Value.FromUInt32((uint)stylesheet.Fills.ChildElements.Count);
                var value = new UInt32Value((uint)stylesheet.Fills.Count() - 1);
                _fills.Add(bgColor.Value, value);
                return value;
            }
        }

        public static UInt32Value GetIdOfDxf(this WorkbookPart book, string bgColor)
        {
            var stylesheet = book.GetStyleSheet();
            return stylesheet.GetIdOfDxf(bgColor);
        }

        private static UInt32Value GetIdOfDxf(this Stylesheet stylesheet, string bgColor)
        {
            try { return _differentialFormats[bgColor]; }
            catch (KeyNotFoundException ex)
            {
                var dfxs = stylesheet.DifferentialFormats.Elements<DifferentialFormat>();

                for (int x = 0; x < dfxs.Count(); x++)
                {
                    var currentDfx = dfxs.ElementAt(x);
                    if (currentDfx.Elements().Count() == 1 && currentDfx.ElementAt(0) is Fill)
                    {
                        var currentFill = currentDfx.ElementAt(0) as Fill;
                        if (currentFill != null && currentFill.Elements().Count() == 1 && currentFill.PatternFill != null && currentFill.PatternFill.Elements().Count() == 1 && currentFill.PatternFill.BackgroundColor != null
                            && currentFill.PatternFill.BackgroundColor.Rgb != null && currentFill.PatternFill.BackgroundColor.Rgb.Value.ToLower() == bgColor.ToLower())
                        {
                            return (uint)x;
                        }
                    }
                }

                stylesheet.DifferentialFormats.Append(new DifferentialFormat(new Fill() { PatternFill = new PatternFill() { BackgroundColor = new BackgroundColor() { Rgb = new HexBinaryValue(bgColor) } } }));
                stylesheet.DifferentialFormats.Count = UInt32Value.FromUInt32((uint)stylesheet.DifferentialFormats.ChildElements.Count);
                var value = new UInt32Value((uint)stylesheet.DifferentialFormats.Count() - 1);
                _differentialFormats.Add(bgColor, value);
                return value;
            }
        }

        public static void SetPrintArea(this WorkbookPart book, string sheetName, string columnName, uint rows)
        {
            var sheets = book.Workbook.Sheets.Elements<Sheet>();
            int? localSheetId = null;
            for (var x = 0; x < sheets.Count(); x++)
            {
                if (sheets.ElementAt(x).Name.Value.ToLower().Equals(sheetName.ToLower()))
                {
                    localSheetId = x;
                    break;
                }
            }
            if (localSheetId != null)
            {
                var definedName = book.Workbook.DefinedNames.Elements<DefinedName>()
                                      .FirstOrDefault(d => d.Name.Value == "_xlnm.Print_Area" 
                                                           && d.LocalSheetId.Value == (uint)localSheetId.Value) 
                    ?? book.Workbook.DefinedNames
                           .AppendChild(new DefinedName() { Name = "_xlnm.Print_Area", 
                                                            LocalSheetId = (uint)localSheetId.Value });
                if (definedName != null) 
                { 
                    definedName.Text = string.Format("'{0}'!$A$1:${1}${2}", sheetName, columnName, rows); 
                }
            }
        }
    }
}
