using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.WEB.ViewModels;

namespace StudentManagementSystem.WEB.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager)  
        {
            _roleManager = roleManager;
        }



        // GET: AdministrationController
        public ActionResult Index()
        {
            return View();
        }



        // GET: AdministrationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: AdministrationController/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: AdministrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateRoleViewModel createRoleVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                IdentityRole role = new IdentityRole
                {
                    Name = createRoleVM.RoleName
                };

                IdentityResult result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Students");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }
            catch(Exception)
            {
                return View();
            }
        }

        // GET: AdministrationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdministrationController/Edit/5
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

        // GET: AdministrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdministrationController/Delete/5
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
