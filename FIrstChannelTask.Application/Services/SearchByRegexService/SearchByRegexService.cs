using FirstChannelTask.Application.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FirstChannelTask.Application.Services.SearchByRegexService
{
    public class SearchByRegexService : BaseService
    {
        public List<string> SearchByRegex(string fileName, string regex)
        {
            var result = new List<string>();
            try
            {
                Logger.Info("Start searching");
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    throw new ArgumentNullException("fileName");
                }

                if(string.IsNullOrWhiteSpace(regex))
                {
                    throw new ArgumentNullException("regex");
                }

                if (!File.Exists(fileName))
                {
                    throw new Exception("File not found");
                }

                var regExpression = new Regex(regex);
                var fileType = GetExtention(fileName);
                if (fileType == FileType.Unknown)
                {
                    throw new Exception("Unknown file type");
                }

                var searcherFactory = new SearcherFactory();
                var searcher = searcherFactory.GetObject(fileType.ToString());
                result = searcher.SearchByRegex(fileName, regExpression);
                Logger.InfoFormat("Searching finished. Found {0} items", result.Count);
            }
            catch(Exception exception)
            {
                Logger.ErrorFormat("Searching failed! Error: {0}", exception.Message);
            }

            return result;
        }

        public FileType GetExtention(string fileName)
        {
            FileType fileType;
            string fileExtension = Path.GetExtension(fileName).ToLower();
            switch (fileExtension)
            {
                case ".xlsx":
                    fileType = FileType.Excel;
                    break;
                case ".txt":
                    fileType = FileType.Txt;
                    break;
                default:
                    fileType = FileType.Unknown;
                    break;
            }

            return fileType;
        }
    }

}

