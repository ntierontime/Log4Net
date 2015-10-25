using System;
using System.Collections.Generic;
using System.Text;
	
namespace Framework.Web
{
    public static class WebFormApplicationUploadFilePathBuilder
    {
        public static string BuildFilePathString(
            string table_Schema,
            string table_Name,
            string column_Name,
            string record_ID,
            string fileName)
        {
            return "~/Brochures/" + fileName;
        }

        public static string BuildFileDirectory(
            string table_Schema,
            string table_Name,
            string column_Name,
            string record_ID,
            string fileName)
        {
            return "~/Brochures/";
        }

        public static bool ValidateFileName(string fileName)
        {
            return true;
        }

        public static bool ValidateFileName(
            string table_Schema,
            string table_Name,
            string column_Name,
            string record_ID,
            string fileName)
        {
            return true;
        }
    }
}