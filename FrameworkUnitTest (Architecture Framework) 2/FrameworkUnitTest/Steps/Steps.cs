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

        public void SelectPage()
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);
            mainPage.OpenPage();
        }

        public void SelectTripsTwoWay(string departureName, string destinationName)
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);        
            mainPage.InsertTripTwoWay(departureName, destinationName);         
            mainPage.ChooseTrip2Dates();
            System.Threading.Thread.Sleep(1000);
        }

        public void SelectTripsOneWay(string departureName, string destinationName)
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);
            mainPage.InsertTripOneWay(departureName, destinationName);
            mainPage.ChooseTripDate();
            System.Threading.Thread.Sleep(1000);
        }

        public void SelectTripsTransfer(string departureName, string destinationName, string destinationName2)
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);
            mainPage.InsertTripTransfer(departureName, destinationName, destinationName2);
            System.Threading.Thread.Sleep(1000);
        }

        public void StartSearchTickets()
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);
            mainPage.ClickOnSearchTickets();
        }

        public void AddChild()
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);
            mainPage.AddChild();
        }

        public void AddSenior()
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);
            mainPage.AddSenior();
        }

        public void SelectFilterBusiness()
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);
            mainPage.SelectBusinessType();
        }

        public void ListPage()
        {
            FrameworkUnitTest.ListPage listPage = new FrameworkUnitTest.ListPage(driver);
            listPage.OpenPage();
        }

        public int ListCount()
        {
            FrameworkUnitTest.ListPage listPage = new FrameworkUnitTest.ListPage(driver);
            return listPage.Count();
        }

        public void SetTimeFilter()
        {
            FrameworkUnitTest.ListPage listPage = new FrameworkUnitTest.ListPage(driver);
            listPage.SetTimeFilter();
        }

        public void SetNonStopFilter()
        {
            FrameworkUnitTest.ListPage listPage = new FrameworkUnitTest.ListPage(driver);
            listPage.SetNonStopFilter();
        }

        public void SetAirportsFilter()
        {
            FrameworkUnitTest.ListPage listPage = new FrameworkUnitTest.ListPage(driver);
            listPage.SetAirportsFilter();
        }

        public bool CheckComparer()
        {
            FrameworkUnitTest.ListPage listPage = new FrameworkUnitTest.ListPage(driver);
            return listPage.CheckComparer();
        }

        public bool CheckPriceChild() {
            FrameworkUnitTest.ListPage listPage = new FrameworkUnitTest.ListPage(driver);
            return listPage.ComparePricesChild();
        }

        public bool CheckPriceSenior()
        {
            FrameworkUnitTest.ListPage listPage = new FrameworkUnitTest.ListPage(driver);
            return listPage.ComparePricesSenior();
        }
    }
}
