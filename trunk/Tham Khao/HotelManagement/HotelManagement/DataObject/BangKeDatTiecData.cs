using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Setting;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagement.DataObject
{
    public class BangKeDatTiecData
    {
        DataService ds = new DataService();

        public DataTable LayBangKeDatTiecData()
        {
            SqlCommand cmd = new SqlCommand("Select * from BANG_KE_DAT_TIEC");
            ds.Load(cmd);
            return ds;
        }

        public DataTable LayBangKeDatTiecMaKhachHang(string cmnd)
        {
            SqlCommand cmd = new SqlCommand("select * from BANG_KE_DAT_TIEC where MaKhachHang = @cmnd");
            cmd.Parameters.Add("cmnd", SqlDbType.VarChar).Value = cmnd;
            ds.Load(cmd);
            return ds;
        }

        public DataRow NewRow()
        {
            return ds.NewRow();
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
