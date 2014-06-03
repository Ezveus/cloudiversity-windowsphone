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
        public Home()
        {
            InitializeComponent();
            //NavigationService.Navigate(new Uri("/PivotPage1.xaml"));
            //NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }
    }
}