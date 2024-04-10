using App.Infra.DataBase.MemoryDataBase;
using Core.AdminEntity.Contracts;
using Core.AdminEntity.DTOs;
using Core.RequestEntity.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminAppService _adminAppService;
        private readonly IRequestAppService _requestAppService;

        public AdminController(IAdminAppService adminAppService,IRequestAppService requestAppService)
        {
            _adminAppService = adminAppService;
            _requestAppService = requestAppService;
        }

        public IActionResult Index()
        {
            if (InMemoryDatabase.ActiveAdmin == null)
            {
                return RedirectToAction("AdminLogin");
            }

            var carList = _requestAppService.GetList();
            return View(carList);
        }

        public IActionResult RequetListByDate()
        {
            if (InMemoryDatabase.ActiveAdmin == null)
            {
                return RedirectToAction("AdminLogin");
            }

            var carList = _requestAppService.GetList();
            return View(carList);
        }


        public IActionResult ViewDetails(int id)
        {
            if (InMemoryDatabase.ActiveAdmin == null)
            {
                return RedirectToAction("AdminLogin");
            }

            var request = _requestAppService.GetById(id);
            return View(request);
        }


        public IActionResult RequestAccept(int id)
        {
            if (InMemoryDatabase.ActiveAdmin == null)
            {
                return RedirectToAction("AdminLogin");
            }

            _requestAppService.AcceptRequest(id);

            return RedirectToAction("Index");
        }

        public IActionResult RequestDelete(int id)
        {
            if (InMemoryDatabase.ActiveAdmin == null)
            {
                return RedirectToAction("AdminLogin");
            }
            _requestAppService.DeleteRequest(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AllConfirmedRequests()
        {
            if (InMemoryDatabase.ActiveAdmin == null)
            {
                return RedirectToAction("AdminLogin");
            }

            var RequestList = _requestAppService.AllAcceptedRequests();
            return View(RequestList);
        }


        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(AdminLoginDTO adminLoginDTO)
        {
            var admin = _adminAppService.GetByUserPass(adminLoginDTO);
            if (admin != null)
            {
                InMemoryDatabase.ActiveAdmin = admin;
                return RedirectToAction("Index");
            }

            return View(adminLoginDTO);
        }
    }
}
