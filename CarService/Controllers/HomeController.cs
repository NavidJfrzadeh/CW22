using CarService.Models;
using Core.CarEntity.Contracts;
using Core.LogEntity.Contracts;
using Core.RequestEntity.Contracts;
using Core.RequestEntity.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRequestAppService _requestAppService;
        private readonly ICarModelAppService _carModelAppService;

        public HomeController(ILogger<HomeController> logger , IRequestAppService RequestAppService , ICarModelAppService carModelAppService)
        {
            _logger = logger;
           _requestAppService = RequestAppService;
            _carModelAppService = carModelAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddRequest()
        {
            var carModels = _carModelAppService.GetCarModels();
            ViewBag.CarModels = carModels;
            return View();
        }

        [HttpPost]
        public IActionResult AddRequest(RequestDTO requestDTO)
        {
            var Message = _requestAppService.CreateRequest(requestDTO);
            TempData["Message"] = Message;
            
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
