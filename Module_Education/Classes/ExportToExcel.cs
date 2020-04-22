using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_Education.Classes
{
    class ExportToExcel
    {
        string fileContent = string.Empty;
        string filePath = string.Empty;
        public string Export(DataGridView dataGridView1)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
       
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
       
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = false;

            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            
            worksheet.Name = "Exported from Module education";
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count ; j++)
                {
                    if(dataGridView1.Rows[i].Cells[j].Value != null)
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            Range aRangeHeaders = worksheet.get_Range("A1", "O100");
            aRangeHeaders.Columns.AutoFit();
            

            string filePath = @"c:\excelTest\" + dataGridView1.Name + DateTime.Now.ToString("_dd-MM-yyyy_hh-mm-ss") + ".xlsx";
            workbook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            app.Quit();
            return filePath;
        }
    }
}
