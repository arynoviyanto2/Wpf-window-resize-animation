using System;
using Wpf_window_resize_animation.ViewModels;

namespace Wpf_window_resize_animation.Utility
{
    public class NavService : BaseService<NavService>
    {
        private BaseViewModel _loadedViewModel;
        public BaseViewModel LoadedViewModel
        {
            get
            {
                return _loadedViewModel;
            }

            set
            {
                _loadedViewModel = value;
                OnPropertyChanged(nameof(LoadedViewModel));
            }
        }

        public RelayCommand LoadViewModelCommand { get; set; }

        public NavService()
        {
            LoadViewModelCommand = new RelayCommand(LoadViewModelCommandMethod);
        }

        public void LoadViewModelCommandMethod(object parameter)
        {
            string viewModelClassName = $"{Constants.ViewModelNamespace}.{(string)parameter}";
            var test = Activator.CreateInstance(null, viewModelClassName);
            LoadedViewModel = (BaseViewModel)test.Unwrap();
        }


    }
}
