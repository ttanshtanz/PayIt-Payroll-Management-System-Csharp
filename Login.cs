using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace PayrollSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");
        public static string Users;
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            /*if (User.Text == "" || Pass.Text == "")
                MessageBox.Show("Missing Information!!");
            else if (User.Text == "Admin" || Pass.Text == "123")
            {
                Home Obj = new Home();
                Obj.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Wrong UserName or Password!");*/

        }

        private void gunaLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://localhost:54435/home.aspx");
        }

       private void LoginBtnn_Click(object sender, EventArgs e)
        {
            if (User.Text == "" || Pass.Text == "")
                MessageBox.Show("Missing Information!!");

            else if (User.Text == "Admin" && Pass.Text == "123")
            {
                Users = User.Text;
                Home Obj = new Home();
                Obj.Show();
                this.Hide();
            }

            else
            {
                Con.Open();
                string Query = "select count(*) from EmployeeTbl where EmpName='" + User.Text+ "' and EmpPass='" + Pass.Text + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    Users = User.Text;
                    UserHome Obj = new UserHome();
                    Obj.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Wrong UserName or Password!");
                Con.Close();
            }
               
        }

        private void User_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Pass_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
