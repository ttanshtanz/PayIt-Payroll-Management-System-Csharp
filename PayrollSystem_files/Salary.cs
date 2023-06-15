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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
            GetEmployees();
            GetAttendance();
            GetBonus();
            ShowSalary();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Clear()
        {

            EmpIdCb.SelectedIndex = -1;
            EmpNameTb.Text = "";
            PresTb.Text = "";
            AbsTb.Text = "";
            ExcTb.Text = "";
            BaseSalTb.Text = "";
            AttNumCb.Text = "";
            //Key = 0;
        }

        private void ShowSalary()
        {
            Con.Open();
            string Query = "select EmpId,EmpName,EmpBasSal,EmpBonus,HR,DA,TA,EPres,EAbs,EExcused,EAttSal,EmpTax,EmpDeduction,EmpBalance,SalPeriod from SalaryTbl ORDER BY CONVERT(DATE, '01-' + SalPeriod, 103) DESC";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SalDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void GetEmployees()
        {
            //to fetch data
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from EmployeeTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId", typeof(int));
            dt.Load(Rdr);
            EmpIdCb.ValueMember = "EmpId";
            EmpIdCb.DataSource = dt;
            Con.Close();
        }
        private void GetBonus()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from BonusTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("BName", typeof(string));
            dt.Load(Rdr);
            BonusIdCb.ValueMember = "BName";
            BonusIdCb.DataSource = dt;
            Con.Close();
        }
        private void GetAttendance()
        {
            Con.Open();
            string Periodd = SalDate.Value.Month + "-" + SalDate.Value.Year;
            SqlCommand cmd = new SqlCommand("select * from AttendanceTbl where Period ='" + Periodd + "' and EmpId=" + EmpIdCb.SelectedValue.ToString()+ " ", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            if (Rdr != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("AttNum", typeof(int));
                dt.Load(Rdr);
                AttNumCb.ValueMember = "AttNum";
                AttNumCb.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No attendance recorded!");
            }
            Con.Close();
        }

        private void GetAttendanceData()
        {
            try
            {
                //to auto-fill
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                string Periodd = SalDate.Value.Month + "-" + SalDate.Value.Year;
                string Query = "select * from AttendanceTbl where Period ='" + Periodd + "' and AttNum= " + AttNumCb.SelectedValue.ToString() + " ";
                SqlCommand cmd = new SqlCommand(Query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        PresTb.Text = dr["DayPres"].ToString();
                        AbsTb.Text = dr["DayAbs"].ToString();
                        ExcTb.Text = dr["DayExcused"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No Attendance Recorded for the specified period!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                }
                Con.Close();
            }
            catch
            {
                MessageBox.Show("No Attendance Recorded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void getEmployeeNamee()
        {
            //to auto-fill
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            string Query = "select EmpName,EmpBasSal from EmployeeTbl where EmpId= " + EmpIdCb.SelectedValue.ToString() + " ";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EmpNameTb.Text = dr["EmpName"].ToString();
                    BaseSalTb.Text = dr["EmpBasSal"].ToString();
                }
            }
            Con.Close();
        }

        private void getBonusAmt()
        {
            Con.Open();
            string Query = "select * from BonusTbl where BName= '" + BonusIdCb.SelectedValue.ToString() + "' ";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BonusTb.Text = dr["BAmt"].ToString();
                }
            }
            Con.Close();
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void AttNumCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || PresTb.Text == "" || AbsTb.Text == "" || ExcTb.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {
                try
                {
                    string Period = SalDate.Value.Month + "-" + SalDate.Value.Year;

                    Con.Open();

                    // Check if salary already exists for the same EmpName
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM SalaryTbl WHERE EmpName = @EN AND SalPeriod = @SP", Con);
                    checkCmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    checkCmd.Parameters.AddWithValue("@SP", Period);
                    int existingSalaryCount = (int)checkCmd.ExecuteScalar();

                    if (existingSalaryCount > 0)
                    {
                        MessageBox.Show("Salary already saved for the same employee and period!");
                    }

                    else
                    {
                        SqlCommand cmd = new SqlCommand("insert into SalaryTbl(EmpId,EmpName,EmpBasSal,EmpBonus,EmpDeduction,EmpTax,EmpBalance,SalPeriod,HR,DA,TA,EPres,EAbs,EExcused,EAttSal) values(@EI,@EN,@EBS,@EBon,@EA,@ET,@EBal,@SP,@HR,@DA,@TA,@EP,@EAbs,@EEx,@EAttSal)", Con);
                        cmd.Parameters.AddWithValue("@EI", EmpIdCb.Text);
                        cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                        cmd.Parameters.AddWithValue("@EBS", BaseSalTb.Text);
                        cmd.Parameters.AddWithValue("@EBon", BonusTb.Text);
                        cmd.Parameters.AddWithValue("@EA", DedTb.Text);
                        cmd.Parameters.AddWithValue("@ET", TotTax);
                        cmd.Parameters.AddWithValue("@EBal", GrdTot);
                        cmd.Parameters.AddWithValue("@SP", Period);
                        cmd.Parameters.AddWithValue("@HR", hr);
                        cmd.Parameters.AddWithValue("@DA", da);
                        cmd.Parameters.AddWithValue("@TA", ta);
                        cmd.Parameters.AddWithValue("@EP", PresTb.Text);
                        cmd.Parameters.AddWithValue("@EAbs", AbsTb.Text);
                        cmd.Parameters.AddWithValue("@EEx", ExcTb.Text);
                        cmd.Parameters.AddWithValue("@EAttSal", AttSal);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Salary Saved!!");
                        Con.Close();
                        ShowSalary();
                        Clear();
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EmpIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        { //when option is chnged,fetch data
            getEmployeeNamee();
            GetAttendance();
            GetAttendanceData();
        }

        private void BonusIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getBonusAmt();
        }

        private void AttNumCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetAttendanceData();
        }

        int DailyBase = 0, Pres = 0, Abs = 0, Exc = 0;
        double hr = 0, ta = 0, da = 0,AttSal=0,Total=0,DGrdTot=0;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("PayIt Ltd", new Font("Arial", 12, FontStyle.Bold), Brushes.BlueViolet, new Point(200, 65));
            e.Graphics.DrawString("Employee PaySlip", new Font("Arial", 10, FontStyle.Bold), Brushes.Blue, new Point(180, 85));
            //string SNum = SalDGV.SelectedRows[0].Cells[0].Value.ToString();
            string EId = SalDGV.SelectedRows[0].Cells[0].Value.ToString();
            string Name = SalDGV.SelectedRows[0].Cells[1].Value.ToString();
            string BasSal = SalDGV.SelectedRows[0].Cells[2].Value.ToString();
            string Bonus = SalDGV.SelectedRows[0].Cells[3].Value.ToString();
            string Deduction = SalDGV.SelectedRows[0].Cells[12].Value.ToString();
            string Tax = SalDGV.SelectedRows[0].Cells[11].Value.ToString();
            string Balance = SalDGV.SelectedRows[0].Cells[13].Value.ToString();
            string Period = SalDGV.SelectedRows[0].Cells[14].Value.ToString();
            string hr = SalDGV.SelectedRows[0].Cells[4].Value.ToString();
            string da = SalDGV.SelectedRows[0].Cells[5].Value.ToString();
            string ta = SalDGV.SelectedRows[0].Cells[6].Value.ToString();
            string Pres = SalDGV.SelectedRows[0].Cells[7].Value.ToString();
            string Abs = SalDGV.SelectedRows[0].Cells[8].Value.ToString();
            string Exc = SalDGV.SelectedRows[0].Cells[9].Value.ToString();
            string AttSalary = SalDGV.SelectedRows[0].Cells[10].Value.ToString();
            e.Graphics.DrawString("Employee ID: " + EId, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(50, 150));
            e.Graphics.DrawString("Employee Name: " + Name, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(250, 150));
            e.Graphics.DrawString("____________________________________________", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(55, 170));
            e.Graphics.DrawString("No of days worked: " + Pres + "    No of applied leaves: " + Abs + "   No of Paid leaves: " + Exc, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(40, 205));
            e.Graphics.DrawString("____________________________________________", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(55, 220));
            e.Graphics.DrawString("Base Salary: Rs " + BasSal, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(50, 250));
            e.Graphics.DrawString("HR: Rs " + hr, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(50, 270));
            e.Graphics.DrawString("DA: Rs " + da, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(50, 290));
            e.Graphics.DrawString("TA: Rs " + ta, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(50, 310));
            e.Graphics.DrawString("Attendance Salary: Rs " + AttSalary, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(50, 330));
            e.Graphics.DrawString("Bonus: Rs " + Bonus, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(50, 350));
            e.Graphics.DrawString("____________________________________________", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(55, 370));

            e.Graphics.DrawString("Tax: Rs " + Tax, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(50, 390));
            e.Graphics.DrawString("Total Deduction: " + string.Format("{0:F3}", Deduction), new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Point(50, 410));

            e.Graphics.DrawString("____________________________________________", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(55, 430));
            e.Graphics.DrawString("Total: Rs " + Balance, new Font("Arial", 10, FontStyle.Bold), Brushes.Blue, new Point(50, 470));
            e.Graphics.DrawString("____________________________________________", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(55, 490));
            e.Graphics.DrawString("Date: " + Period, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(50, 520));

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home Objh = new Home();
            Objh.Show();
            this.Hide();
        }

        private void Emp_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void Bonus_Click(object sender, EventArgs e)
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

        private void Rep_Click(object sender, EventArgs e)
        {
            Report Obj = new Report();
            Obj.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
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

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            Login Objl = new Login();
            Objl.Show();
            this.Hide();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Login Objl = new Login();
            Objl.Show();
            this.Hide();
        }

        private void BalanceTb_TextChanged(object sender, EventArgs e)
        {

        }

        //int Key;
        private void SalDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize=new System.Drawing.Printing.PaperSize("pprnm",450,600);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        double GrdTot = 0, TotTax = 0,Deduct=0;
        private void ComputeBtn_Click(object sender, EventArgs e)
        {
            if(BaseSalTb.Text == "")
            {
                MessageBox.Show("Select the Employee!!");
            }
            else if (BonusTb.Text == "")
            {
                MessageBox.Show("Select the Bonus!!");
            }
             
            else
            {
                hr = Convert.ToInt32(BaseSalTb.Text) * 0.10;
                ta = Convert.ToInt32(BaseSalTb.Text) * 0.25;
                da = Convert.ToInt32(BaseSalTb.Text) * 0.05;
                Pres = Convert.ToInt32(PresTb.Text);
                Abs = Convert.ToInt32(AbsTb.Text);
                Exc = Convert.ToInt32(ExcTb.Text);
                DailyBase = Convert.ToInt32(BaseSalTb.Text)/28;
                AttSal = ((DailyBase) * Pres) + ((DailyBase / 2) * Exc);
                Total = AttSal + hr + da + ta;
                double Tax = Total * 0.16;
                TotTax = Total - Tax;
                GrdTot = TotTax + Convert.ToInt32(BonusTb.Text);

                //deducting
                if (GrdTot > 50000 && GrdTot < 40000)
                    DGrdTot = GrdTot - (GrdTot * 0.30);
                else if (GrdTot > 40000 && GrdTot < 20000)
                    DGrdTot = GrdTot - (GrdTot * 0.20);
                else if (GrdTot > 20000 && GrdTot < 10000)
                    DGrdTot = GrdTot - (GrdTot * 0.10);
                else
                    DGrdTot = GrdTot - (GrdTot * 0.05);

                Deduct = GrdTot - DGrdTot;

                BalanceTb.Text = "Rs " + DGrdTot;
                DedTb.Text = "Rs " + Deduct;
                hra.Text = "Rs " + hr;
                textBox2.Text = "Rs " + da;
                textBox3.Text = "Rs " + ta;

            }

        }
    }
}
