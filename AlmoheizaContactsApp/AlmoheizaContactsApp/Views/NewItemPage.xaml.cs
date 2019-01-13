using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AlmoheizaContactsApp.Services;

namespace AlmoheizaContactsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public ContactItem Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new ContactItem
            {
                Name = "Item name",
                Email = "This is an item email."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}