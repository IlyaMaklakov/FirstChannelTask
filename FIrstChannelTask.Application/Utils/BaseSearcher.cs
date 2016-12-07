using FirstChannelTask.Application.Services;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FirstChannelTask.Application
{
    public abstract class BaseSearcher : LoggerService
    {
       public abstract List<string> SearchByRegex(string fileName, Regex regex);
    }
}
