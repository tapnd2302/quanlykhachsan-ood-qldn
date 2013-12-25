using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Setting;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagement.DataObject
{
    public class DatTiecData
    {
        DataService ds = new DataService();

        public DataTable LayDatTiecData()
        {
            SqlCommand cmd = new SqlCommand("Select * From DAT_TIEC");
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
