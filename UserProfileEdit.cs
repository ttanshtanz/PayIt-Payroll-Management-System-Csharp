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
    public partial class UserProfileEdit : Form
    {
        public UserProfileEdit()
        {
            InitializeComponent();
            UserNamee.Text = Login.Users;
            getEmployee();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void getEmployee()
        {
            //to auto-fill
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            string Query = "select * from EmployeeTbl where EmpName='" + UserNamee.Text + "' ";
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
                    qual.Text = dr["EmpQual"].ToString();
                }
            }
            Con.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update EmployeeTbl set EmpName=@EN,EmpGen=@EG,EmpDOB=@ED,EmpPhone=@EP,EmpAdd=@EA,EmpQual=@EQ where EmpName='" + UserNamee.Text + "' ", Con);
                cmd.Parameters.AddWithValue("@EN", name.Text);
                cmd.Parameters.AddWithValue("@EG", gen.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@ED", dob.Value.Date);
                cmd.Parameters.AddWithValue("@EP", ph.Text);
                cmd.Parameters.AddWithValue("@EA", add.Text);
                cmd.Parameters.AddWithValue("@EQ", qual.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Profile Updated!!");
                Con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void view_Click(object sender, EventArgs e)
        {
            UserProfile Obj = new UserProfile();
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

        private void Salic_Click(object sender, EventArgs e)
        {
            UserSal Obj = new UserSal();
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            UserFeedback Obj = new UserFeedback();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            UserFeedback Obj = new UserFeedback();
            Obj.Show();
            this.Hide();
        }
    }
}
