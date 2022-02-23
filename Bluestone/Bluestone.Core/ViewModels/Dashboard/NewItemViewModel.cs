using Bluestone.Core.DataServices;
using Bluestone.Core.Models.Dashboard;
using Bluestone.Core.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Core.ViewModels.Dashboard
{
    public class NewItemViewModel : ViewModelBase
    {
        private IDataStore _dataStore;
        private string _text;
        private string _description;

        public NewItemViewModel()
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

        public ICommand SaveCommand => new Command(async () => await OnSave());
        public ICommand CancelCommand => new Command(async () => await OnCancel());

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_text)
                && !String.IsNullOrWhiteSpace(_description);
        }

        private async Task OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async Task OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };

            await _dataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
