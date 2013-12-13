using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.BusinessObject
{
    public class LoaiNguoiDungInFo
    {
        private int m_LoaiNguoiDung;
        public int LoaiNguoiDung
        {
            get { return m_LoaiNguoiDung; }
            set { m_LoaiNguoiDung = value; }
        }

        private string m_TenLoaiNguoiDung;
        public string TenLoaiNguoiDung
        {
            get { return m_TenLoaiNguoiDung; }
            set { m_TenLoaiNguoiDung = value; }
        }
    }
}
