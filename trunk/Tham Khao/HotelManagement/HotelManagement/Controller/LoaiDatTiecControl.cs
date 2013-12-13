using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using System.Windows.Forms;
using System.Data;

namespace HotelManagement.Controller
{
    public class LoaiDatTiecControl
    {
        LoaiDatTiecData data = new LoaiDatTiecData();

        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayLoaiDatTiecData();
            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiComboBox(ComboBox combobox)
        {
            combobox.DataSource = data.LayLoaiDatTiecData();
            combobox.DisplayMember = "TenLoaiDatTiec";
            combobox.ValueMember = "MaLoaiDatTiec";
        }

        public void HienThiDataGridViewComboBoxColumn(DataGridViewComboBoxColumn cmb)
        {
            DataTable dt = data.LayLoaiDatTiecData();
            cmb.DataSource = dt;
            cmb.DisplayMember = "TenLoaiDatTiec";
            cmb.ValueMember = "MaLoaiDatTiec";
            cmb.DataPropertyName = "MaLoaiDatTiec";
            cmb.HeaderText = "Loại đặt tiệc";
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