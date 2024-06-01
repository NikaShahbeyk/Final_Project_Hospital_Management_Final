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

    public partial class Bedcs : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Nika\Desktop\Final_OS_HOSPITAL_MANAGEMENT\Hospital Management\Hospital Management\Database1.mdf; Integrated Security = True");
        public Bedcs()
        {
            InitializeComponent();
        }

        void populate()
        {
            con.Open();

            string query = "select * from bed";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);

            var ds = new DataSet();
            da.Fill(ds);
            DoctorGV.DataSource = ds.Tables[0];
            con.Close();
        }
        void populatecombox1()
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
                comboBox3.ValueMember = "PatientID";
                comboBox3.DataSource = dt;
                con.Close();
            }
            catch
            {
                MessageBox.Show("error!");
            }
        }

        void populatecombox2()
        {
            string sql = "select * from Final_Doctor";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdd;
            try
            {
                con.Open();
                DataTable dtt = new DataTable();
                dtt.Columns.Add("DoctorID", typeof(int));
                rdd = cmd.ExecuteReader();
                dtt.Load(rdd);
                comboBox2.ValueMember = "DoctorID";
                comboBox2.DataSource = dtt;
                con.Close();
            }
            catch
            {
                MessageBox.Show("error!");
            }
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

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void Bedcs_Load(object sender, EventArgs e)
        {
            populatecombox1();
            populatecombox2();
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string pid = comboBox3.Text;
            string did = comboBox2.Text;
            string part = comboBox1.Text;

            string sql = "insert into bed(PatientID, DoctorID, Part)" +
                "values('" + pid + "', '" + did + "', '" + part + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("added Successfully!");
            con.Close();
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "delete from bed where PatientID = " + comboBox3.Text + " ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted!");
            con.Close();
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "update bed set PatientID = '" + comboBox3.Text + "', DoctorID = '" + comboBox2.Text + "', Part = '" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("successfully updated!");
            con.Close();
            populate();
        }
    }
}
