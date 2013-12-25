using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.BusinessObject;

namespace HotelManagement.DataObject
{
    public class DanhSachSuDungDichVuInFo
    {
        private string m_MaSuDungDVu;
        public string MaSuDungDV
        {
            get { return m_MaSuDungDVu; }
            set { m_MaSuDungDVu = value; }
        }

        private string m_MaDichVu;
        public string MaDichVu
        {
            get { return m_MaDichVu; }
            set { m_MaDichVu = value; }
        }

        private int m_SoLuong;
        public int SoLuong
        {
            get { return m_SoLuong; }
            set { m_SoLuong = value; }
        }
    }
}
