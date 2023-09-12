using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Lib.Models;
using StudentManagementSystem.WEB.ViewModels;
using System.Collections.Generic;

namespace StudentManagementSystem.WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
                return RedirectToAction("Login", "Account");
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
            IList<ApplicationUser> userList = _userManager.Users.ToList();

            IList<UserListViewModel> userListVM = new List<UserListViewModel>();

            foreach (var user in userList)
            {
                UserListViewModel userVM = new UserListViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName
                };

                userListVM.Add(userVM);
            }

            return View(userListVM);
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
        public async Task<ActionResult> Edit(string id)
        {
            ApplicationUser existingUser = await _userManager.FindByIdAsync(id);

            if (existingUser == null)
            {
                ViewData["NotFound"] = $"The user with id = {id} was not found!";
                return View("NotFound");
            }

            IList<string> userRoles = await _userManager.GetRolesAsync(existingUser);

            EditUserViewModel editUserVM = new EditUserViewModel()
            {
                Id = existingUser.Id,
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                Email = existingUser.Email,
                Username = existingUser.UserName,
                Roles = userRoles
            };

            return View(editUserVM);
        }



        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditUserViewModel editUserVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ApplicationUser existingUser = await _userManager.FindByIdAsync(editUserVM.Id);

            if (existingUser == null)
            {
                ViewData["NotFound"] = $"The user with id = {editUserVM.Id} was not found!";
                return View("NotFound");
            }

            existingUser.FirstName = editUserVM.FirstName;
            existingUser.LastName = editUserVM.LastName;
            existingUser.Email = editUserVM.Email;
            existingUser.UserName = editUserVM.Email;

            IdentityResult result = await _userManager.UpdateAsync(existingUser);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Account");
            }
            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUserRoles(IList<UserRoleViewModel> userRolesList, string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewData["NotFound"] = $"The user with id = {userId} was not found!";
                return View("NotFound");
            }

            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            IdentityResult result = await _userManager.RemoveFromRolesAsync(user, userRoles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Error removing the user from the existing role!");
                return View();
            }

            result = await _userManager.AddToRolesAsync(user, userRolesList.Where(r => r.IsRoleSelected).Select(sr => sr.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Error adding the user to the selected role!");
                return View();
            }

            return RedirectToAction("Edit", "Account", new { id = userId });
        }


        public async Task<ActionResult> EditUserRoles(string userId)
        {
            ViewData["UserId"] = userId;

            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewData["NotFound"] = $"The user with id = {userId} was not found!";
                return View("NotFound");
            }

            IList<UserRoleViewModel> userRoles = new List<UserRoleViewModel>();

            foreach (var role in _roleManager.Roles)
            {
                UserRoleViewModel userRoleVM = new UserRoleViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleVM.IsRoleSelected = true;
                }
                else
                {
                    userRoleVM.IsRoleSelected = false;
                }
                userRoles.Add(userRoleVM);
            }

            return View(userRoles);
        }






        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }



        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByIdAsync(id);

                if (user == null)
                {
                    ViewData["NotFound"] = $"The user with id = {id} was not found!";
                    return View("NotFound");
                }

                IdentityResult result = await _userManager.DeleteAsync(user);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                return RedirectToAction("Index", "Account");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        [AllowAnonymous]

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
