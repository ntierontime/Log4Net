using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ClosedXML.Excel;

namespace Framework.Services
{
    public abstract class DataStreamServiceProviderBase<TCollection, TItem> : Framework.IDataStreamServiceProviderBase<TCollection, TItem>
        where TCollection : List<TItem>, new()
        where TItem : class, new()
    {
        #region Write to stream

        public Framework.DataStreamServiceResult BuildResult(TCollection input, Framework.DataServiceTypes dataServiceType)
        {
            if (dataServiceType == Framework.DataServiceTypes.Csv)
            {
                Framework.DataStreamServiceResult result = new Framework.DataStreamServiceResult
                {
                    DataServiceType = dataServiceType,
                    MIMEType = "text/csv",
                    FileExtension = ".csv"
                };
                result.Result = BuildStreamOfLinqToCsv(input);
                return result;
            }
            else if (dataServiceType == Framework.DataServiceTypes.Excel2010)
            {
                Framework.DataStreamServiceResult result = new Framework.DataStreamServiceResult
                {
                    DataServiceType = dataServiceType,
                    MIMEType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    FileExtension = ".xlsx"
                };
                result.Result = BuildStreamOfCloseXmlExcel2010(input);
                return result;
            }
            else
            {
                throw new Exception(string.Format("Service Not Provided: {0}", dataServiceType));
            }
        }

        protected Stream BuildStreamOfLinqToCsv(TCollection input)
        {
            return Framework.Services.LinqToCsvHelper.WriteToStream<TCollection, TItem>(input);
        }

        #region BuildStreamOfCloseXmlExcel2010

        protected Stream BuildStreamOfCloseXmlExcel2010(TCollection input)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Export");

            int startRowIndex = 1;
            WriteHeaderLineToClosedXmlWorkSheet(worksheet, startRowIndex);

            if (input != null)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    WriteDataItemToClosedXmlWorkSheet(worksheet, input[i], i + startRowIndex + 1);
                }
            }

            MemoryStream ms = new MemoryStream();
            workbook.SaveAs(ms);

            ms.Seek(0, SeekOrigin.Begin);

            return ms;
        }

        public abstract void WriteHeaderLineToClosedXmlWorkSheet(IXLWorksheet worksheet, int row);
        public abstract void WriteDataItemToClosedXmlWorkSheet(IXLWorksheet worksheet, TItem dataItem, int row);

        #endregion BuildStreamOfCloseXmlExcel2010

        #endregion Write to stream


        #region Read from stream

        public TCollection GetCollectionFromStream(Framework.DataStreamServiceResult input)
        {
            TCollection collection;
            if (input.DataServiceType == Framework.DataServiceTypes.Csv)
            {
                collection = Framework.Services.LinqToCsvHelper.ReadFromStream<TCollection, TItem>(input.Result);
            }
            else if (input.DataServiceType == Framework.DataServiceTypes.Excel2010)
            {
                collection = Framework.Services.LinqToExcelHelper.Read<TCollection, TItem>(input);
            }
            else
            {
                collection = null;
            }

            return collection;
        }

        #endregion Read from stream
    }
}