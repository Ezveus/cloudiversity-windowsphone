using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;

namespace ClouDiversity {
    public partial class MyAssessments : PhoneApplicationPage {
        string token = string.Empty;
        string mail = string.Empty;

        public class Period2 {
            public int id { get; set; }
            public string name { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
        }

        public class Discipline2 {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Teacher {
            public int id { get; set; }
            public int user_id { get; set; }
            public string login { get; set; }
            public string name { get; set; }
        }

        public class Assessment {
            public int id { get; set; }
            public string assessment { get; set; }
            public bool school_class_assessment { get; set; }
            public Teacher teacher { get; set; }
        }

        public class Discipline {
            public Discipline2 discipline { get; set; }
            public List<Assessment> assessments { get; set; }
        }

        public class Period {
            public Period2 period { get; set; }
            public List<Discipline> disciplines { get; set; }
        }

        public class RootObject {
            public List<Period> periods { get; set; }
        }

        private class AssessmentItem {
            public string Discipline { get; set; }
            public string Teacher { get; set; }
            public string Assessment { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string SchoolClassAssessment { get; set; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {

            if (NavigationContext.QueryString.TryGetValue("token", out token)) {
            }
            if (NavigationContext.QueryString.TryGetValue("mail", out mail)) {
            }
            loadApi(mail, token);
        }


        public void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e) {
            System.Diagnostics.Debug.WriteLine("BONDOUR");
            var test = e.Error;

        }


        private async void loadApi(string mmail, string mtoken) {



            HttpClient httpClient = new HttpClient();

            // Add a new Request Message
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://hogwarts.cloudiversity.eu/evaluations/assessments.json?as=student");

            // Add our custom headers

            // listBox1.Items.Add("Mail: " + mmail + "<<");
            requestMessage.Headers.Add("X-User-Email", mmail);
            requestMessage.Headers.Add("X-User-Token", mtoken);

            // Send the request to the server

            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);


            // Just as an example I'm turning the response into a string here
            string responseAsString = await response.Content.ReadAsStringAsync();

            var resJson = JsonConvert.DeserializeObject<RootObject>(responseAsString);
            
            foreach (Period period in resJson.periods)
            {
                var period2 = period.period;
                foreach (Discipline discipline in period.disciplines)
                {
                    var discipline2 = discipline.discipline;
                    foreach (Assessment assessement in discipline.assessments)
                    {
                        var assessment_str = assessement.assessment;
                        var schoolClassAssessment = assessement.school_class_assessment;
                        var teacherName = assessement.teacher.name;
                        string sca_str;

                        if (schoolClassAssessment)
                        {
                            sca_str = "Assigned to whole class";
                        }
                        else
                        {
                            sca_str = "Assigned to you";
                        }
                        AssessmentsList.Items.Add(new AssessmentItem() {
                            Discipline = discipline2.name,
                            Assessment = assessment_str,
                            StartDate = period2.start_date,
                            EndDate = period2.end_date,
                            Teacher = teacherName,
                            SchoolClassAssessment = sca_str
                        });
                    }
                }
            }








        }
        public MyAssessments() {
            InitializeComponent();
        }
    }
}