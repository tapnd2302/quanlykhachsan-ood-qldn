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
    public class DangKyPhongControl
    {
        DangKyPhongData data = new DangKyPhongData();
        BindingSource bs = new BindingSource();

        public DangKyPhongControl()
        {
            bs.DataSource = data.LayDangKyPhongData();
        }

        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            bs.DataSource = data.LayDangKyPhongData();
            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThi(DataGridView dgv, BindingNavigator bn, TextBox txtMaDangKy, TextBox txtTenKhachHang,
            TextBox txtCMND, ComboBox cmbTenPhong, DateTimePicker dateNgayDangKy, DateTimePicker dateNgayNhan)
        {
            bs.DataSource = data.LayDangKyPhongData();
            dgv.DataSource = bs;
            bn.BindingSource = bs;

            txtMaDangKy.DataBindings.Clear();
            txtMaDangKy.DataBindings.Add("Text", bs, "MaDangKy");

            txtTenKhachHang.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Add("Text", bs, "TenKhachHang");

            txtCMND.DataBindings.Clear();
            txtCMND.DataBindings.Add("Text", bs, "CMND");

            cmbTenPhong.DataBindings.Clear();
            cmbTenPhong.DataBindings.Add("SelectedValue", bs, "MaPhong");

            dateNgayDangKy.DataBindings.Clear();
            dateNgayDangKy.DataBindings.Add("Value", bs, "NgayDangKy");

            dateNgayNhan.DataBindings.Clear();
            dateNgayNhan.DataBindings.Add("Value", bs, "NgayNhanPhong");
        }

        public void HienThiDataGridViewComboBoxMaDangKy(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = data.LayDangKyPhongData();
            cmb.DisplayMember = "MaDangKy";
            cmb.ValueMember = "MaDangKy";
            cmb.DataPropertyName = "MaDangKy";
            cmb.HeaderText = "Mã đăng ký";
        }

        public void HienThiComboBox(ComboBox cmd)
        {
            cmd.DataSource = data.LayDangKyPhongData();
            cmd.DisplayMember = "MaDangKy";
            cmd.ValueMember = "MaDangKy";
        }

        public DangKyPhongInFo LayDangKyPhongData(string id)
        {
            DataTable dt = data.LayThongTinMaDangKyPhong(id);
            DangKyPhongInFo ph = null;
            DangKyPhongControl dkpCtrl = new DangKyPhongControl();
            if (dt.Rows.Count > 0)
            {
                ph.MaPhong = Convert.ToString(dt.Rows[0]["MaPhong"]);
                ph.NgayDangKy = Convert.ToDateTime(dt.Rows[0]["NgayDangKy"]);
            }

            return ph;
        }

        public void HienThiComboBoxPhong(string id, ComboBox cmb)
        {
            DangKyPhongData dataP = new DangKyPhongData();
            cmb.DataSource = dataP.LayThongTinMaDangKyPhong(id);
            cmb.DisplayMember = "MaPhong";
            cmb.ValueMember = "MaPhong";
        }

        public void HienThiDateNgayDangKy(string id, DateTimePicker time)
        {
            DangKyPhongData dataP = new DangKyPhongData();
            ComboBox cmb = new ComboBox();
            cmb.DataSource = dataP.LayThongTinMaDangKyPhong(id);
            cmb.DisplayMember = "NgayDangKy";
            cmb.ValueMember = "NgayDangKy";
            time.Text = cmb.Text;
        }

        public void XoaDataTheoMaPhong(string maDK)
        {
            data.XoaDataTheoMaPhong(maDK);
        }

        public void Update()
        {
            bs.MoveNext();
            data.Save();
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
