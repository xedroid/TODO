using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using TODOList.Models;

namespace TODOList.Utilities
{
    public class EmailManager
    {
        public static bool isValidEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }

        public void SendEmail(string email, string title = "", string body = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    using (MailMessage mm = new MailMessage("zadanie.todo.rekrutacyjne@gmail.com", email))
                    {
                        mm.Subject = title;
                        mm.Body = body;

                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                        credentials.UserName = "zadanie.todo.rekrutacyjne@gmail.com";
                        credentials.Password = "zadanie123!";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = credentials;
                        smtp.Port = 587;
                        smtp.Send(mm);
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public string SendNotification()
        {
            string error = "";
            string email = "";
            int numberOfDays = 0;
            DateTime notificationDate = DateTime.Now;
            string emailTitle = "Information about upcoming tasks";
            Dictionary<string, object> filters = new Dictionary<string, object>();


            Settings s = new SettingsManager().Get(1);
            if (s != null)
            {
                email = s.Email;
                numberOfDays = s.NumberDays;
            }

            filters.Add("NotificationDate", notificationDate.AddDays(numberOfDays).Date);

            CustomTasks ts = new CustomTasks();
            List<CustomTask> list = ts.GetTasks(filters);

            if (list.Count > 0)
            {
                StringBuilder content = new StringBuilder("<strong>Upcoming tasks:</strong></br></br>");

                content.Append("<table border='1'>");
                content.Append("<tr>");
                content.Append("<th>Title</th>");
                content.Append("<th>Description</th>");
                content.Append("</tr>");

                foreach (CustomTask task in list)
                {
                    content.Append("<tr>");
                    content.Append("<td>" + task.Title + "</td>");
                    content.Append("<td>" + task.Description + "</td>");
                    content.Append("</tr>");
                }

                content.Append("</table>");

                if (isValidEmail(email))
                {
                    SendEmail(email, emailTitle, content.ToString());
                }
                else { error += "Invalid format email address.\n"; }
            }
            return error;
        }

    }
}
