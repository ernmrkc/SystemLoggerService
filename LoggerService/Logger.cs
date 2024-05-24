using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
    internal class Logger
    {
        private readonly string logFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// Creates a "SystemLogger" directory in the common application data folder if it doesn't exist,
        /// and creates a log file "SysLog.txt" within that directory.
        /// </summary>
        public Logger() {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string appFolderPath = Path.Combine(folderPath, "SystemLogger");
            Directory.CreateDirectory(appFolderPath);

            this.logFilePath = Path.Combine(appFolderPath, "SysLog.txt");
            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath).Close();
            }
        }

        /// <summary>
        /// Logs a message to the log file with additional information including the current date and time,
        /// the computer name, and the username of the current Windows user.
        /// </summary>
        /// <param name="message"> The message to log. </param>
        public void Log(string message)
        {
            try
            {
                string computerName = Environment.MachineName;
                string userName = WindowsIdentity.GetCurrent().Name;
                string logEntry = $"{DateTime.Now}, {computerName}, {userName}, {message}";

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine(logEntry);
                }
            }
            catch (Exception exception)
            {   
                ErrorHandler.HandleError(exception);
            }
        }
    }
}
