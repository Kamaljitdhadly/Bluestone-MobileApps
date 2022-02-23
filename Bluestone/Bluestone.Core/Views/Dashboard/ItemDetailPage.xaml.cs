using Bluestone.Core.ViewModels.Dashboard;
using System.ComponentModel;
using Xamarin.Forms;

namespace Bluestone.Core.Views.Dashboard
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}