using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using LINQtoCSV;

namespace Framework.Services
{
    /// <summary>
    /// http://www.codeproject.com/Articles/25133/LINQ-to-CSV-library
    /// </summary>
    public static class LinqToCsvHelper
	{
        public static Stream WriteToStream<TCollection, TItem>(TCollection input)
            where TCollection : List<TItem>
            where TItem: class, new()
        {
            CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };

            CsvContext cc = new CsvContext();

            MemoryStream ms = new MemoryStream();
            StreamWriter tw = new StreamWriter(ms);
            cc.Write<TItem>(input, tw);
            tw.Flush();
            ms.Seek(0, SeekOrigin.Begin);

            return ms;
        }

        public static TCollection ReadFromStream<TCollection, TItem>(Stream input)
            where TCollection : List<TItem>, new()
            where TItem: class, new()
        {
            CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };

            CsvContext cc = new CsvContext();

            StreamReader sr = new StreamReader(input);
            var resultFromFile = cc.Read<TItem>(sr).AsEnumerable();

            TCollection collection = new TCollection();
            collection.AddRange(resultFromFile);

            return collection;
        }
    }
}