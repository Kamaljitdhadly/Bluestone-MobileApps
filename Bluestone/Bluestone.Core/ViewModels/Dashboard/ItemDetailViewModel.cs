using Bluestone.Core.DataServices;
using Bluestone.Core.ViewModels.Base;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Bluestone.Core.ViewModels.Dashboard
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : ViewModelBase
    {
        private string itemId;
        private string _text;
        private string _description;
        private IDataStore _dataStore;
        public string Id { get; set; }

        public ItemDetailViewModel()
        {
            _dataStore = DependencyService.Get<IDataStore>();
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                RaisePropertyChanged(() => Text);
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await _dataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
