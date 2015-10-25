using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace Log4Net.SL5App
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ContentFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void ContentFrame_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
        {

        }

        private void hyperlinkButton1_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new Uri("/Views/AspNet_SqlCacheTablesForChangeNotificationView.xaml", UriKind.Relative)); 
        }
    }
}