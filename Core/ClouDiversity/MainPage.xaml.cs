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
        }



        private async void Button_Click(object sender, RoutedEventArgs e)
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




            String data = "?user[login]=fluttershy&user[password]=yellowquiet";
            WebClient wc = new WebClient();
            Uri uri = new Uri("http://testapp.cloudiversity.eu/users/sign_in.json");
            wc.UploadStringCompleted += new UploadStringCompletedEventHandler(wc_UploadStringCompleted);
            wc.Headers["Content-Type"] = "form-data";
            //wc.Encoding = Encoding.UTF8;
            //wc.
            wc.Encoding = System.Text.Encoding.UTF8;
            wc.UploadStringAsync(uri, "POST", data);



            var client = new HttpClient();
            client.BaseAddress = new Uri("http://testapp.cloudiversity.eu/");
            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("user[login]", username),
                new KeyValuePair<string, string>("user[password]", password)
            });
            var result = await client.PostAsync("http://testapp.cloudiversity.eu/users/sign_in.json", content);

            



            string resultContent = result.Content.ReadAsStringAsync().Result;


            JRet res = (JRet)JsonConvert.DeserializeObject<JRet>(resultContent);
            var ml = res.email;
            
            //TextBlock1.Text = ml;
            
            /*
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://testapp.cloudiversity.eu/");
                var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("user[login]", "fluttershy"),
                new KeyValuePair<string, string>("user[password]", "yellowquiet")
            });
                var result = client.PostAsync("http://testapp.cloudiversity.eu/users/sign_in.json", content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                TextBlock1.Text = resultContent;
                Console.WriteLine(resultContent);
            }*/
            






           // wc.UploadStringAsync(formattedUri, "POST");




            if (res.success == true)
            {
                NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
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