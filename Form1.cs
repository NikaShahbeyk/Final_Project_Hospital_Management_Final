using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Please enter username and password!");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Nika\Desktop\Final_OS_HOSPITAL_MANAGEMENT\Hospital Management\Hospital Management\Database1.mdf; Integrated Security = True");
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from Login_Details where username = '"+username.Text+"' and passwrd = '"+password.Text+"' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString()=="1")
                {
                    Home H = new Home();
                    MessageBox.Show("Welcome to Nika Hospital!");
                    H.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong username or password!!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            username.Text = "";
            password.Text = "";
        }
    }
}
