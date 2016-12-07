using FirstChannelTask.Application.Enums;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FirstChannelTask.Application
{
    public class TxtSearcher : BaseSearcher
    {
        public override List<string> SearchByRegex(string fileName, Regex regex)
        {
            var results = new List<string>();
            using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {   
                    var matches = regex.Matches(line);
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
            return FileType.Txt.ToString();
        }
    }
}
