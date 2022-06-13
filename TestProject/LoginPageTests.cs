using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            //������� localhost5001
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
        }

        [TestCase("User", "newyork1", "Incorrect password!")]
        [TestCase("test", "newyork", "Incorrect password!")]
        [TestCase("", "newyork1", "Incorrect user name!")]
        [TestCase("test", "", "Incorrect password!")]
        [TestCase("", "", "User not found!")]
        public void IncorrectLoginTest(string login, string password, string expectedError)
        {
            //2.������� ������������ ����� User
            IWebElement loginField = driver.FindElement(By.Id("login"));
            loginField.SendKeys(login);
            //3.������� ������ neywork1
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys(password);
            //4.������� �����
            IWebElement loginButton = driver.FindElement(By.Id("loginBtn"));
            loginButton.Click();
            Thread.Sleep(2000);
            IWebElement errorMessage = driver.FindElement(By.Id("errorMessage"));
            string ActualErrorMessage = errorMessage.Text;
            Assert.AreEqual(expectedError, ActualErrorMessage);
            //ex: �������� ��������� �� ������
        }

        [Test]
        public void LogOutTest()
        {
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
            //��: ������������ ���������
        }

        [Test]
        public void PaswordTest()
        {
            IWebElement passwordLabel = driver.FindElement(By.ClassName("pass"));
            Assert.AreEqual("Password:", passwordLabel.Text);
        }
    }
}