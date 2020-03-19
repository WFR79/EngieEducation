using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ISNuclear.OpenXML
{
    public static class MySharedStringTablePart
    {
        public static int InsertSharedStringItem(this SharedStringTablePart part, string text)
        {
            if (part.SharedStringTable == null) { part.SharedStringTable = new SharedStringTable(); }

            int i = 0;
            foreach (var item in part.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text) { return i; }
                i++;
            }

            part.SharedStringTable.AppendChild(new SharedStringItem(new Text(text)));
            return i;
        }
    }
}
