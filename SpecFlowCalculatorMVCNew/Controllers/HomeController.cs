using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpecFlowCalculatorMVCNew.Models;


namespace SpecFlowCalculatorMVCNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly Calculator _calculator;


        public HomeController()
        {
            _calculator = new Calculator();
        }

        public IActionResult Index(CalculatorViewModel calculatorViewModel)
        {
            return View(calculatorViewModel);
        }

        public IActionResult Add(CalculatorViewModel calculatorViewModel)
        {
            calculatorViewModel.Result = _calculator.Add(calculatorViewModel.FirstNumber, calculatorViewModel.SecondNumber);
            return View("index", calculatorViewModel);
        }
        public IActionResult Subtract(CalculatorViewModel calculatorViewModel)
        {
            calculatorViewModel.Result = _calculator.Subtract(calculatorViewModel.FirstNumber, calculatorViewModel.SecondNumber);
            return View("index", calculatorViewModel);
        }

        public IActionResult Multiply(CalculatorViewModel calculatorViewModel)
        {
            calculatorViewModel.Result = _calculator.Multiply(calculatorViewModel.FirstNumber, calculatorViewModel.SecondNumber);
            return View("index", calculatorViewModel);

        }

        public IActionResult Divide(CalculatorViewModel calculatorViewModel)
        {
            calculatorViewModel.Result = _calculator.Divide(calculatorViewModel.FirstNumber, calculatorViewModel.SecondNumber);
            return View("index", calculatorViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}