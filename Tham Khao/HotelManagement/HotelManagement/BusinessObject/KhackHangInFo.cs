using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.BusinessObject
{
    public class KhachHangInFo
    {
        private string m_MaKhachHang;
        public string MaKhachHang
        {
            get { return m_MaKhachHang; }
            set { m_MaKhachHang = value; }
        }

        private string m_TenKhachHang;
        public string TenKhachHang
        {
            get { return m_TenKhachHang; }
            set { m_TenKhachHang = value; }
        }

        private string m_CMND;
        public string CMND
        {
            get { return m_CMND; }
            set { m_CMND = value; }
        }
    }
}
