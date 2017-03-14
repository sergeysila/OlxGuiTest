using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace TestTaskOlx
{
    internal class MainPage 
    {
        public MainPage()
        {
            PageFactory.InitElements(DriverInit.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "postNewAdLink")]
        public IWebElement AdCreate { get; set; }

        public LoginPage CreateAd()
        {
            AdCreate.Click();
            DriverInit.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            return new LoginPage();
        }
    }
}
