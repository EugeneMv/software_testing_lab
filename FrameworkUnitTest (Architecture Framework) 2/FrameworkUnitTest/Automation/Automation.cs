using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace FrameworkUnitTest
{
    [TestFixture]
    class Automation
    {
        private FrameworkUnitTest.Steps steps = new FrameworkUnitTest.Steps();
        private const string depatureName = "Minsk, Belarus";
        private const string destinationName = "Berlin, Germany";
        private const string destinationName2 = "Frankfurt, Germany";
        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void TwoWayTrips()
        {
            steps.SelectMainPage();
            steps.InsertSelectionData2Way(depatureName, destinationName);
            steps.StartSearchTickets();
            steps.SelectListPage();

            Assert.AreNotEqual(steps.ListCount(), 0);
        }

        [Test]
        public void OneWayTrips()
        {
            steps.SelectMainPage();
            steps.InsertSelectionDataWay(depatureName, destinationName);
            steps.StartSearchTickets();
            steps.SelectListPage();

            Assert.AreNotEqual(steps.ListCount(), 0);
        }

        [Test]
        public void TripsWithTransfer()
        {
            steps.SelectMainPage();
            steps.InsertSelectionDataTransferWay(depatureName, destinationName, destinationName2);
            steps.StartSearchTickets();
            steps.SelectListPage();

            Assert.AreNotEqual(steps.ListCount(), 0);
        }

        [Test]
        public void BusinessTrip()
        {
            steps.SelectMainPage();
            steps.InsertBusinessSelectionData2Way(depatureName, destinationName);
            steps.StartSearchTickets();
            steps.SelectListPage();

            Assert.AreNotEqual(steps.ListCount(), 0);
        }

        [Test]
        public void TripWithTimeFilter()
        {
            steps.SelectMainPage();
            steps.InsertSelectionData2Way(depatureName, destinationName);
            steps.StartSearchTickets();
            steps.SelectListPage();
            steps.SetFilter(Steps.ListFilter.Time);

            Assert.AreNotEqual(steps.ListCount(), 0);
        }

        [Test]
        public void TripWithNonStopFilter()
        {
            steps.SelectMainPage();
            steps.InsertSelectionData2Way(depatureName, destinationName);
            steps.StartSearchTickets();
            steps.SelectListPage();
            steps.SetFilter(Steps.ListFilter.Nonstop);

            Assert.AreNotEqual(steps.ListCount(), 0);
        }

        [Test]
        public void TripWithAirportsFilter()
        {
            steps.SelectMainPage();
            steps.InsertSelectionData2Way(depatureName, destinationName);
            steps.StartSearchTickets();
            steps.SelectListPage();
            steps.SetFilter(Steps.ListFilter.Airports);

            Assert.AreNotEqual(steps.ListCount(), 0);
        }

        [Test]
        public void CompareTwoTrips()
        {
            steps.SelectMainPage();
            steps.InsertSelectionData2Way(depatureName, destinationName);
            steps.StartSearchTickets();
            steps.SelectListPage();

            Assert.IsTrue(steps.CheckComparer());
        }

        [Test]
        public void ComparePricesChild()
        {
            steps.SelectMainPage();
            steps.InsertSelectionData2Way(depatureName, destinationName);
            steps.AddPassenger(Steps.Passenger.Child);
            steps.StartSearchTickets();
            steps.SelectListPage();
            
            Assert.IsTrue(steps.CheckPrice(Steps.Passenger.Child));
        }

        [Test]
        public void ComparePricesSenior()
        {
            steps.SelectMainPage();
            steps.InsertSelectionData2Way(depatureName, destinationName);
            steps.AddPassenger(Steps.Passenger.Senior);
            steps.StartSearchTickets();
            steps.SelectListPage();

            Assert.IsTrue(steps.CheckPrice(Steps.Passenger.Senior));
        }
    }

}
