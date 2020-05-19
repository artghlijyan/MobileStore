using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileStore.DbRepo;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        MobileContext _mobileContext;

        public HomeController(MobileContext mobileContext)
        {
            _mobileContext = mobileContext;
        }

        public IActionResult Index()
        {
            return View(_mobileContext.Phones.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) 
                return RedirectToAction("Index");

            ViewBag.PhoneId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            _mobileContext.Orders.Add(order);
            _mobileContext.SaveChanges();
            return "Thank you " + order.User + " for your order";
        }
    }
}
