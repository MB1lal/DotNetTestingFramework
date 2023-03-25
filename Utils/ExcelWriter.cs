﻿using IronXL;

namespace DotNetTestingFramework.Utils
{
    internal class ExcelWriter
    {
        private static WorkBook _workBook = WorkBook.Load(System.IO.Path.GetFullPath(@"..\..\..\Resources\testData.xlsx"));

        public void CreateNewWorkbook(string workbookName)
        {
            _workBook.CreateWorkSheet(workbookName);
        }

        public void WriteToExcelSheet(List<List<string>> data, string sheetName)
        {
            WorkSheet workSheet = _workBook.GetWorkSheet(sheetName);

            for(int row=0; row<data.Count; row++)
            {
                for(int col=0; col < data[row].Count; col++)
                {
                    workSheet.SetCellValue(row, col, data[row][col]);
                }
            }

        }

        public void SaveFile()
        {
            _workBook.Save();
        }
    }
}
