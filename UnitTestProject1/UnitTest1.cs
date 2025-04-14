using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ASP.NETMVCClassWork.Controllers;
using System.Web.Mvc;
using System.Web.Helpers;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HomeController ct = new HomeController();

            ViewResult res = ct.Index() as ViewResult;

            Assert.AreEqual(null, res.ViewBag.Message);

        }

        [TestMethod]
        public void TestMethod2()
        {
            HomeController ct = new HomeController();  

            // 1. Serialize the object to JSON string
            string jsonString = JsonConvert.SerializeObject(ct.MyJson().Data);

            // 2. Deserialize into dynamic
            dynamic data = JsonConvert.DeserializeObject<dynamic>(jsonString);

            Debug.WriteLine(data.Name as string );

            Assert.AreEqual("Tornike", (data["Name"] as JValue).Value as string);

        }

    }
}
