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
    public partial class Pharmacy : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Nika\Desktop\Final_OS_HOSPITAL_MANAGEMENT\Hospital Management\Hospital Management\Database1.mdf; Integrated Security = True");
        public Pharmacy()
        {
            InitializeComponent();
        }

        void populatecombox()
        {
            string query = "select * from Final_Patient";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd;

            DataTable dt = new DataTable();
            dt.Columns.Add("PatientID", typeof(int));
            rd = cmd.ExecuteReader();
            dt.Load(rd);
            comboBox1.ValueMember = "PatientID";
            comboBox1.DataSource = dt;
            con.Close();

        }

        void populate()
        {
            con.Open();
            string query = "select * from pharmacy";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);

            var ds = new DataSet();
            da.Fill(ds);

            DiagnosisGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string pid = comboBox1.Text;
            string drug = comboBox2.Text;
            string cost = textBox5.Text;

            int pid1 = int.Parse(pid);
            string query = "insert into pharmacy(PatientID, Drug, Cost)" + 
                "values('"+pid1+"','"+drug+"','" + cost + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("added successfully!");

            con.Close();
            populate();
        }

        private void Pharmacy_Load(object sender, EventArgs e)
        {
            populatecombox();
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete from pharmacy where PatientID = " + comboBox1.Text + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted Successfully!");
            con.Close();
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update pharmacy set PatientID = '" + comboBox1.Text + "', Drug = '" + comboBox2.Text + "', Cost = '" + textBox5.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated successfully!");
            con.Close();
            populate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox5.Text = "";
        }
    }
}
