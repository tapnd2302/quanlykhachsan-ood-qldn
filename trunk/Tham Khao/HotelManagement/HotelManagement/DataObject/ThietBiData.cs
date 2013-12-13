using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Setting;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagement.DataObject
{
    public class ThietBiData
    {
        DataService ds = new DataService();
        public DataTable LayMaThietBi()
        {
            SqlCommand cmd = new SqlCommand("select * from THIET_BI");
            ds.Load(cmd);
            return ds;
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
