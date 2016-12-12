using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace QuanLyBanHang.Model
{
    class ConnectDatabase
    {
        #region Availible
        //private MySqlConnection Conn;
        private SqlConnection Conn;
        //private MySqlCommand _cmd;
        private SqlCommand _cmd;
        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public SqlConnection Connection
        //public MySqlConnection Connection
        {
            get { return Conn; }
        }

        public SqlCommand CMD
        //public MySqlCommand CMD
        {
            get { return _cmd; }
            set { _cmd = value; }
        }
        private string StrCon = null;
        #endregion
        #region Contrustor
        public ConnectDatabase()
        {
            StrCon = @"Data Source=VU;Initial Catalog=QLBH;Integrated Security=True";
            //Conn = new MySqlConnection(StrCon);
            Conn = new SqlConnection(StrCon);
        }
        #endregion
        #region Methods
        public bool OpenConn()
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
            }
            catch(Exception ex)
            {
                _error = ex.Message;
                return false;
            }
            return true;
        }
        public bool CloseConn()
        {
            try
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }
            return true;
        }
        #endregion
    }
}
