using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using System.Data;
using System.Windows.Forms;

namespace HotelManagement.Controller
{
    public class BangKeDatTiecControl
    {
        BangKeDatTiecData data = new BangKeDatTiecData();

        public BangKeDatTiecControl()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayBangKeDatTiecData();
        }

        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayBangKeDatTiecData();

            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThi(DataGridView dgv, BindingNavigator bn, string id)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayBangKeDatTiecMaKhachHang(id);

            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiComboBoxMaDichVu(string id, ComboBox cmb)
        {
            BangKeDatTiecData dataP = new BangKeDatTiecData();
            cmb.DataSource = dataP.LayBangKeDatTiecMaKhachHang(id);
            cmb.DisplayMember = "MaDatTiec";
            cmb.ValueMember = "MaDatTiec";
        }

        public void HienThiDataGridViewComboBoxColumnMaBangKeDV(DataGridViewComboBoxColumn cmbMaBangKe)
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            DataTable dt = data.LayBangKeDatTiecData();
            cmb.DataSource = dt;
            cmb.DisplayMember = "MaBangKeDatTiec";
            cmb.ValueMember = "MaBangKeDatTiec";
            cmb.DataPropertyName = "MaBangKeDatTiec";
            cmb.HeaderText = "Mã bảng kê đặt tiệc";
        }

        public void HienThiComboBoxMaBangKeDV(ComboBox cmb)
        {
            cmb.DataSource = data.LayBangKeDatTiecData();
            cmb.DisplayMember = "MaBangKeDatTiec";
            cmb.ValueMember = "MaBangKeDatTiec";
        }

        public float TinhTienDatTiec(string id)
        {
            float tien = 0;
            DataTable dt = data.LayBangKeDatTiecMaKhachHang(id);

            for (int i = 0; i < dt.DefaultView.Count; i++)
            {
                tien += Convert.ToSingle(dt.Rows[i]["ThanhTien"]);
            }

            return tien;
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
