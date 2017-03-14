using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestTaskOlx
{
    internal class CreateAdPageSuccessful
    {
        public CreateAdPageSuccessful()
        {
            PageFactory.InitElements(DriverInit.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//p[text()='Ваше объявление принято!']")]
        public IWebElement SuccessBox { get; set; }

        public void IsEqual()
        {
            const string successText = "Ваше объявление принято!";
            Assert.AreEqual(SuccessBox.Text, successText);
        }
    }
}
