using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Setting;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagement.DataObject
{
    public class BangKeDichVuData
    {
        DataService ds = new DataService();

        public DataTable LayDSSuDungDichVuData()
        {
            SqlCommand cmd = new SqlCommand("Select * from BANG_KE_DICH_VU");
            ds.Load(cmd);
            return ds;
        }

        public DataTable LayDSSuDungDichVuDataMaKhachHang(string cmnd)
        {
            SqlCommand cmd = new SqlCommand("select * from BANG_KE_DICH_VU where MaKhachHang = @cmnd");
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
