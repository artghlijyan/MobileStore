using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileStore.DbRepo;

namespace MobileStore.Controllers
{
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
    }
}
