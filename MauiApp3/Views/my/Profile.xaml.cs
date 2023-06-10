
using ASMB.ViewModels;
using Maons.Controls;
using Maons.Views.my;
using MauiApp3;
using System.Drawing;
using System.Runtime.Intrinsics.X86;

namespace Maons.my;

public partial class Profile : MaonsViewItem
{
	public Profile()
    {
		InitializeComponent();
        
    }
    
    public override void Changemenu(string menu)
    {
        //  
        var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
        avm.GetMetaEx(avm.Model);
        
        //if (avm.list ==null|| avm.list?.Count==0)
        //{
        //    avm.GetList();
        //}
        //if (avm.Model.Balance == null)
        //{
        //    avm.GetAccount(avm.Model);
        //}
        base.Changemenu(menu);


    }
    //public string ConvertImageToBase64(FileResult file)
    //{
    //    using (MemoryStream memoryStream = new MemoryStream())
    //    {
    //        file.Save(memoryStream, file.RawFormat);
    //        byte[] imageBytes = memoryStream.ToArray();
    //        return Convert.ToBase64String(imageBytes);
    //    }
    //}
    private async  void ImageButton_Clicked(object sender, EventArgs e)
    {
        
        var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
        if (avm.Model.Address==null || avm.Model.MetaEx==null)
        {
            await App.Current.MainPage.DisplayAlert("刷新后重试", "", "关闭");
            return;
        }
        this.Push(new Avatar(avm.Model));

    }
}