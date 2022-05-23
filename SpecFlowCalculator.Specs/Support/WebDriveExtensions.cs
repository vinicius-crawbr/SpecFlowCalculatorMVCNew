using System;
using OpenQA.Selenium;

namespace SpecFlowCalculator.Specs.Support
{
    public static class WebDriveExtensions
    {
        public static void IrParaPagina(this IWebDriver driver, TimeSpan timeToWait, string UrlLogin)
        {
            driver.Manage().Timeouts().PageLoad = timeToWait;
            driver.Navigate().GoToUrl(UrlLogin);
            driver.Manage().Window.Maximize();

        }

        public static void AtualizarPagina(this IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }

        public static void Aguarde(this IWebDriver driver, int ms)
        {
            Thread.Sleep(ms);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static IWebElement SetText(this IWebDriver driver, By by, int number)
        {
            IWebElement element = driver.FindElement(by);
            element.Clear();
            element.SendKeys(number.ToString());
            return element;
        }

        public static void ClickButton(this IWebDriver driver, By by)
        {
            driver.FindElement(by).Submit();
        }
        public static string GetInput(this IWebDriver driver, By by)
        {
            string result = driver.FindElement(by).GetAttribute("value");
            return result;
        }
    }
}
