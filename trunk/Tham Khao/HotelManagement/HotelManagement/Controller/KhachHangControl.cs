using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using System.Windows.Forms;
using HotelManagement.BusinessObject;
using System.Data;

namespace HotelManagement.Controller
{
    public class KhachHangControl
    {
        KhachHangData data = new KhachHangData();
        BindingSource bs = new BindingSource();

        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayMaKhachHang();

            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiComboBoxTenKhachHang(ComboBox cmb)
        {
            cmb.DataSource = data.LayMaKhachHang();
            cmb.DisplayMember = "TenKhachHang";
            cmb.ValueMember = "MaKhachHang";
        }

        public void HienThiDataGridViewComboBoxColumnTenKhachHang(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = data.LayMaKhachHang();
            cmb.DisplayMember = "TenKhachHang";
            cmb.ValueMember = "MaKhachHang";
            cmb.DataPropertyName = "MaKhachHang";
            cmb.HeaderText = "Tên Khách hàng";
        }

        public void HienThiComboBoxMaKhachHang(ComboBox cmb)
        {
            cmb.DataSource = data.LayMaKhachHang();
            cmb.DisplayMember = "MaKhachHang";
            cmb.ValueMember = "MaKhachHang";
        }

        public void HienThiDataGridViewComboBoxColumnMaKhachHang(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = data.LayMaKhachHang();
            cmb.DisplayMember = "MaKhachHang";
            cmb.ValueMember = "MaKhachHang";
            cmb.DataPropertyName = "MaKhachHang";
            cmb.HeaderText = "Mã Khách hàng";
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
