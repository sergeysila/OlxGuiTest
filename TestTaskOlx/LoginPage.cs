using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestTaskOlx
{
    internal class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(DriverInit.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@class='login-page']//*[@id='userEmail']")]
        public IWebElement UserEmail { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='login-page']//*[@id='userPass']")]
        public IWebElement UserPass { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='login-page']//*[@id='se_userLogin']")]
        public IWebElement SubmitLogin { get; set; }

        public CreateAdPage FillLoginForm(string email, string password)
        {
            UserEmail.SendKeys(email);
            UserPass.SendKeys(password);
            SubmitLogin.Click();
            return new CreateAdPage();
        }
    }
}
