using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Lib.Models;
using StudentManagementSystem.WEB.ViewModels;

namespace StudentManagementSystem.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        // GET: AccountController
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginVM, string returnUrl)
        {
            var result = await _signInManager.PasswordSignInAsync(loginVM.Email, loginVM.Password, loginVM.RememberMe, false);

            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction("Index", "Students");
                else
                    return LocalRedirect(returnUrl);
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt!");

            return View();
        }



        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Students");
        }




        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }



        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel registerVM)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            ApplicationUser user = new ApplicationUser
            {
                Email = registerVM.Email,
                UserName = registerVM.Email,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Students");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View();
        }





        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
