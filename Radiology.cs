using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management
{
    public partial class Radiology : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Nika\Desktop\Final_OS_HOSPITAL_MANAGEMENT\Hospital Management\Hospital Management\Database1.mdf; Integrated Security = True");
        void populatecombox()
        {
            string sql = "select * from Final_Patient";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd;
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("PatientID", typeof(int));
                rd = cmd.ExecuteReader();
                dt.Load(rd);
                comboBox1.ValueMember = "PatientID";
                comboBox1.DataSource = dt;
                con.Close();
            }
            catch
            {

            }
        }


        void populate()
        {
            con.Open();
            string query = "select * from radiology";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);

            var ds = new DataSet();

            da.Fill(ds);

            DiagnosisGV.DataSource = ds.Tables[0];

            con.Close();
        }

        public Radiology()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Radiology_Load(object sender, EventArgs e)
        {
            populatecombox();
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pid = comboBox1.Text;
            string type = comboBox2.Text;
            string Date = textBox1.Text;
            string cost = textBox2.Text;


            int pid1 = int.Parse(pid);
            con.Open();
            string query = "insert into radiology(PatientID, Type, Date, Cost)" +
                "values('" + pid1 + "' , '" + type + "', '" + Date + "', '" + cost + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("radiology added!");
            con.Close();
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete from radiology where PatientID = " + comboBox1.Text + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("radiology deleted successfully!");
            con.Close();
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update radiology set PatientID = '"+comboBox1.Text+"', Type = '"+comboBox2.Text+"', Date = '"+textBox1.Text+"', Cost = '"+textBox2.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated successfully!");
            con.Close();
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void DiagnosisGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
