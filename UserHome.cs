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
    public partial class UserHome : Form
    {
        public UserHome()
        {
            InitializeComponent();
            UserNamee.Text = Login.Users;
            SumSalary();
            SumBonus();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SumSalary()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(EmpBalance) from SalaryTbl where EmpName='"+ UserNamee.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SalNum.Text = "Rs " + dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void SumBonus()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(EmpBonus) from SalaryTbl where EmpName='" + UserNamee.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BonNum.Text = "Rs " + dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Login Objl = new Login();
            Objl.Show();
            this.Hide();
        }

        private void Salic_Click(object sender, EventArgs e)
        {
            UserSal Objl = new UserSal();
            Objl.Show();
            this.Hide();
        }

        private void Sal_Click(object sender, EventArgs e)
        {
            UserSal Obj = new UserSal();
            Obj.Show();
            this.Hide();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            UserProfile Obj = new UserProfile();
            Obj.Show();
            this.Hide();
        }

        private void repic_Click(object sender, EventArgs e)
        {
            UserProfile Obj = new UserProfile();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            UserFeedback Obj = new UserFeedback();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            UserFeedback Obj = new UserFeedback();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
