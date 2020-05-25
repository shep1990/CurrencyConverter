﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly ILog _logger = LogManager.GetLogger(typeof(CurrencyController));

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
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

                var response = new
                {
                    amount = Math.Round(convertedAmount, 2).ToString("N2"),
                };

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