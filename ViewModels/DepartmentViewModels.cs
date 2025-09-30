using LTW05_bai1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTW05_bai1.ViewModels
{
    public class DepartmentViewModels
    {
        public PhongBan Department { get; set; }
        public List<Employee> Employeee { get; set; }
    }
}