using FirstChannelTask.Application.Services.SearchByRegexService;
using System;
using System.Linq;

namespace FirstChannelTask
{
    class Program
    {
        /// <summary>
        /// Search regex matching in file
        /// </summary>
        /// <param name="args">
        /// args[0] - path to file
        /// args[1] - regular expression
        /// </param>
        static void Main(string[] args)
        {
            var filePath = string.Empty;
            var regex = string.Empty;
            if (args != null && args.Length == 2)
            {
                filePath = args[0];
                regex = args[1];
            }

            var searcherService = new SearchByRegexService();
            var foundElements = searcherService.SearchByRegex(filePath, regex);
            var exitCode = foundElements.Any() ? 1 : 0;

            Environment.Exit(exitCode);
        }
    }
}
