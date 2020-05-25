﻿using System;
using System.Linq;
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
        public async Task<IActionResult> Index(CurrencyViewModel model)
        {
            try{
                var convertedAmount = await Fixer.ConvertAsync(
                    model.SourceCurrency,
                    model.TargetCurrency,
                    model.Amount
                );

                var exchangeRate = await Fixer.RateAsync(model.SourceCurrency, model.TargetCurrency);

                var response = new
                {
                    amount = Math.Round(convertedAmount, 2).ToString("N2"),
                };

                var request = new CurrencyLoggingModel
                {
                    Amount = model.Amount,
                    SourceCurrencyId = model.SourceCurrencyId,
                    TargetCurrencyId = model.TargetCurrencyId,
                    DateLogged = DateTime.UtcNow,
                    Rate = exchangeRate.Rate
                };

                await _currencyLoggingService.AddCurrencyLog(request);

                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.Error(string.Format("An error occurred while converting the currency ({0} to {1} for {2}) : {3}", model.SourceCurrency, model.TargetCurrency, model.Amount, ex.Message));
                return BadRequest();
            }
        }
    }
}