using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _selleService;

        public SellersController(SellerService sellerService)
        {
            _selleService = sellerService;
        }
        public IActionResult Index()
        {
            var list = _selleService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Seller seller)
        {
            _selleService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}