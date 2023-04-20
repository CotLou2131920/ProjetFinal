using Microsoft.VisualStudio.TestTools.UnitTesting;
using bibli;
using System;
using System.Collections.Generic;
using System.Text;

namespace bibli.Tests
{
    [TestClass()]
    public class CalculateurTests
    {
        [TestMethod()]
        public void AditionTest()
        {
            Calculateur cal = new Calculateur();
            if (cal.Adition(5, 4) != 9)
                Assert.Fail();
           
        }
        [TestMethod()]
        public void Soustraction()
        {
            Calculateur cal = new Calculateur();
            if (cal.Soustraction(22, 10) != 12)
                Assert.Fail();
        }

        [TestMethod()]
        public void Diviser()
        {
            Calculateur cal = new Calculateur();
            if (cal.Diviser(50, 5) != 10)
                Assert.Fail();
        }

        [TestMethod()]
        public void Multiplier()
        {
            Calculateur cal = new Calculateur();
            if (cal.Multiplier(10, 5) != 50)
                Assert.Fail();
        }

        [TestMethod()]
        public void Log()
        {
            Calculateur cal = new Calculateur();
            if (cal.Log(100, 10) != 2)
                Assert.Fail();
        }
    }
}