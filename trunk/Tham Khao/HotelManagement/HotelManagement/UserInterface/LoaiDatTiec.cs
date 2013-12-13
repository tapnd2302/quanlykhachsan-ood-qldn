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
    public partial class LoaiDatTiec : Form
    {
        public LoaiDatTiec()
        {
            InitializeComponent();
        }

        LoaiDatTiecControl ldtCtrl = new LoaiDatTiecControl(); 

        private void LoaiDatTiec_Load(object sender, EventArgs e)
        {
            ldtCtrl.HienThi(dataGridView, bindingNavigator);
            txtMaLoaiDatTiec.Text = AutoID.AutoIDCreater("MaLoaiDatTiec", "LDT", dataGridView);
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            ldtCtrl.Save();
            MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                bindingNavigatorPositionItem.Focus();
                bindingNavigator.BindingSource.RemoveCurrent();
                ldtCtrl.Save();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiDatTiec.Text == "")
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin!\nVui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRow row = ldtCtrl.NewRow();

                row["MaLoaiDatTiec"] = txtMaLoaiDatTiec.Text;
                row["TenLoaiDatTiec"] = txtTenLoaiDatTiec.Text;
                ldtCtrl.Add(row);
                ldtCtrl.Save();
                bindingNavigator.BindingSource.MoveLast();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTenLoaiDatTiec.ResetText();
                txtTenLoaiDatTiec.Focus();
                txtMaLoaiDatTiec.Text = AutoID.AutoIDCreater("MaLoaiDatTiec", "LDT", dataGridView);
            }
        }

        private void txtTenLoaiDatTiec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButton1_Click(sender, e);
            }
        }
    }
}
