using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ISNuclear.OpenXML
{
    public static class MyPageSetup
    {
        public static void AddFitToWidth(this PageSetup pageSetup)
        {
            if (pageSetup == null) { return; }
            pageSetup.FitToWidth = 1;
        }

        public static void RemoveFitToHeight(this PageSetup pageSetup)
        {
            if (pageSetup == null) { return; }
            pageSetup.FitToHeight = 0;
        }

        public static void RemoveFitToWidth(this PageSetup pageSetup)
        {
            if (pageSetup == null) { return; }
            pageSetup.FitToWidth = 0;
        }

        public static void RemoveScale(this PageSetup pageSetup)
        {
            if (pageSetup == null) { return; }
            pageSetup.Scale = 0;
        }
    }
}
