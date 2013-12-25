using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Setting;
using System.Data.SqlClient;
using System.Data;

namespace HotelManagement.DataObject
{
    public class DonViData
    {
        DataService ds = new DataService();

        public DataTable LayMaDonVi()
        {
            SqlCommand cmd = new SqlCommand("Select * From DON_VI");
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
            return ds.ExecuteNoneQuery() > 0;
        }
    }
}
