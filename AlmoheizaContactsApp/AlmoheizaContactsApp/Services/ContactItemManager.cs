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
        IMobileServiceTable<ContactItem> ContactsTable;

        public void SetSerachkey(int category, string key)
        {
            serachCategory = category;
            searchKey = key;

        }

        string searchKey;
        int serachCategory;

       

        const string offlineDbPath = @"localstore.db";

        private ContactItemManager()
        {
            this.client = new MobileServiceClient(Connection.AppURL);
            this.ContactsTable = client.GetTable<ContactItem>();

        }

        public static ContactItemManager DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
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
            get { return ContactsTable is Microsoft.WindowsAzure.MobileServices.Sync.IMobileServiceSyncTable<ContactItem>; }
        }

        public async Task<ObservableCollection<ContactItem>> GetContactItemsAsync(bool syncItem = false)
        {
            try
            {
                if (serachCategory == 0)
                {
                        IEnumerable<ContactItem> items = await ContactsTable.Where(ContactItem => ContactItem.Name == searchKey).ToEnumerableAsync();
                        return new ObservableCollection<ContactItem>(items);
                }
                else if (serachCategory == 1)
                {
                    IEnumerable<ContactItem> items = await ContactsTable.Where(ContactItem => ContactItem.Job == searchKey).ToEnumerableAsync();
                    return new ObservableCollection<ContactItem>(items);
                }

                //IEnumerable<ContactItem> items = await ContactsTable.Where(ContactItem => ContactItem.Name == searchKey).ToEnumerableAsync();
                //return new ObservableCollection<ContactItem>(items);
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
                    await ContactsTable.InsertAsync(item);
                }
                else
                {
                    await ContactsTable.UpdateAsync(item);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Save error: {0}", new[] { e.Message });
            }
        }
    }
}
