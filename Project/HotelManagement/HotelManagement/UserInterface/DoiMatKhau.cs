using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotelManagement.Controller;
using HotelManagement.BusinessObject;

namespace HotelManagement.UserInterface
{
    public partial class DoiMatKhau : Form
    {
        NguoiDungControl ndCtrl = new NguoiDungControl();
        private int kTra;
        public int KTDangNhap
        {
            get { return kTra; }
            set { kTra = value; }
        }

        private NguoiDungInFo m_NguoiDung;
        public NguoiDungInFo NguoiDungDMK
        {
            get { return m_NguoiDung; }
            set { m_NguoiDung = value; }
        }

        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            this.txtMatKhauCu.Text = "";
            this.txtMatKhauMoi.Text = "";
            this.txtMatKhauXacNhanDoiMK.Text = "";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void txtMatKhauXacNhanDoiMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonX2_Click(sender, e);
            }
        }

        private void txtMatKhauMoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonX2_Click(sender, e);
            }
        }

        private void txtMatKhauCu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonX2_Click(sender, e);
            }
        }
    }
}
