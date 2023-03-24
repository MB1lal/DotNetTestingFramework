using IronXL;

namespace DotNetTestingFramework.Utils
{
    internal class ExcelWriter
    {
        private static WorkBook workBook = WorkBook.Load(System.IO.Path.GetFullPath(@"..\..\..\Resources\testData.xlsx"));

        public void CreateNewWorkbook(string _workbookName)
        {
            workBook.CreateWorkSheet(_workbookName);
        }

        public void WriteToExcelSheet(List<List<string>> _data, string _sheetName)
        {
            WorkSheet workSheet = workBook.GetWorkSheet(_sheetName);

            for(int row=0; row<_data.Count; row++)
            {
                for(int col=0; col < _data[row].Count; col++)
                {
                    workSheet.SetCellValue(row, col, _data[row][col]);
                }
            }

        }

        public void SaveFile()
        {
            workBook.Save();
        }
    }
}
