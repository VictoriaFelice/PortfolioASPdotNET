using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using PortfolioASPdotNET.Models;
using System.Text;

namespace PortfolioASPdotNET.Controllers {
	public class HomeController : Controller {
		// GET: About
		public ActionResult Index() {
			return View();
		}

		public ActionResult Portfolio() {
			return View();
		}

		public ActionResult Contact() {
			return View();
		}

		//business logic here is the initial validation check on our required fields, and then sending the mail to the specified recipient once validation passes.
		[HttpPost] /*Annotate our method by using [HttpPost], which means we’re posting back to a server*/
		public ActionResult Contact(ContactModels c) { /*Pass our contact model class as a method parameter*/
			if (ModelState.IsValid) { /*If it’s true, we’ll try and send the e-mail. It it’s false, we’ll re-display the form and appropriate error messages*/
				try {
					MailMessage msg = new MailMessage(); /*Create an object from the mail message class*/
					SmtpClient smtp = new SmtpClient(); /*Create an object from the SMTP client message class*/
					MailAddress from = new MailAddress(c.Email.ToString()); /*Create an object from the mail address class*/
					StringBuilder sb = new StringBuilder(); /*Create an object from the string builder class*/

					smtp.Host = "smtp.gmail.com";
					smtp.Port = 587;
					smtp.EnableSsl = true;
					smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
					smtp.Credentials = new System.Net.NetworkCredential("MyEmail@gmail.com", "MyPassword");

					msg.IsBodyHtml = false; /*Whether our e-mail will contain HTML*/
					msg.To.Add("MyEmail@gmail.com"); /*An e-mail address of the recipient*/
					msg.From = from;
					msg.Subject = "Message from a visitor of my Portfolio website!"; /*A subject*/
					sb.Append("First name: " + c.FirstName); /*Concatenate(append) our form field values from our model to the string builder object, with appropriate carriage returns*/
					sb.Append(Environment.NewLine);
					sb.Append("Last name: " + c.LastName);
					sb.Append(Environment.NewLine);
					sb.Append("Email: " + c.Email);
					sb.Append(Environment.NewLine);
					sb.Append("Comments: " + c.Comment);
					msg.Body = sb.ToString(); /*After concatenation is complete, we assign the body of our mail message to the contents of our string builder object*/
					smtp.Send(msg); /*Call the send method, and pass in our mail object*/
					msg.Dispose(); /*Dispose of the mail object and show a success view*/
					return View("Success");
				}
				catch (Exception) {
					return View("Error");
				}
			}
			return View();
		}
	}
}