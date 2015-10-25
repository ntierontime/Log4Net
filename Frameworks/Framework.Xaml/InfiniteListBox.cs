#if WINDOWS_PHONE

using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Framework.Xaml
{
    /// <summary>
    /// 
    /// http://stackoverflow.com/questions/13678211/handling-event-of-user-control-in-its-holding-pages-code-behind
    /// </summary>
    public class InfiniteListBox : ListBox
    {
        public ICommand CompressionBottomCommand
        {
            get { return (ICommand)GetValue(CompressionBottomCommandProperty); }
            set { SetValue(CompressionBottomCommandProperty, value); }
        }

        public static readonly DependencyProperty CompressionBottomCommandProperty =
                DependencyProperty.Register("CompressionBottomCommand", typeof(ICommand), typeof(ListBox), new PropertyMetadata(null));

        private bool scrollEventsHooked = false;

        public InfiniteListBox()
        {
            this.Loaded += InfiniteListBox_Loaded;
        }

        void InfiniteListBox_Loaded(object sender, RoutedEventArgs e)
        {
            PrepareCompressionTracking();
        }

        private void PrepareCompressionTracking()
        {
            ScrollViewer scrollViewer = null;

            if (scrollEventsHooked)
                return;

            scrollViewer = FindFirstElement(this, typeof(ScrollViewer)) as ScrollViewer;

            if (scrollViewer != null)
            {
                FrameworkElement element = VisualTreeHelper.GetChild(scrollViewer, 0) as FrameworkElement;

                if (element != null)
                {
                    var verticalStateGroup = FindVisualStateGroup(element, "VerticalCompression");
                    var horizontalStateGroup = FindVisualStateGroup(element, "HorizontalCompression");

                    if (verticalStateGroup != null)
                    {
                        verticalStateGroup.CurrentStateChanging += verticalStateGroup_CurrentStateChanging;
                    }

                    if (horizontalStateGroup != null)
                    {
                        horizontalStateGroup.CurrentStateChanging += horizontalStateGroup_CurrentStateChanging;
                    }
                }
            }

            scrollEventsHooked = true;
        }

        void horizontalStateGroup_CurrentStateChanging(object sender, VisualStateChangedEventArgs e)
        {
            //if (e.NewState.Name == "CompressionLeft" && CompressionOccured != null)
            //{
            //    CompressionOccured(this, new CompressionEventArgs(CompressionType.Left));
            //}
            //else if (e.NewState.Name == "CompressionRight" && CompressionOccured != null)
            //{
            //    CompressionOccured(this, new CompressionEventArgs(CompressionType.Right));
            //}
        }

        void verticalStateGroup_CurrentStateChanging(object sender, VisualStateChangedEventArgs e)
        {
            //if (e.NewState.Name == "CompressionTop" && CompressionOccured != null)
            //{
            //    CompressionOccured(this, new CompressionEventArgs(CompressionType.Top));
            //}
            //else if (e.NewState.Name == "CompressionBottom" && CompressionOccured != null)
            //{
            //    CompressionOccured(this, new CompressionEventArgs(CompressionType.Bottom));
            //}

            if (e.NewState.Name == "CompressionTop")
            {
            }
            else if (e.NewState.Name == "CompressionBottom" && CompressionBottomCommand != null)
            {
                if(CompressionBottomCommand.CanExecute(null))
                {
                    CompressionBottomCommand.Execute(null);
                }
            }
        }

        private VisualStateGroup FindVisualStateGroup(FrameworkElement parent, string name)
        {
            if (parent == null)
                return null;

            IList groups = VisualStateManager.GetVisualStateGroups(parent);
            foreach (VisualStateGroup group in groups)
            {
                if (group.Name == name)
                    return group;
            }

            return null;
        }

        private UIElement FindFirstElement(FrameworkElement parent, Type targetType)
        {
            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            UIElement returnedElement = null;

            if (childCount > 0)
            {
                for (int i = 0; i < childCount; i++)
                {
                    var element = VisualTreeHelper.GetChild(parent, i);
                    if (element.GetType().Equals(targetType))
                    {
                        returnedElement = (UIElement)element;
                        break;
                    }
                }
            }

            return returnedElement;
        }
    }

    public class CompressionEventArgs : EventArgs
    {
        CompressionType _type;

        public CompressionType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public CompressionEventArgs(CompressionType type)
        {
            _type = type;
        }
    }

    public enum CompressionType
    {
        Top,
        Bottom,
        Left,
        Right
    }
}

#endif