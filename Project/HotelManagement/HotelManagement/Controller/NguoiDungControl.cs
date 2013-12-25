using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using System.Windows.Forms;
using System.Data;

namespace HotelManagement.Controller
{
    public class NguoiDungControl
    {
        NguoiDungData data = new NguoiDungData();
        NguoiDungData data1 = new NguoiDungData();

        public NguoiDungControl()
        {

        }

        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDSNguoiDung();

            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        private string m_PhanQuyen;
        public string PhanQuyen
        {
            get { return m_PhanQuyen; }
            set { m_PhanQuyen = value; }
        }

        //0: nguoi dung khong ton tai
        //1: sai mat khau
        //2: mat khau thanh cong

        public int DangNhap(String tenDangNhap, String matKhau)
        {
            DataTable dt = data.LayDSNguoiDung(tenDangNhap);
            if (dt.Rows.Count == 0)
                return 0;

            String matkhau_hethong = dt.Rows[0]["MatKhau"].ToString();

            if (matkhau_hethong != matKhau)
            {
                return 1;// sai mat khau
            }
            else
            {
                PhanQuyen = dt.Rows[0]["MaLoaiNguoiDung"].ToString();
                return 2;// Dang nhap thanh cong
            }
        }

        public void UpdatePassWord(String tenDangNhap, String matKhau)
        {
            data1.UpdatePassWord(tenDangNhap, matKhau);
        }

        public DataRow NewRow()
        {
            return this.data.NewRow();
        }

        public void Add(DataRow row)
        {
            this.data.Add(row);
        }

        public bool Save()
        {
            return this.data.Save();
        }
    }
}
