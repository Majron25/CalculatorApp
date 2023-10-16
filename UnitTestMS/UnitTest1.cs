namespace UnitTestMS
{
    [TestClass]
    public class CalculatorTests
    {
        private IWebDriver _driverChrome;
        private IWebDriver _driverFirefox;

        [TestInitialize]
        public void Initialize()
        {
            _driverChrome = new ChromeDriver(); // You can use other browsers as well
            _driverFirefox = new FirefoxDriver();
        }

        [TestMethod]
        public void TestCalculatorChrome()
        {
            _driverChrome.Navigate().GoToUrl("https://sdcalculatorappweb.azurewebsites.net/");

            IWebElement num1 = _driverChrome.FindElement(By.Id("txtNum1"));
            num1.SendKeys("10");

            IWebElement num2 = _driverChrome.FindElement(By.Id("txtNum2"));
            num2.SendKeys("5");

            IWebElement operation = _driverChrome.FindElement(By.Id("operation"));
            operation.SendKeys("+");

            IWebElement calculateButton = _driverChrome.FindElement(By.XPath("//input[@value='Calculate']"));
            calculateButton.Click();

            IWebElement resultLabel = _driverChrome.FindElement(By.Id("lblResult"));
            Assert.AreEqual("Result: 15", resultLabel.Text);
        }

        [TestMethod]
        public void TestCalculatorFirefox()
        {
            _driverFirefox.Navigate().GoToUrl("https://sdcalculatorappweb.azurewebsites.net/");

            IWebElement num1 = _driverFirefox.FindElement(By.Id("txtNum1"));
            num1.SendKeys("10");

            IWebElement num2 = _driverFirefox.FindElement(By.Id("txtNum2"));
            num2.SendKeys("5");

            IWebElement operation = _driverFirefox.FindElement(By.Id("operation"));
            operation.SendKeys("+");

            IWebElement calculateButton = _driverFirefox.FindElement(By.XPath("//input[@value='Calculate']"));
            calculateButton.Click();

            IWebElement resultLabel = _driverFirefox.FindElement(By.Id("lblResult"));
            Assert.AreEqual("Result: 15", resultLabel.Text);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driverChrome.Quit();
            _driverFirefox.Quit();
        }
    }
}