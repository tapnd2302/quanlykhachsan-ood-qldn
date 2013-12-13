using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using System.Windows.Forms;
using HotelManagement.BusinessObject;
using System.Data;

namespace HotelManagement.Controller
{
    public class LoaiNguoiDungControl
    {
        LoaiNguoiDungData data = new LoaiNguoiDungData();

        public void HienThiDataGridViewComboBoxColumn(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = data.LayDSLoaiNguoiDung();
            cmb.DisplayMember = "TenLoaiNguoiDung";
            cmb.ValueMember = "MaLoaiNguoiDung";
            cmb.DataPropertyName = "MaLoaiNguoiDung";
            cmb.HeaderText = "Loại người dùng";
        }

        public void HienThiComboBox(ComboBox cmb)
        {
            cmb.DataSource = data.LayDSLoaiNguoiDung();
            cmb.DisplayMember = "TenLoaiNguoiDung";
            cmb.ValueMember = "MaLoaiNguoiDung";
        }

        public LoaiNguoiDungInFo LayLoaiNguoiDung(string id)
        {
            LoaiNguoiDungInFo lnd = null;
            DataTable dt = data.LayDSLoaiNguoiDung_Ten(id);
            if (dt.Rows.Count > 0)
            {
                lnd = new LoaiNguoiDungInFo();
                lnd.LoaiNguoiDung = Convert.ToInt32(dt.Rows[0]["MaLoaiNguoiDung"]);
            }
            return lnd;
        }

        public void Update()
        {
            data.Update();
        }
    }
}
