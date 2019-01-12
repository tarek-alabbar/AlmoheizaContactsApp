using System;

using AlmoheizaContactsApp.Models;

namespace AlmoheizaContactsApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Contact Item { get; set; }
        public ItemDetailViewModel(Contact item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
