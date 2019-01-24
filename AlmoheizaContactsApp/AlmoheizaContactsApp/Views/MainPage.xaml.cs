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
        string searchKey;
        int serachCategoryIndex;


        public MainPage ()
		{
			InitializeComponent ();
            Picker_DataLoad(categoryPicker);
            categoryPicker.Title = "البحث بــ...";

        }

        private async void Search_Button_Clicked(object sender, EventArgs e)
        {
            searchKey = searchNameEntry.Text;
            ContactItemManager.DefaultManager.SetSerachkey(serachCategoryIndex, searchKey);
            await Navigation.PushModalAsync(new ContactsListViewPage());
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            serachCategoryIndex = categoryPicker.SelectedIndex;
        }

        private void Picker_DataLoad(Picker picker)
        {
            picker.Items.Add("الاسم");
            picker.Items.Add("الوظيفة");
            picker.Items.Add("جهة العمل");
        }
    }
}