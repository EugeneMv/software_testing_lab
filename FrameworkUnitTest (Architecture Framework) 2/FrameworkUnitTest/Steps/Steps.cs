using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Security.Policy;
using System.Threading;
using System.Globalization;

namespace FrameworkUnitTest
{
    class Steps
    {
        IWebDriver driver;
        public void InitBrowser()
        {
            driver = FrameworkUnitTest.Instance.GetInstance();
        }

        public void CloseBrowser()
        {
            FrameworkUnitTest.Instance.CloseBrowser();
        }

        public void SelectMainPage()
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);
            mainPage.OpenPage();
        }

        public void SelectListPage()
        {
            FrameworkUnitTest.ListPage listPage = new FrameworkUnitTest.ListPage(driver);
            listPage.OpenPage();
        }

        public void InsertSelectionData2Way(string departureName, string destinationName)
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);
            mainPage.InsertDeparturePlace(departureName);
            mainPage.InsertDestinationPlace(destinationName);
            mainPage.ToCalendar();
            mainPage.ChooseTripDateFrom();
            mainPage.ChooseTripDateTo();
        }

        public void InsertSelectionDataWay(string departureName, string destinationName)
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);
            mainPage.SetType(MainPage.Types.OneWay);
            mainPage.InsertDeparturePlace(departureName);
            mainPage.InsertDestinationPlace(destinationName);
            mainPage.ToCalendar();
            mainPage.ChooseTripDateFrom();
        }

        public void InsertSelectionDataTransferWay(string departureName, string destinationName, string destinationName2)
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);
            mainPage.SetType(MainPage.Types.Transfer);
            mainPage.InsertDeparturePlace(departureName);
            mainPage.InsertDestinationPlace(destinationName);
            mainPage.ChooseTripDateFrom();
            mainPage.AddLeg();
            mainPage.InsertDestination2Place(destinationName2);
            mainPage.ChooseTripDateTo();
        }

        public void InsertBusinessSelectionData2Way(string departureName, string destinationName)
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);
            mainPage.InsertDeparturePlace(departureName);
            mainPage.InsertDestinationPlace(destinationName);
            mainPage.ToCalendar();
            mainPage.ChooseTripDateFrom();
            mainPage.ChooseTripDateTo();
            mainPage.SetBusinessType();
        }


        public void StartSearchTickets()
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);
            mainPage.ClickOnSearchTickets();
        }
        
        public int ListCount()
        {
            FrameworkUnitTest.ListPage listPage = new FrameworkUnitTest.ListPage(driver);
            return listPage.Count();
        }

        public enum ListFilter
        {
            Time,
            Nonstop,
            Airports
        }

        public void SetFilter(ListFilter filter)
        {
            FrameworkUnitTest.ListPage listPage = new FrameworkUnitTest.ListPage(driver);
            switch (filter)
            {
                case ListFilter.Airports:
                    listPage.SetAirportsFilter();
                    break;
                case ListFilter.Time:
                    listPage.SetTimeFilter();
                    break;
                case ListFilter.Nonstop:
                    listPage.SetNonStopFilter();
                    break;
            }
        }
       
        public bool CheckComparer()
        {
            ListPage listPage = new ListPage(driver);
            return listPage.CheckComparer();
        }

        public bool CheckPrice(Passenger passenger) {
            ListPage listPage = new ListPage(driver);
            double first_price = 0, second_price = 0;
            listPage.OpenReviewTrips();
            
            switch (passenger)
            {
                case Passenger.Child:
                    first_price = double.Parse(listPage.FirstPriceC.Text, CultureInfo.InvariantCulture);
                    second_price = double.Parse(listPage.SecondPriceC.Text, CultureInfo.InvariantCulture);
                    break;
                case Passenger.Senior:
                    first_price = double.Parse(listPage.FirstPriceS.Text, CultureInfo.InvariantCulture);
                    second_price = double.Parse(listPage.SecondPriceS.Text, CultureInfo.InvariantCulture);
                    break;
            }
            var current_price = double.Parse(listPage.CurrentPriceS.Text, CultureInfo.InvariantCulture);
            
            return Math.Abs((first_price + second_price) - current_price) < 0.01;
        }

        public enum Passenger
        {
            Child,
            Senior
        }

        public void AddPassenger(Passenger passenger)
        {
            MainPage mainPage = new MainPage(driver);
            switch (passenger)
            {
                case Passenger.Child:
                    mainPage.AddChild();
                    break;
                case Passenger.Senior:
                    mainPage.AddSenior();
                    break;
            }
        }
    }
}
