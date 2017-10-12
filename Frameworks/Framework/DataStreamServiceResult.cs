using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Framework
{
    public class DataStreamServiceResult
    {

        public DataStreamServiceResult()
        {
        }

        public DataStreamServiceResult(string fileName, string mimeType, int contentLength, Stream input)
        {
            this.FileName = fileName;
            this.FileExtension = System.IO.Path.GetExtension(fileName);
            this.MIMEType = mimeType;
            this.ContentLength = contentLength;
            this.Result = input;

            if (this.FileExtension.ToLower() == ".xlsx" || this.FileExtension.ToLower() == "xlsx")
            {
                this.DataServiceType = Framework.DataServiceTypes.Excel2010;
            }
            else if (this.FileExtension.ToLower() == ".csv" || this.FileExtension.ToLower() == "csv")
            {
                this.DataServiceType = Framework.DataServiceTypes.Csv;
            }
            else
            {
                this.DataServiceType = Framework.DataServiceTypes.Csv;
            }
        }

        public Framework.DataServiceTypes DataServiceType { get; set; }
        public int ContentLength { get; set; }
        public string MIMEType { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string TempFilePath { get; set; }

        public Stream Result { get; set; }
    }
}

