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
    public partial class UserFeedback : Form
    {
        public UserFeedback()
        {
            InitializeComponent();
            UserNamee.Text = Login.Users;
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void Clear()
        {
            FeedbkTb.Text = "";
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (FeedbkTb.Text == "")
            {
                MessageBox.Show("Feedback cannot be Empty!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into FeedbackTbl(EmpName,Message,Period) values(@EN,@M,@P)", Con);
                    cmd.Parameters.AddWithValue("@EN", UserNamee.Text);
                    cmd.Parameters.AddWithValue("@M", FeedbkTb.Text);
                    cmd.Parameters.AddWithValue("@P", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Feedback has been Submitted!!");
                    Con.Close();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void pictureBox3_Click(object sender, EventArgs e)
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

        private void HomeLbl_Click(object sender, EventArgs e)
        {
            UserHome Obj = new UserHome();
            Obj.Show();
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
    }
}
