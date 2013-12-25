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
    public partial class DatTiec : Form
    {
        public DatTiec()
        {
            InitializeComponent();
        }

        DatTiecControl dtCtrl = new DatTiecControl();
        KhachHangControl khCtrl = new KhachHangControl();
        LoaiDatTiecControl ldtCtrl = new LoaiDatTiecControl();
        MonAnControl maCtrl = new MonAnControl();
        BangKeDatTiecControl bkdtCtrl = new BangKeDatTiecControl();

        private void DatTiec_Load(object sender, EventArgs e)
        {
            khCtrl.HienThiComboBoxMaKhachHang(cmbMaKhachHang);
            khCtrl.HienThiDataGridViewComboBoxColumnMaKhachHang(MaKhachHang);

            ldtCtrl.HienThiComboBox(cmbMaLoaiDatTiec);
            ldtCtrl.HienThiDataGridViewComboBoxColumn(MaLoaiDatTiec);

            maCtrl.HienThiComboBox(cmbMonAn);
            maCtrl.HienThiDataGridViewComboBoxColumn(MaMonAn);

            dtCtrl.HienThi(dataGridView, bindingNavigator);

            txtMaDatTiec.Text = AutoID.AutoIDCreater("MaDatTiec", "DT", dataGridView);
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            dtCtrl.Save();
            MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.ShowDialog();
            khCtrl.HienThiComboBoxMaKhachHang(cmbMaKhachHang);
        }

        private void btMaLoaiDatTiec_Click(object sender, EventArgs e)
        {
            LoaiDatTiec ldt = new LoaiDatTiec();
            ldt.ShowDialog();
            ldtCtrl.HienThiComboBox(cmbMaLoaiDatTiec);
        }

        private void btMaMonAn_Click(object sender, EventArgs e)
        {
            MonAn ma = new MonAn();
            ma.ShowDialog();
            maCtrl.HienThiComboBox(cmbMonAn);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataRow row = dtCtrl.NewRow();

            row["MaDatTiec"] = txtMaDatTiec.Text;
            row["MaKhachHang"] = cmbMaKhachHang.SelectedValue;
            row["MaLoaiDatTiec"] = cmbMaLoaiDatTiec.SelectedValue;
            row["MaMonAn"] = cmbMonAn.SelectedValue;
            row["NgayDat"] = dateNgayDat.Value.Date;
            row["DonGia"] = numDonGia.Value;

            dtCtrl.Add(row);
            bindingNavigator.BindingSource.MoveLast();
            dtCtrl.Save();

            DataRow rowDT = bkdtCtrl.NewRow();

            rowDT["MaBangKeDatTiec"] = "BKDT" + (bindingNavigator.BindingSource.Count);
            rowDT["MaDatTiec"] = txtMaDatTiec.Text;
            rowDT["MaKhachHang"] = cmbMaKhachHang.SelectedValue;
            rowDT["ThanhTien"] = numDonGia.Value;

            bkdtCtrl.Add(rowDT);
            bkdtCtrl.Save();

            txtMaDatTiec.Text = AutoID.AutoIDCreater("MaDatTiec", "DT", dataGridView);

            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
