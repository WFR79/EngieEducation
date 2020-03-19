using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ISNuclear.OpenXML
{
    public static class MySpreadSheetDocument
    {
        public static void CreateWorkSheet(this SpreadsheetDocument doc, string name)
        {
            if (doc != null && doc.WorkbookPart != null) { doc.WorkbookPart.CreateWorkSheet(name); }
        }
    }
}
