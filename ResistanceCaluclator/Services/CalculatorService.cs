using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResistanceCalculator.ViewModels;

namespace ResistanceCalculator.Services
{
    
    public class CalculatorService : ICalculatorService
    {
        
        public async Task<Dictionary<string, int>> GetBandColorValues()
        {
            var dictionary = new Dictionary<string, int>
            {
                {"Black", 0},
                {"Brown", 1},
                {"Red", 2},
                {"Orange", 3},
                {"Yellow",4},
                {"Green", 5},
                {"Blue", 6},
                {"Violet", 7},
                {"Grey", 8},
                {"White", 9}
            };
            return await Task.FromResult(dictionary);
        }


        public async Task<Dictionary<string, double>> GetMultiplierBandValues()
        {
            var dictionary = new Dictionary<string, double>
            {
                {"Black", 1},
                {"Brown", 10},
                {"Red", 100},
                {"Orange", 1000},
                {"Yellow", 10000},
                {"Green", 100000},
                {"Blue", 1000000},
                {"Gold", 0.1},
                {"Silver", 0.01}
            };

           
            return await  Task.FromResult(dictionary);
        }


        public async Task<Dictionary<string, double>> GetToleranceBandValues()
        {
            var dictionary = new Dictionary<string, double>
            {
                
                {"Brown", 0.01},
                {"Red", 0.02},
                {"Orange", 0.03},
                {"Yellow", 0.04},
                {"Green", 0.005},
                {"Blue", 0.0025},
                {"Violet", 0.001},
                {"Grey", 0.0005},
                {"Gold", 0.05},
                {"Silver", 0.1}
            };
            return await Task.FromResult(dictionary);
        }


        public async Task<int> CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {

            if(string.IsNullOrEmpty(bandAColor) || string.IsNullOrEmpty(bandBColor) || string.IsNullOrEmpty(bandCColor) || string.IsNullOrEmpty(bandDColor))
                throw new ArgumentException("bandValues cannot be null");


            var calculatorViewModel = await GetCalculatorViewModel();

            var bandValuesLookup = calculatorViewModel.BandValues;
            var bandMultiplierLookup = calculatorViewModel.MultiplierValues;
            var bandToleranceLookup = calculatorViewModel.ToleranceValues;


            bandValuesLookup.TryGetValue(bandAColor,out var bandAValue);
            bandValuesLookup.TryGetValue(bandBColor, out var bandBValue);
            bandMultiplierLookup.TryGetValue(bandCColor, out var bandCValue);
            bandToleranceLookup.TryGetValue(bandDColor, out var bandDValue);



            var tempResult =   (bandAValue * 10) + bandBValue;

            var finalResult = tempResult * bandCValue;
            var maxValue = finalResult +(finalResult * bandDValue); // never used but calculated for usage of tolerance selected Value
            var minValue = finalResult - (finalResult * bandDValue);
            return await Task.FromResult(Convert.ToInt32(finalResult));

        }


        public async Task<CalculatorViewModel> GetCalculatorViewModel()
        {

            var bandALookup = await GetBandColorValues();
            var bandCLookup = await GetMultiplierBandValues();
            var bandDLookup = await GetToleranceBandValues();

            var calculatorViewModel = new CalculatorViewModel()
            {
                BandValues = bandALookup,
                MultiplierValues = bandCLookup,
                ToleranceValues = bandDLookup
            };

            return await Task.FromResult(calculatorViewModel);
        }
    }
}
