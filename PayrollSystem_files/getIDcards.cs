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
    public partial class getIDcards : Form
    {
        public getIDcards()
        {
            InitializeComponent();
            //this.NameCb.Text = "--Select--";
            GetEmployeeName();
            ShowData();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trials\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void GetEmployeeName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from EmployeeTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpName", typeof(string));
            dt.Load(Rdr);
            NameCb.ValueMember = "EmpName";
            NameCb.DataSource = dt;
            Con.Close();
        }
        private void ShowData()
        {
            Con.Open();
            string Query = "select EmpId,EmpName,EmpGen,EmpDOB,EmpPhone,EmpAdd from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void NameCb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            string Query = "select EmpId,EmpName,EmpGen,EmpDOB,EmpPhone,EmpAdd from EmployeeTbl where EmpName='" + NameCb.Text + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 120, 180);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("PayIT Ltd", new Font("Segoe UI Black", 5, FontStyle.Bold), Brushes.BlueViolet, new Point(40, 15));
            e.Graphics.DrawString("Payroll Management System", new Font("Segoe UI Black", 4, FontStyle.Bold), Brushes.Blue, new Point(20, 25));
            //string SNum = SalDGV.SelectedRows[0].Cells[0].Value.ToString();
            //EmpId,EmpName,EmpGen,EmpDOB,EmpPhone,EmpAdd
            string EId = EmpDGV.SelectedRows[0].Cells[0].Value.ToString();
            string Name = EmpDGV.SelectedRows[0].Cells[1].Value.ToString();
            string Gender = EmpDGV.SelectedRows[0].Cells[2].Value.ToString();
            string DOB = EmpDGV.SelectedRows[0].Cells[3].Value.ToString();
            string Phone = EmpDGV.SelectedRows[0].Cells[4].Value.ToString();
            string Address = EmpDGV.SelectedRows[0].Cells[5].Value.ToString();
            e.Graphics.DrawString("ID: " + EId, new Font("Arial", 3, FontStyle.Bold), Brushes.Black, new Point(30, 60));
            e.Graphics.DrawString("Name: " + Name, new Font("Arial", 3, FontStyle.Bold), Brushes.Black, new Point(30, 75));
            e.Graphics.DrawString("Gender: " + Gender, new Font("Arial", 3, FontStyle.Bold), Brushes.Black, new Point(30, 90));
            e.Graphics.DrawString("DOB: " + DOB, new Font("Arial", 3, FontStyle.Bold), Brushes.Black, new Point(30, 105));
            e.Graphics.DrawString("Phone: " + Phone, new Font("Arial", 3, FontStyle.Bold), Brushes.Black, new Point(30, 120));
            e.Graphics.DrawString("Address: " + Address, new Font("Arial", 3, FontStyle.Bold), Brushes.Black, new Point(30, 135));
            e.Graphics.DrawString("___________________________________________", new Font("Arial", 3, FontStyle.Bold), Brushes.Black, new Point(10, 165));
            e.Graphics.DrawString("www.payit.com", new Font("Arial", 3, FontStyle.Bold), Brushes.Black, new Point(45, 170));
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
        {
            Attendance Obj = new Attendance();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Salary Obj = new Salary();
            Obj.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Feedback Obj = new Feedback();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Feedback Obj = new Feedback();
            Obj.Show();
            this.Hide();
        }
    }
}
