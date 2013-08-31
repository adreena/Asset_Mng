using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Asset_Mng
{
    public partial class compare : Form
    {
        public compare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = Main.connection;
            string check = "Select [‘‰«”Â] from [ò«·«] where not exists (select [AssetNo] from DCT_Asset where DCT_Asset.[AssetNo]=ò«·«.‘‰«”Â)";
            connection.Open();
            SqlCommand com = new SqlCommand(check, connection);
            SqlDataAdapter da = new SqlDataAdapter(com.CommandText.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            BindingSource bs = new BindingSource(dt, null);
            dataGridView1.DataSource = bs;
            bindingNavigator1.BindingSource = bs;
            connection.Close();
        }
    }
}