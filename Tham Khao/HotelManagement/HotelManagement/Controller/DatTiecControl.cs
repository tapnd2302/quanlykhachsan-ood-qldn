using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using HotelManagement.BusinessObject;
using System.Data;
using System.Windows.Forms;

namespace HotelManagement.Controller
{
    public class DatTiecControl
    {
        DatTiecData data = new DatTiecData();

        public void HienThi(DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDatTiecData();
            dg.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiComboBoxTenDichVu(ComboBox cmb)
        {
            cmb.DataSource = data.LayDatTiecData();
            cmb.DisplayMember = "MaDatTiec";
            cmb.ValueMember = "MaDatTiec";
        }

        public void HienThiDataGridViewComboBoxColumnTenDichVu(DataGridViewComboBoxColumn cmb)
        {
            DataTable dt = data.LayDatTiecData();
            cmb.DataSource = dt;
            cmb.DisplayMember = "MaDatTiec";
            cmb.ValueMember = "MaDatTiec";
            cmb.DataPropertyName = "MaDatTiec";
            cmb.HeaderText = "Mã đặt tiệc";
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
            return this.data.Save();
        }
    }
}
