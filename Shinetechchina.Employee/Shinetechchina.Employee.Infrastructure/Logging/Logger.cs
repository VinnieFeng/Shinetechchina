using log4net;
using System;
using System.Reflection;

namespace Shinetechchina.Employee.Infrastructure.Logging
{
    public interface ILogger
    {
        void Debug(object message);

        void Debug(object message, Exception exception);

        void Error(object message);

        void Error(object message, Exception exception);

        void Fatal(object message);

        void Fatal(object message, Exception exception);

        void Info(object message);

        void Info(object message, Exception exception);

        void Warn(object message);

        void Warn(object message, Exception exception);
    }

    public class Logger : ILogger
    {
        private ILog Log { get; }
        public Logger()
        {
            Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        public Logger(ILog log)
        {
            Log = log;
        }

        public void Debug(object message) => Log.Debug(message);

        public void Debug(object message, Exception exception) => Log.Debug(message, exception);

        public void Error(object message) => Log.Error(message);

        public void Error(object message, Exception exception) => Log.Error(message, exception);

        public void Fatal(object message) => Log.Fatal(message);

        public void Fatal(object message, Exception exception) => Log.Fatal(message, exception);

        public void Info(object message) => Log.Info(message);

        public void Info(object message, Exception exception) => Log.Info(message, exception);

        public void Warn(object message) => Log.Warn(message);

        public void Warn(object message, Exception exception) => Log.Warn(message, exception);
    }
}
