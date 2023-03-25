using AngleSharp.Common;
using IronXL;

namespace DotNetTestingFramework.Utils
{
    internal class ExcelReader
    {
        private static WorkBook _workBook = WorkBook.Load(System.IO.Path.GetFullPath(@"..\..\..\Resources\testData.xlsx"));
      

        public Dictionary<string,string> getFullExcelSheet(string workSheetName)
        {
            WorkSheet _workSheet = _workBook.GetWorkSheet(workSheetName);
            Dictionary<string, string> excelSheet = new Dictionary<string, string>();
            foreach (var row in _workSheet.Rows)
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

    }
}
