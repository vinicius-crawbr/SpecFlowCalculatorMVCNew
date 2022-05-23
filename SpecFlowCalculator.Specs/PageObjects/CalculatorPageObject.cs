using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowCalculator.Specs.Support;
using System;
namespace SpecFlowCalculator.Specs.PageObjects
{
    public class CalculatorPageObject
    {
        private readonly IConfiguration _configuration;
        private IWebDriver _driver;

        public CalculatorPageObject(IConfiguration configuration)
        {
            _configuration = configuration;
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");
            chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.Off);
            chromeOptions.SetLoggingPreference(LogType.Driver, LogLevel.Off);

            if (!String.IsNullOrWhiteSpace(_configuration["PathDriveChrome"]))
            {
                _driver = new ChromeDriver(_configuration["PathDriveChrome"], chromeOptions);
            }
            else
                _driver = new ChromeDriver(chromeOptions);


        }
        public void CarregarPagina()
        {
            _driver.IrParaPagina(TimeSpan.FromSeconds(Convert.ToInt32(_configuration["Timeout"])), _configuration["UrlLogin"]);
        }

        public string GetUrl()
        {
            string stringAtual = _driver.Url;
            return stringAtual;
        }

        public void SetAlfanumerico(string nameInput, int number)
        {
            //_driver.AtualizarPagina();
            _driver.SetText(By.Name(nameInput), number);
            _driver.Aguarde(1000);
        }
        public void Click(string nameButton)
        {
            _driver.ClickButton(By.Id(nameButton));
            _driver.Aguarde(1000);
        }
        public string Input()
        {
            string resultInput = _driver.GetInput(By.Id("result"));
            _driver.Aguarde(1000);
            return resultInput;

        }

        public void FecharPagina()
        {
            _driver!.Quit();
            _driver = null;
        }

    }



}
