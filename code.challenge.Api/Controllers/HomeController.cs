using code.challenge.Core.Entities;
using code.challenge.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code.challenge.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetCarsService _getCarsService;
        private IEnumerable<Car> _cars;

        public HomeController(IGetCarsService getCarsService)
        {
            _getCarsService = getCarsService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _getCarsService.GetAllAsync();

            return View(cars);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int carId, int guessPrice)
        {
            var car = await _getCarsService.GetAsync(carId);
            if (car != null)
            {
                var difference = Math.Abs(car.Price - guessPrice);
                if (difference <= 5000)
                {
                    TempData["GuessResult"] = "Great job!";
                    TempData["GuessResultColor"] = "green";
                }
                else
                {
                    TempData["GuessResult"] = "Sorry, your guess is not close enough.";
                    TempData["GuessResultColor"] = "red";
                }
            }

            return RedirectToAction("Index");
        }
    }
}
