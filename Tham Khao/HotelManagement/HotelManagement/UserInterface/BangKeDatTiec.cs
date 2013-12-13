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
    public partial class BangKeDatTiec : Form
    {
        public BangKeDatTiec()
        {
            InitializeComponent();
        }

        BangKeDatTiecControl bkdtCtrl = new BangKeDatTiecControl();
        KhachHangControl khCtrl = new KhachHangControl();

        private void BangKeDatTiec_Load(object sender, EventArgs e)
        {
            khCtrl.HienThiComboBoxMaKhachHang(cmbMaKhachHang);
            bkdtCtrl.HienThi(dataGridView, bindingNavigator);
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            bkdtCtrl.HienThi(dataGridView, bindingNavigator, cmbMaKhachHang.SelectedValue.ToString());
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            bkdtCtrl.HienThi(dataGridView, bindingNavigator);
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.ShowDialog();
        }
    }
}
