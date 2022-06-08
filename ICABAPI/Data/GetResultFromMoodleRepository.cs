using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ICABAPI.Data
{
    public class GetResultFromMoodleRepository : IGetResultFromMoodleService
    {
        private static readonly HttpClient client;

        static GetResultFromMoodleRepository()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://cbt.icab.org.bd")
            };
        }

        public async Task<List<CourseListFromMoodle>> GetCourseListFromMoodles()
        {
            var url = string.Format("/webservice/rest/server.php?wstoken=aaf95a2371ae4ef9d840ae76bc1c6bd4&wsfunction=core_course_get_courses");
            List<CourseListFromMoodle> courseList = new();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string xml = await response.Content.ReadAsStringAsync();
                var xdoc = XDocument.Parse(xml);

                var courseXmlBreakDown = xdoc.Descendants("SINGLE")
                                        .Select(y => new CourseListFromMoodle //idnumber
                                        {
                                            CourseIdFromMoodle = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "id").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                                            Fullname = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "fullname").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                                            CourseIdNumber = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "idnumber").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                                        });

                List<string> c = new();
                c.Add("611");
                c.Add("612");
                c.Add("613");
                c.Add("614");
                c.Add("615");
                c.Add("616");
                c.Add("617");
                foreach (var item in courseXmlBreakDown)
                {
                    CourseListFromMoodle clist = new CourseListFromMoodle();



                    if (item.CourseIdNumber != "" && item.CourseIdNumber != null && c.Contains(item.CourseIdNumber))
                    {
                        clist.CourseIdFromMoodle = item.CourseIdFromMoodle;
                        clist.Fullname = item.Fullname;
                        clist.CourseIdNumber = item.CourseIdNumber;

                        courseList.Add(clist);
                    }

                }

            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return courseList;

        }

        public async Task<List<CourseGrades>> GetCourseGrades(int RegNo)
        {
            //var url = string.Format("/api/v2/PublicHolidays/{0}/{1}", year, countryCode);
            var url = string.Format("/webservice/rest/server.php?wstoken=aaf95a2371ae4ef9d840ae76bc1c6bd4&wsfunction=gradereport_overview_get_course_grades&userid=" + RegNo);
            List<CourseGrades> courseGrades = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {

                string xml = await response.Content.ReadAsStringAsync();

                var xdoc = XDocument.Parse(xml);
                var breakDown = xdoc.Descendants("KEY")
                                 .Where(x => x.Attribute("name").Value == "grades")
                                 .Descendants("SINGLE")
                                 .Select(y => new CourseGrades
                                 {
                                     Courseid = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "courseid").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                                     Grade = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "grade").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                                     Rawgrade = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "rawgrade").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                                     Rank = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "rank").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                                 });

                foreach (var item in breakDown)
                {
                    CourseGrades gR = new CourseGrades();

                    gR.Courseid = item.Courseid;
                    gR.Grade = item.Grade;
                    gR.Rawgrade = item.Rawgrade;
                    gR.Rank = item.Rank;

                    courseGrades.Add(gR);
                }

            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return courseGrades;
        }

        public async Task<SingleUserFromMoodle> GetSingleUserFromMoodle(int RegNo)
        {
            var url = string.Format("/webservice/rest/server.php?wstoken=aaf95a2371ae4ef9d840ae76bc1c6bd4&wsfunction=core_user_get_users&criteria[0][key]=username&criteria[0][value]=" + RegNo);
            SingleUserFromMoodle singleUser = new();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string xml = await response.Content.ReadAsStringAsync();
                var xdoc = XDocument.Parse(xml);

                var userXmlBreakDown = xdoc.Descendants("KEY")
                                            .Where(x => x.Attribute("name").Value == "users")
                                            .Descendants("SINGLE")
                                            .Select(y => new 
                                            {
                                                MoodleUserId = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "id").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                                                RegNo = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "username").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                                                Name = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "fullname").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                                                Email = y.Descendants("KEY").Where(z => z.Attribute("name").Value == "email").Select(a => a.Element("VALUE").Value).FirstOrDefault(),
                                            }).FirstOrDefault();


                if(userXmlBreakDown == null)
                {
                    singleUser = null;
                    return singleUser;
                }

                singleUser.MoodleUserId = userXmlBreakDown.MoodleUserId;
                singleUser.RegNo = Convert.ToInt32(userXmlBreakDown.RegNo);
                singleUser.Name = userXmlBreakDown.Name;
                singleUser.Email = userXmlBreakDown.Email;

            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return singleUser;

        }


    }
}
