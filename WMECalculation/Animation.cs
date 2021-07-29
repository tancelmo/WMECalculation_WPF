using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WMECalculation
{
    internal class Animation
    {
        public static void AnimateWindowHeight(Window windows, double height, bool isRelative = false)
        {
            //---------------------------------------------------
            //  Settings
            //---------------------------------------------------

            TimeSpan duration = TimeSpan.FromSeconds(0.2);
            double newHeight = isRelative ? windows.Height - height : height;

            _ = windows.Dispatcher.BeginInvoke(new Action(() =>
              {
                  Storyboard storyboard = new Storyboard();


                  //---------------------------------------------------
                  //  Animate Height
                  //---------------------------------------------------
                  DoubleAnimation heightAnimation = new DoubleAnimation()
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

        public static void AnimateGroupBoxHeight(GroupBox windows, double height, bool isRelative = false)
        {
            //---------------------------------------------------
            //  Settings
            //---------------------------------------------------

            TimeSpan duration = TimeSpan.FromSeconds(0.2);
            double newHeight = isRelative ? windows.Height - height : height;

            _ = windows.Dispatcher.BeginInvoke(new Action(() =>
              {
                  Storyboard storyboard = new Storyboard();


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
