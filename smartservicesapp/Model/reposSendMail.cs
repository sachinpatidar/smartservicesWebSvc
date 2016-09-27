
namespace gmcscoServices.Model
{
    using System;
    using System.Net.Mail;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Net.Security;
    using System.Text;
    using System.Configuration;

    public class reposSendMail 
    {
        public string MailBody(string body)
        {
            StringBuilder Str = new StringBuilder();
//<img src='http://thedesignfactoryindia.com/Content/UserSite/Images/MailLogo.jpg' style='width:140px; padding:5px'>
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

                        Thanks for choosing Feeling Well
                        <br/><br/>
                        Best Regards,<br/>
                        JP. Foam Enterprise<br/>
                       <br />Mr. Jagdish Prasad<br /> plot no 258,<br /> udyog kendra-1,Ecotech - 3rd, Greater Noida-201306 (U.P) India<br />
                        
                Phone No. +91 981 157 1392
                        <br />
                        Email :. <span style='text-transform: none;'>jagdishprasad0111@gmail.com</span>
                        </p>

                        </div>";

                return SendEmail("Hi! " + Name + " Wants to Contact you", StrB.ToString());
            }
            catch (Exception)
            {
                throw;
            }


        }
        public string contentBody(ContactMessage obj)
        {
            try
            {
                string StrB = string.Empty;
                StrB += @"<div style='padding:10px;'>
                        Hi Admin 
                        <br/><br/>
                        One of the visitor want to make a Contact with you whose Details are below
                        <br/><br/>";
                StrB += " Name : " + obj.FirstName + " " + obj.LastName + "<br/>";
                StrB += "Company: " + obj.Company+ "<br/>";
                StrB += "Email Address : " + obj.Email + "<br/>";
                StrB += "Phone/Mobile : " + obj.PhoneNo+ "<br/>";
                StrB += "Message : " + obj.Msg + "<br/>";

                StrB += @"<br/><br/>

 

                      

                        Thanks for choosing Feeling Well
                        <br/><br/>
                        Best Regards,<br/>
                        GMCSCO Pvt Ltd. <br/>                       
                        
                Phone No. +91 (8884) 33-3268 
                        <br />
                        Email :. <span style='text-transform: none;'>info@gmcsco.com </span>
                        </p>

                        </div>";
               return MailBody(StrB.ToString()).ToString();
                //return SendEmail("Hi! " + obj.FirstName + " " + obj.LastName+ " Wants to consultation from you", StrB.ToString());
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
                MailAddress Send_frm = new MailAddress("<no-reply@gmcsco.com>", "GMCSCO(no-reply)");


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