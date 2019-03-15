using System.Collections.Generic;
using System.Threading.Tasks;
using ResistanceCalculator.ViewModels;

namespace ResistanceCalculator.Services
{
    public interface ICalculatorService
    {
        Task<int> CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
        Task<CalculatorViewModel> GetCalculatorViewModel();

        Task<Dictionary<string, int>> GetBandColorValues();
        Task<Dictionary<string, double>> GetMultiplierBandValues();
        Task<Dictionary<string, double>> GetToleranceBandValues();


    }
}
