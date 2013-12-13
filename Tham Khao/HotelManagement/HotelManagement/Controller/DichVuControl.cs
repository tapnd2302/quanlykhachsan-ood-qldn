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
    public class DichVuControl
    {
        DichVuData data = new DichVuData();

        public void HienThi(DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDichVuData();
            dg.DataSource = bs;
            bn.BindingSource = bs;
        }

        public DichVuInFo LayDichVuTheoMaKhachHang(String id)
        {
            DataTable dt = data.LayDichVuDataMaKhachHang(id);
            DichVuInFo dvInfo = null;

            BangKeDichVuControl khCtrl = new BangKeDichVuControl();
            if (dt.Rows.Count > 0)
            {
                dvInfo = new DichVuInFo();
                dvInfo.MaDichVu = Convert.ToString(dt.Rows[0]["MaDichVu"]);
                dvInfo.MaKhachHang = Convert.ToString(dt.Rows[0]["MaKhachHang"]);
                dvInfo.MaLoaiDichVu = Convert.ToString(dt.Rows[0]["MaLoaiDichVu"]);
                dvInfo.MaDonVi = Convert.ToString(dt.Rows[0]["MaDonVi"]);
                dvInfo.DonGia = Convert.ToSingle(dt.Rows[0]["DonGia"]);
                dvInfo.SoLuong = Convert.ToInt32(dt.Rows[0]["SoLuong"]);
            }

            return dvInfo;
        }

        public void HienThiComboBoxTenDichVu(ComboBox cmb)
        {
            cmb.DataSource = data.LayDichVuData();
            cmb.DisplayMember = "MaDichVu";
            cmb.ValueMember = "MaDichVu";
        }

        public void HienThiDataGridViewComboBoxColumnTenDichVu(DataGridViewComboBoxColumn cmb)
        {
            DataTable dt = data.LayDichVuData();
            cmb.DataSource = dt;
            cmb.DisplayMember = "MaDichVu";
            cmb.ValueMember = "MaDichVu";
            cmb.DataPropertyName = "MaDichVu";
            cmb.HeaderText = "Mã Dịch Vụ";
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
