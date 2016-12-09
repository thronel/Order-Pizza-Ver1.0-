using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ConnectToSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String StrCon = @"Data Source=VU;Initial Catalog=QLBH;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(StrCon);
            try
            {
                Conn.Open();
                MessageBox.Show("Success!", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Failure!", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
