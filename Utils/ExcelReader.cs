using AngleSharp.Common;
using DotNetTestingFramework.Tests.SeleniumTests;
using IronXL;
using System;
using System.Collections.Generic;

namespace DotNetTestingFramework.Utils
{
    internal class ExcelReader
    {
        private static WorkBook workBook = WorkBook.Load(System.IO.Path.GetFullPath(@"..\..\..\Resources\testData.xlsx"));
        private static WorkSheet workSheet = workBook.GetWorkSheet("Input");

        public Dictionary<string,string> getFullExcelSheet()
        {
            Dictionary<string, string> excelSheet = new Dictionary<string, string>();
            foreach (var row in workSheet.Rows)
            {
                if(!row.StringValue.Equals(""))
                {
                    string key = row.Columns.GetItemByIndex(0).ToString();
                    string value = row.Columns.GetItemByIndex(1).ToString();
                    excelSheet.Add(key, value);
                }
            }

            return excelSheet;
        }

        public string getSingleCellValue(string cellName)
        {
            return workSheet[cellName].StringValue;
        }

    }
}
