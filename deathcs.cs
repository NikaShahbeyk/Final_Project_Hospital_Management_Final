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
    public partial class deathcs : Form
    {
        public deathcs()
        {
            InitializeComponent();
        }
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
                comboBox2.ValueMember = "PatientID";
                comboBox2.DataSource = dt;
                con.Close();
            }
            catch
            {
                MessageBox.Show("error!");
            }
        }

        void populate()
        {
            con.Open();
            string query = "select * from death";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);

            var ds = new DataSet();

            da.Fill(ds);

            DoctorGV.DataSource = ds.Tables[0];

            con.Close();
        }

        private void deathcs_Load(object sender, EventArgs e)
        {
            populatecombox();
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update death set ID = '" + comboBox2.Text + "', date = '" + textBox4.Text + "', cause = '" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated successfully!");
            con.Close();
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = comboBox2.Text;
            string b = textBox4.Text;
            string h = comboBox1.Text;



            int a1 = int.Parse(a);

            con.Open();
            string query = "insert into death(ID, date, cause)" +
                "values('" + a1 + "' , '" + b + "', '" + h + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("death added!");
            con.Close();
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete from death where ID = " + comboBox2.Text + " ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted successfully!");
            con.Close();
            populate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox4.Text = "";
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
