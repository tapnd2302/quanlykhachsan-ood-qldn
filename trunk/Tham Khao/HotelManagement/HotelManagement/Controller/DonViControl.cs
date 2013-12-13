using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using System.Windows.Forms;
using System.Data;

namespace HotelManagement.Controller
{
    public class DonViControl
    {
        DonViData data = new DonViData();

        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            DataTable dt = data.LayMaDonVi();
            bs.DataSource = dt;
            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiComboBox(ComboBox cmb)
        {
            cmb.DataSource = data.LayMaDonVi();
            cmb.DisplayMember = "TenDonVi";
            cmb.ValueMember = "MaDonVi";
        }

        public void HienThiDataGridViewComboBoxColumn(DataGridViewComboBoxColumn cmb)
        {
            DataTable dt = data.LayMaDonVi();
            cmb.DataSource = dt;
            cmb.DisplayMember = "TenDonVi";
            cmb.ValueMember = "MaDonVi";
            cmb.DataPropertyName = "MaDonVi";
            cmb.HeaderText = "Mã Đơn vị";
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
