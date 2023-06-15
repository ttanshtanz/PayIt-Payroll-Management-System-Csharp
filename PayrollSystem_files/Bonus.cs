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
    public partial class Bonus : Form
    {
        public Bonus()
        {
            InitializeComponent();
            showBonus();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void Clear()
        {
            BNameTb.Text = "";
            BAmtTb.Text = "";
            Key = 0;
        }
        private void showBonus()
        {
            Con.Open();
            string Query = "select * from BonusTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BonusDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (BNameTb.Text == "" || BAmtTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into BonusTbl(BName,BAmt) values(@BN,@BA)", Con);
                    cmd.Parameters.AddWithValue("@BN", BNameTb.Text);
                    cmd.Parameters.AddWithValue("@BA", BAmtTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bonus Saved!!");
                    Con.Close();
                    showBonus();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key;
         private void EditBtn_Click(object sender, EventArgs e)
        {
            if (BNameTb.Text == "" || BAmtTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update BonusTbl set BName=@BN, BAmt=@BA where BId=@BKey", Con);
                    cmd.Parameters.AddWithValue("@BN", BNameTb.Text);
                    cmd.Parameters.AddWithValue("@BA", BAmtTb.Text);
                    cmd.Parameters.AddWithValue("@BKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bonus Updated!!");
                    Con.Close();
                    showBonus();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select the Bonus to be deleted!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from BonusTbl where BId=@BKey", Con);
                    cmd.Parameters.AddWithValue("@BKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bonus Deleted!!");
                    Con.Close();
                    showBonus();
                   }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void BonusDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            BNameTb.Text = BonusDGV.SelectedRows[0].Cells[1].Value.ToString();
            BAmtTb.Text = BonusDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (BNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(BonusDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

       private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void Home_Click(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {

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

        private void label4_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Feedback Obj = new Feedback();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Feedback Obj = new Feedback();
            Obj.Show();
            this.Hide();
        }
    }
}
