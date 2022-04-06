using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PositiveTest()
       {
            var options = new ChromeOptions
            {
                UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore,
                AcceptInsecureCertificates = true
            };
            IWebDriver driver = new ChromeDriver(options);
            //            1.Открыть localhost5001
            driver.Url = "https://localhost:5001";
            //2.Введите логин test
            IWebElement loginField = driver.FindElement(By.Id("login"));
            loginField.SendKeys("test");
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("newyork1");
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));
            loginButton.Click();
            //3.Введите пароль нбпбо
            //4.Нажмите логин
            Thread.Sleep(2000);
            //ех: юрл изменился
            Assert.AreEqual("https://localhost:5001/Calculator", driver.Url);
            driver.Quit();
        }

        [Test]
        public void IncorrectPasswordTest()
        {
            var options = new ChromeOptions
            {
                UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore,
                AcceptInsecureCertificates = true
            };
            IWebDriver driver = new ChromeDriver(options);
            //            1.Открыть localhost: 5001
            driver.Url = "https://localhost:5001";
            //2.Введите неправильный логин User
            IWebElement loginField = driver.FindElement(By.Id("login"));
            loginField.SendKeys("User");
            //3.Введите пароль neywork1
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("newyork1");
            //4.Нажмите логин
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));
            loginButton.Click();
            Thread.Sleep(2000);
            IWebElement errorMessage = driver.FindElement(By.Id("errorMessage"));
            string ActualErrorMessage = errorMessage.Text;
            Assert.AreEqual("Incorrect password!", ActualErrorMessage);
            driver.Quit();
        //ex: появится сообщение об ошибке
        }
    }
}