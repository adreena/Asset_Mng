using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Asset_Mng
{
    public partial class Report : Form
    {
        public Report()
        {
           // InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            if (Main.report_kind == "All-Reports")
            {
              //  rptAll rpt = new rptAll();
              //  crystalReportViewer1.ReportSource = rpt;
                // crystalReportViewer1.Show();
            }
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }
    }
}