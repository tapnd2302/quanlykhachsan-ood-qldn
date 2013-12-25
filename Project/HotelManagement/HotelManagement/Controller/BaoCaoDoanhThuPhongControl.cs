using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using System.Data;
using System.Windows.Forms;

namespace HotelManagement.Controller
{
    public class BaoCaoDoanhThuPhongControl
    {
        BaoCaoDoanhThuPhongData data = new BaoCaoDoanhThuPhongData();

        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayBaoCaoData();

            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public DataRow NewRow()
        {
            return this.data.NewRow();
        }

        public void Add(DataRow row)
        {
            this.data.Add(row);
        }

        public bool Save()
        {
            return data.Save();
        }
    }
}