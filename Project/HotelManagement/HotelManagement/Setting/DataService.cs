using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagement.Setting
{
    public class DataService : DataTable
    {
        static SqlConnection m_Connection;
        SqlDataAdapter m_DataAdapter;//thuonng dung doc du lieu lenh datagridview. ton nhieu bo nho
        SqlCommand m_Command;//doc du lieu len combobox. ton it bo nho

        public static string strConnect = "Data Source=(local);Initial Catalog=QUAN_LY_KHACH_SAN;Integrated Security=True";

        public DataService()
        {

        }

        public void Load(SqlCommand command)
        {
            m_DataAdapter = new SqlDataAdapter();
            m_Command = new SqlCommand();
            if (m_Connection == null || m_Connection.State == ConnectionState.Closed)
            {
                m_Connection = new SqlConnection(strConnect);
                m_Connection.Open();
            }

            m_Command = command;
            m_Command.Connection = m_Connection;
            m_DataAdapter = new SqlDataAdapter(m_Command);
            this.Clear();
            m_DataAdapter.Fill(this);// lay du lieu tu datasource do len dataset/datatable
        }

        public static bool OpenConnection()
        {
            try
            {
                if (m_Connection == null)
                {
                    m_Connection = new SqlConnection(strConnect);
                }
                if (m_Connection.State == ConnectionState.Closed)
                {
                    m_Connection.Open();
                }
                return true;
            }
            catch (System.Exception ex)
            {
                m_Connection.Close();
                return false;
            }
        }

        public void Update()
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(m_DataAdapter);
            m_DataAdapter.Update(this);//do du lieu vao datasource
        }

        public void UpdatePassWord(String tenDangNhap, String matKhauMoi)
        {
            m_Command = new SqlCommand();
            m_DataAdapter = new SqlDataAdapter();
            String sql = "UPDATE NGUOI_DUNG SET MatKhau = @matKhau WHERE TenDangNhap = @ten";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("ten", SqlDbType.VarChar).Value = tenDangNhap;
            cmd.Parameters.Add("matKhau", SqlDbType.VarChar).Value = matKhauMoi;
            if (m_Connection == null || m_Connection.State == ConnectionState.Closed)
            {
                m_Connection = new SqlConnection(strConnect);
                m_Connection.Open();
            }

            m_Command = cmd;
            m_Command.Connection = m_Connection;
            m_DataAdapter = new SqlDataAdapter(m_Command);
            m_DataAdapter.Fill(this);
            SqlCommandBuilder builder = new SqlCommandBuilder(m_DataAdapter);
            // SqlCommandBuilder: sẽ quản lí những thay đổi trên Datasource, sau đó
            // nó tự động update vào csdl mà chúng ta không cần phải làm gì.
            m_DataAdapter.Update(this);
        }

        public int ExecuteNoneQuery()
        {
            int result = 0;
            SqlTransaction tr = null;
            try
            {
                tr = m_Connection.BeginTransaction();

                m_Command.Connection = m_Connection;
                m_Command.Transaction = tr;

                m_DataAdapter = new SqlDataAdapter();
                m_DataAdapter.SelectCommand = m_Command;

                SqlCommandBuilder builder = new SqlCommandBuilder(m_DataAdapter);

                result = m_DataAdapter.Update(this);
                tr.Commit();
            }
            catch (System.Exception ex)
            {
                if (tr != null) tr.Rollback();
            }
            return result;
        }

        // thuc thi 1 command
        public int ExecuteNoneQuery(SqlCommand cmd)
        {
            int result = 0;
            SqlTransaction tr = null;

            try
            {
                tr = m_Connection.BeginTransaction();

                cmd.Connection = m_Connection;
                cmd.Transaction = tr;

                result = cmd.ExecuteNonQuery();

                this.AcceptChanges();

                tr.Commit();
            }
            catch (System.Exception ex)
            {
                if (tr != null)
                    tr.Rollback();
                throw;
            }
            return result;
        }

        public object ExecuteScalar(SqlCommand cmd)
        {
            object result = null;
            SqlTransaction tr = null;

            tr = m_Connection.BeginTransaction();

            cmd.Connection = m_Connection;
            cmd.Transaction = tr;
            result = cmd.ExecuteScalar();
            this.AcceptChanges();
            tr.Commit();
            if (result == DBNull.Value)
            {
                result = null;
            }
            return result;
        }

    }
}