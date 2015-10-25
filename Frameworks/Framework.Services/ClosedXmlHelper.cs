using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Framework.Services
{
    /// <summary>
    /// http://www.codeproject.com/Articles/25133/LINQ-to-CSV-library
    /// </summary>
    public static class ClosedXmlHelper
	{
        public static string GetCellKey(int row, char cell)
        {
            string cellKey;
            cellKey = string.Format("{0}{1}", cell, row);
            return cellKey;
        }
    }
}