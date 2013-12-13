using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using System.Windows.Forms;
using System.Data;

namespace HotelManagement.Controller
{
    public class PhongControl
    {
        PhongData data = new PhongData();

        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayMaPhong();
            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiDataGridViewComboBoxMaPhong(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = data.LayMaPhong();
            cmb.DisplayMember = "MaPhong";
            cmb.ValueMember = "MaPhong";
            cmb.DataPropertyName = "MaPhong";
            cmb.HeaderText = "Phòng";
        }

        public void HienThiComboBoxPhong(string id, ComboBox cmb)
        {
            cmb.DataSource = data.LayDataTheoMaLoaiPhong(id);
            cmb.DisplayMember = "TenPhong";
            cmb.ValueMember = "MaPhong";
        }


        public void HienThiComboBox(ComboBox cmd)
        {
            cmd.DataSource = data.LayMaPhong();
            cmd.DisplayMember = "TenPhong";
            cmd.ValueMember = "MaPhong";
        }

        public string LayMaLoaiPhong(string id)
        {
            DataTable dt = data.LayMaLoaiPhong(id);
            string str = Convert.ToString(dt.Rows[0]["MaLoaiPhong"]);

            return str;
        }

        public void SetTinhTrangPhong(string maPhong, string maTinhTrang)
        {
            data.UpdateTinhTrangPhong(maPhong, maTinhTrang);
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
