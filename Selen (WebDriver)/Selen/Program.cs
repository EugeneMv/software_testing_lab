using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace Selen
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.cheapair.com/");

                Thread.Sleep(2000);

                var inputFrom = driver.FindElement(By.Id("to1"));
                inputFrom.Click();
                inputFrom.Clear();
                inputFrom.SendKeys("Berlin, Germany");
                inputFrom.Click();
                Thread.Sleep(1000);

                //  var button = driver.FindElement(By.ClassName("btn large block"));
                // button.Click();
                // Set dates
                var dates = driver.FindElement(By.CssSelector("#dates"));
                dates.Click();

               // dateFrom.Click();
                Thread.Sleep(1000);
                var daysFrom = driver.FindElement(By.CssSelector("#datePickerContainer > div > div.ui-datepicker-group.ui-datepicker-group-last > table > tbody > tr:nth-child(4) > td:nth-child(1)"));
                daysFrom.Click();
                Thread.Sleep(500);

                var daysTo = driver.FindElement(By.XPath("//*[@id=\"datePickerContainer\"]/div/div[2]/table/tbody/tr[4]/td[4]"));
                daysTo.Click();
                Thread.Sleep(1000);

                var subm = driver.FindElement(By.XPath("//*[@id=\"fltSearchForm\"]/button"));
                subm.Click();
                Thread.Sleep(4000);

            }
        }
    }
}
