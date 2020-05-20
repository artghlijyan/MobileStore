using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MobileStore.DbRepo;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    [Controller]
    public class HomeController : BaseController
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
        public IActionResult Buy(Order order)
        {

            _mobileContext.Orders.Add(order);
            _mobileContext.SaveChanges();
            return Content("Thank you " + order.User + " for your order");
        }
    }
}
