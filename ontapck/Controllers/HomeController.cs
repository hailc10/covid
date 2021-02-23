using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ontapck.Models;

namespace ontapck.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult ThemDiemCachLy()
        {
            return View();
        }
        
        public IActionResult InsertDCL(diemcachly kh)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(ontapck.Models.StoreContext)) as StoreContext;
            count = context.InsertDCL(kh);
            if (count > 0)
                ViewData["thongbao"] = "Insert thành công";
            else
                ViewData["thongbao"] = "Insert không thành công";
            return View();
        }

        

        public IActionResult ViewTrieuChung(int SoTrieuChung)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(ontapck.Models.StoreContext)) as StoreContext;

            return View(context.GetCNtheotrieuchung(SoTrieuChung));
        }

        public IActionResult LietKeTenDiemCL(string MaDiemCachLy)
        {
            StoreContext context1 = HttpContext.RequestServices.GetService(typeof(ontapck.Models.StoreContext)) as StoreContext;
            StoreContext context2 = HttpContext.RequestServices.GetService(typeof(ontapck.Models.StoreContext)) as StoreContext;

            MixCNDCL Itemglobal = new MixCNDCL();
            Itemglobal.listdiemcl = context1.GetDiemCachLy();
            Itemglobal.listcongnhan = context2.GetCongNhanByMaDiem(MaDiemCachLy);

            return View(Itemglobal);
        }

        public IActionResult XoaCongNhan(string Id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(ontapck.Models.StoreContext)) as StoreContext;
            int count = context.XoaCongNhan(Id);
            if (count > 0)
            {
                ViewData["thongbao"] = "Xóa thành công";
            }
            else
            {
                ViewData["thongbao"] = "Xóa không thành công";
            } 
            return View();
        }


        public IActionResult ViewCongNhan(string Id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(ontapck.Models.StoreContext)) as StoreContext;
            congnhan cn = context.ViewCongNhan(Id);
            ViewData.Model = cn;
            return View();
        }

        public IActionResult UpdateCongNhan(congnhan kh)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(ontapck.Models.StoreContext)) as StoreContext;
            count = context.UpdateCongNhan(kh);
            if (count > 0)
                ViewData["thongbao"] = "Update thành công";
            else
                ViewData["thongbao"] = "Update không thành công";
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
