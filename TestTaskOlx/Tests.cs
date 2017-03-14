using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace TestTaskOlx
{
    internal class Tests
    {
        [SetUp]
        public void Open()
        {
            DriverInit.Driver = new ChromeDriver();
            DriverInit.Driver.Navigate().GoToUrl("https://www.olx.ua");
            DriverInit.Driver.Manage().Window.Maximize();
        }

        [Test]
        public void AdCreationTest()
        {
            var mainPage = new MainPage();
            var loginPage = mainPage.CreateAd();
            var createAdPage = loginPage.FillLoginForm("sasha_olx@binka.me", "qwerty");
            var success = createAdPage.FillAdFrom();
            success.IsEqual();
        }

        [TearDown]
        public void Close()
        {
            DriverInit.Driver.Close();
        }
    }
}
