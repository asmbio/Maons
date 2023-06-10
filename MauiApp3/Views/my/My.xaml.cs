
using ASMB.ViewModels;
using Maons.Controls;
namespace Maons.my;

public partial class My : MaonsViewItem
{
	public My()
	{
		InitializeComponent();
	}
    
    public override void Changemenu(string menu)
    {
        //  
        var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
        
        if (avm.list ==null|| avm.list?.Count==0)
        {
            avm.GetList();
        }
        if (avm.Model.Balance == null)
        {
            avm.GetAccount(avm.Model);
        }
        base.Changemenu(menu);
    }
}