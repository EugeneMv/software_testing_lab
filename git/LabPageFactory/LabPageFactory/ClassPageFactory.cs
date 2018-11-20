using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LabPageFactory
{
    class ClassPageFactory
    {
        public ClassPageFactory()
        {
            PageFactory.InitElements(Program.browser, this);
        }

        [FindsBy(How = How.Id, Using = "to1")]
        public IWebElement PlaceFrom;

        [FindsBy(How = How.CssSelector, Using = "#dates")]
        public IWebElement Dates;

        [FindsBy(How = How.CssSelector, Using = "#datePickerContainer > div > div.ui-datepicker-group.ui-datepicker-group-last > table > tbody > tr:nth-child(4) > td:nth-child(1)")]
        public IWebElement DaysFrom;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"datePickerContainer\"]/div/div[2]/table/tbody/tr[4]/td[4]")]
        public IWebElement DaysTo;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"fltSearchForm\"]/button")]
        public IWebElement Submit;
    }
}
