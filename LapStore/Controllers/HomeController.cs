using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LapStore.Bl;
using Bl;
using LapShop.Models;
using LapStore.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LapStore.Controllers
{

    public class HomeController : Controller
    {
        IItems oClsItems;
        ISliders oClsSliders;
        ICategories oClsCategories;
        public HomeController(IItems item, ISliders oSliders, ICategories categories)
        {
            oClsItems = item;
            this.oClsSliders = oSliders;
            this.oClsCategories = categories;
        }
       
        public IActionResult Index()
        {
            
            VmHomePage vm = new VmHomePage();
           
            
           
            vm.lstAllItems = oClsItems.GetAllItemsData(null).Skip(20).Take(24).ToList();
            vm.lstRecommendedItems = oClsItems.GetAllItemsData(null).Skip(60).Take(10).ToList();
            vm.lstNewItems = oClsItems.GetAllItemsData(null).Skip(90).Take(10).ToList();
            vm.lstFreeDelivry = oClsItems.GetAllItemsData(null).Skip(200).Take(2).ToList();
            vm.lstSliders = oClsSliders.GetAll();
            vm.lstCategories = oClsCategories.GetAll().Take(4).ToList();
            

            //// Add items to the list
            //vm.Items.Add(new VwItem
            //{
            //    ItemName = item.ItemName,
            //    PurchasePrice = item.PurchasePrice,
            //    SalesPrice = item.SalesPrice,
            //    CategoryId = item.CategoryId,
            //    ImageName = item.ImageName,
            //    //CreatedDate = DateTime.Now,
            //    //CreatedBy = "Admin",
            //    //CurrentState = 1,
            //    //UpdatedBy = "Admin",
            //    //UpdatedDate = DateTime.Now,
            //    Description = item.Description,
            //    Gpu = item.Gpu,
            //    HardDisk = item.HardDisk,
            //    ItemTypeId = item.ItemTypeId,
            //    Processor = item.Processor,
            //    RamSize = item.RamSize,
            //    ScreenReslution = item.ScreenReslution,
            //    ScreenSize = item.ScreenSize,
            //    Weight = item.Weight,
            //    OsId = item.OsId,
            //    CategoryName = item.CategoryName,
            //    ItemTypeName =item.ItemTypeName,
            //    OsName = item.OsName,
            //    ItemId = item.ItemId,
            //});
          
            return View(vm);
        }
    }
}
