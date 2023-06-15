using Microsoft.Reporting.WinForms;
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
    public partial class Monthly : Form
    {
        public Monthly()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VS\PayrollSystem\PayRollDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Monthly_Load(object sender, EventArgs e)
        {
            this.MonReport.RefreshReport();
            this.MonReport.RefreshReport();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            // where SalPeriod.Value.Month='"+ MonthTb.Text+ "' 
            SqlCommand cmd = new SqlCommand("select * from SalaryTbl where SalPeriod= '" + MonCb.SelectedValue.ToString() + "'", Con);
            SqlDataAdapter d=new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);

            MonReport.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("MonthlyS", dt);
            MonReport.LocalReport.ReportPath = @"D:\Trials\PayrollSystem\MonthlySal.rdlc";
            MonReport.LocalReport.DataSources.Add(source);
            MonReport.RefreshReport();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
