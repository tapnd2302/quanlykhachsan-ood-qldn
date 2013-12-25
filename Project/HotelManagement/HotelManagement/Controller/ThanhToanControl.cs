using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using HotelManagement.BusinessObject;
using System.Windows.Forms;
using System.Data;

namespace HotelManagement.Controller
{
    public class ThanhToanControl
    {
        ThanhToanData data = new ThanhToanData();
        BindingSource bs = new BindingSource();

        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LoadTraPhongData();
            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public float LayDoanhThuBaoCaoPhong(string id, int thang, int nam)
        {
            float tongDoanhThuThang = 0;

            DataTable dt = data.LayThongTinBaoCaoPhong(id, thang ,nam);

            for (int i = 0; i < dt.DefaultView.Count; i++)
            {
                tongDoanhThuThang += Convert.ToSingle(dt.Rows[i]["TongTien"]);
            }

            return tongDoanhThuThang;
        }

        public DataRow NewRow()
        {
            return data.NewRow();
        }

        public void Add(DataRow row)
        {
            data.Add(row);
        }

        public bool Save()
        {
            return data.Save();
        }
    }
}
