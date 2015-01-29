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

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net.Http;

using Newtonsoft.Json;


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
//            System.Diagnostics.Debug.WriteLine("BONDOUR");
  //          NavigationService.Navigate(new Uri("/PivotPage1.xaml", UriKind.Relative));

            // Exemple de code pour la localisation d'ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        public void webClient_DownloadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {

            System.Diagnostics.Debug.WriteLine("BONDOUR");
            //TextBlock1.Text = e.Result;
        }

        public void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("BONDOUR");
            //TextBlock1.Text = e.Result;

            //JsonConvert.DeserializeObject(e.Result);
            //var lol = e.Result;
            var test = e.Error;
            //TextBlock1.Text = test.ToString();
            
        }

        public class JRet
        {
            public string email;
            public bool success;
            public string token;
        }



        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string password;
            string username;

            password = this.Password.Password;
            username = this.Username.Text;

            WebClient webClient = new WebClient();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://hogwarts.cloudiversity.eu/");
            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("user[login]", username),
                new KeyValuePair<string, string>("user[password]", password)
            });
            var result = await client.PostAsync("http://hogwarts.cloudiversity.eu/users/sign_in.json", content);

            string resultContent = result.Content.ReadAsStringAsync().Result;
            JRet res = (JRet)JsonConvert.DeserializeObject<JRet>(resultContent);
            var myMail = res.email;
            var myToken = res.token;
           



            if (res.success == true)
            {
                NavigationService.Navigate(new Uri("/Home.xaml?token=" + myToken + "&mail=" + myMail, UriKind.Relative));
            }
            else
                Error.Text = "Mauvais login/mot de passe";

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
