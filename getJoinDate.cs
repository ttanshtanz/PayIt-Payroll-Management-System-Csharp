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

namespace PayrollSystem
{
    public partial class getJoinDate : Form
    {
        public getJoinDate()
        {
            InitializeComponent();
            ShowEmployee();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void ShowEmployee()
        {
            Con.Open();
            string Query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            JDDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void homic_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }
        private void Empic_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void Bonic_Click(object sender, EventArgs e)
        {
            Bonus Obj = new Bonus();
            Obj.Show();
            this.Hide();
        }

        private void Attic_Click(object sender, EventArgs e)
        {
            Attendance Obj = new Attendance();
            Obj.Show();
            this.Hide();
        }

        private void Salic_Click(object sender, EventArgs e)
        {
            Salary Obj = new Salary();
            Obj.Show();
            this.Hide();
        }

        private void repic_Click(object sender, EventArgs e)
        {
            Report Obj = new Report();
            Obj.Show();
            this.Hide();
        }

        private void logic_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Bonus Obj = new Bonus();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Attendance Obj = new Attendance();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Salary Obj = new Salary();
            Obj.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Report Obj = new Report();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*private void getDetails()
        {
            FromLbl.Text = DateFrom.Value.Date.ToString();
            ToLbl.Text = DateTo.Value.Date.ToString();
        }*/

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            /*getDetails();
             Con.Open();
             //string PeriodFrom = DateTo.Value.Month + "-" + DateTo.Value.Day + "-" + DateTo.Value.Year;
             //string PeriodTo = DateFrom.Value.Month + "-" + DateFrom.Value.Day + "-" + DateFrom.Value.Year;
             //SqlDataAdapter sda = new SqlDataAdapter("Select * from EmployeeTbl where JoinDate between '" + DateFrom.Value.Date + "' and '" + DateTo.Value.Date + "' ", Con);
             SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
             var ds = new DataSet();
             sda.Fill(ds);
             JDDGV.DataSource = ds.Tables[0];
             Con.Close();*/
            Con.Open();
            //string Query = "select * from EmployeeTbl where ((SELECT MONTH(JoinDate) AS month) >= '" + DateFrom.Value.Month + "' and (SELECT MONTH(JoinDate) AS month) <= '" + DateTo.Value.Month + "') and ((SELECT YEAR(JoinDate) AS year) >= '" + DateFrom.Value.Year + "' and (SELECT YEAR(JoinDate) AS year) <= '" + DateTo.Value.Year + "')";
            string Query = "select * from EmployeeTbl where ((SELECT YEAR(JoinDate) AS year) >= '" + DateFrom.Value.Year + "' and (SELECT YEAR(JoinDate) AS year) <= '" + DateTo.Value.Year + "')";
            //string Query = "select * from EmployeeTbl where NOT((SELECT JoinDate AS date) >= '" + DateFrom.Value.Date + "' AND (SELECT JoinDate AS date) <= '" + DateTo.Value.Date + "') ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            JDDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void JFDate_onValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void JTDate_onValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void JDDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Feedback Obj = new Feedback();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Feedback Obj = new Feedback();
            Obj.Show();
            this.Hide();
        }
    }
}
