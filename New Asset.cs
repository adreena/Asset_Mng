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
    public partial class New_Asset : Form
    {
        public New_Asset()
        {
            InitializeComponent();
        }

        private void New_Asset_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'asset_MngDataSet.Type' table. You can move, or remove it, as needed.
          
            //this.typeTableAdapter.Fill(this.asset_MngDataSet.type);
            // TODO: This line of code loads data into the 'asset_MngDataSet.فروشنده' table. You can move, or remove it, as needed.
            this.فروشندهTableAdapter.Fill(this.asset_MngDataSet.فروشنده);
            

        }

        private void Type__SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection connection = Main.connection;
            connection.Open();
            string com = "SELECT نام FROM زیر_Type WHERE Type='" + Type_.Text + "';";
            sub_type.Items.Clear();
            SqlCommand subtypes = new SqlCommand(com, connection);
            SqlDataReader reader = subtypes.ExecuteReader();
            while (reader.Read())
            {
                sub_type.Items.Add(reader["نام"].ToString());
                
            }
            connection.Close();
        }

        private void Company_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection connection = Main.connection;
            connection.Open();
            string com = "SELECT * FROM [فروشنده] WHERE [نام_شرکت]='" + Company.Text + "';";
            SqlCommand command = new SqlCommand(com, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               //reader["شناسه"].ToString();
                reader["نام_شرکت"].ToString();
                contact.Text = reader["رابط"].ToString();

                Vtel.Text = reader["تلفن"].ToString();
                //Vemail.Text = reader["ایمیل"].ToString();
                Vweb.Text = reader["وب_سایت"].ToString();
                Vadd.Text = reader["آدرس"].ToString();
               
            }
            connection.Close();
        }
        public static string check;
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = Main.connection;
            con.Open();
            string find = "SELECT شناسه from کالا where شناسه='" + Asset_ID.Text + "'";
            SqlCommand command = new SqlCommand(find, con);
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                MessageBox.Show("این شناسه قبلاً در سیستم وارد شده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                check = "no";
            }
            else
            {
                MessageBox.Show("شناسه مورد قبول است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                check = "ok";
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
            if (check == "ok")
            {
                SqlConnection con = Main.connection;
                string ins = "INSERT INTO کالا ([شناسه],[تاریخ_خرید],[اتمام_گارانتی],[مدل],[زیرType],[فروشنده],[وضعیت] ) VALUES(@id,@pdate,@gdate,@model,@subtype,@vendor,@status);";
                con.Open();
                SqlCommand command = new SqlCommand(ins, con);
                DateTime pdate = DateTime.Today;
                monthCalendar1.MaxSelectionCount = 1;
                monthCalendar2.MaxSelectionCount = 1;
              

                //      MessageBox.Show(pdate.Month.ToString()+pdate.Day.ToString());

                //guaranty.Text = "0";
                command.Parameters.Add("@id", Asset_ID.Text);
                command.Parameters.Add("@pdate", monthCalendar1.SelectionRange.Start.Date);
                command.Parameters.Add("@gdate", monthCalendar2.SelectionRange.Start.Date);
                command.Parameters.Add("@model", model.Text);
                command.Parameters.Add("@subtype",sub_type.Text);
                command.Parameters.Add("@vendor", Company.Text);
                command.Parameters.Add("@status", status.Text);
               
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("با موفقیت ثبت شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void New_Asset_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            Application.DoEvents();
        }
    }
}