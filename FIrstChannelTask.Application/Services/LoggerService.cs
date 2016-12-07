using log4net;
using System.Reflection;
namespace FirstChannelTask.Application.Services
{
    public abstract class LoggerService
    {
        private static readonly ILog log;

        static LoggerService()
        {
            log4net.Config.XmlConfigurator.Configure();
            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public ILog Logger
        {
            get
            {
                return log;
            }
        }
    }
}

