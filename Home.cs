using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

            Home h = new Home();

            h.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoctorForm doc = new DoctorForm();
            doc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatientFormcs pa = new PatientFormcs();
            pa.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DiagnosisForm diagnosis = new DiagnosisForm();
            diagnosis.Show();
            this.Hide();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Surgery doc = new Surgery();
            doc.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Radiology rd = new Radiology();
            rd.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Builder b = new Builder();
            b.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Pharmacy p = new Pharmacy();
            p.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bedcs b = new Bedcs();
            b.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Nurse n = new Nurse();
            n.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            NewBorncs n = new NewBorncs();
            n.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            deathcs d = new deathcs();
            d.Show();
            this.Hide();
        }
    }
}
