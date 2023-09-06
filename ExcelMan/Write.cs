using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Excel
{
    public class Write
    {
        public void WriteExcelWord(string Word)
        {
            string DefaultPath = "C:\\test\\test.xlsx";

            var Application = new Microsoft.Office.Interop.Excel.Application();
            Application.SheetsInNewWorkbook = 1;
            Microsoft.Office.Interop.Excel.Workbook WorkBook = Application.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet Sheet = (Microsoft.Office.Interop.Excel.Worksheet)Application.Worksheets.Item[1];

            Sheet.Cells[1, 1] = Word;

            WorkBook.SaveAs(DefaultPath);
            WorkBook.Close();
            Application.Quit();
        }
    }
}
