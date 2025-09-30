using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace LTW05_bai1.Models
{
    public class DuLieu
    {
        // thuoc tinh
        static string strcon = "Data Source=WINNER; database=QL_NhanSu; User ID = sa; Password = 123 ; ";
        SqlConnection cn = new SqlConnection(strcon);

        public List<Employee> dsNV = new List<Employee>();
        public List<PhongBan> dsPhong = new List<PhongBan>();
        public DuLieu()
        {
            ThietLap_DSNV();
            ThietLap_DSPhongBan();
        }

        public void ThietLap_DSNV()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_Employee", cn);
            DataTable dt = new DataTable();

            da.Fill(dt);// dt["Id"]
            //mapping tu dt sang class
            foreach (DataRow dr in dt.Rows)
            {
                var em = new Employee();
                em.Manv = int.Parse(dr["Id"].ToString());
                em.Ten = dr["Name"].ToString();
                em.GioiTinh = dr["Gender"].ToString();
                em.QueQuan = dr["City"].ToString();
                em.MaPhong = (int)dr["DeptId"];
                dsNV.Add(em);
            }
        }

        public void ThietLap_DSPhongBan()
        {
            ///cau truy van select
            /// // tao du lieu cho danh sach nhan vien
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_Department", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);// dt["Id"]
            //mapping tu dt sang class
            foreach (DataRow dr in dt.Rows)
            {
                var p = new PhongBan();
                p.MaPhong = int.Parse(dr["DeptId"].ToString());
                p.TenPhong = dr["Name"].ToString();
                dsPhong.Add(p);
            }
        }

        public PhongBan ChiTietPhongBan(int maPhong)
        {
            PhongBan department = new PhongBan();
            string sqlScript = string.Format("select * from tbl_Department where DeptId = {0}", maPhong);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, cn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            department.MaPhong = int.Parse(dt.Rows[0]["DeptId"].ToString());
            department.TenPhong = dt.Rows[0]["Name"].ToString();
            return department;

        }

        public List<Employee> dsNVTheoMaPhong(int maPhong)
        {
            List<Employee> employees = new List<Employee>();
            string sqlScript = string.Format("select * from tbl_Employee where DeptId = {0}", maPhong);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, cn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var em = new Employee();
                em.Manv = int.Parse(dr["Id"].ToString());
                em.Ten = dr["Name"].ToString();
                em.GioiTinh = dr["Gender"].ToString();
                em.QueQuan = dr["City"].ToString();
                em.MaPhong = (int)dr["DeptId"];
                employees.Add(em);
            }
            return employees;
        }
    }
}