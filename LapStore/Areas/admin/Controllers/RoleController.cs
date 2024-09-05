using Bl;
using LapStore.Filters;
using LapStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LapStore.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    [Auhorization]
    public class RoleController : Controller
    {
        IUsers oClsUsers;
          LapShopContext context=new LapShopContext();
            public RoleController(IUsers user)
        {
            oClsUsers = user;         
        }
        public IActionResult Index()
        {
            List<VwUsers> vwUsers = new List<VwUsers>();
            vwUsers=oClsUsers.GetAll();
            ViewBag.lstRoles = oClsUsers.GetAll().ToList();
            return View(vwUsers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string Id)
        {

            //    var user = await context.Users.FindAsync(Id);
            //context.Users.Remove(user);
            //    await context.SaveChangesAsync();
            //    return View();

           
            
                if (string.IsNullOrEmpty(Id))
                {
                    return NotFound();
                }

                var user = await context.Users.FindAsync(Id);
            if (user == null)
                {
                    return NotFound();
                }

                context.Users.Remove(user);
                await context.SaveChangesAsync();
            return Redirect("/admin");
        }
        }



    }

