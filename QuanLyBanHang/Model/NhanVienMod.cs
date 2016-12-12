using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using QuanLyBanHang.Object;

namespace QuanLyBanHang.Model
{
    class NhanVienMod
    {
        ConnectDatabase con = new ConnectDatabase();
        //MySqlCommand cmd = new MySqlCommand();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            //MaNhanVien, TenNhanVien, GioiTinh, NamSinh, DiaChi, SDT
            cmd.CommandText = "SELECT MaNhanVien, TenNhanVien, GioiTinh, NamSinh, DiaChi, SDT FROM nhanvien";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                //MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return dt;
        }

        public bool AddData(NhanVienObj nvObj)
        {
            cmd.CommandText = "Insert into nhanvien values (N'" + nvObj.TenNhanVien + "',N'" + nvObj.GioiTinh + "',CONVERT(DATE,'" + nvObj.NamSinh + "',103),N'" + nvObj.DiaChi + "','" + nvObj.DienThoai + "','" + nvObj.MatKhau + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }

        public bool UpdData(NhanVienObj nvObj)
        {
            cmd.CommandText = "Update nhanvien set TenNhanVien =  N'" + nvObj.TenNhanVien + "', GioiTinh = N'" + nvObj.GioiTinh + "', NamSinh = CONVERT(DATE,'" + nvObj.NamSinh + "',103), DiaChi = N'" + nvObj.DiaChi + "',SDT = '" + nvObj.DienThoai + "' Where MaNhanVien = '" + nvObj.MaNhanVien + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }

        public bool UpdMK(NhanVienObj nvObj)
        {
            cmd.CommandText = "Update nhanvien set MatKhau ='" + nvObj.MatKhau + "' Where MaNhanVien = '" + nvObj.MaNhanVien + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }

        public bool DelData(string ma)
        {
            cmd.CommandText = "Delete nhanvien Where MaNhanVien = '" + ma + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
    }
}
