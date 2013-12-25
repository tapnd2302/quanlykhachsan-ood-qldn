using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.BusinessObject
{
    public class LoaiDichVuInFo
    {
        private int m_MaLoaiDichVu;
        public int MaLoaiDichVu
        {
            get { return m_MaLoaiDichVu; }
            set { m_MaLoaiDichVu = value; }
        }

        private string m_TenLoaiDichVu;
        public string TenLoaiDichVu
        {
            get { return m_TenLoaiDichVu; }
            set { m_TenLoaiDichVu = value; }
        }
    }
}

