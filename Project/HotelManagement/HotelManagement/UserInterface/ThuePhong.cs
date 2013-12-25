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
    public partial class ThuePhong : Form
    {
        public ThuePhong()
        {
            InitializeComponent();
        }

        DangKyPhongControl dkpCtrl = new DangKyPhongControl();
        PhieuThuePhongControl tpCtrl = new PhieuThuePhongControl();
        PhongControl pCtrl = new PhongControl();
        KhachHangControl khCtrl = new KhachHangControl();
        LoaiPhongControl lpCtrl = new LoaiPhongControl();
        bool dangKyTruoc = false;

        private void ThuePhong_Load(object sender, EventArgs e)
        {
            cmbMaDangKy.Enabled = false;
            btDangKyPhong.Enabled = false;
            //khCtrl.HienThiComboBoxMaKhachHang(cmbMaKhachHang);
            pCtrl.HienThiComboBoxPhong("TTP01", cmbMaPhong);
            //khCtrl.HienThiDataGridViewComboBoxColumnMaKhachHang(MaKhachHang);
            //pCtrl.HienThiDataGridViewComboBoxMaPhong(MaPhong);
            tpCtrl.HienThi(dataGridView, bindingNavigator);
            //dkpCtrl.HienThiDataGridViewComboBoxMaDangKy(MaDangKy);

            txtMaPhieuThue.Text = AutoID.AutoIDCreater("MaPhieuThuePhong", "PTP", dataGridView);
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbCo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCo.Checked)
            {
                dangKyTruoc = true;
                btDangKyPhong.Enabled = true;
                cmbMaDangKy.Enabled = true;
                //cmbMaPhong.Enabled = false;
                dkpCtrl.HienThiComboBox(cmbMaDangKy);
            }
        }

        private void rbKhong_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKhong.Checked)
            {
                dangKyTruoc = false;
                btDangKyPhong.Enabled = false;
                cmbMaDangKy.Enabled = false;
                cmbMaPhong.Enabled = true;

                pCtrl.HienThiComboBoxPhong("TTP01", cmbMaPhong);
            }
        }

        private void btDangKyPhong_Click(object sender, EventArgs e)
        {
            DangKyPhong dkp = new DangKyPhong();
            dkp.ShowDialog();
            dkpCtrl.HienThiComboBox(cmbMaDangKy);
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            tpCtrl.Save();
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void themtoolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaPhieuThue.Text == null || cmbMaKhachHang.SelectedValue == null || numSoLuong.Value == 0) 
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin\nVui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string maLoaiPhong = pCtrl.LayMaLoaiPhong(cmbMaPhong.SelectedValue.ToString());

                    if (DateTime.Compare(dateNgayThue.Value.Date, dateNgayTra.Value.Date) >= 1)
                    {
                        MessageBox.Show("Ngày trả phải lớn hơn hoặc bằng ngày thuê.\nVui lòn kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (numSoLuong.Value > lpCtrl.LaySoNguoiToiDa(maLoaiPhong))
                    {
                        MessageBox.Show("Số người thuê quá số lượng chứa cho phép của phòng.\nVui lòn kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        bool checkContain = false;
                        foreach (DataGridViewRow item in dataGridView.Rows)
                        {
                            if (item.Cells["MaPhieuThuePhong"].Value.ToString() == txtMaPhieuThue.Text)
                            {
                                checkContain = true;
                                break;
                            }
                        }
                        if (checkContain)
                        {
                            MessageBox.Show("Mã phiếu thuê phòng đã tồn tại!\nVui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DataRow row = tpCtrl.NewRow();

                            row["MaPhieuThuePhong"] = txtMaPhieuThue.Text;
                            row["MaPhong"] = cmbMaPhong.SelectedValue;
                            row["MaKhachHang"] = cmbMaKhachHang.SelectedValue;
                            row["NgayThuePhong"] = dateNgayThue.Value.Date;
                            row["NgayTra"] = dateNgayTra.Value.Date;
                            row["SoLuong"] = numSoLuong.Value;

                            tpCtrl.Add(row);
                            bindingNavigator.BindingSource.MoveLast();
                            tpCtrl.Save();

                            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            pCtrl.SetTinhTrangPhong(cmbMaPhong.SelectedValue.ToString(), "TTP2");

                            if (dangKyTruoc)
                            {
                                dkpCtrl.XoaDataTheoMaPhong(cmbMaDangKy.SelectedValue.ToString());
                            }

                            txtMaPhieuThue.Text = AutoID.AutoIDCreater("MaPhieuThuePhong", "PTP", dataGridView);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.ShowDialog();
            khCtrl.HienThiComboBoxMaKhachHang(cmbMaKhachHang);
        }

        private void btPhong_Click(object sender, EventArgs e)
        {
            Phong p = new Phong();
            p.ShowDialog();
            pCtrl.HienThiComboBox(cmbMaPhong);
        }

        private void cmbMaDangKy_Click(object sender, EventArgs e)
        {
            string str = cmbMaDangKy.SelectedValue.ToString();
            dkpCtrl.HienThiComboBoxPhong(str, cmbMaPhong);
            cmbMaPhong.SelectedValue = cmbMaPhong.Items[0];
        }
    }
}
