using System.Linq;
using System.Threading.Tasks;
using CurrencyConverter.Domain.Services;
using CurrencyConverter.Models;
using FixerSharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CurrencyConverter.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        // GET: Currency
        public async Task<ActionResult> Index()
        {
            var currencyList = await _currencyService.GetCurrencies();

            var model = new CurrencyViewModel()
            {
                CurrencyTypes = new SelectList(currencyList.OrderBy(c => c.CurrencyName), "Id", "CurrencyName"),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> Index(CurrencyViewModel model)
        {
            double convertedAmount = await Fixer.ConvertAsync(
                model.SourceCurrency, 
                model.TargetCurrency, 
                model.Amount
            );

            var response = new
            {
                amount = convertedAmount,
            };

            return Json(response);


        }
    }
}