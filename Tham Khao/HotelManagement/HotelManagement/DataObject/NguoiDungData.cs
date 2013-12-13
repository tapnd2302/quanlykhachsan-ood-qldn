using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Setting;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagement.DataObject
{
    public class NguoiDungData
    {
        DataService ds = new DataService();
        DataService ds1 = new DataService();

        public DataTable LayDSNguoiDung()
        {
            SqlCommand cmd = new SqlCommand("Select * From NGUOI_DUNG");
            ds.Load(cmd);
            return ds;
        }

        public DataTable LayDSNguoiDung(string tenDangNhap)
        {
            String sql = "SELECT * FROM NGUOI_DUNG WHERE TenDangNhap = @ten";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("ten", SqlDbType.VarChar).Value = tenDangNhap;
            //dung Parameters: tranh loi về chuỗi, dễ thay đổi CSDL, tránh được sự phức tạp
            ds.Load(cmd);
            return ds;
        }

        public DataTable LayDSNguoiDung_Loai(string loaiNguoiDung)
        {
            SqlCommand cmd = new SqlCommand("Select * From NGUOI_DUNG Where LoaiNguoiDung='" + loaiNguoiDung + "'");
            ds.Load(cmd);
            return ds;
        }

        public void UpdatePassWord(string tenDangNhap, string matKhau)
        {
            ds1.UpdatePassWord(tenDangNhap, matKhau);
        }

        public DataRow NewRow()
        {
            return ds.NewRow();
        }

        public void Add(DataRow row)
        {
            ds.Rows.Add(row);
        }

        public bool Save()
        {
            return (ds.ExecuteNoneQuery() > 0);
        }

        public void DoiMatKhau(string ten, string matKhau)
        {
            SqlCommand cmd = new SqlCommand("Update NGUOI_DUNG Set MatKhau=@matKhau where TenDangNhap=@ten");
            cmd.Parameters.Add("ten", SqlDbType.VarChar).Value = ten;
            cmd.Parameters.Add("matKhau", SqlDbType.VarChar).Value = matKhau;
            ds.Load(cmd);
        }
        public void DoiMatKhauSQL(String ten, String matKhau, String matKhauMoi)
        {
            SqlCommand cmd = new SqlCommand("exec sp_password @matKhau, @matKhauMoi, @ten");
            cmd.Parameters.Add("matKhau", SqlDbType.VarChar).Value = matKhau;
            cmd.Parameters.Add("matKhauMoi", SqlDbType.VarChar).Value = matKhauMoi;
            cmd.Parameters.Add("ten", SqlDbType.VarChar).Value = ten;
            ds.Load(cmd);
        }
    }
}
