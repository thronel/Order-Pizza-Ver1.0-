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
    class ChamCongMod
    {
        ConnectDatabase con = new ConnectDatabase();
        //MySqlCommand cmd = new MySqlCommand();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            
            cmd.CommandText = "SELECT * FROM chamcong";
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
        public bool AddData(ChamCongObj ccObj)
        {
            cmd.CommandText = "insert into chamcong values ('"+ ccObj.Manv +"',CONVERT('"+ ccObj.Date +"',103),'"+ ccObj.Lydo +"', '"+ ccObj.Name +"')";
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

        //public bool GetCode(ChamCongObj ccObj)
        //{
        //    cmd.CommandText = "select nv.MaNhanDang from nhanvien nv, chamcong cc where nv.MaNhanVien = cc.NhanVien";
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = con.Connection;
        //    try
        //    {
        //        con.OpenConn();
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        string mex = ex.Message;
        //        cmd.Dispose();
        //        con.CloseConn();
        //    }
        //    return false;


        //}
        //public bool Check(ChamCongObj ccObj)
        //{
        //    cmd.CommandText = "select nv.TenNhanVien ,nv.MaNhanVien from nhanvien nv , chamcong cc where nv.MaNhanDang = cc.MaNhanDang";
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = con.Connection;
        //    try
        //    {
        //        con.OpenConn();
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        string mex = ex.Message;
        //        cmd.Dispose();
        //        con.CloseConn();
        //    }
        //    return false;
        //}
    }
}
