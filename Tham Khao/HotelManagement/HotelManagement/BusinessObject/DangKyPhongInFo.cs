using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.BusinessObject
{
    public class DangKyPhongInFo
    {
        private string m_MaPhong;
        public string MaPhong
        {
            get { return m_MaPhong; }
            set { m_MaPhong = value; }
        }

        private DateTime m_NgayDangKy;
        public DateTime NgayDangKy
        {
            get { return m_NgayDangKy; }
            set { m_NgayDangKy = value; }
        }
    }
}
