using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using System.Windows.Forms;
using System.Data;

namespace HotelManagement.Controller
{
    public class MonAnControl
    {
        MonAnData data = new MonAnData();

        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayMonAnData();
            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiComboBox(ComboBox combobox)
        {
            combobox.DataSource = data.LayMonAnData();
            combobox.DisplayMember = "TenMonAn";
            combobox.ValueMember = "MaMonAn";
        }

        public void HienThiDataGridViewComboBoxColumn(DataGridViewComboBoxColumn cmb)
        {
            DataTable dt = data.LayMonAnData();
            cmb.DataSource = dt;
            cmb.DisplayMember = "TenMonAn";
            cmb.ValueMember = "MaMonAn";
            cmb.DataPropertyName = "MaMonAn";
            cmb.HeaderText = "Món ăn";
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

