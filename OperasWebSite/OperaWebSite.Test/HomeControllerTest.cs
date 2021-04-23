using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OperasWebSite.Controllers;  //agregar
using System.Web.Mvc; //agregar

namespace OperaWebSite.Test
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_Return_View_Test()
        {
            HomeController home = new HomeController();

            var result = home.Index() as ViewResult;   // devuelve la vista index como resultado

            Assert.AreEqual("Index", result.ViewName); //comparamos el nombre de la vista con el de default
        }
    }
}
