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
    public partial class getEmpReport : Form
    {
        public getEmpReport()
        {
            InitializeComponent();
            GetEmployeeName();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void GetEmployeeName()
        {
            //to fetch data
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from EmployeeTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpName", typeof(string));
            dt.Load(Rdr);
            NameCb.ValueMember = "EmpName";
            NameCb.DataSource = dt;
            Con.Close();
        }

        private void getEmployeeDetails()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            string Query = "select * from EmployeeTbl where EmpName='" + NameCb.Text + "' ";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    name.Text = dr["EmpName"].ToString();
                    gen.Text = dr["EmpGen"].ToString();
                    dob.Text = dr["EmpDOB"].ToString();
                    ph.Text = dr["EmpPhone"].ToString();
                    add.Text = dr["EmpAdd"].ToString();
                    pos.Text = dr["EmpPos"].ToString();
                    jd.Text = dr["JoinDate"].ToString();
                    qua.Text = dr["EmpQual"].ToString();
                    EmpBasSalary.Text = dr["EmpBasSal"].ToString();
                }
            }
            Con.Close();
        }
        private void CountPresent()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(DayPres) from AttendanceTbl where EmpName ='" + NameCb.Text + "' ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            pres.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void CountAbs()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(DayAbs) from AttendanceTbl where EmpName ='" + NameCb.Text + "' ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            abs.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void SumBonus()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(EmpBonus) from SalaryTbl where EmpName ='" + NameCb.Text + "' ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bonus.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void SumSalary()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(EmpBalance) from SalaryTbl where EmpName ='" + NameCb.Text + "' ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sal.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void homic_Click(object sender, EventArgs e)
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

        private void Empic_Click(object sender, EventArgs e)
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

        private void Bonic_Click(object sender, EventArgs e)
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

        private void Attic_Click(object sender, EventArgs e)
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

        private void Salic_Click(object sender, EventArgs e)
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

        private void logic_Click(object sender, EventArgs e)
        {
            Report Obj = new Report();
            Obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void NameCb_SelectedValueChanged_1(object sender, EventArgs e)
        {
            getEmployeeDetails();
            CountPresent();
            CountAbs();
            SumBonus();
            SumSalary();
        }

        private void label21_Click(object sender, EventArgs e)
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
