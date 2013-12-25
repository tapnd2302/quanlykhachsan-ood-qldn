using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Setting;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagement.DataObject
{
    public class KhachHangData
    {
        DataService ds = new DataService();

        public DataTable LayMaKhachHang()
        {
            SqlCommand cmd = new SqlCommand("select * From KHACH_HANG");
            ds.Load(cmd);
            return ds;
        }

        public DataTable LKH(String id)
        {
            SqlCommand cmd = new SqlCommand("select * From KHACH_HANG where MaKhachHang = @id");
            cmd.Parameters.Add("id", SqlDbType.VarChar, 10).Value = id;
            ds.Load(cmd);
            return ds;
        }

        public DataTable TimHoTen(string hoTen)
        {
            SqlCommand cmd = new SqlCommand("Select * from KHACH_HANG where TenKhachHang = @hoten");
            cmd.Parameters.Add("hoten", SqlDbType.NVarChar).Value = hoTen;
            ds.Load(cmd);
            return ds;
        }

        public DataTable TimDiaChi(string diaChi)
        {
            SqlCommand cmd = new SqlCommand("Select * from KHACH_HANG where DiaChi = @diachi");
            cmd.Parameters.Add("diachi", SqlDbType.NVarChar).Value = diaChi;
            ds.Load(cmd);
            return ds;
        }

        public DataTable TimGioiTinh(string gioiTinh)
        {
            SqlCommand cmd = new SqlCommand("Select * From KHACH_HANG where GioiTinh = @gioiTinh");
            cmd.Parameters.Add("gioiTinh", SqlDbType.NVarChar).Value = gioiTinh;
            ds.Load(cmd);
            return ds;
        }

        public DataTable TimCMND(string cmnd)
        {
            SqlCommand cmd = new SqlCommand("Select * from KHACH_HANG where CMND = @cmnd");
            cmd.Parameters.Add("cmnd", SqlDbType.NVarChar).Value = cmnd;
            ds.Load(cmd);
            return ds;
        }
        public DataRow NewRow()
        {
            return this.ds.NewRow();
        }

        public void Add(DataRow row)
        {
            this.ds.Rows.Add(row);
        }

        public bool Save()
        {
            return (ds.ExecuteNoneQuery() > 0);
        }
    }
}
