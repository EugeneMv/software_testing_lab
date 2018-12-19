using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LabPageFactory
{
    class Program
    {
        public static IWebDriver browser;

        static void Main(string[] args)
        {
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("https://www.cheapair.com/");
            ClassPageFactory pageObject = new ClassPageFactory();

            pageObject.PlaceFrom.Clear();
            pageObject.PlaceFrom.SendKeys("Berlin, Germany");
            System.Threading.Thread.Sleep(1000);
            pageObject.PlaceFrom.Click();

            pageObject.Dates.Click();

            System.Threading.Thread.Sleep(1000);
            pageObject.DaysFrom.Click();
            System.Threading.Thread.Sleep(1000);
            pageObject.DaysTo.Click();
            System.Threading.Thread.Sleep(1000);
            pageObject.Submit.Click();
           
        }
    }
}
