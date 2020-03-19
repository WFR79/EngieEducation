using System;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ss=DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace ISNuclear.OpenXML
{
    public static class MyWorkSheetPart
    {
        public static DrawingsPart GetDrawingsPart(this WorksheetPart sheet)
        {
            if (sheet.DrawingsPart == null) { sheet.AddNewPart<DrawingsPart>(); }
            return sheet.DrawingsPart;
        }

        public static Cell InsertCell(this WorksheetPart part, WorkbookPart book, string columnName, 
                                      uint rowIndex, string text, 
                                      CellValues dataType = CellValues.SharedString, string formula = null, 
                                      bool isPercentage = false)
        {
            var sheet = part.Worksheet;
            return sheet.InsertCell(book, columnName, rowIndex, text, dataType, formula, isPercentage);
        }

        public static void InsertChart<Y>(this WorksheetPart sheet, BaseChart<Y> chart, string columnId, 
                                       string columnOffset, string rowId, string rowOffset, string toColumnId, 
                                       string toColumnOffset, string toRowId, string toRowOffset)
        {
            if (sheet.Worksheet.Elements<Drawing>().Count() <= 0)
            {
                sheet.Worksheet.Append(new Drawing() { Id = sheet.GetIdOfPart(sheet.GetDrawingsPart()) });
                sheet.Worksheet.Save();
            }

            // Position the chart on the worksheet using a TwoCellAnchor object.
            if (sheet.DrawingsPart.WorksheetDrawing == null) 
            { sheet.DrawingsPart.WorksheetDrawing = new ss::WorksheetDrawing(); }
            var twoCellAnchor = sheet.DrawingsPart.WorksheetDrawing.AppendChild(new ss::TwoCellAnchor());
            twoCellAnchor.Append(new ss::FromMarker(new ss::ColumnId(columnId), new ss::ColumnOffset(columnOffset), 
                                                new ss::RowId(rowId), new ss::RowOffset(rowOffset)));
            twoCellAnchor.Append(new ss::ToMarker(new ss::ColumnId(toColumnId), 
                                              new ss::ColumnOffset(toColumnOffset), new ss::RowId(toRowId),
                                              new ss::RowOffset(toRowOffset)));

            // Append a GraphicFrame to the TwoCellAnchor object.
            var graphicFrame = twoCellAnchor.AppendChild(new ss::GraphicFrame());
            graphicFrame.Macro = "";
            graphicFrame.Append(new ss::NonVisualGraphicFrameProperties(
                new ss::NonVisualDrawingProperties() { Id = new UInt32Value(2u), Name = "Chart 1" },
                new ss::NonVisualGraphicFrameDrawingProperties()));

            graphicFrame.Append(new ss::Transform(new Offset() { X = 0L, Y = 0L }, 
                                new Extents() { Cx = 0L, Cy = 0L }));
            graphicFrame.Append(new Graphic(new GraphicData(new ChartReference() { Id = chart.Id }) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }));

            twoCellAnchor.Append(new ss::ClientData());

            // Save the WorksheetDrawing object.
            sheet.DrawingsPart.WorksheetDrawing.Save();
        }

        public static void InsertShape(this WorksheetPart sheet, string columnId, string columnOffset,
                                       string rowId, string rowOffset, string toColumnId,
                                       string toColumnOffset, string toRowId, string toRowOffset)
        {
            
            if (sheet.Worksheet.Elements<Drawing>().Count() <= 0)
            {
                sheet.Worksheet.Append(new Drawing() { Id = sheet.GetIdOfPart(sheet.GetDrawingsPart()) });
                sheet.Worksheet.Save();
            }

            // Position the shape on the worksheet using a TwoCellAnchor object.
            if (sheet.DrawingsPart.WorksheetDrawing == null) { sheet.DrawingsPart.WorksheetDrawing = new ss::WorksheetDrawing(); }

            var twoCellAnchor = sheet.DrawingsPart.WorksheetDrawing.AppendChild(new ss::TwoCellAnchor());
            twoCellAnchor.Append(new OpenXmlElement[] { new ss::FromMarker(new ss::ColumnId(columnId),
                                                                           new ss::ColumnOffset(columnOffset), new ss::RowId(rowId),
                                                                           new ss::RowOffset(rowOffset)),
                                                        new ss::ToMarker(new ss::ColumnId(toColumnId),
                                                                         new ss::ColumnOffset(toColumnOffset), new ss::RowId(toRowId),
                                                                         new ss::RowOffset(toRowOffset)),
                                                        new ss::ConnectionShape(new ss::NonVisualConnectionShapeProperties(new ss::NonVisualDrawingProperties() { Name = "Straight Connector 2", Id = 2U },
                                                                                                                           new ss::NonVisualConnectorShapeDrawingProperties()),
                                                                                new ss::ShapeProperties(new Transform2D(new Offset() { Y = 211282, X = 14096134 }, new Extents() { Cy = 22954576, Cx = 15875 }),
                                                                                                        new PresetGeometry(new AdjustValueList()) { Preset = ShapeTypeValues.Line },
                                                                                                        new DocumentFormat.OpenXml.Drawing.Outline() { Width = 38100 }),
                                                                                new ss::ShapeStyle(new LineReference(new SchemeColor() { Val = SchemeColorValues.Accent1 }) { Index = 1U },
                                                                                                   new FillReference(new SchemeColor() { Val = SchemeColorValues.Accent1 }) { Index = 0U },
                                                                                                   new EffectReference(new SchemeColor() { Val = SchemeColorValues.Accent1 }) { Index = 0U },
                                                                                                   new FontReference(new SchemeColor() { Val = SchemeColorValues.Text1 }) { Index = FontCollectionIndexValues.Minor })) { Macro = "" },
                                                        new ss::ClientData()});

            // Save the WorksheetDrawing object.
            sheet.DrawingsPart.WorksheetDrawing.Save();
        }

        public static Cell InsertMergeCell(this WorksheetPart part, WorkbookPart book, string startColumnName, 
                                           uint startRowIndex, string end, string text)
        {
            var sheet = part.Worksheet;
            return sheet.InsertMergeCell(book, startColumnName, startRowIndex, end, text);
        }

        public static Cell SetCellBackgroundColor(this WorksheetPart part, WorkbookPart book, 
                                                  string columnName, uint startRow, HexBinaryValue color)
        {
            var sheet = part.Worksheet;
            return sheet.SetCellBackgroundColor(book, columnName, startRow, color);
        }

        public static bool SetConditionalFormatting(this WorksheetPart part, WorkbookPart book, 
                                                    string columnName, uint startRow, 
                                                    Func<ConditionalFormatting, bool> IsConditionalFormatting, 
                                                    Func<WorkbookPart, uint, ConditionalFormatting> CreateConditionalFormatting)
        {
            return part.Worksheet.SetConditionalFormatting(book, columnName, startRow, IsConditionalFormatting, 
                                                           CreateConditionalFormatting); 
        }

        public static void SetPageSetUpProperties(this WorksheetPart part, string codeName)
        {
            var sheet = part.Worksheet;
            sheet.SetPageSetUpProperties(codeName);
        }
    }
}
