namespace UnitTestMS
{
    [TestClass]
    public class CalculatorTests
    {
        private IWebDriver _driver;

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver(); // You can use other browsers as well
        }

        [TestMethod]
        public void TestCalculator()
        {
            _driver.Navigate().GoToUrl("https://sdcalculatorappweb.azurewebsites.net/");

            IWebElement num1 = _driver.FindElement(By.Id("txtNum1"));
            num1.SendKeys("10");

            IWebElement num2 = _driver.FindElement(By.Id("txtNum2"));
            num2.SendKeys("5");

            IWebElement operation = _driver.FindElement(By.Id("operation"));
            operation.SendKeys("+");

            IWebElement calculateButton = _driver.FindElement(By.XPath("//input[@value='Calculate']"));
            calculateButton.Click();

            IWebElement resultLabel = _driver.FindElement(By.Id("lblResult"));
            Assert.AreEqual("Result: 15", resultLabel.Text);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}