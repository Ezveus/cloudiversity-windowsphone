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
    public partial class Page1 : PhoneApplicationPage
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
            public string id { get; set; }
            [JsonProperty("title")]
            public string title { get; set; }
            [JsonProperty("deadline")]
            public string deadline { get; set; }
            [JsonProperty("duetime")]
            public string duetime { get; set; }
            [JsonProperty("progress")]
            public string progress { get; set; }
            [JsonProperty("AgendaElementDiscipline")]
            public string AgendaElementDiscipline { get; set; }

            /*[JsonProperty("progress")]
            public string title { get; set; }*/

        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (NavigationContext.QueryString.TryGetValue("token", out token))
            {
                //listBox1.Items.Add(token);
            }
            if (NavigationContext.QueryString.TryGetValue("mail", out mail))
            {
                //listBox1.Items.Add(mail);
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
            //listBox1.Items.Add(test);
            //TextBlock1.Text = test.ToString();

        }


        private async void loadApi(string mmail, string mtoken)
        {

                      /* var client = new HttpClient();
            client.BaseAddress = new Uri("http://hogwarts.adaedra.eu/");
            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("X-User-Email", mail),
                new KeyValuePair<string, string>("X-User-Token", token)
            });


            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("http://hogwarts.adaedra.eu/agenda.json"),
                Method = HttpMethod.Get
            };
            request.Headers.Add("X-User-Email", mail);
            request.Headers.Add("X-User-Token", token);

             //= await client.SetAsync(request);
            var result = await client.SendAsync(request);

            string resultContent = await result.Content.ReadAsStringAsync();
            //string resultContent = result.Content.ReadAsStringAsync().Result;
            listBox1.Items.Add(resultContent);*/



            HttpClient httpClient = new HttpClient();

            // Add a new Request Message
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://hogwarts.adaedra.eu/agenda.json");

            // Add our custom headers

           // listBox1.Items.Add("Mail: " + mmail + "<<");
            requestMessage.Headers.Add("X-User-Email", mmail);
            requestMessage.Headers.Add("X-User-Token", mtoken);

            // Send the request to the server

                HttpResponseMessage response = await httpClient.SendAsync(requestMessage);


            // Just as an example I'm turning the response into a string here
                string responseAsString = await response.Content.ReadAsStringAsync();


                var resJson = JsonConvert.DeserializeObject<List<AgendaElement>>(responseAsString);

                var elements = resJson.ToArray();

                int nb = elements.Length;

                for (int i = 0; i < nb; i++)
                {
                    listBox1.Items.Add(elements[0].deadline);
                    listBox1.Items.Add("   " + elements[i].title + " (" + elements[i].progress + " %)");
                    
                    
                    

                    //listBox1.Items.Add("   " + elements[i].title + " (" + elements[i].progress + " %)");
                }
            /*var id = elements[0].id;
                
            
            
            var full_name = elements[0].full_name;
                listBox1.Items.Add("id: "+id+" name: "+full_name);*/
 


            


        }

        public Page1()
        {
            InitializeComponent();

           /* ListBox listBox1 = new ListBox();
            listBox1.Items.Add("Item 1");
            listBox1.Items.Add("Item 2");
            listBox1.Items.Add("Item 3");
            listBox1.Width = 140;
            //listBox1.SelectionChanged += ListBox_SelectionChanged;
            */
            // Add the list box to a parent container in the visual tree.

        }
    }
}