using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NASMB.TYPES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMB.ViewModels
{
    internal partial class ShellVm: CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        Dictionary<string, string> _data = new Dictionary<string, string>()
        {
            {"最新","htaM6rQvi4ci3bQ5uReAm5XXytv" },
            {"提案","3E4ZuLQW2NAtB8aCvH4CTm2iBVMa" },
            {"DAO","4ZFmgxH4KPVzUtPS16CdoKAEw76Z" },
        };

        public ShellVm()
        {
       
        }
        private RelayCommand<string> fenquCmd;
        public RelayCommand<string> FenquCmd
        {
            get
            {
                return fenquCmd ?? (fenquCmd = new RelayCommand<string>(fenqu));
            }
        }

        public async void fenqu(string name) {

            if (_data.ContainsKey(name))
            {
                await (App.Current.MainPage as Shell). GoToAsync("//zhuye", new Dictionary<string, object>()
                {
                    {  "Vm",new WorksVm(_data[name]) }
                });
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("提示", "功能完善中", "确定");
            }
        }
    }
}
