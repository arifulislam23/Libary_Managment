using Libary_Managment.Data;
using Libary_Managment.DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Libary_Managment.Controllers
{
    public class CategoryManagmentController : Controller
    {
        private readonly ApplicationDbContext _dbcon;

        public CategoryManagmentController(ApplicationDbContext dbcon)
        {
            _dbcon = dbcon;
        }

        public IActionResult CategoryList()
        {
            return View();
        }
        public IActionResult CategoryCreate(Category datamodel)
        {
            return View(datamodel);
        }
        public IActionResult SubmitCategoryCreate(Category datamodel)
        {
            if(!String.IsNullOrWhiteSpace(datamodel.CategoryName) && !String.IsNullOrWhiteSpace(datamodel.CategoryDescription))
            {

                var checkdata = _dbcon.Categories.Where(x => x.CategoryName == datamodel.CategoryName).Any();
                if(checkdata == false)
                {
                    _dbcon.Categories.Add(datamodel);
                    _dbcon.SaveChanges();

                    return RedirectToAction("CategoryCreate");

                }
               
            }

            return RedirectToAction("CategoryCreate", datamodel);
        }
    }
}
