using ProductManagerApp.Business.Abstract;
using ProductManagerApp.Cms.Models;
using ProductManagerApp.Common.Helper;
using ProductManagerApp.Dto;
using System.Linq;
using System.Web.Mvc;

namespace ProductManagerApp.Cms.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public HomeController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public ActionResult Index()
        {
            if (Session["Id"] != null && (int)Session["RoleId"] == 1)
            {
                return RedirectToAction("Index","Products");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Register()
        {
            ViewBag.Roles = _roleService.GetAll().ToList().Select(x => new SelectListItem() { Text = x.RoleName, Value = x.Id.ToString() });

            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UsersDto user,int roleId)
        {
            if (ModelState.IsValid)
            {
                var check = _userService.GetByMail(user.Email);
                if (check == null)
                {
                    user.RoleId = roleId;
                    user.Password = LoginHelper.HashingPassword(user.Password);
                    _userService.Insert(user);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var hashPassword = LoginHelper.HashingPassword(password);
                var data = _userService.LoginUser(email, hashPassword);
                if (data != null && data.RoleId == 1)
                {
                    //add session
                    Session["FullName"] = data.Name;
                    Session["Email"] = data.Email;
                    Session["Id"] = data.Id;
                    Session["RoleId"] = data.RoleId;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Giriş Hatalı veya Admin değilsiniz.";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
    }
}