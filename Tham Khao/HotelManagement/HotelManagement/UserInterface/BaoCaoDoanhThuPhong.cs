using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotelManagement.Controller;

namespace HotelManagement.UserInterface
{
    public partial class BaoCaoDoanhThuPhong : Form
    {
        public BaoCaoDoanhThuPhong()
        {
            InitializeComponent();
        }

        private int thang;
        private int nam;

        PhongControl phongCtrl = new PhongControl();
        ThanhToanControl thanhToanCtrl = new ThanhToanControl();
        BaoCaoDoanhThuPhongControl bcCtrl = new BaoCaoDoanhThuPhongControl();

        private void BaoCaoMatDoSuDungPhong_Load(object sender, EventArgs e)
        {
            phongCtrl.HienThiComboBox(cmbMaPhong);
            bcCtrl.HienThi(dataGridView, bindingNavigator);
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            thang = dateThangNam.Value.Month;
            nam = dateThangNam.Value.Year;

            if (nam > DateTime.Now.Year || (nam == DateTime.Now.Year && thang > DateTime.Now.Month))
            {
                MessageBox.Show("Không thể báo cáo tháng chưa tới!\nTrở về tháng hiện tại.");
            }
            else
            {
                string id = cmbMaPhong.SelectedValue.ToString();

                float doanhThu = thanhToanCtrl.LayDoanhThuBaoCaoPhong(id, thang, nam);

                DataRow row = bcCtrl.NewRow();

                row["MaBaoCao"] = "BC" + id + "." + thang + "." + nam;
                row["MaPhong"] = id;
                row["ThangBaoCao"] = thang;
                row["NamBaoCao"] = nam;
                row["DoanhThu"] = doanhThu;

                bcCtrl.Add(row);
                bindingNavigator.BindingSource.MoveLast();
                bcCtrl.Save();
            }
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            bcCtrl.Save();
        }
    }
}
