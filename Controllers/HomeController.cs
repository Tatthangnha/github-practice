
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW05_bai1.Models;
using LTW05_bai1.ViewModels;

namespace LTW05_bai1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        DuLieu csdl = new DuLieu();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HienThiNhanVien()
        {
            List<Employee> dsnv = csdl.dsNV;
            return View(dsnv);
        }

        public ActionResult HienThiDSPhong()
        {
            List<PhongBan> ds = csdl.dsPhong;
            return View(ds);// truyen sang model
        }
        [HttpGet]
        public ActionResult Details_PhongBan(int id)
        {
            DepartmentViewModels department = new DepartmentViewModels();
            PhongBan ds = csdl.ChiTietPhongBan(id);
            List<Employee> dsnv = csdl.dsNVTheoMaPhong(id);
            department.Department = ds;
            department.Employeee = dsnv;
            return View(department);// truyen sang model
        }
    }
}