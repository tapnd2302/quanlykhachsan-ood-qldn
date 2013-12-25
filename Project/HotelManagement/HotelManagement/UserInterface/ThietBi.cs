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
    public partial class ThietBi : Form
    {
        public ThietBi()
        {
            InitializeComponent();
        }

        ThietBiControl tbCtrl = new ThietBiControl();
        LoaiPhongControl lpCtrl = new LoaiPhongControl();

        private void ThietBi_Load(object sender, EventArgs e)
        {
            lpCtrl.HienThiComboBoxMaLoaiPhong(cmbMaLoaiPhong);
            lpCtrl.HienThiDataGridViewComboBoxColumnMaLoaiPhong(MaLoaiPhong);
            tbCtrl.HienThi(dataGridView, bindingNavigator);
            txtMaThietBi.Text = AutoID.AutoIDCreater("MaThietBi", "TB", dataGridView);
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            tbCtrl.Save();
            MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                bindingNavigatorPositionItem.Focus();
                bindingNavigator.BindingSource.RemoveCurrent();
                tbCtrl.Save();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (txtTenThietBi.Text == "")
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin!\nVui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRow row = tbCtrl.NewRow();

                row["MaThietBi"] = txtMaThietBi.Text;
                row["TenThietBi"] = txtTenThietBi.Text;
                row["MaLoaiPhong"] = cmbMaLoaiPhong.SelectedValue;
                row["SoLuong"] = numSoLuong.Value;
                tbCtrl.Add(row);
                tbCtrl.Save();
                bindingNavigator.BindingSource.MoveLast();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTenThietBi.ResetText();
                txtTenThietBi.Focus();
                txtMaThietBi.Text = AutoID.AutoIDCreater("MaThietBi", "TB", dataGridView);
            }
        }

        private void numSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButton1_Click(sender, e);
            }
        }
    }
}
