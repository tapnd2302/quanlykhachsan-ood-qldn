using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotelManagement.Controller;
using HotelManagement.Setting;
using HotelManagement.DataObject;
using HotelManagement.BusinessObject;

namespace HotelManagement.UserInterface
{
    public partial class TraPhong : Form
    {
        public TraPhong()
        {
            InitializeComponent();
        }

        ThanhToanControl traPhongCtrl = new ThanhToanControl();
        PhongControl phongCtr = new PhongControl();
        KhachHangControl khachHangCtrl = new KhachHangControl();
        BangKeDichVuControl bkdvCtrl = new BangKeDichVuControl();
        BangKeDatTiecControl bkdtCtrl = new BangKeDatTiecControl();
        PhieuThuePhongControl thuePhongCtrl = new PhieuThuePhongControl();
        LoaiPhongControl loaiPhongCtrl = new LoaiPhongControl();

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TraPhong_Load(object sender, EventArgs e)
        {
            //phongCtr.HienThiComboBoxPhong("TTP03", cmbMaPhong);
            phongCtr.HienThiComboBox(cmbMaPhong);
            traPhongCtrl.HienThi(dataGridView, bindingNavigator);
            txtMaPhieuTra.Text = AutoID.AutoIDCreater("MaPhieuThanhToan", "PTT", dataGridView);
        }

        private void btPhong_Click(object sender, EventArgs e)
        {
            ThuePhong p = new ThuePhong();
            p.ShowDialog();
            phongCtr.HienThiComboBox(cmbMaPhong);
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.ShowDialog();
            khachHangCtrl.HienThiComboBoxMaKhachHang(cmbTenKhachHang);
        }

        private void btBKDichVu_Click(object sender, EventArgs e)
        {
            BangKeDichVu dv = new BangKeDichVu();
            dv.ShowDialog();
            bkdvCtrl.HienThiComboBoxMaBangKeDV(cmbMaSDDVu);
        }

        private void btBKDatTiec_Click(object sender, EventArgs e)
        {
            BangKeDatTiec dt = new BangKeDatTiec();
            dt.ShowDialog();
            bkdtCtrl.HienThiComboBoxMaBangKeDV(cmbMaDatTiec);
        }

        private void cmbMaPhong_SelectedValueChanged(object sender, EventArgs e)
        {
            string strMaPhong = "";
            string strMaKH = "";

            if (cmbMaPhong.SelectedValue != null)
            {
                strMaPhong = cmbMaPhong.SelectedValue.ToString();
                thuePhongCtrl.HienThiComboBoxMaKhachHang(strMaPhong, cmbTenKhachHang);

                if (cmbTenKhachHang.SelectedValue != null)
                {
                    strMaKH = cmbTenKhachHang.SelectedValue.ToString();
                    bkdvCtrl.HienThiComboBoxMaDichVu(strMaKH, cmbMaSDDVu);
                    bkdtCtrl.HienThiComboBoxMaDichVu(strMaKH, cmbMaDatTiec);

                    DateTime dateThue = thuePhongCtrl.LayNgayThuePhong(strMaPhong);
                    DateTime today = DateTime.Today;

                    int soNgayThue = (today.Date.Year - dateThue.Date.Year) * 365 + (today.Date.Month - dateThue.Date.Month) * 20 + (today.Date.Day - dateThue.Date.Day);

                    txtSoNgayThue.Text = soNgayThue.ToString();

                    string maLoaiPhong = "";
                    maLoaiPhong = phongCtr.LayMaLoaiPhong(strMaPhong);

                    float donGia = loaiPhongCtrl.LayDonGiaLoaiPhong(maLoaiPhong);
                    if (soNgayThue == 0)
                    {
                        numTienPhong.Value = (int)donGia * (int)soNgayThue;
                    }
                    else
                    {
                        numTienPhong.Value = (int)donGia;
                    }

                    numTienDichVu.Value = (int)bkdvCtrl.TinhTienDichVu(strMaKH);

                    numTienDatTiec.Value = (int)bkdtCtrl.TinhTienDatTiec(strMaKH);

                    numThanhTien.Value = numTienPhong.Value + numTienDichVu.Value + numTienDatTiec.Value;
                }
            }
        }

        private void cmbMaPhong_Click(object sender, EventArgs e)
        {
            phongCtr.HienThiComboBox(cmbMaPhong);
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            bindingNavigator.BindingSource.MoveLast();
            traPhongCtrl.Save();
            MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtNguoiThanhToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButtonThem_Click(sender, e);
            }
        }

        private void toolStripButtonThem_Click(object sender, EventArgs e)
        {
            //try
            {
                if (txtNguoiThanhToan.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataRow row = traPhongCtrl.NewRow();

                    row["MaPhieuThanhToan"] = txtMaPhieuTra.Text;
                    row["MaKhachHang"] = cmbTenKhachHang.SelectedValue;
                    row["MaPhong"] = cmbMaPhong.SelectedValue;
                    row["NguoiThanhToan"] = txtNguoiThanhToan.Text;
                    row["NgayThanhToan"] = DateTime.Today.Date;
                    row["TongTien"] = numThanhTien.Value;

                    string maPhong = cmbMaPhong.SelectedValue.ToString();

                    traPhongCtrl.Add(row);
                    bindingNavigator.BindingSource.MoveLast();
                    traPhongCtrl.Save();

                    txtMaPhieuTra.Text = AutoID.AutoIDCreater("MaPhieuThanhToan", "PTT", dataGridView);

                    phongCtr.SetTinhTrangPhong(maPhong, "TTP1");

                    thuePhongCtrl.XoaDataTheoMaPhong(maPhong);

                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //catch (Exception ex)
            //{
            //   MessageBox.Show("Lỗi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void toolStripButtonXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bindingNavigator.BindingSource.RemoveCurrent();
                bindingNavigatorPositionItem.Focus();
                traPhongCtrl.Save();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
