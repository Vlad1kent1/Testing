using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using lab2_Testing.PageObjects;


namespace lab2_Testing.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginObject loginPage;

        [Given("I navigate to the SauceDemo login page")]
        public void GivenINavigateToTheSauceDemoLoginPage()
        {
            driver = new ChromeDriver("C:/Users/Admin/.cache/selenium/chromedriver/win64/118.0.5993.70/chromedriver.exe");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPage = new LoginObject(driver);
        }

        [When(@"I login with username ""(.*)"" and password ""(.*)""")]
        public void WhenILoginWithUsernameAndPassword(string username, string password)
        {
            loginPage.Login(username, password);
        }

        [Then("I should be redirected to the inventory page")]
        public void ThenIShouldBeRedirectedToTheInventoryPage()
        {
            IWebElement inventorySidebar = driver.FindElement(By.Id("inventory_container"));
            Assert.IsTrue(inventorySidebar.Displayed);
        }

        [Then("I should see the error message")]
        public void ThenIShouldSeeTheErrorMessage()
        {
            IWebElement inventoryHeader = driver.FindElement(By.ClassName("error-message-container"));
            Assert.IsTrue(inventoryHeader.Displayed);
        }

        [After]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
