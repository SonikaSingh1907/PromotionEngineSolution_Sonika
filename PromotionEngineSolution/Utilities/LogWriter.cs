using System;
using System.IO;
using System.Reflection;

namespace PromotionEngineSolution.Utilities
{
    internal class LogWriter
    {
        private static string message = string.Empty;

        internal static void LogWrite(string logMessage)
        {
                message = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                try
                {
                    using (StreamWriter w = File.AppendText(message + "\\" + Constants.LogFileName))
                    {
                        Log(logMessage, w);
                    }
                }
                catch (Exception)
                {
                }
            }

        private static void Log(object logMessage, StreamWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception)
            {
            }
        }
    }
}