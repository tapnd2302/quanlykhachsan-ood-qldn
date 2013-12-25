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
    public partial class LoaiDichVu : Form
    {
        public LoaiDichVu()
        {
            InitializeComponent();
        }

        LoaiDichVuControl ldvCtrl = new LoaiDichVuControl();

        private void LoaiDichVu_Load(object sender, EventArgs e)
        {
            ldvCtrl.HienThi(dataGridView, bindingNavigator);
            txtMaLoaiDichVu.Text = AutoID.AutoIDCreater("MaLoaiDichVu", "LDV", dataGridView);
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            ldvCtrl.Save();
            MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                bindingNavigatorPositionItem.Focus();
                bindingNavigator.BindingSource.RemoveCurrent();
                ldvCtrl.Save();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiDichVu.Text == "")
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin!\nVui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRow row = ldvCtrl.NewRow();

                row["MaLoaiDichVu"] = txtMaLoaiDichVu.Text;
                row["TenLoaiDichVu"] = txtTenLoaiDichVu.Text;
                ldvCtrl.Add(row);
                ldvCtrl.Save();
                bindingNavigator.BindingSource.MoveLast();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTenLoaiDichVu.ResetText();
                txtTenLoaiDichVu.Focus();
                txtMaLoaiDichVu.Text = AutoID.AutoIDCreater("MaLoaiDichVu", "LDV", dataGridView);
            }
        }

        private void txtTenLoaiDichVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButton1_Click(sender, e);
            }
        }
    }
}
