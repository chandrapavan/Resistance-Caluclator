using ResistanceCalculator.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ResistanceCalculator.Tests.ServiceTest
{

    public class CalculatorServiceTests
    {
        [Fact]
        public async Task CalculateService_InvokedWithAllNullInput_Explodes()
        {
            await Assert.ThrowsAnyAsync<Exception>(() => new CalculatorService().CalculateOhmValue(null, null, null, null));
        }

        [Fact]
        public async Task CalculateService_InvokedWithFirstBandNullInput_Explodes()
        {
            await Assert.ThrowsAnyAsync<Exception>(() => new CalculatorService().CalculateOhmValue(null, "Black", "Brown", "Brown"));
        }

        [Fact]
        public async Task CalculateService_InvokedWithSecondBandNullInput_Explodes()
        {
            await Assert.ThrowsAnyAsync<Exception>(() => new CalculatorService().CalculateOhmValue("Black",null , "Brown", "Brown"));
        }

        [Fact]
        public async Task CalculateService_InvokedWithMultiplierNullInput_Explodes()
        {
            await Assert.ThrowsAnyAsync<Exception>(() => new CalculatorService().CalculateOhmValue("Black", "Brown", null, "Brown"));
        }

        [Fact]
        public async Task CalculateService_InvokedWithToleranceNullInput_Explodes()
        {
            await Assert.ThrowsAnyAsync<Exception>(() => new CalculatorService().CalculateOhmValue("Black", "Brown", "Black", null));
        }

        [Fact]
        public async Task CalculateService_InvokedWithBandValueInputDoesntExist_Explodes()
        {
            var result = await new CalculatorService().CalculateOhmValue("B", "Black", "Black", "Black");
             Assert.Equal(0,result);
        }
    }
}
