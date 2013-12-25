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
    public partial class QuiDinh : Form
    {
        public QuiDinh()
        {
            InitializeComponent();
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
