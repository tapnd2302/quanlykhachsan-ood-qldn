using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using System.Data;
using System.Windows.Forms;

namespace HotelManagement.Controller
{
    public class BangKeDichVuControl
    {
        BangKeDichVuData data = new BangKeDichVuData();

        public BangKeDichVuControl()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDSSuDungDichVuData();
        }

        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDSSuDungDichVuData();

            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThi(DataGridView dgv, BindingNavigator bn, string id)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDSSuDungDichVuDataMaKhachHang(id);

            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiDataGridViewComboBoxColumnMaBangKeDV(DataGridViewComboBoxColumn cmbMaBangKe)
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            DataTable dt = data.LayDSSuDungDichVuData();
            cmb.DataSource = dt;
            cmb.DisplayMember = "MaBangKeDichVu";
            cmb.ValueMember = "MaBangKeDichVu";
            cmb.DataPropertyName = "MaBangKeDichVu";
            cmb.HeaderText = "Mã bảng kê dịch vụ";
        }

        public void HienThiComboBoxMaDichVu(string id, ComboBox cmb)
        {
            BangKeDichVuData dataP = new BangKeDichVuData();
            cmb.DataSource = dataP.LayDSSuDungDichVuDataMaKhachHang(id);
            cmb.DisplayMember = "MaDichVu";
            cmb.ValueMember = "MaDichVu";
        }

        public void HienThiComboBoxMaBangKeDV(ComboBox cmb)
        {
            cmb.DataSource = data.LayDSSuDungDichVuData();
            cmb.DisplayMember = "MaBangKeDichVu";
            cmb.ValueMember = "MaBangKeDichVu";
        }


        public float TinhTienDichVu(string id)
        {
            float tien = 0;
            DataTable dt = data.LayDSSuDungDichVuDataMaKhachHang(id);

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
