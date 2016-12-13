using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.Control;
using QuanLyBanHang.Object;
using QuanLyBanHang.Model;

namespace QuanLyBanHang.View
{
    public partial class ChamCongForm : Form
    {
        public ChamCongForm()
        {
            InitializeComponent();
        }
        ChamCongCtrl ccCtr = new ChamCongCtrl();
        ChamCongMod ccMod = new ChamCongMod();
        private int flagLuu = 0;
        string ID1, ID2;

        private void ChamCongForm_Load(object sender, EventArgs e)
        {
            DataTable dtDS = new System.Data.DataTable();
            dtDS = ccCtr.GetData();
            dtgvDS.DataSource = dtDS;
            binhding();
            DisEnl(false);
        }

        private void DisEnl(bool p)
        {
            
        }

        private void binhding()
        {
            dpNgay.DataBindings.Clear();
            dpNgay.DataBindings.Add("Text", dtgvDS.DataSource, "NgayNghi");
            txtLydo.DataBindings.Clear();
            txtLydo.DataBindings.Add("Text", dtgvDS.DataSource, "LyDo");
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add("Text", dtgvDS.DataSource, "Tennhanvien");
            txtManv.DataBindings.Clear();
            txtManv.DataBindings.Add("Text", dtgvDS.DataSource, "Nhanvien");
        }

        private void clearData()
        {
            txtName.Text = "";
            txtLydo.Text = "";
            dpNgay.Value = DateTime.Now.Date;
            txtCheck.Text = "";
        }
        private void addData(ChamCongObj cc)
        {
            cc.Manv = int.Parse(txtManv.Text.Trim());
            cc.Lydo = txtLydo.Text.Trim();
            cc.Name = txtName.Text.Trim();
            cc.Date = dpNgay.Text.Trim();
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
            if (ID1 == ID2)
            { 
              txtName.Enabled = true;
              txtManv.Enabled = true;
              cbCophep.Enabled = true;
              cbKhongphep.Enabled = true;
            }
        }

        private void txtCheck_TextChanged(object sender, EventArgs e)
        {
            
            ID1 = txtCheck.Text.ToString();
        }

        private void txtCheck2_TextChanged(object sender, EventArgs e)
        {

            ID2 = txtCheck2.Text.ToString(); 
        }

        private void cbCophep_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbCophep.Checked == true)
            //{
            //    txtLydo.Enabled = true;
            //    cbKhongphep.Enabled = false;
            //}
            //else  if(cbCophep.Checked == false)
            //{
            //    cbKhongphep.Enabled = true;
            //    txtLydo.Enabled = false;
            //}
        }

        private void cbKhongphep_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbKhongphep.Checked == true)
            //{
            //    txtLydo.Enabled = false;
            //}
            //else if (cbKhongphep.Checked == false)
            //{
            //    cbCophep.Enabled = true;
            //}
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            flagLuu = 0;
            clearData();
            DisEnl(true);
        }

        private void lbLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.microsoft.com/cognitive-services/en-us/face-api");
        }



    }
}
