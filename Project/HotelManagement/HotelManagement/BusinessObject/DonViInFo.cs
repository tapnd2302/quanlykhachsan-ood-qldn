using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.BusinessObject
{
    public class DonViInFo
    {
        private int m_MaDonVi;
        public int MaDonVi
        {
            get { return m_MaDonVi; }
            set { m_MaDonVi = value; }
        }

        private string m_TenDonVi;
        public string TenDonVi
        {
            get { return m_TenDonVi; }
            set { m_TenDonVi = value; }
        }
    }
}

