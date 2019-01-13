using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AlmoheizaContactsApp.Services;
using AlmoheizaContactsApp.ViewModels;

namespace AlmoheizaContactsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new ContactItem
            {
                Name = "Item 1",
                Email = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}