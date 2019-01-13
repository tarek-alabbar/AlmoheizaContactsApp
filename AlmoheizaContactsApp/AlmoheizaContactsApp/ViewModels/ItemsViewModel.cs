using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using AlmoheizaContactsApp.Models;
using AlmoheizaContactsApp.Views;
using AlmoheizaContactsApp.Services;

namespace AlmoheizaContactsApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<ContactItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        ContactItemManager contactItemManager;



        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<ContactItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            /*MessagingCenter.Subscribe<NewItemPage, Contact>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Contac;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });*/
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                //Items.Clear();
                //var items = await DataStore.GetItemsAsync(true);
                var items = await contactItemManager.GetContactItemsAsync(true);
                foreach (var item in items)
                {

                    Items.Add(item);
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}