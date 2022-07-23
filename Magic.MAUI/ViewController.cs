using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Magic.Mountain.Comm
{
    public class ViewController
    {

        static Dictionary<string, object> Views = new Dictionary<string, object>();

        private static readonly object sysobj = new object();

        public static void Dispase() 
        {
            foreach (var item in Views)
            {
                if (typeof(Window).IsAssignableFrom(item.Value.GetType()))
                {
                    ((Window)item.Value).Closing -= View_Closing;
                    ((Window)item.Value).Close();
                }
            }
        
        }
        public static Window GetInstanceViewCache<T>() where T : System.Windows.Window
        {
            lock (sysobj)
            {
                if (!Views.ContainsKey(typeof(T).ToString()))
                {
                    T tmp = Activator.CreateInstance<T>();
                    tmp.Closing += View_Closing;
                    tmp.Closed += View_Closed;
                    Views.Add(typeof(T).ToString(), tmp);
                }
            }

            return (T)Views[typeof(T).ToString()];
        }
        public static Window GetInstanceViewCache<T>(params object[] args) where T : Window
        {
            lock (sysobj)
            {
                if (!Views.ContainsKey(typeof(T).ToString()))
                {
                    T tmp = (T)Activator.CreateInstance(typeof(T), args);
                    tmp.Closing += View_Closing;
                    tmp.Closed += View_Closed;
                    Views.Add(typeof(T).ToString(), tmp);
                }
            }


            return (T)Views[typeof(T).ToString()];
        }
        public static Window GetInstanceView<T>() where T : System.Windows.Window
        {
            lock (sysobj)
            {
                if (!Views.ContainsKey(typeof(T).ToString()))
                {
                    T tmp = Activator.CreateInstance<T>();
                    tmp.Closed += View_Closed;
                    Views.Add(typeof(T).ToString(), tmp);
                }
            }


            return (T)Views[typeof(T).ToString()];
        }
        public static Window GetInstanceView<T>(params object[] args) where T : Window
        {
            lock (sysobj)
            {
                if (!Views.ContainsKey(typeof(T).ToString()))
                {
                    T tmp = (T)Activator.CreateInstance(typeof(T), args);
                    tmp.Closed += View_Closed;
                    Views.Add(typeof(T).ToString(), tmp);
                }
            }

            return (T)Views[typeof(T).ToString()];
        }

        private static void View_Closed(object sender, EventArgs e)
        {
            lock (sysobj)
            {
                Views.Remove(sender.GetType().ToString());
            }
        }

        private static void View_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            ((Window)sender).Hide();
        }
        public static T GetInstanceObjectView<T>() where T : UserControl
        {
            lock (sysobj)
            {
                
                if (!Views.ContainsKey(typeof(T).ToString()))
                {
                    T tmp = Activator.CreateInstance<T>();
                    Views.Add(typeof(T).ToString(), tmp);
                }
            }            
            return (T)Views[typeof(T).ToString()];
        }

    }
}
