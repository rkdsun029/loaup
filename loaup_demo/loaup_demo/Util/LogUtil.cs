using log4net;
using System.Reflection;
// ----------------------------------------------------
// fileName : LogUtil.cs
// description : 로깅
// create : 2023-10-13
// update : 
// ----------------------------------------------------
namespace loaup_demo.Util.LogUtil
{
    public class LogUtil
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void test()
        {
            log.Info("test");
        }

        /*public void WriteLog(string level, Exception ex, string message = "")
        {
            Write(level, ex, message);
        }

        private void Write(string level, Exception ex, string message)
        {
            log4net.Core.ILogger logManager = LoggerManager.GetLogger("loaup", "main");

            LoggingEventData eventData = new LoggingEventData();
            eventData.Level = Level.Debug; // level
            eventData.Message = message;

            LoggingEvent loggingEvent = new LoggingEvent(eventData);
            logManager.Log(loggingEvent);
        }*/
    }
}