using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject
{
    public class LoginPageTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions
            {
                UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore,
                AcceptInsecureCertificates = true
            };
             driver = new ChromeDriver(options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Открыть localhost5001
            driver.Url = "https://localhost:5001";
        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Quit();
        }

        [Test]
        public void PositiveTest()
        {
            //2.Введите логин test
            IWebElement loginField = driver.FindElement(By.XPath //*[@id='login']);
            loginField.SendKeys("test");
            IWebElement passwordField = driver.FindElement(By.XPath //*[@id='password']);
            passwordField.SendKeys("newyork1");
            IWebElement loginButton = driver.FindElement(By.XPath //*[@id="loginBtn"]);
            loginButton.Click();
            //3.Введите пароль newyork1
            //4.Нажмите логин
            //ех: юрл изменился
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.UrlContains("Calculator"));
            Assert.AreEqual("https://localhost:5001/Calculator", driver.Url);
        }

        [TestCase("User", "newyork1", "Incorrect password!")]
        [TestCase("test", "newyork", "Incorrect password!")]
        [TestCase("", "newyork1", "Incorrect user name!")]
        [TestCase("test", "", "Incorrect password!")]
        [TestCase("", "", "User not found!")]
        public void IncorrectLoginTest(string login, string password, string expectedError)
        {
            //2.Введите неправильный логин User
            IWebElement loginField = driver.FindElement(By.Id("login"));
            loginField.SendKeys(login);
            //3.Введите пароль neywork1
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys(password);
            //4.Нажмите логин
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));
            loginButton.Click();
            IWebElement errorMessage = driver.FindElement(By.Id("errorMessage"));

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.TextToBePresentInElement(errorMessage, expectedError));
            string ActualErrorMessage = errorMessage.Text;
            Assert.AreEqual(expectedError, ActualErrorMessage);
            //ex: появится сообщение об ошибке
        }

        [Test]
        public void LogOutTest()
        {
            //2.Введите логин test
            IWebElement loginField = driver.FindElement(By.Id("login"));
            loginField.SendKeys("test");
            //3.Введите пароль newyork1
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("newyork1");
            //4.Нажмите логин
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));
            loginButton.Click();
            driver.Url = "https://localhost:5001";
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.UrlContains("Calculator"));
            Assert.AreEqual("https://localhost:5001/Calculator", driver.Url);
            //ех: пользователь залогинен
        }
    }
}