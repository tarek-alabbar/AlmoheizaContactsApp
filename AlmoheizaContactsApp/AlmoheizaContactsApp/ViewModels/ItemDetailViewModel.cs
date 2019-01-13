using System;

using AlmoheizaContactsApp.Services;

namespace AlmoheizaContactsApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ContactItem Item { get; set; }
        public ItemDetailViewModel(ContactItem item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
