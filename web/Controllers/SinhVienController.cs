using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstWeb.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        /*
        public string XemDiem() {
            return "Đây là  trang web xem điểm sinh viên";
        }*/

       /* public string XemDiem(string name, double diem=9)
        {
            return HtmlEncoder.Default.Encode($"Ten {name} Diem trung binh {diem}");  
        }*/
        /*
        public string XemDiem(string name, double diem=9, int ID=1)
        {
            return HtmlEncoder.Default.Encode($"ID {ID} Ten {name} Diem trung binh {diem}");  
        }*/
        public IActionResult XemDiem(string name, double diem = 9)
        {
            ViewData["name"] = name;
            ViewData["diem"] = diem;
            return View();
        }
        

    }
}
