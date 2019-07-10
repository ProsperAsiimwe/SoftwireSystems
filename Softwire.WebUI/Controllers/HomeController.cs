using Softwire.Domain.Context;
using Softwire.Domain.Entities;
using Softwire.WebUI.Infrastructure.Helpers;
using Softwire.WebUI.Models.QuoteRequests;
using Softwire.WebUI.Models.SupportRequests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Softwire.WebUI.Controllers
{
    public class HomeController : BaseController
    {
       

        public ActionResult Index()
        {           
            return View();
        }

      
        public ActionResult About()
        {
            return View();

        }

        public ActionResult Services()
        {
          
            return View();
        }

        [HttpGet]
        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }


        public ActionResult Quotation()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Quotation(QuoteRequestViewModel q)
        {
            if (ModelState.IsValid)
            {
                using (context)
                {
                    var quote = q.ParseAsEntity(new QuoteRequest());
                    context.QuoteRequests.Add(quote);
                    context.SaveChanges();

                    // send email
                    var mail = GetMailHelper();
                    string subject = string.Format("{0} - Quote request", quote.Name);
                    string message = QuotationNotificationMsg(quote);
                    string status = string.Join(":", mail.SendMail(subject, message, ConfigurationManager.AppSettings["Settings.Company.Email"]));
                    mail.RecordErrors();

                    return RedirectToAction("Thanks");
                }

            }

            return View();
        }

        public ActionResult Support()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Support(SupportRequestViewModel s)
        {
            if (ModelState.IsValid)
            {
                using (context)
                {
                    var support = s.ParseAsEntity(new SupportRequest());
                    context.SupportRequests.Add(support);
                    context.SaveChanges();

                    // send email
                    var mail = GetMailHelper();
                    string subject = string.Format("{0} - Support request", support.Name);
                    string message = SupportNotificationMsg(support);
                    string status = string.Join(":", mail.SendMail(subject, message, ConfigurationManager.AppSettings["Settings.Company.Email"]));
                    mail.RecordErrors();

                    return RedirectToAction("Thanks");
                }

            }

            return View();
        }

        public ActionResult AdminPage()
        {

            return RedirectToAction("Index", "HomeAdmin");
        }

        public ActionResult Thanks()
        {
            return View();
        }

        public MailHelper GetMailHelper()
        {
            MailHelper mail = new MailHelper(null);
            mail.UserId = null;

            return mail;
        }

    }
}