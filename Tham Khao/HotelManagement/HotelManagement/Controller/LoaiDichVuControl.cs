using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using System.Windows.Forms;
using System.Data;

namespace HotelManagement.Controller
{
    public class LoaiDichVuControl
    {
        LoaiDichVuData data = new LoaiDichVuData();

        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayLoaiDichVuData();
            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiComboBox(ComboBox combobox)
        {
            combobox.DataSource = data.LayLoaiDichVuData();
            combobox.DisplayMember = "TenLoaiDichVu";
            combobox.ValueMember = "MaLoaiDichVu";
        }

        public void HienThiDataGridViewComboBoxColumn(DataGridViewComboBoxColumn cmb)
        {
            DataTable dt = data.LayLoaiDichVuData();
            cmb.DataSource = dt;
            cmb.DisplayMember = "TenLoaiDichVu";
            cmb.ValueMember = "MaLoaiDichVu";
            cmb.DataPropertyName = "MaLoaiDichVu";
            cmb.HeaderText = "Loại dịch vụ";
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

