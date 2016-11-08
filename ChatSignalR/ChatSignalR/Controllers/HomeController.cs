using System.Data.Entity.Validation;
using System.Web.Mvc;
using ChatSignalR.Models;

namespace ChatSignalR.Controllers
{
    public class HomeController : Controller
    {
        ChatRepository ChatRepo = new ChatRepository();
        public ActionResult Index()
        {          
            return View(new User());
        }
        public ActionResult Login(string login, string password)
        {
            try
            {
                User user = ChatRepo.CheckLoginPassword(login, password);
                return View("~/Views/Home/ChatRoom.cshtml", user);
            }
            catch (UserException e)
            {
                ViewBag.Ex = e.Message;
                return View("~/Views/Home/Index.cshtml");
            }           
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View("~/Views/Home/Register.cshtml");
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (user.Name != null && user.Email != null && user.Password != null)
            {
                try
                {
                    ChatRepo.AddUser(user);
                    return View("~/Views/Home/ChatRoom.cshtml", user);
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        foreach (var ve in eve.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error: {ve.ErrorMessage}");
                        }                      
                                              
                    }
                    return View("~/Views/Home/Register.cshtml");
                }
                catch (UserException e)
                {
                    ViewBag.Ex = e.Message;
                    return View("~/Views/Home/Register.cshtml");

                }
            }
            return View("~/Views/Home/Register.cshtml");
        }

    }
}