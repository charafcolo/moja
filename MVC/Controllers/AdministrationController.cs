using DAO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Models.Administration;

namespace MVC.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AdministrationController> _logger;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
                                        UserManager<ApplicationUser> userManager,
                                        ILogger<AdministrationController> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new()
                {
                    Name = model.RoleName
                };

                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            return View(_roleManager.Roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role is null)
            {
                ViewBag.ErrorMessage = $"Role with {id} Not Found";

                return View("NotFound");
            }

            EditRoleViewModel model = new()
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in _userManager.Users.ToList()) // ToList() sinon Exception
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);

            if (role is null)
            {
                ViewBag.ErrorMessage = $"Role with {model.Id} Not Found";

                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.RoleId = roleId; // On passe le roleId par le ViewBag plutôt que par UserRoleViewModel pour éviter d'avoir à le répéter...

            var role = await _roleManager.FindByIdAsync(roleId);

            if (role is null)
            {
                ViewBag.ErrorMessage = $"Role with {roleId} Not Found";

                return View("NotFound");
            }

            List<UserRoleViewModel> model = new();

            foreach (var user in _userManager.Users.ToList()) // ToList() sinon Exception
            {
                UserRoleViewModel userRoleViewModel = new()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    IsSelected = await _userManager.IsInRoleAsync(user, role.Name)
                };

                model.Add(userRoleViewModel);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> users, string roleId) // role ID from Query String
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role is null)
            {
                ViewBag.ErrorMessage = $"Role with {roleId} Not Found";

                return View("NotFound");
            }

            for (int i = 0; i < users.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(users[i].UserId);

                IdentityResult result = null;

                if (users[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!users[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < users.Count - 1)
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRole", new { Id = roleId });
                    }
                }
            }
            return RedirectToAction("EditRole", new { Id = roleId });
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            return View(_userManager.Users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user is null)
            {
                ViewBag.ErrorMessage = $"User with {id} Not Found";

                return View("NotFound");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            EditUserViewModel model = new()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Roles = userRoles.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user is null)
            {
                ViewBag.ErrorMessage = $"User with {model.Id} Not Found";

                return View("NotFound");
            }
            else
            {
                user.UserName = model.UserName;
                user.Email = model.UserName;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user is null)
            {
                ViewBag.ErrorMessage = $"User with {id} Not Found";

                return View("NotFound");
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("ListUsers");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(String.Empty, error.Description);
            }

            return View("ListUsers");
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.UserId = userId; // On passe le userId par le ViewBag plutôt que par UserRolesViewModel pour éviter d'avoir à le répéter...

            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                ViewBag.ErrorMessage = $"User with {userId} Not Found";

                return View("NotFound");
            }

            List<UserRolesViewModel> model = new();

            foreach (var role in _roleManager.Roles.ToList()) // ToList() sinon Exception
            {
                UserRolesViewModel userRolesViewModel = new()
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = await _userManager.IsInRoleAsync(user, role.Name)
                };

                model.Add(userRolesViewModel);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role is null)
            {
                ViewBag.ErrorMessage = $"Role with {id} Not Found";

                return View("NotFound");
            }

            try
            {
                var result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }

                return View("ListRoles");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error deleting role : {ex.Message}");

                ErrorViewModel error = new()
                {
                    Title = $"Role {role.Name} is in use",
                    Message = "Please remove all users from this role before deleting it"
                };

                return View("Error", error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> roles, string userId) // user ID from Query String
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                ViewBag.ErrorMessage = $"USer with {userId} Not Found";

                return View("NotFound");
            }

            // On commence par supprimer tous les roles du user
            var userRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, userRoles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(String.Empty, "Error while removing roles from user");
                return View(roles);
            }

            //Avant de rajouter que ceux qui sont cochés dans la liste
            result = await _userManager.AddToRolesAsync(user, roles.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError(String.Empty, "Error while adding roles to user");
                return View(roles);
            }
            return RedirectToAction("EditUser", new { Id = userId });
        }
    }
}
