using Sandbox.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Sandbox.Mobile.Views
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