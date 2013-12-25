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
    public partial class LoaiTinhTrangPhong : Form
    {
        LoaiTinhTrangPhongControl ctrl = new LoaiTinhTrangPhongControl();

        public LoaiTinhTrangPhong()
        {
            InitializeComponent();
        }

        private void LoaiTinhTrangPhong_Load(object sender, EventArgs e)
        {
            ctrl.HienThi(dataGridView, bindingNavigator);
            // Tao MaLoaiTinhTrang tu dong
            txtMaLoaiTinhTrang.Text = AutoID.AutoIDCreater("MaTinhTrang", "TTP", dataGridView);
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

        private void toolStripButtonLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            ctrl.Save();
            MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonThem_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiTinhTrang.Text == "")
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin!\nVui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRow row = ctrl.NewRow();

                row["MaTinhTrang"] = txtMaLoaiTinhTrang.Text;
                row["TenTinhTrang"] = txtTenLoaiTinhTrang.Text;
                ctrl.Add(row);
                ctrl.Save();
                bindingNavigator.BindingSource.MoveLast();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset txtTenLoaiTinhTrang
                txtTenLoaiTinhTrang.ResetText();
                txtTenLoaiTinhTrang.Focus();
                // Tao MaLoaiTinhTrang tu dong
                txtMaLoaiTinhTrang.Text = AutoID.AutoIDCreater("MaTinhTrang", "TTP", dataGridView);
            }
        }

        private void txtTenLoaiTinhTrang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButtonThem_Click(sender, e);
            }
        }
    }
}
