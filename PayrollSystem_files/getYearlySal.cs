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
    public partial class getYearlySal : Form
    {
        public getYearlySal()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void SumSalary()
        {
            Con.Open();
            string Periodd = YearCb.Value.Month + "-" + YearCb.Value.Year;
            //SqlDataAdapter sda = new SqlDataAdapter("select count(EmpID) from EmployeeTbl where (SELECT YEAR(JoinDate) AS year) ='" + YearCb.Value.Year + "' ", Con);
            //SqlDataAdapter sda = new SqlDataAdapter("select sum(EmpBalance) from SalaryTbl where (SELECT YEAR(SalPeriod) AS year) ='" + YearCb.Value.Year + "' ", Con);
            SqlDataAdapter sda = new SqlDataAdapter("select sum(EmpBalance) from SalaryTbl where SalPeriod ='" + Periodd + "' ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sal.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void SumBonus()
        {
            Con.Open();
            string Periodd = YearCb.Value.Month + "-" + YearCb.Value.Year;
            SqlDataAdapter sda = new SqlDataAdapter("select sum(EmpBonus) from SalaryTbl where SalPeriod ='" + Periodd + "' ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bonus.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            SumSalary();
            SumBonus();
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

        private void label25_Click(object sender, EventArgs e)
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
