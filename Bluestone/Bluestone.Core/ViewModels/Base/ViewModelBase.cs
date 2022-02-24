using Bluestone.Core.AppLayout.Settings;
using Bluestone.Core.Services.Dialog;
using Bluestone.Core.Services.Navigation;
using Bluestone.Core.Services.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bluestone.Core.ViewModels.Base
{
    public abstract class ViewModelBase : ExtendedBindableObject, IQueryAttributable
    {
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;
        protected readonly ISettingsService SettingsService;

        private bool _isInitialized;

        public bool IsInitialized
        {
            get => _isInitialized;

            set
            {
                _isInitialized = value;
                OnPropertyChanged(nameof(IsInitialized));
            }
        }

        private bool _multipleInitialization;

        public bool MultipleInitialization
        {
            get => _multipleInitialization;

            set
            {
                _multipleInitialization = value;
                OnPropertyChanged(nameof(MultipleInitialization));
            }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;

            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public ViewModelBase()
        {
            DialogService = DependencyService.Get<IDialogService>();
            NavigationService = DependencyService.Get<INavigationService>();
            SettingsService = DependencyService.Get<ISettingsService>();
        }

        public virtual Task InitializeAsync(IDictionary<string, string> query)
        {
            return Task.FromResult(false);
        }

        public async void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (!IsInitialized)
            {
                IsInitialized = true;
                await InitializeAsync(query);
            }
        }
    }
}