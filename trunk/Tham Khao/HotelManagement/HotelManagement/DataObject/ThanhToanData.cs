using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Setting;
using System.Data.SqlClient;
using System.Data;

namespace HotelManagement.DataObject
{
    public class ThanhToanData
    {
        DataService ds = new DataService();

        public DataTable LoadTraPhongData()
        {
            SqlCommand cmd = new SqlCommand("Select * From THANH_TOAN");
            ds.Load(cmd);
            return ds;
        }

        public DataTable LayThongTinBaoCaoPhong(string id, int thangBaoCao, int namBaoCao)
        {
            SqlCommand cmd = new SqlCommand("Select * From THANH_TOAN WHERE (MaPhong = @id AND MONTH(NgayThanhToan) = @thangBaoCao AND YEAR(NgayThanhToan) = @namBaoCao)");
            cmd.Parameters.Add("id", SqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("thangBaoCao", SqlDbType.Int).Value = thangBaoCao;
            cmd.Parameters.Add("namBaoCao", SqlDbType.Int).Value = namBaoCao;
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
            return ds.ExecuteNoneQuery() > 0;
        }
    }

}
