
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace LTW05_bai1.Models
{
    public class Employee
    {
        public int Manv { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public int MaPhong { get; set; }

      
    }

}