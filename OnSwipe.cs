using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Input;


namespace App1SwipeOnScrollView
{
    public static class OnSwipe
    {
        public static ICommand GetLeftCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(LeftCommandProperty);
        }

        public static void SetLeftCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(LeftCommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for LeftCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeftCommandProperty =
            DependencyProperty.RegisterAttached("LeftCommand", typeof(ICommand), typeof(OnSwipe), new PropertyMetadata(null, OnLeftCommandPropertyChanged));


        private static void OnLeftCommandPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is FrameworkElement frameworkElement)
            {
                //if(frameworkElement is ScrollViewer scrollViewer)
                //{
                //    var result = scrollViewer.CancelDirectManipulations();
                //    if(scrollViewer.Content is FrameworkElement scrollViewerframework)
                //    {
                //        frameworkElement = scrollViewerframework;
                //    }
                //}
                // New translation transform populated in 
                // the ManipulationDelta handler.
                //GestureRecognizer gestureRecognizer = new GestureRecognizer();
                //ManipulationInputProcessor manipulationInputProcessor = 
                //    new ManipulationInputProcessor(gestureRecognizer, frameworkElement, frameworkElement.Parent as FrameworkElement);



                frameworkElement.ManipulationDelta += FrameworkElement_ManipulationDelta;

                frameworkElement.PointerEntered += FrameworkElement_PointerEntered;
                frameworkElement.PointerMoved += FrameworkElement_PointerMoved;
                frameworkElement.PointerExited += FrameworkElement_PointerExited;
                frameworkElement.PointerCanceled += FrameworkElement_PointerCanceled;
                frameworkElement.Holding += FrameworkElement_Holding;
                frameworkElement.PointerReleased += FrameworkElement_PointerReleased;
                frameworkElement.ManipulationStarted += FrameworkElement_ManipulationStarted;
                frameworkElement.ManipulationDelta += FrameworkElement_ManipulationDelta;
                frameworkElement.ManipulationCompleted += FrameworkElement_ManipulationCompleted;
                frameworkElement.ManipulationInertiaStarting += FrameworkElement_ManipulationInertiaStarting;
            }
        }

        private static void FrameworkElement_ManipulationInertiaStarting(object sender, Windows.UI.Xaml.Input.ManipulationInertiaStartingRoutedEventArgs e)
        {
            if (PointerDeviceType.Touch.Equals(e.PointerDeviceType))
            {
                System.Diagnostics.Debug.WriteLine($"ManipulationInertiaStarting");
            }
        }

        private static void FrameworkElement_ManipulationCompleted(object sender, Windows.UI.Xaml.Input.ManipulationCompletedRoutedEventArgs e)
        {
            if (PointerDeviceType.Touch.Equals(e.PointerDeviceType))
            {
                System.Diagnostics.Debug.WriteLine($"ManipulationCompleted{e.Position.X},{e.Position.Y}");
            }
        }

        private static void FrameworkElement_ManipulationDelta(object sender, Windows.UI.Xaml.Input.ManipulationDeltaRoutedEventArgs e)
        {
            if (PointerDeviceType.Touch.Equals(e.PointerDeviceType))
            {
                System.Diagnostics.Debug.WriteLine($"FrameworkElement_ManipulationDelta{e.Position.X},{e.Position.Y}");
            }
        }

        private static void FrameworkElement_ManipulationStarted(object sender, Windows.UI.Xaml.Input.ManipulationStartedRoutedEventArgs e)
        {
            if (PointerDeviceType.Touch.Equals(e.PointerDeviceType))
            {
                System.Diagnostics.Debug.WriteLine($"FrameworkElement_ManipulationStarted{e.Position.X},{e.Position.Y}");
            }
        }

        private static void FrameworkElement_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (PointerDeviceType.Touch.Equals(e.Pointer.PointerDeviceType))
            {
                System.Diagnostics.Debug.WriteLine($"FrameworkElement_PointerReleased{e.GetCurrentPoint(sender as UIElement).Position.X},{e.GetCurrentPoint(sender as UIElement).Position.Y}");
            }
        }

        private static void FrameworkElement_Holding(object sender, Windows.UI.Xaml.Input.HoldingRoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"FrameworkElement_Holding{e.HoldingState}");
        }

        private static void FrameworkElement_PointerCanceled(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (PointerDeviceType.Touch.Equals(e.Pointer.PointerDeviceType))
            {
                System.Diagnostics.Debug.WriteLine($"FrameworkElement_PointerCanceled{e.GetCurrentPoint(sender as UIElement).Position.X},{e.GetCurrentPoint(sender as UIElement).Position.Y}");
            }
        }

        private static void FrameworkElement_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (PointerDeviceType.Touch.Equals(e.Pointer.PointerDeviceType))
            {
                System.Diagnostics.Debug.WriteLine($"FrameworkElement_PointerExited{e.GetCurrentPoint(sender as UIElement).Position.X},{e.GetCurrentPoint(sender as UIElement).Position.Y}");
            }
        }

        private static void FrameworkElement_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (PointerDeviceType.Touch.Equals(e.Pointer.PointerDeviceType))
            {
                System.Diagnostics.Debug.WriteLine($"FrameworkElement_PointerMoved{e.GetCurrentPoint(sender as UIElement).Position.X},{e.GetCurrentPoint(sender as UIElement).Position.Y}");
            }
        }

        private static void FrameworkElement_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (PointerDeviceType.Touch.Equals(e.Pointer.PointerDeviceType))
            {
                if (sender is FrameworkElement framework)
                {
                    if (framework.Parent is ScrollViewer scrollViewer)
                    {
                        var r = scrollViewer.CancelDirectManipulations();
                    }
                }
                else if (sender is ScrollViewer scrollViewer)
                {
                    var r = scrollViewer.CancelDirectManipulations();
                }

                System.Diagnostics.Debug.WriteLine($"FrameworkElement_PointerEntered{e.GetCurrentPoint(sender as UIElement).Position.X},{e.GetCurrentPoint(sender as UIElement).Position.Y}");
            }
        }
    }
}
