using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotelManagement
{
    public static class AutoID
    {
        public static string AutoIDCreater(string key, string headID, DataGridView data)
        {
            string id = headID;
            int headLength = headID.Length;
            int tailLength = 0;
            if (data.RowCount == 0)
            {
                return (headID + "1");
            }
            else
            { 
                DataGridViewRow item = data.Rows[data.RowCount - 1];

                string lastID = item.Cells[key].Value.ToString();

                tailLength = lastID.Length;

                string count = lastID.Substring(headLength, lastID.Length - headLength);

                id = headID + (Convert.ToInt32(count) + 1);
            }

            return id;
        }
    }
}
