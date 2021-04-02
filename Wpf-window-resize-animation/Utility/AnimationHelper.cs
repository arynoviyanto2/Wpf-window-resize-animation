using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Wpf_window_resize_animation.Utility
{
    public static class AnimationHelper
    {
        public static void AnimateWindowHeight(Window window, double previousHeight, double nextHeight)
        {
            window.BeginInit();

            window.SizeToContent = SizeToContent.Manual;

            window.Dispatcher.BeginInvoke(new Action(() =>
            {
                DoubleAnimation heightAnimation = new DoubleAnimation
                {
                    Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                    From = previousHeight,
                    To = nextHeight,
                    FillBehavior = FillBehavior.HoldEnd
                };

                heightAnimation.Completed += ((sender, eArgs) =>
                {
                    window.SizeToContent = SizeToContent.WidthAndHeight;
                });

                window.BeginAnimation(Window.HeightProperty, heightAnimation);


            }), null);
            window.EndInit();
        }

        public static void AnimateWindowWidth(Window window, double previousWidth, double nextWidth, bool wait = false)
        {
            window.BeginInit();

            window.SizeToContent = SizeToContent.Manual;

            window.Dispatcher.BeginInvoke(new Action(() =>
            {
                DoubleAnimation widthAnimation = new DoubleAnimation();
                widthAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.2));
                widthAnimation.From = previousWidth;
                widthAnimation.To = nextWidth;
                widthAnimation.FillBehavior = FillBehavior.HoldEnd;

                widthAnimation.Completed += ((sender, eArgs) =>
                {
                    window.SizeToContent = SizeToContent.WidthAndHeight;
                });

                window.BeginAnimation(Window.WidthProperty, widthAnimation);


            }), null);
            window.EndInit();
        }

        public static void AnimateWindowHeightWidth(Window window, double previousHeight, double nextHeight, double previousWidth, double nextWidth)
        {
            window.BeginInit();

            window.SizeToContent = SizeToContent.Manual;

            window.Dispatcher.BeginInvoke(new Action(() =>
            {
                bool isCompleted = false;
                // Width
                DoubleAnimation widthAnimation = new DoubleAnimation();
                widthAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.3));
                widthAnimation.From = previousWidth;
                widthAnimation.To = nextWidth;
                widthAnimation.FillBehavior = FillBehavior.HoldEnd;

                widthAnimation.Completed += ((sender, eArgs) =>
                {
                    if (isCompleted)
                    {
                        window.SizeToContent = SizeToContent.WidthAndHeight;
                    }
                    else
                    {
                        isCompleted = true;
                    }
                    
                });

                

                // Height
                DoubleAnimation heightAnimation = new DoubleAnimation
                {
                    Duration = new Duration(TimeSpan.FromSeconds(0.3)),
                    From = previousHeight,
                    To = nextHeight,
                    FillBehavior = FillBehavior.HoldEnd
                };

                heightAnimation.Completed += ((sender, eArgs) =>
                {
                    if (isCompleted)
                    {
                        window.SizeToContent = SizeToContent.WidthAndHeight;
                    }
                    else
                    {
                        isCompleted = true;
                        window.BeginAnimation(Window.WidthProperty, widthAnimation);
                    }
                });

                window.BeginAnimation(Window.HeightProperty, heightAnimation);

            }), null);
            window.EndInit();
        }
    }
}
