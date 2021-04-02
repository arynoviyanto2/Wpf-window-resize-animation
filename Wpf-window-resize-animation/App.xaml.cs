using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wpf_window_resize_animation.ViewModels;

namespace Wpf_window_resize_animation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            (new MainWindow
            {
                DataContext = new MainWindowViewModel()
            }
            ).Show();

            base.OnStartup(e);
        }
    }
}
