using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Setting;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagement.DataObject
{
    public class LoaiNguoiDungData
    {
        DataService ds = new DataService();
        public DataTable LayDSLoaiNguoiDung()
        {
            SqlCommand cmd = new SqlCommand("Select * From LOAI_NGUOI_DUNG");
            ds.Load(cmd);
            return ds;
        }

        public DataTable LayDSLoaiNguoiDung_Ten(string loaiNguoiDung)
        {
            SqlCommand cmd = new SqlCommand("Select * From LOAI_NGUOI_DUNG Where TenLoaiNguoiDung = '" + loaiNguoiDung + "'");
            ds.Load(cmd);
            return ds;
        }

        public void Update()
        {
            ds.Update();
        }
    }
}
