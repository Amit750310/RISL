using System;
using BL;
using System.Data;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace vms
{
    public partial class Dashboard : System.Web.UI.Page
    {
        ClsDashboardBL tbldashboard = new ClsDashboardBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string project="";
                filldropdoen();
                BindCounter();
                Bindchart(project);
                Bindchart2(project);
                Bindchart1(project);
                //getChartData3();
            }
        }

        void filldropdoen()
        {
          tbldashboard.bindprojet(Projectname);
        }
        private void BindCounter()
        {
            string Level = "";
            //string Emp_code = Convert.ToString(Session["Employeecode"]);
            string Emp_code = Convert.ToString(Session["loginId"]);
            if (Convert.ToString(Session["roleID"]) == "4")
            {
                Level = "4";
            }
            else
            {
                Level = Convert.ToString(Session["HiLevel"]);
            }

            DataTable dt = tbldashboard.GetLeadCounter(Convert.ToString(Session["loginId"]), Level);
            if (dt.Rows.Count > 0)
            {
                lbltotalvendors.Text = dt.Rows[0]["totalvendors"].ToString();
                lbltodayVendors.Text = dt.Rows[0]["todayVendors"].ToString();

            }


        }


        public void Bindchart(string Projectname)
        {
            DataSet ds = new DataSet();
            ds = tbldashboard.DashboradCount(Projectname);
            DataTable ChartData = ds.Tables[0];

            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            int[] YPointMember = new int[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["Name"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["Count1"]);
            }
            //binding chart control  
            Chart1.Series[0].Points.DataBindXY(XPointMember, YPointMember);

            //Setting width of line  
            Chart1.Series[0].BorderWidth = 10;
            //setting Chart type   
            Chart1.Series[0].ChartType = SeriesChartType.Pie;
            foreach (Series charts in Chart1.Series)
            {
                foreach (DataPoint point in charts.Points)
                {
                    switch (point.AxisLabel)
                    {
                        case "Q1": point.Color = Color.RoyalBlue; break;
                        case "Q2": point.Color = Color.SaddleBrown; break;
                        case "Q3": point.Color = Color.SpringGreen; break;
                    }
                    point.Label = string.Format("{0:0} - {1}", point.YValues[0], point.AxisLabel);

                }
            }
            //Enabled 3D  
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;  
        }
        public void Bindchart1(string projectName)
        {
            DataSet ds = new DataSet();
            ds = tbldashboard.DashboradCount1(projectName);
            DataTable ChartData = ds.Tables[0];
            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            int[] YPointMember = new int[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["Name"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["Count1"]);
            }
            //binding chart control  
            Chart2.Series[0].Points.DataBindXY(XPointMember, YPointMember);

            //Setting width of line  
            Chart2.Series[0].BorderWidth = 10;
            //setting Chart type   
            Chart2.Series[0].ChartType = SeriesChartType.Column;
            foreach (Series charts in Chart2.Series)
            {
                foreach (DataPoint point in charts.Points)
                {
                    switch (point.AxisLabel)
                    {
                        case "Q1": point.Color = Color.RoyalBlue; break;
                        case "Q2": point.Color = Color.SaddleBrown; break;
                        case "Q3": point.Color = Color.SpringGreen; break;
                    }
                    point.Label = string.Format("{0:0} - {1}", point.YValues[0], point.AxisLabel);

                }
            }
            //Enabled 3D  
            Chart2.ChartAreas["ChartArea2"].Area3DStyle.Enable3D = true;
        }


        public void Bindchart2( string project)
        {
            DataSet ds = new DataSet();
            ds = tbldashboard.districtCount(project);
            DataTable ChartData = ds.Tables[0];
            //storing total rows count to loop on each Record  
            string[] XPointMember = new string[ChartData.Rows.Count];
            int[] YPointMember = new int[ChartData.Rows.Count];

            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                //storing Values for X axis  
                XPointMember[count] = ChartData.Rows[count]["district"].ToString();
                //storing values for Y Axis  
                YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["Count1"]);
            }
            //binding chart control  
            Chart3.Series[0].Points.DataBindXY(XPointMember, YPointMember);

            //Setting width of line  
            Chart3.Series[0].BorderWidth = 10;
            //setting Chart type   
            Chart3.Series[0].ChartType = SeriesChartType.Bar;
            foreach (Series charts in Chart3.Series)
            {
                foreach (DataPoint point in charts.Points)
                {
                    switch (point.AxisLabel)
                    {
                        case "Q1": point.Color = Color.RoyalBlue; break;
                        case "Q2": point.Color = Color.SaddleBrown; break;
                        case "Q3": point.Color = Color.SpringGreen; break;
                    }
                    point.Label = string.Format("{0:0} - {1}", point.YValues[0], point.AxisLabel);

                }
            }
            //Enabled 3D  
            Chart3.ChartAreas["ChartArea3"].Area3DStyle.Enable3D = true;
        }

        protected void Projectname_SelectedIndexChanged(object sender, EventArgs e)
        {
              string ProjectName= Projectname.SelectedItem.Text;
              Bindchart(ProjectName);
              Bindchart2(ProjectName);
              Bindchart1(ProjectName);


        }
    }
}
