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
    public partial class UserProfile : Form
    {
        public UserProfile()
        {
            InitializeComponent();
            UserNamee.Text = Login.Users;
            getEmployee();

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");

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

        private void Sal_Click(object sender, EventArgs e)
        {
            UserSal Obj = new UserSal();
            Obj.Show();
            this.Hide();
        }

        private void Salic_Click(object sender, EventArgs e)
        {
            UserSal Obj = new UserSal();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Login Objl = new Login();
            Objl.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                    pos.Text = dr["EmpPos"].ToString();

                    jd.Text = dr["JoinDate"].ToString();

                    qua.Text = dr["EmpQual"].ToString();
                    EmpBasSalary.Text = dr["EmpBasSal"].ToString();
                }
            }
            Con.Close();
        }

        private void EmpBasSalary_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            UserProfileEdit Obj = new UserProfileEdit();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            UserChngePass Obj = new UserChngePass();
            Obj.Show();
            this.Hide();
        }

        private void repic_Click(object sender, EventArgs e)
        {

        }
    }
}
