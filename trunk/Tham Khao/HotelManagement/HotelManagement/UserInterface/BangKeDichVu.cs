using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotelManagement.Controller;
using HotelManagement.DataObject;
using HotelManagement.BusinessObject;

namespace HotelManagement.UserInterface
{
    public partial class BangKeDichVu : Form
    {
        public BangKeDichVuControl dsdvCtrl = new BangKeDichVuControl();
        public DichVuControl dvCtrl = new DichVuControl();
        public KhachHangControl khCtrl = new KhachHangControl();

        public BangKeDichVu()
        {
            InitializeComponent();
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.ShowDialog();
        }

        private void cmbMaKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void cmbMaKhachHang_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DanhSachSuDungDichVu_Load(object sender, EventArgs e)
        {
            khCtrl.HienThiComboBoxMaKhachHang(cmbMaKhachHang);
            dsdvCtrl.HienThi(dataGridView, bindingNavigator);
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            dsdvCtrl.HienThi(dataGridView, bindingNavigator, cmbMaKhachHang.SelectedValue.ToString());
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            dsdvCtrl.HienThi(dataGridView, bindingNavigator);
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            DichVu dv = new DichVu();
            dv.ShowDialog();
        }
    }
}
