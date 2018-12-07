using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLF.Controllers;
using PLF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF.Controllers.Tests
{
    [TestClass()]
    public class PLFControllerTests
    {
       
        [TestMethod()]
        public void GetTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest2()
        {
            var resurl = 1;
            Assert.IsTrue(resurl == 1);
        }
    }
}