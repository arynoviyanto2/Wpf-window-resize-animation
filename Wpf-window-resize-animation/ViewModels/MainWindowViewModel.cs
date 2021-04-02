using Wpf_window_resize_animation.Utility;

namespace Wpf_window_resize_animation.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public NavService NavService { get; set; } = NavService.Instance;

        public MainWindowViewModel()
        {
            NavService.LoadedViewModel = new PageOneViewModel();
        }
    }
}
