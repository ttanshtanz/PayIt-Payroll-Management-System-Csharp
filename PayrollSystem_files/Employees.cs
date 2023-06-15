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
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            showEmployee();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void Clear()
        {
            EmpNameTb.Text = "";
            EmpPhoneTb.Text = "";
            EmpGenCb.SelectedIndex = -1;
            EmpAddTb.Text = "";
            EmpSalTb.Text = "";
            EmpQualCb.SelectedIndex = -1;
            EmpPosCb.SelectedIndex = -1;
            Key = 0;
        }
        private void showEmployee()
        {
            Con.Open();
            string Query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpPhoneTb.Text == "" ||EmpGenCb.SelectedIndex == -1 || EmpAddTb.Text == "" || EmpSalTb.Text == "" || EmpQualCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(EmpNameTb.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters!");
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(EmpPhoneTb.Text, "^[0-9]{10}"))
            {
                MessageBox.Show("Please enter 10 digits!");
            }

            else
            {
                try
                {
                    //string Period = JDate.Value.Day + "-" + JDate.Value.Month + "-" + JDate.Value.Year;
                    Con.Open();

                    //check if empname already exists
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM EmployeeTbl WHERE EmpName = @EN", Con);
                    checkCmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    int nameCount = (int)checkCmd.ExecuteScalar();

                    if (nameCount > 0)
                    {
                        MessageBox.Show("Employee name already exists!");
                        Con.Close();
                        return; // Exit the method without saving
                    }

                    SqlCommand cmd = new SqlCommand("insert into EmployeeTbl(EmpName,EmpGen,EmpDOB,EmpPhone,EmpAdd,EmpPos,JoinDate,EmpQual,EmpBasSal,EmpPass) values(@EN,@EG,@ED,@EP,@EA,@EPOS,@JD,@EQ,@EBS,@EPa)", Con);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EG", EmpGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ED", EmpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddTb.Text);
                    cmd.Parameters.AddWithValue("@EPOS", EmpPosCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@JD", JDate.Value.Date);
                    cmd.Parameters.AddWithValue("@EQ", EmpQualCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@EBS", EmpSalTb.Text);
                    cmd.Parameters.AddWithValue("@EPa", EmpNameTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Saved!!");
                    Con.Close();
                    showEmployee();
                    Clear();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key;

        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            EmpNameTb.Text = EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpGenCb.SelectedItem = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmpDOB.Value = Convert.ToDateTime(EmployeeDGV.SelectedRows[0].Cells[3].Value);
            EmpPhoneTb.Text = EmployeeDGV.SelectedRows[0].Cells[4].Value.ToString();
            EmpAddTb.Text = EmployeeDGV.SelectedRows[0].Cells[5].Value.ToString();
            EmpPosCb.SelectedItem = EmployeeDGV.SelectedRows[0].Cells[6].Value.ToString();
            JDate.Value = Convert.ToDateTime(EmployeeDGV.SelectedRows[0].Cells[7].Value);
            EmpQualCb.SelectedItem = EmployeeDGV.SelectedRows[0].Cells[8].Value.ToString();
            EmpSalTb.Text = EmployeeDGV.SelectedRows[0].Cells[9].Value.ToString();
            if (EmpNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmployeeDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpGenCb.SelectedIndex == -1 || EmpAddTb.Text == "" || EmpSalTb.Text == "" || EmpQualCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(EmpNameTb.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters!");
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(EmpPhoneTb.Text, "^[0-9]{10}"))
            {
                MessageBox.Show("Please enter 10 digits!");
            }

            else
            {
                try
                {
                    //string Period = JDate.Value.Day + "-" + JDate.Value.Month + "-" + JDate.Value.Year;
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update EmployeeTbl set EmpName=@EN,EmpGen=@EG,EmpDOB=@ED,EmpPhone=@EP,EmpAdd=@EA,EmpPos=@EPOS,JoinDate=@JD,EmpQual=@EQ ,EmpBasSal=@EBS where EmpId=@EmpKey", Con);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EG", EmpGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ED", EmpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddTb.Text);
                    cmd.Parameters.AddWithValue("@EPOS", EmpPosCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@JD", JDate.Value.Date);
                    cmd.Parameters.AddWithValue("@EQ", EmpQualCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@EBS", EmpSalTb.Text);
                    //cmd.Parameters.AddWithValue("@EPa", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EmpKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated!!");
                    Con.Close();
                    showEmployee();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select the Employee to be deleted!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from EmployeeTbl where EmpId=@EmpKey", Con);
                    cmd.Parameters.AddWithValue("@EmpKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted!!");
                    Con.Close();
                    showEmployee();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home Objh = new Home();
            Objh.Show();
            this.Hide();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Login Objl = new Login();
            Objl.Show();
            this.Hide();
        }

        private void EmpPhoneTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Error,Cannot Contain Letters ");
            }
        }

        private void EmpPhoneTb_TextChanged(object sender, EventArgs e)
        {
            if (EmpPhoneTb.TextLength == 10)
                EmpPhoneTb.ForeColor = Color.Green;   

            else
                EmpPhoneTb.ForeColor = Color.Red;
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Bonus Obj = new Bonus();
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

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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

        private void EmpSalTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Error,Cannot Contain Letters ");
            }
        }
    }
}
