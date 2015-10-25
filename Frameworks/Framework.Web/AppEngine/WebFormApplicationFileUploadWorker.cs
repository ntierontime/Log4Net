using System;
using System.Collections.Generic;
using System.Text;
	
namespace Framework.Web
{
    public class WebFormApplicationFileUploadWorker
    {
        public byte[] UploadMetadataInDatabase(
            System.Web.UI.WebControls.FileUpload fileUploader,
            string tableSchema,
            string tableName,
            string columnName,
            string id)
        {
            byte[] _retval = null;
            if (fileUploader.HasFile)
            {
                // Make sure that a PDF has been uploaded
                if (true == Framework.Web.WebFormApplicationUploadFilePathBuilder.ValidateFileName(
                    tableSchema, tableName, columnName, id,
                    fileUploader.FileName))
                {
                    _retval = fileUploader.FileBytes;
                }
            }
            return _retval;
        }


        public string UploadMetadataInFileSystem(
            System.Web.UI.WebControls.FileUpload fileUploader,
            System.Web.HttpServerUtility Server,
            string tableSchema,
            string tableName,
            string columnName,
            string id)
        {
            string _retval = null;
            if (fileUploader.HasFile)
            {
                // Make sure that a PDF has been uploaded
                if (true == Framework.Web.WebFormApplicationUploadFilePathBuilder.ValidateFileName(
                    tableSchema, tableName, columnName, id,
                    fileUploader.FileName))
                {
                    string fileDirectory = Framework.Web.WebFormApplicationUploadFilePathBuilder.BuildFileDirectory(
                        tableSchema, tableName, columnName, id,
                        fileUploader.FileName);
                    string filePath = fileDirectory + "/" + fileUploader.FileName;
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileUploader.FileName);
                    string fileExtension = System.IO.Path.GetExtension(fileUploader.FileName);
                    int iteration = 1;

                    while (System.IO.File.Exists(Server.MapPath(filePath)))
                    {
                        filePath = string.Concat(fileDirectory, fileNameWithoutExtension, "-", iteration, fileExtension);
                        iteration++;
                    }

                    // Save the file to disk and set the value of the brochurePath parameter
                    fileUploader.SaveAs(Server.MapPath(filePath));
                    _retval = filePath;
                }
            }

            return _retval;
        }
    }
}