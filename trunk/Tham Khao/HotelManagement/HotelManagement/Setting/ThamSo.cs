using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace HotelManagement.Setting
{
    public enum Controll
    {
        Normal,
        AddNew,
        Edit
    }

    public class ThamSo
    {
        public static void PreMonth(ref int thangTruoc, ref int namTruoc, int thang, int nam)
        {
            thangTruoc = thang - 1;
            namTruoc = nam - 1;
            if (thangTruoc == 0)
            {
                thangTruoc = 12;
                namTruoc = nam - 1;
            }
        }

        public static bool LaSoNguyen(String so)
        {
            try
            {
                Convert.ToInt64(so);
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public static int LayPhieuDangKy()
        {
            DataService ds = new DataService();
            object obj = ds.ExecuteScalar(new System.Data.SqlClient.SqlCommand("select PhieuDangKy from THAM_SO"));
            return Convert.ToInt32(obj);
        }

        public static void GanPhieuDangKy(int id)
        {
            DataService ds = new DataService();
            ds.ExecuteNoneQuery(new SqlCommand("Update THAM_SO set PhieuDangKy = " + id));
        }

        public static long LayHoaDon()
        {
            DataService ds = new DataService();
            object obj = ds.ExecuteScalar(new SqlCommand("select HoaDon from THAM_SO"));
            return Convert.ToInt32(obj);
        }

        public static void GanHoaDon(long id)
        {
            DataService ds = new DataService();
            ds.ExecuteNoneQuery(new SqlCommand("update THAM_SO set HoaDon = " + id));
        }

        public static int LayPhieuNhan()
        {
            DataService ds = new DataService();
            object obj = ds.ExecuteScalar(new SqlCommand("select PhieuNhan from THAM_SO"));
            return Convert.ToInt32(obj); 
        }

        public static void GanPhieuNhan(int id)
        {
            DataService ds = new DataService();
            ds.ExecuteNoneQuery(new SqlCommand("update THAM_SO set PhieuNhan = " + id));
        }

        public static long HoaDon
        {
            get
            {
                DataService ds = new DataService();
                object obj = ds.ExecuteScalar(new SqlCommand("select HoaDon from THAM_SO"));
                return Convert.ToInt32(obj);
            }
            set
            {
                DataService ds = new DataService();
                ds.ExecuteNoneQuery(new SqlCommand("update THAM_SO set HoaDon = " + value));
            }
        }
    }
}
