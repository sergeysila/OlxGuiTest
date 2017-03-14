using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestTaskOlx
{
    class CreateAdPageSuccessful
    {
        public CreateAdPageSuccessful()
        {
            PageFactory.InitElements(DriverInit.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//p[text()='Ваше объявление принято']")]
        public IWebElement SuccessBox { get; set; }

        public void IsEqual()
        {
            string successText = "Ваше объявление принято";
            Assert.AreEqual(SuccessBox.Text, successText);
        }
    }
}
