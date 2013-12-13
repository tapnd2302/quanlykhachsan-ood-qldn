using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Setting;
using System.Data.SqlClient;
using System.Data;

namespace HotelManagement.DataObject
{
    public class PhieuThuePhongData
    {
        DataService ds = new DataService();

        public DataTable LoadPhieuThuePhong()
        {
            SqlCommand cmd = new SqlCommand("select * from PHIEU_THUE_PHONG");
            ds.Load(cmd);
            return ds;
        }

        public DataTable LayThongTinTheoMaPhong(string id)
        {
            SqlCommand cmd = new SqlCommand("Select * from PHIEU_THUE_PHONG where MaPhong = @id");
            cmd.Parameters.Add("id", SqlDbType.VarChar).Value = id;
            ds.Load(cmd);
            return ds;
        }

        public void XoaDataTheoMaPhong(string maPhong)
        {
            SqlCommand cmd = new SqlCommand("Delete from PHIEU_THUE_PHONG where MaPhong = @maPhong");
            cmd.Parameters.Add("maPhong", SqlDbType.VarChar).Value = maPhong;
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
            return ds.ExecuteNoneQuery() > 0;
        }
    }

}
