using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private String m_TenNguoiDung;
        public String lay_TenNguoiDung
        {
            get { return m_TenNguoiDung; }
            set { m_TenNguoiDung = value; }
        }

        public String m_MatKhau;
        public String lay_MatKhau
        {
            get { return m_MatKhau; }
            set { m_MatKhau = value; }
        }

        private void btDongY_Click(object sender, EventArgs e)
        {
            this.txtTenDangNhap.Focus();
            m_TenNguoiDung = txtTenDangNhap.Text;
            m_MatKhau = txtMatKhau.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            this.txtTenDangNhap.Text = "";
            this.txtMatKhau.Text = "";
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            this.txtTenDangNhap.Focus();
            m_TenNguoiDung = txtTenDangNhap.Text;
            m_MatKhau = txtMatKhau.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btLogin_Click(sender, e);
            }
        }

        private void txtTenDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btLogin_Click(sender, e);
            }
        }
    }
}
