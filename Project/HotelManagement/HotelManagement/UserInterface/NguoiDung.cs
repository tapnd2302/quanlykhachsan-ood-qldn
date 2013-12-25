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
    public partial class NguoiDung : Form
    {
        NguoiDungControl ndCtrl = new NguoiDungControl();
        LoaiNguoiDungControl lndCtrl = new LoaiNguoiDungControl();

        string name = "";

        public NguoiDung()
        {
            InitializeComponent();
        }

        public NguoiDung(string nameDN)
        {
            name = nameDN;
            InitializeComponent();
        }

        private void NguoiDung_Load(object sender, EventArgs e)
        {
            lndCtrl.HienThiComboBox(cmbLoaiNguoiDung);
            lndCtrl.HienThiDataGridViewComboBoxColumn(MaLoaiNguoiDung);
            ndCtrl.HienThi(dataGridView, bindingNavigator);
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonThem_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == null || txtMatKhau.Text == "" || cmbLoaiNguoiDung.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin!\nVui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool checkContain = false;
                foreach (DataGridViewRow item in dataGridView.Rows )
                {
                    if (item.Cells["TenDangNhap"].Value.ToString() == txtTenDangNhap.Text)
                    {
                        checkContain = true;
                        break;
                    }
                }
                if (checkContain)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!\nVui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataRow row = ndCtrl.NewRow();

                    row["TenDangNhap"] = txtTenDangNhap.Text;
                    row["MatKhau"] = txtMatKhau.Text;
                    row["MaLoaiNguoiDung"] = cmbLoaiNguoiDung.SelectedValue.ToString();
                    ndCtrl.Add(row);
                    ndCtrl.Save();
                    bindingNavigator.BindingSource.MoveLast();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void toolStripButtonXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bindingNavigatorPositionItem.Focus();
                bindingNavigator.BindingSource.RemoveCurrent();
                ndCtrl.Save();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButtonThem_Click(sender, e); 
            }
        }

        private void txtTenDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButtonThem_Click(sender, e);
            }
        }
    }
}
