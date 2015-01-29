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
    public partial class HomeworksPage : PhoneApplicationPage
    {
        string token = string.Empty;
        string mail = string.Empty;


        public class AgendaJson
        {
            [JsonProperty("AgendaElement")]
            public AgendaElement AgendaElement { get; set; }
        }

        public class AgendaElementDiscipline
        {
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("name")]
            public string title { get; set; }
        }

        public class AgendaElement
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("title")]
            public string Title { get; set; }
            [JsonProperty("deadline")]
            public string Deadline { get; set; }
            [JsonProperty("duetime")]
            public string Duetime { get; set; }
            [JsonProperty("progress")]
            public string Progress { get; set; }
            [JsonProperty("AgendaElementDiscipline")]
            public string AgendaElementDiscipline { get; set; }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.TryGetValue("token", out token))
            {
                //HomeworksList.Items.Add(token);
            }
            if (NavigationContext.QueryString.TryGetValue("mail", out mail))
            {
                //HomeworksList.Items.Add(mail);
                // Whatever
            }
            loadApi(mail, token);
        }


        public void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("BONDOUR");
            //TextBlock1.Text = e.Result;

            //JsonConvert.DeserializeObject(e.Result);
            //var lol = e.Result;
            var test = e.Error;
            //HomeworksList.Items.Add(test);
            //TextBlock1.Text = test.ToString();

        }


        private async void loadApi(string mmail, string mtoken)
        {
            HttpClient httpClient = new HttpClient();

            // Add a new Request Message
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://hogwarts.cloudiversity.eu/agenda.json");

            // Add our custom headers

            requestMessage.Headers.Add("X-User-Email", mmail);
            requestMessage.Headers.Add("X-User-Token", mtoken);

            // Send the request to the server

                HttpResponseMessage response = await httpClient.SendAsync(requestMessage);


            // Just as an example I'm turning the response into a string here
                string responseAsString = await response.Content.ReadAsStringAsync();


                var resJson = JsonConvert.DeserializeObject<List<AgendaElement>>(responseAsString);

                var elements = resJson.ToArray();

                foreach (var homework in elements)
                {
//                    HomeworksList.Items.Add(elements[0].deadline);
//                    HomeworksList.Items.Add("   " + elements[i].Title + " (" + elements[i].progress + " %)");
//                    HomeworksList.Items.Add("-----------------------");
                    HomeworksList.Items.Add(homework);
                }
        }

        private List<AgendaElement> Ls;

        public HomeworksPage()
        {
            InitializeComponent();
//            var homework = new AgendaElement();
//            homework.Title = "Test";
//            homework.Deadline = "Plop";
//            homework.Progress = "42";
//
//            var homework2 = new AgendaElement();
//            homework2.Title = "Test2";
//            homework2.Deadline = "Plop2";
//            homework2.Progress = "42";
//            homework2.Duetime = "23:42";
//            Ls = new List<AgendaElement>() { homework, homework2 };
//            DataContext = this;
        }
    }
}