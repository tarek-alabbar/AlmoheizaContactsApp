using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AlmoheizaContactsApp.Services;

namespace AlmoheizaContactsApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
        }

        private async void Search_Button_Clicked(object sender, EventArgs e)
        {
            ContactItemManager.DefaultManager.SetSerachkey("Email", searchNameEntry.Text);
            await Navigation.PushModalAsync(new ContactsListViewPage());
        }
    }
}