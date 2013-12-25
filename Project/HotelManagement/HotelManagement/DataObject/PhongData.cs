using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Setting;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagement.DataObject
{
    public class PhongData
    {
        DataService ds = new DataService();
        public DataTable LayMaPhong()
        {
            SqlCommand cmd = new SqlCommand("Select * From PHONG");
            ds.Load(cmd);
            return ds;
        }

        public DataTable LayDataTheoMaLoaiPhong(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from PHONG where MaTinhTrang = @id");
            cmd.Parameters.Add("id", SqlDbType.VarChar).Value = id;
            ds.Load(cmd);
            return ds;
        }

        public DataTable LayMaLoaiPhong(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from PHONG where MaPhong = @id");
            cmd.Parameters.Add("id", SqlDbType.VarChar).Value = id;
            ds.Load(cmd);
            return ds;
        }

        public void UpdateTinhTrangPhong(string maPhong, string maTinhTrang)
        {
            SqlCommand cmd = new SqlCommand("Update PHONG Set MaTinhTrang = @maTinhTrang where MaPhong = @maPhong");
            cmd.Parameters.Add("maPhong", SqlDbType.VarChar).Value = maPhong;
            cmd.Parameters.Add("maTinhTrang", SqlDbType.VarChar).Value = maTinhTrang;
            ds.Load(cmd);
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
            return this.ds.ExecuteNoneQuery() > 0;
        }
    }
}
