using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResistanceCalculator.Services;
using ResistanceCaluclator.Models;
using ResistanceCalculator.ViewModels;

namespace ResistanceCalculator.Controllers
{
    public class HomeController : Controller
    {
        private ICalculatorService _calculatorService;

        public HomeController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dropDownValues = await _calculatorService.GetCalculatorViewModel();
            return View(dropDownValues);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CalculatorViewModel calculatorViewModel)
        {
            var firstBandValue = calculatorViewModel.FirstBandSelectedValue;
            var secondBandValue = calculatorViewModel.SecondBandSelectedValue;
            var multiplierValue = calculatorViewModel.MultiplierSelectedValue;
            var toleranceValue = calculatorViewModel.ToleranceSelectedValue;
            var ohmValue = await _calculatorService.CalculateOhmValue(firstBandValue, secondBandValue,multiplierValue,toleranceValue );
            calculatorViewModel.OhmsValue = ohmValue;
            calculatorViewModel.BandValues = await _calculatorService.GetBandColorValues();
            calculatorViewModel.MultiplierValues = await _calculatorService.GetMultiplierBandValues();
            calculatorViewModel.ToleranceValues = await _calculatorService.GetToleranceBandValues();
            return View(calculatorViewModel);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
