using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace WMECalculation
{
    class Animation
    {
        public static void AnimateWindowHeight(Window windows, double height, bool isRelative = false)
        {
            //---------------------------------------------------
            //  Settings
            //---------------------------------------------------

            var duration = TimeSpan.FromSeconds(0.2);
            var newHeight = isRelative ? windows.Height - height : height;

            windows.Dispatcher.BeginInvoke(new Action(() =>
            {
                var storyboard = new Storyboard();


                //---------------------------------------------------
                //  Animate Height
                //---------------------------------------------------
                var heightAnimation = new DoubleAnimation()
                {
                    Duration = new Duration(duration),
                    From = windows.ActualHeight,
                    To = newHeight
                };

                Storyboard.SetTarget(heightAnimation, windows);
                Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(Window.HeightProperty));
                storyboard.Children.Add(heightAnimation);

                //---------------------------------------------------
                //  Play
                //---------------------------------------------------
                windows.BeginStoryboard(storyboard, HandoffBehavior.SnapshotAndReplace, false);
            }), null);
        }
    }
}
