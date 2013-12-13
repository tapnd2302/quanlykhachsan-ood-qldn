using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.BusinessObject
{
    public class LoaiDatTiecInFo
    {
        private int m_MaLoaiDatTiec;
        public int MaLoaiDatTiec
        {
            get { return m_MaLoaiDatTiec; }
            set { m_MaLoaiDatTiec = value; }
        }

        private string m_TenLoaiDatTiec;
        public string TenLoaiDatTiec
        {
            get { return m_TenLoaiDatTiec; }
            set { m_TenLoaiDatTiec = value; }
        }
    }
}
