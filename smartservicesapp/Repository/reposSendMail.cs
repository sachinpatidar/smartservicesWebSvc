﻿
namespace smartservicesapp.Repository
{
    using System;
    using System.Net.Mail;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Net.Security;
    using System.Text;
    using System.Configuration;
    using smartservicesapp.Model;

    public class reposSendMail 
    {
        public string MailBody(string body)
        {
            StringBuilder Str = new StringBuilder();

            Str.Append(@"

            <html>
 
<body>
 
<div >
<div style='Margin:10% 20%;border:1px solid grey;border-radius: 8px;'>
<div style='background-color: #45916B; height: 50px; width: 100%; margin-bottom: 10px; border-top-left-radius: 5px; border-top-right-radius: 5px;'>
<a href='http://gmcsco.com' target='_blank'> <img alt=' ' src='http://gmcsco.com/images/logo-header.png'></a></div>
");
            Str.Append(body);
            Str.Append(@"
<div style='background-color: grey; height: 25px; width: 100%; margin-top: 10px;border-bottom-left-radius: 5px; border-bottom-right-radius: 5px;'>

</div>


</div>

</div>

<body>
</html>");
            return Str.ToString();
        }

        public bool contentBody(string Name, string Email, string subject, string message)
        {
            try
            {
                string StrB = string.Empty;
                StrB += @"<div style='padding:10px;'>
                        Hi Admin 
                        <br/><br/>
                        One of the Customer want to make a Contact with you whose Details are below
                        <br/><br/>";
                StrB += " Name : " + Name + "<br/>";
                StrB += "Email : " + Email + "<br/>";
                StrB += "Subject : " + subject + "<br/>";
                StrB += "Message : " + message + "<br/>";
                StrB += @"<br/><br/>

                        Please don't hesitate to contact us if you require further information.
                        <br/><br/>

                        Thanks for choosing 
                        <br/><br/>
                        Best Regards,<br/>
                       GmCsco Administration<br/>
                       

                        </div>";

                return SendEmail("Hi! " + Name + " Wants to Contact you", StrB.ToString());
            }
            catch (Exception)
            {
                throw;
            }


        }
        public bool contentBody(UserRegister obj)
        {
            try
            {
                string StrB = string.Empty;
                StrB += @"<div style='padding:10px;'>Hi " + obj.FirstName + " " + obj.LastName ;
                StrB += "<br/><br/> Your Password for Smart Service App is below <br/>";
                StrB += "<h3>" + obj.Password+ "<h3/>";
                StrB += @"<br/><br/>
                        Best Regards,<br/>
                        Smart Service App. <br/>
                Phone No. +91 (8884) 33-3268 
                        <br />
                        Email :. <span style='text-transform: none;'>info@gmcsco.com </span>
                        </p>
                        </div>";
             //  return;
                return SendEmail("Password Recovery Mail from Smart Service APP", StrB.ToString().Replace("\r", string.Empty).Replace("\n", string.Empty));
            }
            catch (Exception)
            {
                throw;
            }


        }

        public bool SendEmail(string Subject, string Body)
        {
            MailMessage msg = new MailMessage();
            try
            {
                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["mailSMTP"].ToString(), int.Parse(ConfigurationManager.AppSettings["mailPort"].ToString()));
                NetworkCredential basicauthenticationinfo = new NetworkCredential(ConfigurationManager.AppSettings["mailUserName"].ToString(), ConfigurationManager.AppSettings["mailPassword"].ToString());
                client.UseDefaultCredentials = false;
                client.Credentials = basicauthenticationinfo;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = false;


                //Convert string to Mail Address
                MailAddress Send_to = new MailAddress(ConfigurationManager.AppSettings["mailSendTo"].ToString());
                MailAddress Send_frm = new MailAddress("<no-reply@smartapp.com>", "SmartApp(no-reply)");


                //SetUp Mesage Setting

                msg.Subject = Subject;
                msg.Body = MailBody(Body).ToString();
                msg.From = Send_frm;
                msg.To.Add(Send_to);
                msg.IsBodyHtml = true;
                client.Timeout = 2000000;
                ServicePointManager.ServerCertificateValidationCallback = (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true;
                client.Send(msg);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
          
            finally
            {
                msg.Dispose();
            }


        }


    }
}