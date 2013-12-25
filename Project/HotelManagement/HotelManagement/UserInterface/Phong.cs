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
    public partial class Phong : Form
    {
        PhongControl pCtrl = new PhongControl();
        LoaiPhongControl lpCtrl = new LoaiPhongControl();
        LoaiTinhTrangPhongControl lttpCtrl = new LoaiTinhTrangPhongControl();

        public Phong()
        {
            InitializeComponent();
        }

        private void Phong_Load(object sender, EventArgs e)
        {
            lpCtrl.HienThiComboBoxMaLoaiPhong(cmbLoaiPhong);
            lpCtrl.HienThiDataGridViewComboBoxColumnMaLoaiPhong(MaLoaiPhong);
            lttpCtrl.HienThiComboBox(cmbLoaiTinhTrangPhong);
            lttpCtrl.HienThiDataGridViewComboBoxColumn(MaLoaiTinhTrangPhong);
            pCtrl.HienThi(dataGridView, bindingNavigator);
            txtMaPhong.Text = AutoID.AutoIDCreater("MaPhong", "P", dataGridView);
        }

        private void btMaLoaiPhong_Click(object sender, EventArgs e)
        {
            LoaiPhong lp = new LoaiPhong();
            lp.ShowDialog();
        }

        private void btTinhTrangPhong_Click(object sender, EventArgs e)
        {
            LoaiTinhTrangPhong ttp = new LoaiTinhTrangPhong();
            ttp.ShowDialog();
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            pCtrl.Save();
            MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow item = dataGridView.SelectedRows[0];
                if (item.Cells["MaLoaiTinhTrangPhong"].Value.ToString() == "TTP1" || item.Cells["MaLoaiTinhTrangPhong"].Value.ToString() == "TTP4")
                {
                    bindingNavigatorPositionItem.Focus();
                    bindingNavigator.BindingSource.RemoveCurrent();
                    pCtrl.Save();
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xóa được!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButtonThem_Click(sender, e);
            }
        }

        private void toolStripButtonThem_Click(object sender, EventArgs e)
        {
            if (txtTenPhong.Text == "")
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin!\nVui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRow row = pCtrl.NewRow();

                row["MaPhong"] = txtMaPhong.Text;
                row["TenPhong"] = txtTenPhong.Text;
                row["MaLoaiPhong"] = cmbLoaiPhong.SelectedValue;
                row["MaTinhTrang"] = cmbLoaiTinhTrangPhong.SelectedValue;
                row["GhiChu"] = txtGhiChu.Text;
                pCtrl.Add(row);
                pCtrl.Save();
                bindingNavigator.BindingSource.MoveLast();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTenPhong.ResetText();
                txtGhiChu.ResetText();
                txtTenPhong.Focus();
                txtMaPhong.Text = AutoID.AutoIDCreater("MaPhong", "P", dataGridView);
            }
        }
    }
}
