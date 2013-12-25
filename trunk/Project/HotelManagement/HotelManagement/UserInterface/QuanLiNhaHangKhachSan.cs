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
using HotelManagement.DataObject;

namespace HotelManagement.UserInterface
{
    public partial class QuanLiNhaHangKhachSan : Form
    {
        string nameDangNhap = "";
        public QuanLiNhaHangKhachSan()
        {
            InitializeComponent();
            Loading m_Loading = new Loading();
            m_Loading.Show();
            System.Threading.Thread.Sleep(3000);
            m_Loading.Close();
        }

        private void UpdateListPhong()
        {
            PhongData data = new PhongData();
            listView.Items.Clear();
            foreach (DataRow dr in data.LayMaPhong().Rows)
            {
                PhongInFo phongInFo = new PhongInFo();
                phongInFo.MaPhong = (string)dr.ItemArray[0];
                phongInFo.MaLoaiPhong = (string)dr.ItemArray[1];
                phongInFo.MaTinhTrangPhong = (string)dr.ItemArray[2];
                
                ListViewItem item = new ListViewItem(phongInFo.TenPhong);

                if (phongInFo.MaTinhTrangPhong == "TTP1")
                {
                    item.ImageIndex = 0;
                }
                else if (phongInFo.MaTinhTrangPhong == "TTP2")
                {
                    item.ImageIndex = 1;
                }
                else if (phongInFo.MaTinhTrangPhong == "TTP3")
                {
                    item.ImageIndex = 2;
                }
                else
                {
                    item.ImageIndex = 3;
                }

                listView.Items.Add(item);
            }
        }

        private void QuanLiNhaHangKhachSan_Load(object sender, EventArgs e)
        {
            //Default();
            UpdateListPhong();
        }
        //
        // He thong
        //-------------------------------------------------------------------------------------
        private void Default()
        {
            btDangNhap.Enabled = true;
            btDangXuat.Enabled = false;
            btDoiMatKhau.Enabled = false;
            btNguoiDung.Enabled = false;
            btThoat.Enabled = true;

            btNhanPhong.Enabled = false;
            btTraPhong.Enabled = false;
            btDangKyTruoc.Enabled = false;
            btPhong.Enabled = false;
            btDichVu.Enabled = false;
            btKhachHang.Enabled = false;

            btLoaiDatTiec.Enabled = false;
            btLoaiTinhTrangPhong.Enabled = false;
            btMonAn.Enabled = false;
            btDonVi.Enabled = false;
            btDSLoaiPhong.Enabled = false;
            btDSLoaiDichVu.Enabled = false;
            btDSThietBi.Enabled = false;
            btDatTiec.Enabled = false;
            btDichVu.Enabled = false;
            btBangKeDichVu.Enabled = false;
            btBangKeDatTiec.Enabled = false;

            btDoanhThu.Enabled = false;

            btQuyDinh.Enabled = false;
            btLienHe.Enabled = true;
        }

        private void Admin()
        {
            btDangNhap.Enabled = true;
            btDangXuat.Enabled = true;
            btDoiMatKhau.Enabled = true;
            btNguoiDung.Enabled = true;
            btThoat.Enabled = true;

            btNhanPhong.Enabled = true;
            btTraPhong.Enabled = true;
            btDangKyTruoc.Enabled = true;
            btPhong.Enabled = true;
            btDichVu.Enabled = true;
            btKhachHang.Enabled = true;

            btLoaiDatTiec.Enabled = true;
            btLoaiTinhTrangPhong.Enabled = true;
            btMonAn.Enabled = true;
            btDonVi.Enabled = true;
            btDSLoaiPhong.Enabled = true;
            btDSLoaiDichVu.Enabled = true;
            btDSThietBi.Enabled = true;
            btDatTiec.Enabled = true;
            btDichVu.Enabled = true;
            btBangKeDichVu.Enabled = true;
            btBangKeDatTiec.Enabled = true;

            btDoanhThu.Enabled = true;

            btQuyDinh.Enabled = true;
            btLienHe.Enabled = true;

            btQuyDinh.Enabled = true;
            btLienHe.Enabled = true;
        }

        private void User()
        {
            btDangNhap.Enabled = true;
            btDangXuat.Enabled = true;
            btDoiMatKhau.Enabled = true;
            btNguoiDung.Enabled = false;
            btThoat.Enabled = true;

            btNhanPhong.Enabled = true;
            btTraPhong.Enabled = true;
            btDangKyTruoc.Enabled = true;
            btPhong.Enabled = false;
            btDichVu.Enabled = true;
            btKhachHang.Enabled = true;

            btLoaiDatTiec.Enabled = false;
            btLoaiTinhTrangPhong.Enabled = false;
            btMonAn.Enabled = false;
            btDonVi.Enabled = false;
            btDSLoaiPhong.Enabled = false;
            btDSLoaiDichVu.Enabled = false;
            btDSThietBi.Enabled = false;
            btDatTiec.Enabled = true;
            btDichVu.Enabled = true;
            btBangKeDichVu.Enabled = true;
            btBangKeDatTiec.Enabled = true;

            btDoanhThu.Enabled = true;

            btQuyDinh.Enabled = true;
            btLienHe.Enabled = true;

            btQuyDinh.Enabled = true;
            btLienHe.Enabled = true;
        }

        DangNhap dangNhap = null;
        private void DangNhap()
        {
        TiepTuc:
            if (dangNhap == null || dangNhap.IsDisposed)
            {
                dangNhap = new DangNhap();
            }
            if (dangNhap.ShowDialog() == DialogResult.OK)
            {
                String tenDangNhap = dangNhap.txtTenDangNhap.Text;
                String matKhau = dangNhap.txtMatKhau.Text;

                NguoiDungControl ndCtrl = new NguoiDungControl();
                int ketqua = ndCtrl.DangNhap(tenDangNhap, matKhau);

                switch (ketqua)
                {
                    case 0:
                        MessageBox.Show("Người dùng không tồn tại!\nVui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto TiepTuc;
                    case 1:
                        MessageBox.Show("Sai mật khẩu!\nVui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto TiepTuc;
                    case 2:
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (ndCtrl.PhanQuyen == "LND01")
                        {
                            nameDangNhap = tenDangNhap;
                            Admin();
                        }
                        else
                        {
                            User();
                        }
                        break;
                }
            }
            else
                dangNhap.Close();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Default();
                MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        DoiMatKhau doiMatKhau = null;
        private void DoiMatKhau()
        {
        tt:
            if (doiMatKhau == null || doiMatKhau.IsDisposed)
            {
                doiMatKhau = new DoiMatKhau();
            }
            if (doiMatKhau.ShowDialog() == DialogResult.OK)
            {
                String tenDN = dangNhap.txtTenDangNhap.Text;
                String mk = dangNhap.txtMatKhau.Text;
                String mkcu = doiMatKhau.txtMatKhauCu.Text;
                String mkmoi = doiMatKhau.txtMatKhauMoi.Text;
                String mkXacNhan = doiMatKhau.txtMatKhauXacNhanDoiMK.Text;

                if (mkcu == "" || mkmoi == "" || mkXacNhan == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto tt;
                }
                else if (mk != mkcu)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!\nVui lòng kiểm tra lại.", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto tt;
                }
                else if (mkmoi != mkXacNhan)
                {
                    MessageBox.Show("Mật khẩu xác nhận không đúng!\nVui lòng kiểm tra lại.", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto tt;
                }
                else
                {
                    NguoiDungControl ndCtrl = new NguoiDungControl();
                    ndCtrl.UpdatePassWord(tenDN, mkmoi);
                    MessageBox.Show("Đổi mật khẩu thành công!", "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau();
        }

        private void btNguoiDung_Click(object sender, EventArgs e)
        {
            NguoiDung nd = new NguoiDung(nameDangNhap);
            nd.ShowDialog();
        }
        //
        // Quan Ly
        //-------------------------------------------------------------------------------------
        private void btNhanPhong_Click(object sender, EventArgs e)
        {
            ThuePhong pnp = new ThuePhong();
            pnp.ShowDialog();
            UpdateListPhong();
        }

        private void btDangKyTruoc_Click(object sender, EventArgs e)
        {
            DangKyPhong pdk = new DangKyPhong();
            pdk.ShowDialog();
            UpdateListPhong();
        }

        private void btTraPhong_Click(object sender, EventArgs e)
        {
            TraPhong hd = new TraPhong();
            hd.ShowDialog();
            UpdateListPhong();
        }

        private void btPhong_Click(object sender, EventArgs e)
        {
            Phong p = new Phong();
            p.ShowDialog();
            UpdateListPhong();
        }
        //
        // Danh muc
        //-------------------------------------------------------------------------------------
        private void btDSThietBi_Click(object sender, EventArgs e)
        {
            ThietBi tb = new ThietBi();
            tb.ShowDialog();
        }

        private void btDSLoaiDichVu_Click(object sender, EventArgs e)
        {
            LoaiDichVu ldv = new LoaiDichVu();
            ldv.ShowDialog();
        }

        private void btDSLoaiPhong_Click(object sender, EventArgs e)
        {
            LoaiPhong lp = new LoaiPhong();
            lp.ShowDialog();
        }

        private void btQuyDinh_Click(object sender, EventArgs e)
        {
            QuiDinh qd = new QuiDinh();
            qd.ShowDialog();
        }

        private void btDichVu_Click(object sender, EventArgs e)
        {
            DichVu dv = new DichVu();
            dv.ShowDialog();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btDangKyTruoc_Click(sender, e);
        }

        private void trảPohngfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btTraPhong_Click(sender, e);
        }

        private void nhậnPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btNhanPhong_Click(sender, e);
        }

        //
        // Right mouse
        //-------------------------------------------------------------------------------------
        private void thêmPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btPhong_Click(sender, e);
        }

        private void buttonLoaiTinhTrangPhong_Click(object sender, EventArgs e)
        {
            LoaiTinhTrangPhong ttp = new LoaiTinhTrangPhong();
            ttp.ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DonVi dv = new DonVi();
            dv.ShowDialog();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            LoaiDatTiec ldt = new LoaiDatTiec();
            ldt.ShowDialog();
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.ShowDialog();
        }

        private void btBangKeDichVu_Click(object sender, EventArgs e)
        {
            BangKeDichVu dv = new BangKeDichVu();
            dv.ShowDialog();
        }

        private void buttonMonAn_Click(object sender, EventArgs e)
        {
            MonAn ma = new MonAn();
            ma.ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            DatTiec dt = new DatTiec();
            dt.ShowDialog();
        }

        private void btBangKeDatTiec_Click(object sender, EventArgs e)
        {
            BangKeDatTiec bkdt = new BangKeDatTiec();
            bkdt.ShowDialog();
        }

        private void btChietXuat_Click(object sender, EventArgs e)
        {
            BaoCaoDoanhThuPhong bc = new BaoCaoDoanhThuPhong();
            bc.ShowDialog();
        }

        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhongData data = new PhongData();
            listView.Items.Clear();
            foreach (DataRow dr in data.LayMaPhong().Rows)
            {
                PhongInFo phongInFo = new PhongInFo();
                phongInFo.MaLoaiPhong = (string)dr.ItemArray[1];
                phongInFo.MaPhong = (string)dr.ItemArray[0];
                phongInFo.MaTinhTrangPhong = (string)dr.ItemArray[2];
                ListViewItem item = new ListViewItem(phongInFo.MaPhong);

                if (phongInFo.MaTinhTrangPhong == "TTP01")
                {
                    item.ImageIndex = 0;
                }
                else if (phongInFo.MaTinhTrangPhong == "TTP02")
                {
                    item.ImageIndex = 1;
                }
                else if (phongInFo.MaTinhTrangPhong == "TTP03")
                {
                    item.ImageIndex = 2;
                }
                else
                {
                    item.ImageIndex = 3;
                }

                listView.Items.Add(item);
            }
        }

        private void btLienHe_Click(object sender, EventArgs e)
        {
            LienHe lh = new LienHe();
            lh.ShowDialog();
        }
        //-------------------------------------------------------------------------------------
    }
}
