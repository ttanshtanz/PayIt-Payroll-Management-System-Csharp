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
    public partial class UserChngePass : Form
    {
        public UserChngePass()
        {
            InitializeComponent();
            UserNamee.Text = Login.Users;
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void Clear()
        {
            newpass.Text = "";
            confirmpass.Text = "";
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(newpass.Text=="")
                MessageBox.Show("Password cannot be Empty!!");

            else if (newpass.Text == confirmpass.Text)
            {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update EmployeeTbl set EmpPass=@EN where EmpName='" + UserNamee.Text + "' ", Con);
                    cmd.Parameters.AddWithValue("@EN", newpass.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Password Updated!!");
                    Con.Close();
                    Clear();
            }
            else
            {
                MessageBox.Show("Password not Matching!!");
            }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Profile_Click(object sender, EventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UserHome Obj = new UserHome();
            Obj.Show();
            this.Hide();
        }

        private void Salic_Click(object sender, EventArgs e)
        {
            UserSal Obj = new UserSal();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            UserFeedback Obj = new UserFeedback();
            Obj.Show();
            this.Hide();
        }

        private void repic_Click(object sender, EventArgs e)
        {
            UserProfile Obj = new UserProfile();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
