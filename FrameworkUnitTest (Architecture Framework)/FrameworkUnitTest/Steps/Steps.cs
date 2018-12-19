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

        public bool SelectFirstTrip(string departureName, string destinationName)
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);        
            mainPage.InsertTrip(departureName, destinationName);         
            mainPage.ChooseTripDate();
            System.Threading.Thread.Sleep(1000);
            return true;
        }

        public bool StartSearchTickets()
        {
            FrameworkUnitTest.MainPage mainPage = new FrameworkUnitTest.MainPage(driver);
            mainPage.ClickOnSearchTickets();
            return true;
        }

        public void SelectPage()
        {
            FrameworkUnitTest.MainPage selectPage = new FrameworkUnitTest.MainPage(driver);
            selectPage.OpenPage();
        }
    }
}
