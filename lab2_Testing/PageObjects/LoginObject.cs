using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_Testing.PageObjects
{
    internal class LoginObject
    {
        private readonly IWebDriver driver;

        public LoginObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement UserNameElement => driver.FindElement(By.Id("user-name"));
        public IWebElement PasswordElement => driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => driver.FindElement(By.Id("login-button"));

        public void Login(string username, string password)
        {
            UserNameElement.SendKeys(username);
            PasswordElement.SendKeys(password);
            LoginButton.Click();
        }
    }
}
