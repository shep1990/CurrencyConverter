using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyConverter.Domain.Services;
using CurrencyConverter.Models;
using Microsoft.AspNetCore.Http;
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
    }
}