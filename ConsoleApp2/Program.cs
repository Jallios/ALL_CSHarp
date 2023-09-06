using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


Console.WriteLine("Hello, World!");
int x = Convert.ToInt32(Console.ReadLine());

switch (x)
{

    default:
        Console.WriteLine("Лееееее ты так не делай эйжиии");
        break;

    case 1:
        string DefaultPath = "C:\\test\\test.xlsx";

        var Application = new Microsoft.Office.Interop.Excel.Application();
        Application.SheetsInNewWorkbook = 1;
        Microsoft.Office.Interop.Excel.Workbook WorkBook = Application.Workbooks.Add();
        Microsoft.Office.Interop.Excel.Worksheet Sheet = (Microsoft.Office.Interop.Excel.Worksheet)Application.Worksheets.Item[1];

        Console.WriteLine("Введите слово которое хотите записать: ");

        string Word = Console.ReadLine();


        Sheet.Cells[1, 1] = Word;

        WorkBook.SaveAs(DefaultPath);
        WorkBook.Close();
        Application.Quit();
        break;

    case 2:
        string DefaultPath1 = "C:\\test\\test.xlsx";

        Microsoft.Office.Interop.Excel.Application ObjWorkExcel = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(DefaultPath1);
        Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
        var lastCell = ObjWorkSheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell);

        string WordR = " ";

        for (int i = 1; i < lastCell.Row; i++)
        {
            if (ObjWorkSheet.Cells[i, 1].ToString() == WordR)
            {
                Word = ObjWorkSheet.Cells[i, 1].ToString();
            }
            else
            {
                Word = "0";
            }
        }

        Console.WriteLine(WordR);

        ObjWorkBook.Close();
        ObjWorkExcel.Quit();
        break;
}

