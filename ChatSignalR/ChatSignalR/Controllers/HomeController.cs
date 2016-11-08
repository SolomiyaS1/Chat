using System.Data.Entity.Validation;
using System.Web.Mvc;
using ChatSignalR.Models;
using ChatSignalR.Service;

namespace ChatSignalR.Controllers
{
    public class HomeController : Controller
    {
        IValidation _validation = new Validation(new ChatRepository());
        public ActionResult Index()
        {          
            return View(new User());
        }
        public ActionResult Login(string login, string password)
        {
            User _user;
            string mes;
            if (_validation.CheckLoginPassword(login, password, out _user, out mes))
            {
                return View("~/Views/Home/ChatRoom.cshtml", _user);
            }
            ViewBag.Ex = mes;
            return View("~/Views/Home/Index.cshtml");         
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View("~/Views/Home/Register.cshtml");
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            string mes;
            if (_validation.AddUser(user, out mes))
            {
                return View("~/Views/Home/ChatRoom.cshtml", user);
            }
            ViewBag.Ex = mes;
            return View("~/Views/Home/Register.cshtml");
        }

    }
}