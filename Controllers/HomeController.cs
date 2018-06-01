using D2Blog;
using D2Blog.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace D2Blog.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [RequireHttps]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [RequireHttps]
        public ActionResult Contact()
        {
            EmailModel model = new EmailModel();
            return View(model);
        }
        [RequireHttps]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //mail message
                    MailMessage mM = new MailMessage();
                    //Mail Address
                    mM.From = new MailAddress("destinyknightw@aol.com");
                    //emailid to send
                    mM.To.Add("destinyknightw@aol.com");
                    //your subject line of the message
                     mM.Subject = "Contact from D2Blog site";
                    //add the body of the email
                    mM.Body = string.Format(model.FromName) + " " + string.Format(model.Subject) + " " + string.Format(model.Body);
                    mM.IsBodyHtml = false;
                     //SMTP 
                    SmtpClient SmtpServer = new SmtpClient();
                    //your credential will go here
                    SmtpServer.Credentials = new System.Net.NetworkCredential("destinyknightw@aol.com", "Byakugan@301");
                    //port number to login yahoo server
                    SmtpServer.Port = 587;
                    //yahoo host name
                    SmtpServer.Host = "smtp.aol.com";
                    SmtpServer.EnableSsl = true;
                    //Send the email
                    SmtpServer.Send(mM);
                    return RedirectToAction("Index", "BlogPosts");
                }//end of try block
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                    return View(model);
                }
                //end of catch
                //end of AOLEmail Method

                //try
                //{
                //var svc = new EmailService();
                //var msg = new IdentityMessage()
                //{
                //Subject = "Contact from D2Blog site",
                //Body = string.Format(model.FromName, model.FromEmail, model.Body),
                //Destination = "destinyknightw@aol.com"
                //};
                //await svc.SendAsync(msg);
                //return View();
                //}

                //catch (Exception ex)
                //{
                //Console.WriteLine(ex.Message);
                //await Task.FromResult(0);
                //return View(model);
                //}
            }
            else
            {
                return View(model);
            }
        }
    }
}
