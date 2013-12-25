using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Setting;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagement.DataObject
{
    public class LoaiPhongData
    {
        DataService ds = new DataService();
        public DataTable LayLoaiPhongData()
        {
            SqlCommand cmd = new SqlCommand("Select * From LOAI_PHONG");
            ds.Load(cmd);
            return ds;
        }

        public DataTable LayDataTheoMaLoaiPhong(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from LOAI_PHONG where MaLoaiPhong = @id");
            cmd.Parameters.Add("id", SqlDbType.VarChar).Value = id;
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
