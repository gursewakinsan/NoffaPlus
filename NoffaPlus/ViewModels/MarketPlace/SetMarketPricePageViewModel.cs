using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class SetMarketPricePageViewModel : BaseViewModel
    {
        #region Constructor.
        public SetMarketPricePageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
    }
}
