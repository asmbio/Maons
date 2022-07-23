
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Magic.MAUI
{


    public abstract class ConcurrentViewModelBase:CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public readonly object _lock = new   object();

        //  public static Thread{ get; set; }
        //public  void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        //{

        // //   sModel = value;
        //    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedOrChangingArgs.SModelPropertyChangedEventArgs);
        //    //if (Dispatcher != null && System.Threading.Thread.CurrentThread.ManagedThreadId != Dispatcher.Thread.ManagedThreadId)
        //    //{
        //    //    Dispatcher.Invoke(() =>
        //    //    {
        //    //        base.RaisePropertyChanged(propertyName);
        //    //        //   this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    //    });
        //    //}
        //    //else
        //    //{
        //    //    base.RaisePropertyChanged(propertyName);
        //    //}
        //}

        public void RaisePropertyChanged([CallerMemberName] string name = "") {
           // PropertyChanged?.Invoke(this, e);
            OnPropertyChanged(name);         
        }
    }

  
}
