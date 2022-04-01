using Bluestone.Presentation.Services.Dialog;
using Bluestone.Presentation.Services.Navigation;
using Bluestone.Presentation.Services.Preference;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bluestone.Presentation.ViewModels.Base
{
    public abstract class ViewModelBase : ExtendedBindableObject, IQueryAttributable
    {
        protected readonly IDialogService DialogService;
        protected readonly IShellDialogService ShellDialogService;
        protected readonly IShellNavigationService ShellNavigationService;
        protected readonly IPreferenceService PreferenceService;

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
            ShellDialogService = DependencyService.Get<IShellDialogService>();
            ShellNavigationService = DependencyService.Get<IShellNavigationService>();
            PreferenceService = DependencyService.Get<IPreferenceService>();
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