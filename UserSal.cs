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
    public partial class UserSal : Form
    {
        public UserSal()
        {
            InitializeComponent();
            UserNamee.Text = Login.Users;

            ShowYearly();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Login Objl = new Login();
            Objl.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UserSal Obj = new UserSal();
            Obj.Show();
            this.Hide();
        }

        private void ShowYearly()
        {
            Con.Open();
            string Query = "select SalPeriod,EmpBonus,HR,DA,TA,EPres,EAbs,EExcused,EAttSal,EmpTax,EmpDeduction,EmpBalance from SalaryTbl where EmpName='" + UserNamee.Text + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            YearlyDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {

            Con.Open();
            string Periodd = SalDate.Value.Month + "-" + SalDate.Value.Year;
            SqlDataAdapter sda = new SqlDataAdapter("select SalPeriod,EmpBonus,HR,DA,TA,EPres,EAbs,EExcused,EAttSal,EmpTax,EmpDeduction,EmpBalance from SalaryTbl where SalPeriod ='" + Periodd + "' and  EmpName='" + UserNamee.Text + "' ", Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            YearlyDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Sal_Click(object sender, EventArgs e)
        {
            UserSal Obj = new UserSal();
            Obj.Show();
            this.Hide();
        }

        private void HomeLbl_Click(object sender, EventArgs e)
        {
            UserHome Obj = new UserHome();
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
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
    }
}
