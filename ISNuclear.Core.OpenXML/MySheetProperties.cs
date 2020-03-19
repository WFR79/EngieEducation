using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ISNuclear.OpenXML
{
    public static class MySheetProperties
    {
        public static void SetPageSetUpProperties(this SheetProperties sheetPr)
        {
            var pageSetUpPr = sheetPr.PageSetupProperties
                ?? sheetPr.InsertAt(new PageSetupProperties() { FitToPage = true }, 0);
        }
    }
}
