using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDemoTest.Log
{
    public class Logging
    {
        public static ILog Logger = LogManager.GetLogger(typeof(Logging));
        /// <summary>
        /// Ghi log Info
        /// </summary>
        /// <param name="message">Nội dung log</param>
        public static void LogInfo(string message)
        {
            Logger.Info(message);
        }

        /// <summary>
        /// Ghi log Info
        /// </summary>
        /// <param name="message">Nội dung log</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogInfo(string message, Exception exception)
        {
            Logger.Info(message, exception);
        }

        /// <summary>
        /// Ghi log Error
        /// </summary>
        /// <param name="message">Nội dung log</param>
        public static void LogError(string message)
        {
            Logger.Error(message);
        }

        /// <summary>
        /// Ghi log Error
        /// </summary>
        /// <param name="message">Nội dung log</param>
        /// <param name="exception">Đối tượng Exception</param>
        public static void LogError(string message, Exception exception)
        {
            Logger.Error(message, exception);
        }
    }
}
