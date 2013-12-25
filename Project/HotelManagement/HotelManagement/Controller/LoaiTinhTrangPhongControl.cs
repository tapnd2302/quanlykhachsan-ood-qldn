using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using System.Windows.Forms;
using System.Data;

namespace HotelManagement.Controller
{
    public class LoaiTinhTrangPhongControl
    {
        LoaiTinhTrangPhongData data = new LoaiTinhTrangPhongData();


        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDSTinhTrangPhong();
            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiComboBox(ComboBox combobox)
        {
            combobox.DataSource = data.LayDSTinhTrangPhong();
            combobox.DisplayMember = "TenTinhTrang";
            combobox.ValueMember = "MaTinhTrang";
        }

        public void HienThiDataGridViewComboBoxColumn(DataGridViewComboBoxColumn cmb)
        {
            DataTable dt = data.LayDSTinhTrangPhong();
            cmb.DataSource = dt;
            cmb.DisplayMember = "TenTinhTrang";
            cmb.ValueMember = "MaTinhTrang";
            cmb.DataPropertyName = "MaTinhTrang";
            cmb.HeaderText = "Tình Trạng Phòng";
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
