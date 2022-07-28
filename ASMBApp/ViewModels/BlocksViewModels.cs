using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMBApp.ViewModels
{
    internal partial class BlocksViewModels : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public BlocksViewModels()
        {
            //   blockheight = UInt64.MaxValue;
            //if (slice )
            //{
            slice.SetAddressByte(NASMB.AConst.MinSlice);

            NextSlice();

            // }
        }
        [ObservableProperty]
        public UInt64 blockheight = UInt64.MaxValue;
        [ObservableProperty]
        public int blocksize = 20;

        [ObservableProperty]
        public bool isRefreshing = false;

        [ObservableProperty]
        public NASMB.TYPES.AsmbAddress slice;
        [ObservableProperty]
        public NASMB.TYPES.AsmbAddress[] allslice;

        [ObservableProperty]
        public NASMB.TYPES.SignBlockHeader[] signBlockHeaders;

        private RelayCommand nextSliceCmd;
        public RelayCommand NextSliceCmd
        {
            get
            {
                return nextSliceCmd ?? (nextSliceCmd = new RelayCommand(NextSlice));
            }
        }

        //GetBlocks(ctx context.Context, h uint64, hash, s[]byte, n int) ([]* SignBlockHeader, error)                                               //perm:sign
        public async void NextSlice()
        {
            try
            {
                if (NASMB.AConst.MaxSlice.SequenceEqual(slice.GetAddressbyte()))
                {
                    await App.Current.MainPage.DisplayAlert("提示", "已经是最后一个分片了", "关闭");
                    return;
                }
                var s = NASMB.Fullapi.GetSliceList(slice.GetAddressbyte(), 1);
                if (s.Length <= 0)
                {
                    await App.Current.MainPage.DisplayAlert("提示", "已经是最后一个分片了", "关闭");
                }
                Slice = s[0];
            }
            catch (Exception e)
            {
                Magic.MAUI.LogHelper.DefaultLogger.Error(e);
                await App.Current.MainPage.DisplayAlert("网络错误", e.Message, "关闭");
            }

        }

        private RelayCommand forwardSliceCmd;
        public RelayCommand ForwardSliceCmd
        {
            get
            {
                return forwardSliceCmd ?? (forwardSliceCmd = new RelayCommand(ForwardSlice));
            }
        }

        //GetBlocks(ctx context.Context, h uint64, hash, s[]byte, n int) ([]* SignBlockHeader, error)                                               //perm:sign
        public async void ForwardSlice()
        {


        }
        private RelayCommand getBlocksCmd;
        public RelayCommand GetBlocksCmd
        {
            get
            {
                return getBlocksCmd ?? (getBlocksCmd = new RelayCommand(GetBlocks));
            }
        }

        //GetBlocks(ctx context.Context, h uint64, hash, s[]byte, n int) ([]* SignBlockHeader, error)                                               //perm:sign
        public async void GetBlocks()
        {
            IsRefreshing = true;
            try
            {
                var add = slice.GetAddressbyte();
                var aRpcClient = NASMB.Fullapi.FindSliceApiService(add);
                var ret = await aRpcClient.SendRequestAsync<NASMB.TYPES.SignBlockHeader[]>("GetBlocks", null, blockheight, null, add, blocksize);
                SignBlockHeaders = ret;
            }
            catch (Exception e)
            {
                Magic.MAUI.LogHelper.DefaultLogger.Error(e);
                await App.Current.MainPage.DisplayAlert("网络错误", e.Message, "关闭");
            }
            IsRefreshing = false;
            //  Model.Balance = ret.Balance;
            //  var ss = Model.Balance / 1;
            //Model.Messagebs = ret;
        }


    }
}
