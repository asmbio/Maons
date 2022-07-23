using GalaSoft.MvvmLight;
using log4net.Appender;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.MAUI
{
    public class UiLogEventArgs : ConcurrentViewModelBase
    {
        private LoggingEvent logEvent { get;  set; }

        public LoggingEvent LogEvent { get { return logEvent; } set { logEvent = value; RaisePropertyChanged(()=>this.LogEvent); } }

        private DateTime date { get; set; }

        public DateTime Date {
            get { return LogEvent.TimeStamp; }
            set { date = value;
                RaisePropertyChanged("Date");
            }
        }

        private string level { get; set; }

        public string Level
        {
            get { return LogEvent.Level.Name; }
            set
            {
                level = value;
                RaisePropertyChanged("Level");
            }
        }
        private string message { get; set; }

        public string Message
        {
            get { return LogEvent.RenderedMessage; }
            set
            {
                message = value;
                RaisePropertyChanged("Message");
            }
        }

        public UiLogEventArgs(LoggingEvent message)
        {
            LogEvent = message;
            Level = message.Level.Name;
        }


        public override string ToString()
        {
            return string.Format("{0}   {1}    {2}", LogEvent.TimeStamp,LogEvent.Level,LogEvent.RenderedMessage);
        }
    }

    public class UiLogAppender : AppenderSkeleton
    {
        public static event EventHandler<UiLogEventArgs> UiLogReceived;

        protected override void Append(LoggingEvent loggingEvent)
        {
            // var message = RenderLoggingEvent(loggingEvent);
            //ConversionPattern
            OnUiLogReceived(new UiLogEventArgs(loggingEvent));


           //$"{loggingEvent.TimeStamp}\t{loggingEvent.Level}\t{loggingEvent.RenderedMessage}")
        }

        protected void OnUiLogReceived(UiLogEventArgs e)
        {
            if (UiLogReceived != null)
                UiLogReceived(this, e);
        }
    }

}
