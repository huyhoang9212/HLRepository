using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HL.Services;


namespace HL.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var customers = _customerService.GetAllCustomers().ToList();
            return View();
        }
    }
}