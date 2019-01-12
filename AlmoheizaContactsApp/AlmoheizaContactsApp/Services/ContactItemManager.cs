using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace AlmoheizaContactsApp.Services
{
    public partial class ContactItemManager
    {
        static ContactItemManager defaultInstance = new ContactItemManager();
        MobileServiceClient client;
        IMobileServiceTable<ContactItem> contactsTable;

        const string offlineDbPath = @"localstore.db";

        private ContactItemManager()
        {
            this.client = new MobileServiceClient(Connection.AppURL);
            this.contactsTable = client.GetTable<ContactItem>();

        }

        public static ContactItemManager DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            set
            {
                defaultInstance = value;
            }
        }

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }

        public bool IsOfflineEnabled
        {
            get { return contactsTable is Microsoft.WindowsAzure.MobileServices.Sync.IMobileServiceSyncTable<ContactItem>; }
        }

        public async Task<ObservableCollection<ContactItem>> GetContactItemsAsync(bool syncItem = false)
        {
            try
            {
                IEnumerable<ContactItem> items = await contactsTable.Where(ContactItem => ContactItem.Name == "teadog").ToEnumerableAsync();
                return new ObservableCollection<ContactItem>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine("Invalid sync operation: {0}", new[] { msioe.Message });
            }
            catch (Exception e)
            {
                Debug.WriteLine("Sync error: {0}", new[] { e.Message });
            }
            return null;
        }

        public async Task SaveTaskAsync(ContactItem item)
        {
            try
            {
                if (item.Id == null)
                {
                    await contactsTable.InsertAsync(item);
                }
                else
                {
                    await contactsTable.UpdateAsync(item);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Save error: {0}", new[] { e.Message });
            }
        }
    }
}
