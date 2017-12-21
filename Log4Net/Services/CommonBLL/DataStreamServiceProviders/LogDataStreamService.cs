using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4Net.CommonBLL
{
    public class LogDataStreamService
        : Framework.Services.DataStreamServiceProviderBase<Log4Net.DataSourceEntities.LogCollection, Log4Net.DataSourceEntities.Log>
    {
        public override void WriteHeaderLineToClosedXmlWorkSheet(ClosedXML.Excel.IXLWorksheet worksheet, int row)
        {
            char cell = 'A';

            string cellKey;
            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = "Id";

            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = "Date";

            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = "Thread";

            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = "Level";

            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = "Logger";

            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = "Message";

            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = "Exception";

        }

        public override void WriteDataItemToClosedXmlWorkSheet(ClosedXML.Excel.IXLWorksheet worksheet, Log4Net.DataSourceEntities.Log dataItem, int row)
        {
            char cell = 'A';

            string cellKey;
            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = dataItem.Id;

            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = dataItem.Date;

            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = dataItem.Thread;

            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = dataItem.Level;

            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = dataItem.Logger;

            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = dataItem.Message;

            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = dataItem.Exception;

        }

        public class KeyInformation
            : Framework.Services.DataStreamServiceProviderBase<Log4Net.DataSourceEntities.Log.KeyInformationCollection, Log4Net.DataSourceEntities.Log.KeyInformation>
        {
            public override void WriteHeaderLineToClosedXmlWorkSheet(ClosedXML.Excel.IXLWorksheet worksheet, int row)
            {
                char cell = 'A';

                string cellKey;
                cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = "Id";

            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = "Thread";

            }

            public override void WriteDataItemToClosedXmlWorkSheet(ClosedXML.Excel.IXLWorksheet worksheet, Log4Net.DataSourceEntities.Log.KeyInformation dataItem, int row)
            {
                char cell = 'A';

                string cellKey;
                cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = dataItem.Id;

            cellKey = Framework.Services.ClosedXmlHelper.GetCellKey(row, cell ++);
            worksheet.Cell(cellKey).Value = dataItem.Thread;

            }
        }

    }
}

