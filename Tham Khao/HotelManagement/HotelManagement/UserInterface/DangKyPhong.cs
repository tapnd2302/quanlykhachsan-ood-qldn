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
    public partial class DangKyPhong : Form
    {
        public DangKyPhong()
        {
            InitializeComponent();
        }

        DangKyPhongControl dkpCtrl = new DangKyPhongControl();
        PhongControl phongCtrl = new PhongControl();

        private void DangKyPhong_Load(object sender, EventArgs e)
        {
            phongCtrl.HienThiComboBox(cmbTenPhong);
            phongCtrl.HienThiDataGridViewComboBoxMaPhong(MaPhong);
            dkpCtrl.HienThi(dataGridView, bindingNavigator);
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonThem_Click(object sender, EventArgs e)
        {
            if (txtMaDangKy.Text == null || txtTenKhachHang.Text == null || txtCMND.Text == null)
            {
                MessageBox.Show("Bạn chưa nhập dầy đủ thông tin.\nVui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool checkContain = false;
                foreach (DataGridViewRow item in dataGridView.Rows)
                {
                    if (item.Cells["MaDangKy"].Value.ToString() == txtMaDangKy.Text)
                    {
                        checkContain = true;
                        break;
                    }
                }
                if (checkContain)
                {
                    MessageBox.Show("Mã đăng ký đã tồn tại!\nVui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (DateTime.Compare(dateNgayDangKy.Value, dateNgayNhan.Value) > 0)
                {
                    MessageBox.Show("Ngày nhận phải lớn hơn hoặc bằng ngày đăng ký.\nVui lòn kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        DataRow row = dkpCtrl.NewRow();
                        row["MaDangKy"] = txtMaDangKy.Text;
                        row["TenKhachHang"] = txtTenKhachHang.Text;
                        row["CMND"] = txtCMND.Text;
                        row["MaPhong"] = cmbTenPhong.SelectedValue;
                        row["NgayDangKy"] = dateNgayDangKy.Value.Date;
                        row["NgayNhanPhong"] = dateNgayNhan.Value.Date;

                        dkpCtrl.Add(row);
                        bindingNavigator.BindingSource.MoveLast();
                        dkpCtrl.Save();

                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        phongCtrl.SetTinhTrangPhong(cmbTenPhong.SelectedValue.ToString(), "TTP02");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripCapNhat_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            dkpCtrl.Save();
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButtonXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bindingNavigator.BindingSource.RemoveCurrent();
                bindingNavigatorPositionItem.Focus();
                dkpCtrl.Save();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btPhong_Click(object sender, EventArgs e)
        {
            Phong p = new Phong();
            p.ShowDialog();
        }

        public void RemoveItem(string maDK)
        { 

        }
    }
}
