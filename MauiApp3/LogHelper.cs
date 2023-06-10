using log4net;
using System;
using System.IO;

namespace Magic.MAUI
{
    class LogHelper
    {
        public static readonly ILog DefaultLogger;


        static LogHelper()
        {
            try
            {
                DefaultLogger = LogManager.Exists("MagicwpfDriver_Log4net", "DefaultLogger");
            }
            catch (Exception)
            {
                if (DefaultLogger == null)
                {
                    var sPath = "Log4net.xml";
                    if (!Path.IsPathRooted(sPath))
                    {
                        sPath = AppDomain.CurrentDomain.BaseDirectory + sPath;
                    }
                    var repository = LogManager.CreateRepository("MagicwpfDriver_Log4net");
                    log4net.Config.XmlConfigurator.Configure(repository, new FileInfo(sPath));
                    DefaultLogger = LogManager.GetLogger(repository.Name, "DefaultLogger");
                }
            }  
           
          
        }
    }
}
