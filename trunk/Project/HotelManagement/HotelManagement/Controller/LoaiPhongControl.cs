using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.DataObject;
using HotelManagement.BusinessObject;
using System.Data;
using System.Windows.Forms;

namespace HotelManagement.Controller
{
    public class LoaiPhongControl
    {
        LoaiPhongData data = new LoaiPhongData();

        public void HienThi(DataGridView dgv, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            DataTable dt = data.LayLoaiPhongData();
            bs.DataSource = dt;
            dgv.DataSource = bs;
            bn.BindingSource = bs;
        }

        public void HienThiComboBoxMaLoaiPhong(ComboBox comboBox)
        {
            comboBox.DataSource = data.LayLoaiPhongData();
            comboBox.DisplayMember = "TenLoaiPhong";
            comboBox.ValueMember = "MaLoaiPhong";
        }

        public void HienThiDataGridViewComboBoxColumnMaLoaiPhong(DataGridViewComboBoxColumn cmb)
        {
            DataTable dt = data.LayLoaiPhongData();
            cmb.DataSource = dt;
            cmb.DisplayMember = "TenLoaiPhong";
            cmb.ValueMember = "MaLoaiPhong";
            cmb.DataPropertyName = "MaLoaiPhong";
            cmb.HeaderText = "Loại Phòng";
        }

        public float LayDonGiaLoaiPhong(string id)
        {
            DataTable dt = data.LayDataTheoMaLoaiPhong(id);
            float dGia = Convert.ToSingle(dt.Rows[0]["DonGia"]);
            return dGia;
        }

        public int LaySoNguoiToiDa(string id)
        {
            DataTable dt = data.LayDataTheoMaLoaiPhong(id);
            int max = Convert.ToInt32(dt.Rows[0]["SoNguoiToiDa"]);
            return max;
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
