using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Excel
{
    public class Read
    {
        public string ReadExcelWord(string Word)
        {
            string DefaultPath = "C:\\test\\test.xlsx";

            Microsoft.Office.Interop.Excel.Application ObjWorkExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(DefaultPath);
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell);

            for (int i = 1; i < lastCell.Row; i++)
            {
                if (ObjWorkSheet.Cells[i, 1].ToString() == Word)
                {
                   Word = ObjWorkSheet.Cells[i,1].ToString();
                }
                else
                {
                    Word = "0";
                }
            }

            ObjWorkBook.Close();
            ObjWorkExcel.Quit();

            Stub stub = new Stub();
            return stub.stubText().ToString();
            //return Word;
        }

    }
}
