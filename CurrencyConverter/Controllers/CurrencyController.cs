using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CurrencyConverter.Domain.Models;
using CurrencyConverter.Domain.Services;
using CurrencyConverter.Models;
using FixerSharp;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CurrencyConverter.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ICurrencyService _currencyService;
        private readonly ICurrencyLoggingService _currencyLoggingService;
        private readonly ILog _logger = LogManager.GetLogger(typeof(CurrencyController));

        public CurrencyController(
            ICurrencyService currencyService,
            ICurrencyLoggingService currencyLoggingService
        )
        {
            _currencyService = currencyService;
            _currencyLoggingService = currencyLoggingService;
        }

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
        public async Task<IActionResult> ConvertAmount(CurrencyViewModel model)
        {
            try{
                var convertedAmount = await Fixer.ConvertAsync(
                    model.SourceCurrency,
                    model.TargetCurrency,
                    model.Amount
                );

                var exchangeRate = await Fixer.RateAsync(model.SourceCurrency, model.TargetCurrency);

                await LogCurrencyConversion(model, exchangeRate.Rate);

                var currencyLogs = new List<CurrencyLoggingModel>();
                if(model.FromDate != null && model.ToDate != null)
                {
                    currencyLogs = await _currencyLoggingService.GetCurrencyLogs(
                        model.FromDate, 
                        model.ToDate, 
                        model.SourceCurrencyId, 
                        model.TargetCurrencyId
                    );
                }

                var response = new
                {
                    amount = Math.Round(convertedAmount, 2).ToString("N2"),
                    returnedLogs = currencyLogs
                };

                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.Error(string.Format("An error occurred while converting the currency ({0} to {1} for {2}) : {3}", model.SourceCurrency, model.TargetCurrency, model.Amount, ex.Message));
                return BadRequest();
            }
        }

        private async Task LogCurrencyConversion(CurrencyViewModel model, double excahngeRate)
        {
            var request = new CurrencyLoggingModel
            {
                Amount = model.Amount,
                SourceCurrencyId = model.SourceCurrencyId,
                TargetCurrencyId = model.TargetCurrencyId,
                DateLogged = DateTime.UtcNow,
                Rate = excahngeRate
            };

            await _currencyLoggingService.AddCurrencyLog(request);
        }
    }
}