using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotelManagement.Controller;

namespace HotelManagement.UserInterface
{
    public partial class LoaiPhong : Form
    {
        LoaiPhongControl ctrl = new LoaiPhongControl();

        public LoaiPhong()
        {
            InitializeComponent();
        }

        private void LoaiPhong_Load(object sender, EventArgs e)
        {
            ctrl.HienThi(dataGridView, bindingNavigator);
            txtMaLoaiPhong.Text = AutoID.AutoIDCreater("MaLoaiPhong", "LP", dataGridView);
        }

        private void toolStripluu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            ctrl.Save();
            MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                bindingNavigatorPositionItem.Focus();
                bindingNavigator.BindingSource.RemoveCurrent();
                ctrl.Save();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButtonThem_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiPhong.Text == "")
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin!\nVui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRow row = ctrl.NewRow();

                row["MaLoaiPhong"] = txtMaLoaiPhong.Text;
                row["TenLoaiPhong"] = txtTenLoaiPhong.Text;
                row["DonGia"] = numDonGia.Value;
                row["SoNguoiToiDa"] = numSoNguoiToiDa.Value;
                ctrl.Add(row);
                ctrl.Save();
                bindingNavigator.BindingSource.MoveLast();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTenLoaiPhong.ResetText();
                txtTenLoaiPhong.Focus();
                txtMaLoaiPhong.Text = AutoID.AutoIDCreater("MaLoaiPhong", "LP", dataGridView);
            }
        }

        private void numDonGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButtonThem_Click(sender, e);
            }
        }
    }
}
