using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace BL
{
    public class clsfill
    {

        public static void fill_kEY_Auditable_Area(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select Key_Area_Code,Key_Area_Name from Audit_Key_Auditable_Area_Master";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            // cmb.DataValueField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }

        public static bool IsSubKeyAreaCodeExist(string code)
        {
            bool exists = false;
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select count(*) from Key_Standard_Object_Master where Object_Code = @Code";
            cmd.Parameters.AddWithValue("@Code", code);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int count = (int)cmd.ExecuteScalar();
            exists = count > 0;
            return exists;
        }



        public static void fillyear(System.Web.UI.WebControls.DropDownList ddyr)
        {
            int i;
            ListItem l;
            //ddyr.Items.Add("Select");
            //ddyr.Items.Insert(0, new ListItem("--Select--", "0"));
            for (i = 2018; i <= System.DateTime.Now.Year; i++)
            {
                l = new ListItem();
                l.Text = i.ToString();
                //l.Text = i + "-" + Convert.ToString(i + 1);
                l.Value = i.ToString();
                ddyr.Items.Add(l);

            }
        }
        public string ToFinancialYear()
        {
            string Year1 = Convert.ToString(DateTime.Now.Year);
            string Year2 = Convert.ToString(DateTime.Now.Year + 1);
            string finYear = Year1 + "-" + Year2;
            return finYear;
        }
        public static void fill_Schedule(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select * from UAM_Schedule_Master";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fillminorhead(System.Web.UI.WebControls.DropDownList cmb, string major)
        {

            conn c = new conn();
            string str1 = "select minor_head_code from Minor_Head_Master where major_head_code=@major";
            SqlCommand cmd = new SqlCommand(str1);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@major", major);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            // cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fillobjecthead(System.Web.UI.WebControls.DropDownList cmb, string major, string minor)
        {

            conn c = new conn();
            string str1 = "select Object_Code,Object_Code_Name from Object_Head_Master where major_head_code=@major and minor_head_code=@minor";
            SqlCommand cmd = new SqlCommand(str1);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@major", major);
            cmd.Parameters.AddWithValue("@minor", minor);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            // cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fillheadrec(System.Web.UI.WebControls.DropDownList cmb)
        {

            conn c = new conn();
            string str1 = "select Major_Head_Code from Major_Head_Master where Flag='Rec'";
            SqlCommand cmd = new SqlCommand(str1);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            // cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fillheadpac(System.Web.UI.WebControls.DropDownList cmb)
        {

            conn c = new conn();
            string str1 = "select Major_Head_Code from Major_Head_Master where Flag='Exp'";
            SqlCommand cmd = new SqlCommand(str1);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            // cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fill_Schedule_income(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select * from UAM_Schedule_Master WHERE id between 21 and 38";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fill_fin_year(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select Fin_Year FROM Fin_Year_Master Where status='A'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            // cmb.DataValueField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public string GetFinancialYear()
        {
            string finYear = string.Empty;
            finYear = DateTime.Now.Month > 3 ? DateTime.Now.Year + Convert.ToString(DateTime.Now.Year + 1) : (DateTime.Now.Year - 1) + Convert.ToString(DateTime.Now.Year); //"20162017";

            return finYear;
        }
        public string GetFinYear(string finYear1)
        {
            string finYear = string.Empty;
            finYear = DateTime.Now.Month > 3 ? DateTime.Now.Year + Convert.ToString(DateTime.Now.Year + 1) : (DateTime.Now.Year - 1) + Convert.ToString(DateTime.Now.Year); //"20162017";
            return finYear;
        }
        public static void fillfinyear(System.Web.UI.WebControls.DropDownList ddyr)
        {
            int i;
            ListItem l;
            //ddyr.Items.Add("Select");
            //ddyr.Items.Insert(0, new ListItem("--Select--", "0"));
            for (i = 2018; i <= System.DateTime.Now.Year; i++)
            {
                l = new ListItem();
                l.Text = i.ToString();
                l.Text = i + Convert.ToString(i + 1);
                l.Value = i.ToString();
                ddyr.Items.Add(l);

            }
        }

        public static void fill_Grant_Number(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select grant_number,grant_name FROM Grant_Master order by Grant_Number";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fill_class_master(System.Web.UI.WebControls.DropDownList cmb, string sch)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            if (sch == "2202011010102" || sch == "2202011010103" || sch == "2202011022000")
            {
                cmd.CommandText = "select * FROM class_master where class_code between 1 and 8 order by 1";
            }
            else if (sch == "2202021090103" || sch == "2202028000300")
            {
                cmd.CommandText = "select * FROM class_master where class_code between 9 and 12 order by 1";
            }
            else if (sch == "2202021092100")
            {
                cmd.CommandText = "select * FROM class_master where class_code = 9 ";
            }
            else
            {
                cmd.CommandText = "select * FROM class_master order by 1 ";
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fill_btype(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select * FROM Benificaries_type order by id";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fill_Head_Code(System.Web.UI.WebControls.DropDownList cmb, string Grant_Number)
        {
            conn c = new conn();
            string str = "select Head_Code,Head_Name FROM Head_Master where Grant_Number=@gc order by Head_Code";
            SqlCommand cmd = new SqlCommand(str);
            cmd.Parameters.AddWithValue("@gc", Grant_Number);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }

        public static void fill_Grant_Number1(System.Web.UI.WebControls.DropDownList cmb, string hod)
        {

            conn c = new conn();
            string str1 = "select DISTINCT(grant_number) FROM scheme_Master where Depatment_code=@hod order by Grant_Number";
            SqlCommand cmd = new SqlCommand(str1);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@hod", hod);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            //cmb.DataTextField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fill_quarter(System.Web.UI.WebControls.DropDownList cmb)
        {

            conn c = new conn();
            string str1 = "select * from Quarter_Master order by Quarter_code";
            SqlCommand cmd = new SqlCommand(str1);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fill_Scheme_Code1(System.Web.UI.WebControls.DropDownList cmb, string Grant_Number, string hod)
        {
            conn c = new conn();
            string str2 = "select Scheme_Code FROM Scheme_Master where Grant_Number=@gc and Depatment_code=@hod order by Scheme_Code";
            SqlCommand cmd = new SqlCommand(str2);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@gc", Grant_Number);
            cmd.Parameters.AddWithValue("@hod", hod);
            da.Fill(ds, "temp");

            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            // cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fill_Intervention(System.Web.UI.WebControls.DropDownList cmb)
        {

            conn c = new conn();
            string str1 = "select * FROM Intervention_Master order by Intervention_code";
            SqlCommand cmd = new SqlCommand(str1);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // cmd.Parameters.AddWithValue("@hod", hod);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }

        public static void fill_Intervention_item(System.Web.UI.WebControls.DropDownList cmb, string intervention)
        {

            conn c = new conn();
            string str1 = "select * FROM Intervention_Item_Master where Intervention_Code=@intervention  order by Intervention_Code,Intervention_Item_Code";
            SqlCommand cmd = new SqlCommand(str1);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@intervention", intervention);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[2].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fill_Scheme_Code(System.Web.UI.WebControls.DropDownList cmb, string Grant_Number)
        {
            conn c = new conn();
            string str3 = "select Scheme_Code,Scheme_Name FROM Scheme_Master where Grant_Number=@gc  order by Scheme_Code";
            SqlCommand cmd = new SqlCommand(str3);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.Parameters.AddWithValue("@gc", Grant_Number);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }

        public static void fill_Bank_Master(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select Bank_code,Bank_Name FROM Bank_Master order by bank_code";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }

        public static void fill_forest_div_Master(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select division_id,division_Name FROM forest_division_master order by division_id";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fill_forest_range_Master(System.Web.UI.WebControls.DropDownList cmb, string div)
        {

            conn c = new conn();
            string str = "select Range_Id,Range_Name FROM forest_range_master where division_id=@div order by Range_Id";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@div", div);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fill_forest_beat_Master(System.Web.UI.WebControls.DropDownList cmb, string div, string range)
        {
            conn c = new conn();
            string str = "select Beat_id,Beat_Name FROM Forest_Beat_Master where division_id=@div and Range_Id=@range ";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@div", div);
            cmd.Parameters.AddWithValue("@range", range);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
            //fill_benefit_type
        }
        public static void fill_Gender_Master(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select Gender_Id,Gender FROM Gender_Master order by Gender_Id";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fill_religion_Master(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select * FROM Religion_Master where id<>'7' order by id";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fill_religion_Master1(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select * FROM Religion_Master order by id desc";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fill_category_sedu(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select * FROM Category_Master_sedu order by 1";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fill_Category_Master(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select Category_Id,Category FROM Category_Master order by Category_Id";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fill_Relation_Master(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select Id,relation_name FROM Relation_Master order by id";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fill_scheme_type(System.Web.UI.WebControls.DropDownList cmb, string g_code, string scheme_code)
        {
            conn c = new conn();
            string str = "select scheme_code,(CASE WHEN state_center_type= 'C' THEN 'Center' else 'State' END) FROM Scheme_Master where grant_number=@gc and scheme_code=@sc ";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@gc", g_code);
            cmd.Parameters.AddWithValue("@sc", scheme_code);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
            //fill_benefit_type
        }
        public static void fill_scheme_type1(System.Web.UI.WebControls.DropDownList cmb, string g_code, string scheme_code, string hod)
        {
            conn c = new conn();
            string str = "select scheme_code,(CASE WHEN state_center_type= 'C' THEN 'Center' else 'State' END) FROM Scheme_Master where grant_number=@gc and scheme_code=@sc and Depatment_code=@hod";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@gc", g_code);
            cmd.Parameters.AddWithValue("@sc", scheme_code);
            cmd.Parameters.AddWithValue("@hod", hod);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
            //fill_benefit_type
        }
        public static void fill_benefit_type(System.Web.UI.WebControls.DropDownList cmb, string g_code, string scheme_code)
        {
            conn c = new conn();
            string str = "select '1'benefit_code,benefit_type FROM Scheme_Master where grant_number=@gc and scheme_code=@sc ";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@gc", g_code);
            cmd.Parameters.AddWithValue("@sc", scheme_code);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
            //fill_benefit_type
        }
        public static void fill_benefit_type1(System.Web.UI.WebControls.DropDownList cmb, string g_code, string scheme_code, string hod)
        {
            conn c = new conn();
            string str = "select '1'benefit_code,benefit_type FROM Scheme_Master where grant_number=@gc and scheme_code=@sc and  Depatment_code=@hod ";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@gc", g_code);
            cmd.Parameters.AddWithValue("@sc", scheme_code);
            cmd.Parameters.AddWithValue("@hod", hod);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
            //fill_benefit_type
        }
        public static void fill_sub_scheme(System.Web.UI.WebControls.DropDownList cmb, string g_code, string scheme_code, string hod)
        {
            conn c = new conn();
            string str = "select distinct(sub_scheme_code),sub_scheme_name_hindi FROM sub_Scheme_Master where grant_number=@gc and scheme_code=@sc and  Depatment_code=@hod ";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@gc", g_code.Trim());
            cmd.Parameters.AddWithValue("@sc", scheme_code);
            cmd.Parameters.AddWithValue("@hod", hod);
            da.Fill(ds, "temp");
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
            //fill_benefit_type
        }
        public static void fill_user(System.Web.UI.WebControls.DropDownList cmb, string hod)
        {
            conn c = new conn();
            string str = "select LOGIN_ID,USER_NM FROM Login_Master where hod=@hod  order by LOGIN_ID";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Parameters.AddWithValue("@hod", hod);
            // cmd.Parameters.AddWithValue("@loginid", 100);
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void filldist(System.Web.UI.WebControls.DropDownList cmb, string hod)
        {
            conn c = new conn();
            string str = "select LOGIN_ID,district FROM Login_Master where hod=@hod order by LOGIN_ID";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@hod", hod);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fill_dpt_Master(System.Web.UI.WebControls.DropDownList cmb, string hod)
        {
            conn c = new conn();
            string str = "select * FROM Department_Master where depatment_code=@hod";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@hod", hod);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fill_dpt_Master1(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            string str = "select distinct(dm.Depatment_code),dm.Department_Name from Department_Master dm inner join  Scheme_Master sm on dm.Depatment_Code=sm.Depatment_code order by department_name";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fill_Farmer_Master(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select * FROM farmer_Master order by Farmer_type_id";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();

        }
        public static void fill_District_Master(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            cmd.CommandText = "select District_id,District_Name FROM District_Master order by District_id";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fillexam(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            string str = "select sub_exam_code,Exam_Name FROM Exam_Master where exam_code=@sec order by sub_exam_code";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int sec = 1;
            cmd.Parameters.AddWithValue("@sec", sec);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fillqulexam(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            string str = "select * FROM Exam_Master1 order by id";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void filleducation(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            string str = "select * FROM Education_Master order by id";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fillexam1(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            string str = "select sub_exam_code,Exam_Name FROM Exam_Master where exam_code=@sec order by sub_exam_code";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int sec = 2;
            cmd.Parameters.AddWithValue("@sec", sec);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fillqualexam(System.Web.UI.WebControls.DropDownList cmb)
        {
            conn c = new conn();
            string str = "select * FROM Exam_Master1 order by id";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fill_sub_District_Master(System.Web.UI.WebControls.DropDownList cmb, string district)
        {
            conn c = new conn();
            string str = "select sub_District_id,Sub_District_Name FROM Sub_District_Master where district_id =@dist order by Sub_District_Name";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@dist", district);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fill_Block_Master(System.Web.UI.WebControls.DropDownList cmb, string block)
        {
            conn c = new conn();
            string str = "select block_id,block_Name FROM Block_Master where district_id =@block order by block_Name";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@block", block);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
        public static void fill_village_Master(System.Web.UI.WebControls.DropDownList cmb, string sub_district)
        {
            conn c = new conn();
            string str = "select village_id,village_Name FROM Village_Master where sub_district_id =@sdist order by village_Name";
            SqlCommand cmd = new SqlCommand(str);
            DataSet ds = new DataSet();
            cmd.Connection = c.sql_open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@sdist", sub_district);
            da.Fill(ds, "temp");
            cmb.DataValueField = ds.Tables["temp"].Columns[0].ToString();
            cmb.DataTextField = ds.Tables["temp"].Columns[1].ToString();
            cmb.DataSource = ds.Tables["temp"];
            cmb.DataBind();
            da.Dispose();
            ds.Clear();
            ds.Dispose();
            cmd.Dispose();
            c.sql_close();
        }
    }
}
