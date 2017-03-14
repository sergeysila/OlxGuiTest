using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace TestTaskOlx
{
    internal class Tests
    {
        private static void Main()
        {
            
        }

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
            MainPage mainPage = new MainPage();
            LoginPage loginPage = mainPage.CreateAd();
            CreateAdPage createAdPage = loginPage.FillLoginForm("sasha_olx@binka.me", "qwerty");
            CreateAdPageSuccessful success = createAdPage.FillAdFrom();
            success.IsEqual();
        }

        [TearDown]
        public void Close()
        {
            DriverInit.Driver.Close();
        }
    }
}
