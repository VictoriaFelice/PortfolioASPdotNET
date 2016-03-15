using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioASPdotNET.Controllers;
using System.Web.Mvc;

namespace PortfolioASPdotNET.Tests {
	[TestClass]
	public class UnitTest1 {
		[TestMethod]
		public void PortfolioActionReturnsPortfolioView() {
			var homeController = new HomeController();
			var result = homeController.Portfolio() as ViewResult;
			Assert.AreEqual("", result.ViewName);
		}
		[TestMethod]
		public void ContactFormSaysThanks() {
			var homeController = new HomeController();
			var result = homeController.Contact("I love your portfolio") as ViewResult;
			Assert.IsNotNull(result.ViewBag.TheMessage);
		}
	}
}