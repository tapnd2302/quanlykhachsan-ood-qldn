using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using HotelManagement.BusinessObject;
using System.Windows.Forms;
using System.Data;

namespace HotelManagement.Controller
{
    public class PhieuThuePhongControl
    {
        PhieuThuePhongData data = new PhieuThuePhongData();
        BindingSource bs = new BindingSource();

        public PhieuThuePhongControl()
        {
            bs.DataSource = data.LoadPhieuThuePhong();
        }

        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LoadPhieuThuePhong();
            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiComboBoxMaPhieuThue(ComboBox cmb)
        {
            cmb.DataSource = data.LoadPhieuThuePhong();
            cmb.DisplayMember = "MaPhieuThue";
            cmb.ValueMember = "MaPhieuThue";
        }

        public void HienThiDataGridViewComboBoxColumn(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = data.LoadPhieuThuePhong();
            cmb.DisplayMember = "MaPhieuThue";
            cmb.ValueMember = "MaPhieuThue";
            cmb.DataPropertyName = "MaPhieuThue";
            cmb.HeaderText = "Mã phiếu thuê";
        }

        public void HienThiComboBoxMaKhachHang(string id, ComboBox cmb)
        {
            PhieuThuePhongData dataP = new PhieuThuePhongData();
            cmb.DataSource = dataP.LayThongTinTheoMaPhong(id);
            cmb.DisplayMember = "MaKhachHang";
            cmb.ValueMember = "MaKhachHang";
        }

        public DateTime LayNgayThuePhong(string id)
        {
            DataTable table = data.LayThongTinTheoMaPhong(id);
            DateTime dateNgayThue = Convert.ToDateTime(table.Rows[0]["NgayThuePhong"]);
            return dateNgayThue;
        }

        public void XoaDataTheoMaPhong(string maPhong)
        {
            data.XoaDataTheoMaPhong(maPhong);
        }
        public DataRow NewRow()
        {
            return data.NewRow();
        }

        public void Add(DataRow row)
        {
            data.Add(row);
        }

        public bool Save()
        {
            return data.Save();
        }
    }
}
