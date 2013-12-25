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
