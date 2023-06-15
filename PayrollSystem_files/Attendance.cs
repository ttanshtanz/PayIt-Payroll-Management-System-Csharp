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
    public partial class Attendance : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");
        public Attendance()
        {
            InitializeComponent();
            ShowAttendance();
            GetEmployees();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void Clear()
        {
            
            EmpIdCb.SelectedIndex = -1;
            EmpNameTb.Text = "";
            PresentTb.Text = "";
            AbsTb.Text = "";
            ExcusedTb.Text = "";
            //Key = 0;
        }

        private void ShowAttendance()
        {
            Con.Open();
            string Query = "select * from AttendanceTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AttDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void GetEmployees()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from EmployeeTbl",Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId",typeof(int));
            dt.Load(Rdr);
            EmpIdCb.ValueMember = "EmpId";
            EmpIdCb.DataSource = dt;
            Con.Close();
        }
        private void getEmployeeNamee()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            string Query = "select EmpName from EmployeeTbl where EmpId= " + EmpIdCb.SelectedValue.ToString() +" ";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EmpNameTb.Text = dr["EmpName"].ToString();
                }
            }
            Con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || PresentTb.Text == "" || AbsTb.Text == "" || ExcusedTb.Text == "" )
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {
                try
                {
                    string Periodd = AttDate.Value.Month + "-" + AttDate.Value.Year;
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into AttendanceTbl(EmpId,EmpName,DayPres,DayAbs,DayExcused,Period) values(@EI,@EN,@DP,@DA,@DE,@PD)", Con);
                    cmd.Parameters.AddWithValue("@EI", EmpIdCb.Text);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@DP", PresentTb.Text);
                    cmd.Parameters.AddWithValue("@DA", AbsTb.Text);
                    cmd.Parameters.AddWithValue("@DE", ExcusedTb.Text);
                    cmd.Parameters.AddWithValue("@PD", Periodd);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendance Saved!!");
                    Con.Close();
                    ShowAttendance();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key;
        private void AttDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpIdCb.Text = AttDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpNameTb.Text = AttDGV.SelectedRows[0].Cells[2].Value.ToString();
            PresentTb.Text = AttDGV.SelectedRows[0].Cells[3].Value.ToString();
            AbsTb.Text = AttDGV.SelectedRows[0].Cells[4].Value.ToString();
            ExcusedTb.Text = AttDGV.SelectedRows[0].Cells[5].Value.ToString();
            AttDate.Value = Convert.ToDateTime(AttDGV.SelectedRows[0].Cells[6].Value);


            if (EmpNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(AttDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EmpIdCb_SelectedValueChanged(object sender, EventArgs e)
        {
            if(EmpIdCb.SelectedValue != null)
            getEmployeeNamee();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || PresentTb.Text == "" || AbsTb.Text == "" || ExcusedTb.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {
                try
                {
                    string Periodd = AttDate.Value.Month + "-" + AttDate.Value.Year;
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update AttendanceTbl set EmpId=@EI,EmpName=@EN,DayPres=@DP,DayAbs=@DA,DayExcused=@DE,Period=@PD where AttNum=@AKey", Con);
                    cmd.Parameters.AddWithValue("@EI", EmpIdCb.Text);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@DP", PresentTb.Text);
                    cmd.Parameters.AddWithValue("@DA", AbsTb.Text);
                    cmd.Parameters.AddWithValue("@DE", ExcusedTb.Text);
                    cmd.Parameters.AddWithValue("@PD", Periodd);
                    cmd.Parameters.AddWithValue("@AKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendance Updated!!");
                    Con.Close();
                    ShowAttendance();
                    Clear();
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {
            Bonus Obj = new Bonus();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from AttendanceTbl where AttNum=@AKey", Con);
                    cmd.Parameters.AddWithValue("@AKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted!!");
                    Con.Close();
                    ShowAttendance();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Feedback Obj = new Feedback();
            Obj.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Feedback Obj = new Feedback();
            Obj.Show();
            this.Hide();
        }
    }
}
