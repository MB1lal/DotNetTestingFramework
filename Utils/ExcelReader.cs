using AngleSharp.Common;
using IronXL;

namespace DotNetTestingFramework.Utils
{
    internal class ExcelReader
    {
        private static readonly WorkBook _workBook = WorkBook.Load(System.IO.Path.GetFullPath(@"..\..\..\Resources\testData.xlsx"));

        public static Dictionary<string, string> GetFullExcelSheet(string workSheetName)
        {
            WorkSheet _workSheet = _workBook.GetWorkSheet(workSheetName);
            Dictionary<string, string> excelSheet = new();
            foreach (var row in _workSheet.Rows)
            {
                if (!row.StringValue.Equals(""))
                {
                    string key = row.Columns.GetItemByIndex(0).ToString();
                    string value = row.Columns.GetItemByIndex(1).ToString();
                    excelSheet.Add(key, value);
                }
            }

            return excelSheet;
        }

    }
}
