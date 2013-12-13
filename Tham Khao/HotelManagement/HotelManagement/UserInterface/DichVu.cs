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
    public partial class DichVu : Form
    {
        DichVuControl dichVuCtrl = new DichVuControl();
        LoaiDichVuControl ldvCtrl = new LoaiDichVuControl();
        DonViControl donViCtrl = new DonViControl();
        KhachHangControl khCtrl = new KhachHangControl();

        BangKeDichVuControl dsdvCtrl = new BangKeDichVuControl();

        public DichVu()
        {
            InitializeComponent();
        }

        private void DichVu_Load(object sender, EventArgs e)
        {
            donViCtrl.HienThiComboBox(cmbMaDonVi);
            ldvCtrl.HienThiComboBox(cmbMaLoaiDV);
            khCtrl.HienThiComboBoxMaKhachHang(cmbMaKhachHang);

            ldvCtrl.HienThiDataGridViewComboBoxColumn(MaLoaiDichVu);
            khCtrl.HienThiDataGridViewComboBoxColumnMaKhachHang(MaKhachHang);
            donViCtrl.HienThiDataGridViewComboBoxColumn(MaDonVi);

            dichVuCtrl.HienThi(dataGridView, bindingNavigator);

            txtMaDichVu.Text = AutoID.AutoIDCreater("MaDichVu", "DV", dataGridView);
        }

        private void btMaLoaiDichVu_Click(object sender, EventArgs e)
        {
            LoaiDichVu ldv = new LoaiDichVu();
            ldv.ShowDialog();
            ldvCtrl.HienThiComboBox(cmbMaLoaiDV);
        }

        private void btMaDonVi_Click(object sender, EventArgs e)
        {
            DonVi dv = new DonVi();
            dv.ShowDialog();
            donViCtrl.HienThiComboBox(cmbMaDonVi);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataRow row = dichVuCtrl.NewRow();

            row["MaDichVu"] = txtMaDichVu.Text;
            row["MaKhachHang"] = cmbMaKhachHang.SelectedValue;
            row["MaLoaiDichVu"] = cmbMaLoaiDV.SelectedValue;
            row["MaDonVi"] = cmbMaDonVi.SelectedValue;
            row["DonGia"] = numDonGia.Value;
            row["SoLuong"] = numSoLuong.Value;
            row["NgaySuDung"] = dateSuDung.Value.Date;

            dichVuCtrl.Add(row);
            bindingNavigator.BindingSource.MoveLast();
            dichVuCtrl.Save();

            DataRow rowDK = dsdvCtrl.NewRow();

            rowDK["MaBangKeDichVu"] = "BKDV" + (bindingNavigator.BindingSource.Count);
            rowDK["MaDichVu"] = txtMaDichVu.Text;
            rowDK["MaKhachHang"] = cmbMaKhachHang.SelectedValue;
            rowDK["ThanhTien"] = numDonGia.Value * numSoLuong.Value;

            dsdvCtrl.Add(rowDK);
            dsdvCtrl.Save();

            txtMaDichVu.Text = AutoID.AutoIDCreater("MaDichVu", "DV", dataGridView);

            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.ShowDialog();
            khCtrl.HienThiComboBoxMaKhachHang(cmbMaKhachHang);
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            dichVuCtrl.Save();
            MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
