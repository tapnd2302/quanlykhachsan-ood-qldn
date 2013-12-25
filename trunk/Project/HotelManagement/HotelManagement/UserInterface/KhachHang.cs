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
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        KhachHangControl khCtrl = new KhachHangControl();

        private void ThoattoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            khCtrl.HienThi(dataGridView, bindingNavigator);
            txtMaKhachHang.Text = AutoID.AutoIDCreater("MaKhachHang", "KH", dataGridView);
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            try
            {
                bindingNavigatorPositionItem.Focus();
                khCtrl.Save();
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập thông tin khách hàng.\nMời bạn kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButton1_Click(sender, e);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (txtTenKhachHang.Text == "" || txtCMND.Text == "" || txtDienThoai.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin!\nVui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DataRow row = khCtrl.NewRow();

                    row["MaKhachHang"] = txtMaKhachHang.Text;
                    row["TenKhachHang"] = txtTenKhachHang.Text;
                    row["CMND"] = txtCMND.Text;
                    row["DiaChi"] = txtDiaChi.Text;
                    row["DienThoai"] = txtDienThoai.Text;
                    khCtrl.Add(row);
                    khCtrl.Save();

                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtTenKhachHang.ResetText();
                    txtCMND.ResetText();
                    txtDiaChi.ResetText();
                    txtDienThoai.ResetText();

                    txtTenKhachHang.Focus();
                    txtMaKhachHang.Text = AutoID.AutoIDCreater("MaKhachHang", "KH", dataGridView);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nhập thông tin khách hàng.\nMời bạn kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                bindingNavigatorPositionItem.Focus();
                bindingNavigator.BindingSource.RemoveCurrent();
                khCtrl.Save();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
