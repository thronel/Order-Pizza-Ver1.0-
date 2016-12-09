using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanHang.Object;

namespace QuanLyBanHang.Model
{
    class NhanVienMod
    {
        ConnectDatabase con = new ConnectDatabase();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            //MaNV, TenNhanVien, GioiTinh, NamSinh, DiaChi, SDT
            cmd.CommandText = "select MaNV, TenNhanVien, GioiTinh, NamSinh, DiaChi, SDT from NhanVien";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
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
            cmd.CommandText = "Insert into NhanVien values ('" + nvObj.MaNhanVien + "',N'" + nvObj.TenNhanVien + "',N'" + nvObj.GioiTinh + "',CONVERT(DATE,'" + nvObj.NamSinh + "',103),N'" + nvObj.DiaChi + "','" + nvObj.DienThoai + "','" + nvObj.MatKhau + "')";
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
            cmd.CommandText = "Update NhanVien set TenNhanVien =  N'" + nvObj.TenNhanVien + "', GioiTinh = N'" + nvObj.GioiTinh + "', NamSinh = CONVERT(DATE,'" + nvObj.NamSinh + "',103), DiaChi = N'" + nvObj.DiaChi + "',SDT = '" + nvObj.DienThoai + "' Where MaNV = '" + nvObj.MaNhanVien + "'";
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
            cmd.CommandText = "Update NhanVien set MatKhau ='" + nvObj.MatKhau + "' Where MaNV = '" + nvObj.MaNhanVien + "'";
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
            cmd.CommandText = "Delete NhanVien Where MaNV = '" + ma + "'";
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
