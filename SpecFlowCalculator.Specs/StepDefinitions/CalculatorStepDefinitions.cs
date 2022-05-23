
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Globalization;

using SpecFlowCalculator.Specs.PageObjects;

namespace SpecFlowCalculator.Specs.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private static readonly IConfiguration _configuration;
        private int _firstNumber;
        private int _secondNumber;
        private string _result;


        static CalculatorStepDefinitions()
        {
            _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .AddEnvironmentVariables().Build();
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _firstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {

            _secondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            var configPage = new CalculatorPageObject(_configuration);
            configPage.CarregarPagina();
            configPage.SetAlfanumerico("FirstNumber", _firstNumber);
            configPage.SetAlfanumerico("SecondNumber", _secondNumber);
            configPage.Click("add");
            _result = configPage.Input();
            configPage.FecharPagina();


        }
        [When("the two numbers are subtract")]
        public void WhenTheTwoNumbersAreSubtract()
        {
            var configPage = new CalculatorPageObject(_configuration);
            configPage.CarregarPagina();
            configPage.SetAlfanumerico("FirstNumber", _firstNumber);
            configPage.SetAlfanumerico("SecondNumber", _secondNumber);
            configPage.Click("subtract");
            _result = configPage.Input();
            configPage.FecharPagina();

        }
        [When("the two numbers are multiply")]
        public void WhenTheTwoNumbersAreMultiply()
        {
            var configPage = new CalculatorPageObject(_configuration);
            configPage.CarregarPagina();
            configPage.SetAlfanumerico("FirstNumber", _firstNumber);
            configPage.SetAlfanumerico("SecondNumber", _secondNumber);
            configPage.Click("multiply");
            _result = configPage.Input();
            configPage.FecharPagina();

        }
        [When("the two numbers are divide")]
        public void WhenTheTwoNumbersAreDivide()
        {
            var configPage = new CalculatorPageObject(_configuration);
            configPage.CarregarPagina();
            configPage.SetAlfanumerico("FirstNumber", _firstNumber);
            configPage.SetAlfanumerico("SecondNumber", _secondNumber);
            configPage.Click("divide");
            _result = configPage.Input();
            configPage.FecharPagina();
        }
        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string result)
        {
            _result.Should().Be(result);

        }
    }
}