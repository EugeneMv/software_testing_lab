using System;
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
        private const string depatureName = "Minsk, Belarus";
        private const string destinationName = "Berlin, Germany";
        private const string destinationName2 = "Paris, France";
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
        public void TwoWayTrips()
        {
            steps.SelectPage();
            steps.SelectTripsTwoWay(depatureName, destinationName);
            steps.StartSearchTickets();
            steps.ListPage();

            var count = steps.ListCount();
            NUnit.Framework.Assert.AreNotEqual(count, 0);
        }

        [Test]
        public void OneWayTrips()
        {
            steps.SelectPage();
            steps.SelectTripsOneWay(depatureName, destinationName);
            steps.StartSearchTickets();
            steps.ListPage();

            var count = steps.ListCount();
            NUnit.Framework.Assert.AreNotEqual(count, 0);
        }

        [Test]
        public void TripsWithTransfer()
        {
            steps.SelectPage();
            steps.SelectTripsTransfer(depatureName, destinationName, destinationName2);
            steps.StartSearchTickets();
            steps.ListPage();

            var count = steps.ListCount();
            NUnit.Framework.Assert.AreNotEqual(count, 0);
        }

        [Test]
        public void BusinessTrip()
        {
            steps.SelectPage();
            steps.SelectTripsTwoWay(depatureName, destinationName);
            steps.SelectFilterBusiness();
            steps.StartSearchTickets();
            steps.ListPage();

            var count = steps.ListCount();
            NUnit.Framework.Assert.AreNotEqual(count, 0);
        }

        [Test]
        public void TripWithTimeFilter()
        {
            steps.SelectPage();
            steps.SelectTripsTwoWay(depatureName, destinationName);
            steps.StartSearchTickets();
            steps.ListPage();
            steps.SetTimeFilter();

            var count = steps.ListCount();
            NUnit.Framework.Assert.AreNotEqual(count, 0);
        }

        [Test]
        public void TripWithNonStopFilter()
        {
            steps.SelectPage();
            steps.SelectTripsTwoWay(destinationName, destinationName2);
            steps.StartSearchTickets();
            steps.ListPage();
            steps.SetNonStopFilter();

            var count = steps.ListCount();
            NUnit.Framework.Assert.AreNotEqual(count, 0);
        }

        [Test]
        public void TripWithAirportsFilter()
        {
            steps.SelectPage();
            steps.SelectTripsTwoWay(destinationName, destinationName2);
            steps.StartSearchTickets();
            steps.ListPage();
            steps.SetAirportsFilter();

            var count = steps.ListCount();
            NUnit.Framework.Assert.AreNotEqual(count, 0);
        }

        [Test]
        public void CompareTwoTrips()
        {
            steps.SelectPage();
            steps.SelectTripsTwoWay(destinationName, destinationName2);
            steps.StartSearchTickets();
            steps.ListPage();

            NUnit.Framework.Assert.IsTrue(steps.CheckComparer());
        }

        [Test]
        public void ComparePricesChild()
        {
            steps.SelectPage();
            steps.SelectTripsTwoWay(depatureName, destinationName);
            steps.AddChild();
            steps.StartSearchTickets();
            steps.ListPage();

            var count = steps.ListCount();
            NUnit.Framework.Assert.IsTrue(steps.CheckPriceChild());
        }

        [Test]
        public void ComparePricesSenior()
        {
            steps.SelectPage();
            steps.SelectTripsTwoWay(depatureName, destinationName);
            steps.AddSenior();
            steps.StartSearchTickets();
            steps.ListPage();

            var count = steps.ListCount();
            NUnit.Framework.Assert.IsTrue(steps.CheckPriceSenior());
        }
    }

}
