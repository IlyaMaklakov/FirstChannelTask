using FirstChannelTask.Application.Enums;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FirstChannelTask.Application
{
    public class ExcelSearcher : BaseSearcher
    {
        public override List<string> SearchByRegex(string fileName, Regex regex)
        {
            var results = new List<string>();
            
            using (var excelPackage = new ExcelPackage(new FileInfo(fileName)))
            {
                var worksheet = excelPackage.Workbook.Worksheets.First();
                var cells = worksheet.Cells;
                cells.Reset();

                while (cells.MoveNext())
                {
                    var cellValue = cells.Current.Value.ToString();
                    var matches = regex.Matches(cellValue);
                    foreach (Match match in matches)
                    {
                        results.Add(match.Value);
                        Logger.InfoFormat("Found: {0}", match.Value);
                    }
                }
            }

            return results;
        }

        public override string ToString()
        {
            return FileType.Excel.ToString();
        }
    }
}
