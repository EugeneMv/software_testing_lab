﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace FrameworkUnitTest
{
    [TestFixture]
    class Automation
    {
        private FrameworkUnitTest.Steps steps = new FrameworkUnitTest.Steps();
        private const string depatureName = "";
        private const string destinationName = "Berlin, Germany";
        private bool status = false;
        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
            System.Threading.Thread.Sleep(1000);
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void WhenDestinationEqualDeparture()
        {
            steps.SelectPage();
            steps.SelectFirstTrip(depatureName, destinationName);
            status = steps.StartSearchTickets();
            NUnit.Framework.Assert.AreEqual(status, true);
        }
    }

}
