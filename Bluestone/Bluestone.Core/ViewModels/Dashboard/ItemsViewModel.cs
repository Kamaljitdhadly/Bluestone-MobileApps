using Bluestone.Core.DataServices;
using Bluestone.Core.Models.Dashboard;
using Bluestone.Core.ViewModels.Base;
using Bluestone.Core.Views.Dashboard;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Core.ViewModels.Dashboard
{
    public class ItemsViewModel : ViewModelBase
    {
        private IDataStore _dataStore;
        private Item _selectedItem;
        public string Title = "";

        public ObservableCollection<Item> Items { get; }
      
        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            _dataStore = DependencyService.Get<IDataStore>();
        }

        public ICommand LoadItemsCommand => new Command(async () => await ExecuteLoadItemsCommand());
        public ICommand AddItemCommand => new Command((async (item) => await OnAddItem(item)));
        public ICommand ItemTapped => new Command<Item>((item) => OnItemSelected(item));

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _dataStore.GetItemsAsync(true);
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
                OnItemSelected(value);
            }
        }

        private async Task OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}