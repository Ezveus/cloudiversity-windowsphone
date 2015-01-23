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
    public partial class MyGrades : PhoneApplicationPage
    {
        string token = string.Empty;
        string mail = string.Empty;

/*
        public class MyGradesJson
        {
            [JsonProperty("periods")]
            public Periods periods { get; set; }
        }

        public class Periods
        {
            [JsonProperty("period")]
            public List<Perioddata> perioddata { get; set; }
        }

        public class Perioddata
        {
            [JsonProperty("period")]
            public Period period { get; set; }
           // [JsonProperty("name")]
           // public List disciplines { get; set; }
        }

        public class Period
        {
            [JsonProperty("id")]
            public int id { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("start_date")]
            public string start_date { get; set; }
            [JsonProperty("end_date")]
            public string end_date { get; set; }
        }


*/



        public class Period2
        {
            public int id { get; set; }
            public string name { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
        }

        public class Discipline2
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Teacher
        {
            public int id { get; set; }
            public int user_id { get; set; }
            public string login { get; set; }
            public string name { get; set; }
        }

        public class Grade
        {
            public int id { get; set; }
            public int note { get; set; }
            public int coefficient { get; set; }
            public string assessment { get; set; }
            public Teacher teacher { get; set; }
        }

        public class Discipline
        {
            public Discipline2 discipline { get; set; }
            public List<Grade> grades { get; set; }
        }

        public class Period
        {
            public Period2 period { get; set; }
            public List<Discipline> disciplines { get; set; }
        }

        public class RootObject
        {
            public List<Period> periods { get; set; }
        }




        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (NavigationContext.QueryString.TryGetValue("token", out token)){
            }
            if (NavigationContext.QueryString.TryGetValue("mail", out mail)){
            }
            loadApi(mail, token);
        }


        public void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("BONDOUR");
            var test = e.Error;

        }


        private async void loadApi(string mmail, string mtoken)
        {



            HttpClient httpClient = new HttpClient();

            // Add a new Request Message
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://hogwarts.adaedra.eu/evaluations/grades.json?as=student");

            // Add our custom headers

           // listBox1.Items.Add("Mail: " + mmail + "<<");
            requestMessage.Headers.Add("X-User-Email", mmail);
            requestMessage.Headers.Add("X-User-Token", mtoken);

            // Send the request to the server

                HttpResponseMessage response = await httpClient.SendAsync(requestMessage);


            // Just as an example I'm turning the response into a string here
                string responseAsString = await response.Content.ReadAsStringAsync();

                var resJson = JsonConvert.DeserializeObject<RootObject>(responseAsString);

            //foreach (var perioddata in resJson.perioddata)
            //{

            //}
                listBox2.Items.Add(resJson.periods.Count);
        
            //listBox2.Items.Add(responseAsString);

           // listBox2.Items.Add(resJson.perioddata.Count);

    
 


            


        }

        public MyGrades()
        {
            InitializeComponent();

        }
    }
}