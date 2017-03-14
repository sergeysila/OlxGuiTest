using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TestTaskOlx
{
    class CreateAdPage
    {
        public CreateAdPage()
        {
            PageFactory.InitElements(DriverInit.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "add-title")]
        public IWebElement Title { get; set; }

        [FindsBy(How = How.Id, Using = "add-description")]
        public IWebElement Description { get; set; }

        [FindsBy(How = How.Id, Using = "add-person")]
        public IWebElement PersonName { get; set; }

        [FindsBy(How = How.Id, Using = "add-phone")]
        public IWebElement Phone { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='box-free']/label[2]")]
        public IWebElement AdType { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='save']")]
        public IWebElement Submit { get; set; }


        public CreateAdPageSuccessful FillAdFrom()
        {
            Title.SendKeys("Отдам котенка бесплатно");
            Description.SendKeys("Отдам котенка бесплатно. Порода - персид. Окраска - серая");
            SelectSection();
            SelectAnimal();
            SelectRole();
            SelectLocation();
            AdType.Click();
            ScrollToElement(By.XPath("//*[@id='footerPartners']/span"));
            Submit.Click();
            return new CreateAdPageSuccessful();
        }

        public void SelectSection()
        {
            DriverInit.Driver.FindElement(By.XPath(".//*[@id='targetrenderSelect1-0']/dt/a")).Click();
            DriverInit.Driver.FindElement(By.XPath(".//*[@id='cat-35']/span[1]")).Click();
            DriverInit.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            DriverInit.Driver.FindElement(By.XPath("//*[@id='category-35']//li[1]/a")).Click();
            //DriverInit.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void SelectAnimal()
        {
            WaitForElementLoad(By.XPath("//*[@id='targetparam434']/dt/a"),3);
            DriverInit.Driver.FindElement(By.XPath("//*[@id='targetparam434']/dt/a")).Click();
            DriverInit.Driver.FindElement(By.XPath("//*[@id='targetparam434']//li[4]/a")).Click();
            
        }

        public void SelectRole()
        {
            DriverInit.Driver.FindElement(By.XPath("//*[@id='targetid_private_business']/dt/a")).Click();
            DriverInit.Driver.FindElement(By.XPath("//*[@id='targetid_private_business']//li[2]/a")).Click();
        }

        public void SelectLocation()
        {
            DriverInit.Driver.FindElement(By.XPath("//*[@id='mapAddress']")).Clear();
            DriverInit.Driver.FindElement(By.XPath("//*[@id='mapAddress']")).Click();
            DriverInit.Driver.FindElement(By.XPath("//*[@id='mapAddress']")).SendKeys("Киев");
            DriverInit.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            DriverInit.Driver.FindElement(By.XPath("//*[@id='autosuggest-geo-ul']/li[1]/a")).Click();
            DriverInit.Driver.FindElement(By.XPath("//*[@id='add-phone']")).Clear();
            DriverInit.Driver.FindElement(By.XPath("//*[@id='add-phone']")).SendKeys("0990007856");
        }

        public void ScrollToElement(By selector)
        {
            var element = DriverInit.Driver.FindElement(selector);
            Actions actions = new Actions(DriverInit.Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
        

        public static void WaitForElementLoad(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(DriverInit.Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
        }

    }
}
