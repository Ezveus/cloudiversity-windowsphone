using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ClouDiversity
{
    public partial class Home : PhoneApplicationPage
    {
        string mail = string.Empty;
        string token = string.Empty;
        public Home()
        {
            InitializeComponent();
            //NavigationService.Navigate(new Uri("/PivotPage1.xaml"));
            //NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (NavigationContext.QueryString.TryGetValue("token", out token))
            {
                
            }
            if (NavigationContext.QueryString.TryGetValue("mail", out mail))
            {

            }
        }

        private void mesDevoirs(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MesDevoirs.xaml?token=" + token + "&mail=" + mail, UriKind.Relative));
        }

        private void myGrades(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyGrades.xaml?token=" + token + "&mail=" + mail, UriKind.Relative));
        }

        private void myAssessments(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyAssessments.xaml?token=" + token + "&mail=" + mail, UriKind.Relative));
        }

        private void myAverages(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyAverages.xaml?token=" + token + "&mail=" + mail, UriKind.Relative));
        }
    }
}