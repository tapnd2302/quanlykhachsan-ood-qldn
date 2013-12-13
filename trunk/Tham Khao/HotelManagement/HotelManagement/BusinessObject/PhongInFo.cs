using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.BusinessObject;

namespace HotelManagement.DataObject
{
    public class PhongInFo
    {
        private string m_MaPhong;
        public string MaPhong
        {
            get { return m_MaPhong; }
            set { m_MaPhong = value; }
        }

        private string m_TenPhong;
        public string TenPhong
        {
            get { return m_TenPhong; }
            set { m_TenPhong = value; }
        }

        private string m_MaLoaiPhong;
        public string MaLoaiPhong
        {
            get { return m_MaLoaiPhong; }
            set { m_MaLoaiPhong = value; }
        }

        private string m_MaTinhTrangPhong;
        public string MaTinhTrangPhong
        {
            get { return m_MaTinhTrangPhong; }
            set { m_MaTinhTrangPhong = value; }
        }

        private string m_GhiChu;
        public string GhiChu
        {
            get { return m_GhiChu; }
            set { m_GhiChu = value; }
        }
    }
}
