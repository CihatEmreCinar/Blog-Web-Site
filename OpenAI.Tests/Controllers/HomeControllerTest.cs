using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenAI;
using OpenAI.Controllers;

namespace OpenAI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Düzenle
            HomeController controller = new HomeController();

            // Davran
            ViewResult result = controller.Index() as ViewResult;

            // Onayla
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
