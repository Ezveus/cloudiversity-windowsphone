using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ClouDiversity.Resources;

namespace ClouDiversity
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructeur
        public MainPage()
        {

            if (System.Diagnostics.Debugger.IsAttached)
            {
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }
            InitializeComponent();
            //NavigationService.Navigate(new Uri("/PivotPage1.xaml"));
            System.Diagnostics.Debug.WriteLine("BONDOUR");
            NavigationService.Navigate(new Uri("/PivotPage1.xaml", UriKind.Relative));

            // Exemple de code pour la localisation d'ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        public void webClient_DownloadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {

            System.Diagnostics.Debug.WriteLine("BONDOUR");
            //TextBlock1.Text = e.Result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string password;
            string username;

            password = this.Password.Password;
            username = this.Username.Text;



            WebClient webClient = new WebClient();


            //webClient.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            //webClient.Headers["user[login]"] = "LOL";
            //webClient.Headers["user[password]"] = "LOL"; 
            //webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
            //


            string param = "?user[login]=toto&user[password]=tutu";
            webClient.UploadStringCompleted += new UploadStringCompletedEventHandler(webClient_DownloadStringCompleted); //new UploadStringCompletedEventHandler(webClient_DownloadStringCompleted);
 
            webClient.UploadStringAsync(new Uri(string.Format("http://testapp.cloudiversity.eu/users/sign_in.json")), "POST", param);

            

            if (username.CompareTo("__test__") == 0 && password.CompareTo("__test__") == 0)
            {
                NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
            }

        }

        // Exemple de code pour la conception d'une ApplicationBar localisée
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Définit l'ApplicationBar de la page sur une nouvelle instance d'ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Crée un bouton et définit la valeur du texte sur la chaîne localisée issue d'AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Crée un nouvel élément de menu avec la chaîne localisée d'AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}