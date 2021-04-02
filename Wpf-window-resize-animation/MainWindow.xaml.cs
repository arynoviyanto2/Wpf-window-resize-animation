using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_window_resize_animation.Utility;

namespace Wpf_window_resize_animation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnChildDesiredSizeChanged(UIElement child)
        {
            if (SizeToContent != SizeToContent.Manual)
            {
                var border = child as Border;

                double previousHeight = border.ActualHeight;
                double nextHeight = border.DesiredSize.Height;

                //AnimationHelper.AnimateWindowHeight(this, previousHeight, nextHeight);

                double previousWidth = border.ActualWidth;
                double nextWidth = border.DesiredSize.Width;

                //AnimationHelper.AnimateWindowWidth(this, previousWidth, nextWidth);

                AnimationHelper.AnimateWindowHeightWidth(this, previousHeight, nextHeight, previousWidth, nextWidth);
            }

            base.OnChildDesiredSizeChanged(child);
        }
    }
}
