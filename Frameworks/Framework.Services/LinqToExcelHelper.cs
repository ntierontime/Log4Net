using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Framework.Services
{
    public static class LinqToExcelHelper
    {
        public static TCollection Read<TCollection, TItem>(Framework.DataStreamServiceResult file)
            where TCollection : List<TItem>, new()
            where TItem : class, new()
        {
            string _tempFilePath = Path.Combine(file.TempFilePath, file.FileName);
            (new FileInfo(_tempFilePath)).Directory.Create();

            using (var fileStream = File.Create(_tempFilePath))
            {
                file.Result.CopyTo(fileStream);
            }

            var excelSheet = new LinqToExcel.ExcelQueryFactory(_tempFilePath);

            var result = (from t in excelSheet.Worksheet<TItem>(0)
                   select t).AsEnumerable();
            TCollection collection = new TCollection();
            collection.AddRange(result);

            File.Delete(_tempFilePath);

            return collection;
        }
    }
}