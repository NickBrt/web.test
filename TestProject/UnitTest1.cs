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
            //            1.������� localhost5001
            driver.Url = "https://localhost:5001";
            //2.������� ����� test
            IWebElement loginField = driver.FindElement(By.Id("login"));
            loginField.SendKeys("test");
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("newyork1");
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));
            loginButton.Click();
            //3.������� ������ �����
            //4.������� �����
            Thread.Sleep(2000);
            //��: ��� ���������
            Assert.AreEqual("https://localhost:5001/Calculator", driver.Url);
            driver.Quit();
        }

        [Test]
        public void IncorrectLoginTest()
        {
            var options = new ChromeOptions
            {
                UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore,
                AcceptInsecureCertificates = true
            };
            IWebDriver driver = new ChromeDriver(options);
            //            1.������� localhost: 5001
            driver.Url = "https://localhost:5001";
            //2.������� ������������ ����� User
            IWebElement loginField = driver.FindElement(By.Id("login"));
            loginField.SendKeys("User");
            //3.������� ������ neywork1
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("newyork1");
            //4.������� �����
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));
            loginButton.Click();
            Thread.Sleep(2000);
            IWebElement errorMessage = driver.FindElement(By.Id("errorMessage"));
            string ActualErrorMessage = errorMessage.Text;
            Assert.AreEqual("Incorrect password!", ActualErrorMessage);
            driver.Quit();
            //ex: �������� ��������� �� ������
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
            //            1.������� localhost: 5001
            driver.Url = "https://localhost:5001";
            //2.������� ����� test
            IWebElement loginField = driver.FindElement(By.Id("login"));
            loginField.SendKeys("test");
            //3.������� ������������ ������ newyork
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("newyork");
            //4.������� �����
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));
            loginButton.Click();
            Thread.Sleep(2000);
            IWebElement errorMessage = driver.FindElement(By.Id("errorMessage"));
            string ActualErrorMessage = errorMessage.Text;
            Assert.AreEqual("Incorrect password!", ActualErrorMessage);
            driver.Quit();
            //ex.�������� ��������� �� ������, IncorrectPassword!
        }

        [Test]
        public void BlankLoginFieldTest()
        {
            var options = new ChromeOptions
            {
                UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore,
                AcceptInsecureCertificates = true
            };
            IWebDriver driver = new ChromeDriver(options);
            //            1.������� localhost: 5001
            driver.Url = "https://localhost:5001/";
            //2.������� ������ newyork1
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("newyork1");
            //3.������� �����
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));
            loginButton.Click();
            Thread.Sleep(2000);
            IWebElement errorMessage = driver.FindElement(By.Id("errorMessage"));
            string ActualErrorMessage = errorMessage.Text;
            Assert.AreEqual("Incorrect user name!", ActualErrorMessage);
            driver.Quit();
            //ex: �������� ��������� �� ������, Incorrect user name!
        }

        [Test]
        public void BlankPasswordFieldTest()
        {
            var options = new ChromeOptions
            {
                UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore,
                AcceptInsecureCertificates = true
            };
            IWebDriver driver = new ChromeDriver(options);
            //            1.������� localhost: 5001
            driver.Url = "https://localhost:5001/";
            //2.������� ����� test
            IWebElement loginField = driver.FindElement(By.Id("login"));
            loginField.SendKeys("test");
            //3.������� �����
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));
            loginButton.Click();
            Thread.Sleep(2000);
            IWebElement errorMessage = driver.FindElement(By.Id("errorMessage"));
            string ActualErrorMessage = errorMessage.Text;
            Assert.AreEqual("Incorrect password!", ActualErrorMessage);
            driver.Quit();
            //ex.�������� ��������� �� ������, Incorrect Password!
        }

        [Test]
        public void BlankFieldsTest()
        {
            var options = new ChromeOptions
            {
                UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore,
                AcceptInsecureCertificates = true
            };
            IWebDriver driver = new ChromeDriver(options);
            //            1.������� localhost: 5001
            driver.Url = "https://localhost:5001/";
            //2.������� �����
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));
            loginButton.Click();
            Thread.Sleep(2000);
            IWebElement errorMessage = driver.FindElement(By.Id("errorMessage"));
            string ActualErrorMessage = errorMessage.Text;
            Assert.AreEqual("User not found!", ActualErrorMessage);
            driver.Quit();
            //ex: �������� ��������� �� ������, User not found!
        }

        [Test]
        public void LogOutTest()
        {
            var options = new ChromeOptions
            {
                UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore,
                AcceptInsecureCertificates = true
            };
            IWebDriver driver = new ChromeDriver(options);
            //������� localhost5001
            driver.Url = "https://localhost:5001";
            //2.������� ����� test
            IWebElement loginField = driver.FindElement(By.Id("login"));
            loginField.SendKeys("test");
            //3.������� ������ newyork1
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("newyork1");
            //4.������� �����
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));
            loginButton.Click();
            driver.Url = "https://localhost:5001";
            Thread.Sleep(2000);
            Assert.AreEqual("https://localhost:5001/Calculator", driver.Url);
            driver.Quit();
            //��: ������������ ���������
        }
    }
}