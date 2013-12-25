using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Setting;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagement.DataObject
{
    public class DangKyPhongData
    {
        DataService ds = new DataService();

        public DataTable LayDangKyPhongData()
        {
            SqlCommand cmd = new SqlCommand("Select * From DANG_KY_THUE_PHONG");
            ds.Load(cmd);
            return ds;
        }

        public DataTable LayThongTinMaDangKyPhong(string id)
        {
            SqlCommand cmd = new SqlCommand("Select * from DANG_KY_THUE_PHONG where MaDangKy = @id");
            cmd.Parameters.Add("id", SqlDbType.VarChar).Value = id;
            ds.Load(cmd);
            return ds;
        }

        public void XoaDataTheoMaPhong(string maDK)
        {
            SqlCommand cmd = new SqlCommand("Delete from DANG_KY_THUE_PHONG where MaDangKy = @maDK");
            cmd.Parameters.Add("maDK", SqlDbType.VarChar).Value = maDK;
            ds.Load(cmd);
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
    }
}
