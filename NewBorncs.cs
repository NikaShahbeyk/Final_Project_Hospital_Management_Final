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
    public partial class NewBorncs : Form
    {
        public NewBorncs()
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
            string query = "select * from baby";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);

            var ds = new DataSet();

            da.Fill(ds);

            DoctorGV.DataSource = ds.Tables[0];

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

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";

        }

        private void NewBorncs_Load(object sender, EventArgs e)
        {
            populatecombox();
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = textBox2.Text;
            string c = textBox3.Text;
            string d = textBox4.Text;
            string f = textBox5.Text;
            string g = comboBox1.Text;
            string h = comboBox2.Text;



            int a1 = int.Parse(a);
            int h1 = int.Parse(h);

            con.Open();
            string query = "insert into baby(BABYID, name, lastname, birthdate,father,gender, motherID)" +
                "values('" + a1 + "' , '" + b+ "', '" + c + "', '" + d + "', '" + f + "', '" + g + "', '" + h1 + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("baby added!");
            con.Close();
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete from baby where BABYID = " + textBox1.Text + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("baby deleted successfully!");
            con.Close();
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update baby set BABYID = '" + textBox1.Text + "', name = '" + textBox2.Text + "', lastname = '" + textBox3.Text + "', birthdate = '" + textBox4.Text + "', father = '" + textBox5.Text + "', gender = '" + comboBox1.Text + "', motherID = '" + comboBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated successfully!");
            con.Close();
            populate();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
