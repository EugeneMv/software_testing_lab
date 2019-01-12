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
            PageFactory.InitElements(PageTest.browser, this);
        }
        [FindsBy(How = How.CssSelector, Using = "#flightsResultsMaster > div > div > div:nth-child(4)")]
        public IWebElement List;

        [FindsBy(How = How.Id, Using = "from1")]
        public IWebElement PlaceFrom;

        [FindsBy(How = How.Id, Using = "to1")]
        public IWebElement PlaceTo;

        [FindsBy(How = How.CssSelector, Using = "#dates")]
        public IWebElement Dates;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"datePickerContainer\"]/div/div[2]/table/tbody/tr[3]/td[1]")]
        public IWebElement DaysFrom;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"datePickerContainer\"]/div/div[2]/table/tbody/tr[4]/td[7]")]
        public IWebElement DaysTo;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"fltSearchForm\"]/button")]
        public IWebElement Submit;

    }
}
