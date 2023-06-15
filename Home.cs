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

namespace PayrollSystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            CountEmployees();
            CountManagers();
            CountSeniors();
            CountJunior();
            SumSalary();
            SumBonus();
            UserNamee.Text = Login.Users;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Bonus Obj = new Bonus();
            Obj.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void CountEmployees()
        {
            Con.Open(); 
            SqlDataAdapter sda=new SqlDataAdapter("select Count(*) from EmployeeTbl",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            EmpLabel.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void CountJunior()
        {

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from EmployeeTbl where EmpPos='Junior'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            JuniorLabel.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void CountSeniors()
        {

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from EmployeeTbl where EmpPos='Senior'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SeniorLabel.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void CountManagers()
        {

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from EmployeeTbl where EmpPos='Manager'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ManagerLabel.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void SumSalary()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(EmpBalance) from SalaryTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SalNum.Text = "Rs "+ dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void SumBonus()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(EmpBonus) from SalaryTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BonNum.Text = "Rs " + dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home Objh = new Home();
            Objh.Show();
            this.Hide();
        }

        
        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void BonNum_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void SalNum_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ManagerLabel_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void EmpLabel_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Login Objl = new Login();
            Objl.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Report Obj = new Report();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Salary Obj = new Salary();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Bonus Obj = new Bonus();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Attendance Obj = new Attendance();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();

        }

        private void Emp_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void Bonus_Click(object sender, EventArgs e)
        {
            Bonus Obj = new Bonus();
            Obj.Show();
            this.Hide();
        }

        private void Attendance_Click(object sender, EventArgs e)
        {
            Attendance Obj = new Attendance();
            Obj.Show();
            this.Hide();
        }

        private void Sal_Click(object sender, EventArgs e)
        {
            Salary Obj = new Salary();
            Obj.Show();
            this.Hide();
        }

        private void Rep_Click(object sender, EventArgs e)
        {
            Report Obj = new Report();
            Obj.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Feedback Obj = new Feedback();
            Obj.Show();
            this.Hide();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            Feedback Obj = new Feedback();
            Obj.Show();
            this.Hide();
        }
    }
}
