using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp3;

namespace ASMB.ViewModels
{
    internal class VMlc
    {
        public static IServiceCollection Services = null;
        public static ServiceProvider ServiceProvider = null;
        public static void Registrar(IServiceCollection serviceDescriptors ) {
            Services = serviceDescriptors;

            Services.AddSingleton<ViewModels.AccountViewModels>();
            //Services.AddSingleton<ViewModels.BlocksViewModels>();
            //Services.AddSingleton<ViewModels.ShellVm>();
            ServiceProvider = Services.BuildServiceProvider();
        }

        public AccountViewModels AccountViewModels
        {
            get
            {
                return ServiceProvider.GetService<AccountViewModels>();
            }
        }

        //public BlocksViewModels BlocksViewModels
        //{
        //    get
        //    {
        //        return ServiceProvider.GetService<BlocksViewModels>();
        //    }
        //}

        //public ShellVm ShellVm
        //{
        //    get
        //    {
        //        return ServiceProvider.GetService<ShellVm>();
        //    }
        //}
    }
}
