using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
//using Oracle.DataAccess.Client;


namespace DL
{
    public class BaseCommon
    {
        static string Msg;
        static string strErrMsg;
        public static DateTime CurrentDate
        {
            get
            {
                TimeZoneInfo timezoneinfo;
                DateTime datetime;
                timezoneinfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                datetime = TimeZoneInfo.ConvertTime((Convert.ToDateTime(GetDataSet("Get_Date", CommandType.Text).Tables[0].Rows[0][0])), timezoneinfo);
                return datetime;
            }
        }
        //public static DataSet GetDataSetOracle(string XcmdText, CommandType XcmdType)
        //{
        //    Msg = "";
        //    OracleConnection con = new OracleConnection(Configuration.OracleConnection);
        //    OracleDataAdapter lda = new OracleDataAdapter();
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand(XcmdText, con);
        //        cmd.CommandType = XcmdType;
        //        cmd.Connection.Open();
        //        OracleDataAdapter da = new OracleDataAdapter(cmd);
        //        da.Fill(ds);
        //        cmd.Connection.Close();
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        Msg = ex.Message;
        //    }
        //    finally
        //    {
        //        lda.Dispose();
        //    }
        //    return ds;
        //}
        public static DataSet GetDataSet(string XcmdText, CommandType XcmdType)
        {
            Msg = "";
            SqlConnection con = new SqlConnection(Configuration.Connection);
            SqlDataAdapter lda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(XcmdText, con);
                cmd.CommandType = XcmdType;
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.Connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
            }
            finally
            {
                lda.Dispose();
            }
            return ds;
        }
        public DataSet fill_export_lov(string PORTTYPE)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@PTYPE", PORTTYPE);
                ds = GetDataSet("PRC_XXCHM_EXPORT_INFO", objSqlParam);


            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
            return ds;
        }
        public static void FillDropDown(ref DropDownList Xddl, string XcmdText, CommandType XcmdType)
        {
            Msg = "";
            SqlConnection con = new SqlConnection(Configuration.Connection);
            try
            {
                SqlCommand cmd = new SqlCommand(XcmdText, con);
                cmd.CommandType = XcmdType;
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Xddl.Items.Add("Select");
                while (dr.Read())
                {
                    ListItem list = new ListItem();
                    list.Text = dr[1].ToString();
                    list.Value = dr[0].ToString();
                    Xddl.Items.Add(list);
                    
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        public static void FillDropDown(ref DropDownList Xddl, string XcmdText, CommandType XcmdType, SqlParameter[] xArrPrm)
        {
            Msg = "";
            SqlConnection con = new SqlConnection(Configuration.Connection);
            try
            {
                SqlCommand cmd = new SqlCommand(XcmdText, con);
                cmd.CommandType = XcmdType;
                cmd.Connection.Open();
                foreach (SqlParameter param in xArrPrm)
                {
                    cmd.Parameters.Add(param);
                }
                SqlDataReader dr = cmd.ExecuteReader();
                Xddl.Items.Add("Select");
                while (dr.Read())
                {
                    ListItem list = new ListItem();
                    list.Text = dr[1].ToString();
                    list.Value = dr[0].ToString();
                    Xddl.Items.Add(list);
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        public static void FillList(ref ListBox Xddl, string XcmdText, CommandType XcmdType)
        {
            Msg = "";
            SqlConnection con = new SqlConnection(Configuration.Connection);
            try
            {
                SqlCommand cmd = new SqlCommand(XcmdText, con);
                cmd.CommandType = XcmdType;
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //Xddl.Items.Add("Select");
                while (dr.Read())
                {
                    ListItem list = new ListItem();
                    list.Text = dr[1].ToString();
                    list.Value = dr[0].ToString();
                    Xddl.Items.Add(list);
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        public static void FillCheckList(ref CheckBoxList Xddl, string XcmdText, CommandType XcmdType)
        {
            Msg = "";
            SqlConnection con = new SqlConnection(Configuration.Connection);
            try
            {
                SqlCommand cmd = new SqlCommand(XcmdText, con);
                cmd.CommandType = XcmdType;
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //Xddl.Items.Add("Select");
                while (dr.Read())
                {
                    ListItem list = new ListItem();
                    list.Text = dr[1].ToString();
                    list.Value = dr[0].ToString();
                    Xddl.Items.Add(list);
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }


        public DataTable GetDatatable(string XcmdText, CommandType XcmdType)
        {
            Msg = "";
            SqlConnection con = new SqlConnection(Configuration.Connection);
            SqlDataAdapter lda = new SqlDataAdapter();
            DataTable ds = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(XcmdText, con);
                cmd.CommandType = XcmdType;
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.Connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
            }
            finally
            {
                lda.Dispose();
            }
            return ds;
        }


        public DataTable GetDatatable(string XcmdText, CommandType XcmdType,SqlParameter [] xArrPrm)
        {
            Msg = "";
            SqlConnection con = new SqlConnection(Configuration.Connection);
            SqlDataAdapter lda = new SqlDataAdapter();
            DataTable ds = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(XcmdText, con);
                cmd.Connection.Open();
                cmd.CommandType = XcmdType;
                foreach (SqlParameter param in xArrPrm)
                {
                    cmd.Parameters.Add(param);
                }
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.Connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
            }
            finally
            {
                lda.Dispose();
            }
            return ds;
        }

        public DataSet GetDataSet(string XcmdText, CommandType XcmdType, SqlParameter[] xArrPrm)
        {
            Msg = "";
            SqlConnection con = new SqlConnection(Configuration.Connection);
            SqlDataAdapter lda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(XcmdText, con);
                cmd.Connection.Open();
                cmd.CommandType = XcmdType;
                foreach (SqlParameter param in xArrPrm)
                {
                    cmd.Parameters.Add(param);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.Connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
            }
            finally
            {
                lda.Dispose();
            }
            return ds;
        }
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static void Insert_Log(string Form_name, string Action, DateTime Add_Date, DateTime Action_Date, string User_Code, string Fin_Year, string Comp_Code, string Branch_Code, string Description)
        {
            SqlConnection con = new SqlConnection(Configuration.Connection);
            try
            {

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.Parameters.Add("@Form_name", SqlDbType.VarChar).Value = Form_name;
                cmd1.Parameters.Add("@Action", SqlDbType.VarChar).Value = Action;
                cmd1.Parameters.Add("@Add_Date", SqlDbType.DateTime).Value = Add_Date;
                cmd1.Parameters.Add("@Action_Date", SqlDbType.DateTime).Value = Action_Date;
                cmd1.Parameters.Add("@User_Code", SqlDbType.VarChar).Value = User_Code;
                cmd1.Parameters.Add("@Fin_Year", SqlDbType.VarChar).Value = Fin_Year;
                cmd1.Parameters.Add("@Comp_Code", SqlDbType.VarChar).Value = Comp_Code;
                cmd1.Parameters.Add("@Branch_Code", SqlDbType.VarChar).Value = Branch_Code;
                cmd1.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;
                cmd1.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd1.CommandText = "CA_Insert_Log";
                if (cmd1.ExecuteNonQuery() < 0)
                {

                }
            }
            catch (Exception ex)
            {
               
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                
            }
            finally { con.Close(); }


        }
        public DataSet GetDataSet(string xSPName, SqlParameter[] xArrPrm)
        {
            Msg = "";
            DataSet ds = new DataSet();
            try
            {

                SqlCommand cmd = new SqlCommand(xSPName, new SqlConnection(Configuration.Connection));
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in xArrPrm)
                {
                    cmd.Parameters.Add(param);
                }

                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.Connection.Close();
            }
            catch (Exception Ex)
            {
                Msg = Ex.Message;
                throw;
            }
            return ds;
        }
        //added by megha
        public bool numericcheck(string str1)
        {

            double mobile;
            bool numericcheck = double.TryParse(str1, out mobile);
            return numericcheck;
        }
        public string GetRandomString()
        {
            string[] arrStr = "A,B,C,D,1,2,3,4,5,6,7,8,9,0".Split(",".ToCharArray());
            string strDraw = string.Empty;
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                strDraw += arrStr[r.Next(0, arrStr.Length - 1)];
            }
            return strDraw;
        }

        public DataSet GetDataSet(string xSPName)
        {
            strErrMsg = "";
            DataSet ds = new DataSet();
            try
            {

                SqlCommand cmd = new SqlCommand(xSPName, new SqlConnection(Configuration.Connection));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.Connection.Close();
            }
            catch (Exception Ex)
            {
                strErrMsg = Ex.Message;
                throw;
            }
            return ds;
        }

        public DataTable getDTtable(string xSPName, SqlParameter[] xArrPrm)
        {
            strErrMsg = "";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Configuration.Connection);
            SqlCommand cmd = new SqlCommand(xSPName, con);
            try
            {


                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in xArrPrm)
                {
                    cmd.Parameters.Add(param);
                }

                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Connection.Close();
                return dt;
            }
            catch (Exception Ex)
            {
                cmd.Connection.Close();
                strErrMsg = Ex.Message;
            }
            return dt;
        }
        public DataTable getDTtable(string xSPName, SqlParameter xSqlParameter1)
        {

            strErrMsg = "";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(xSPName, new SqlConnection(Configuration.Connection));
            try
            {


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(xSqlParameter1);
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Connection.Close();
                return dt;

            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                cmd.Connection.Close();
                cmd.Dispose();
            }

            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
            return dt;
        }
        public DataTable getDTtable(string xSPName)
        {

            strErrMsg = "";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(xSPName, new SqlConnection(Configuration.Connection));
            try
            {


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Connection.Close();
                return dt;

            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                cmd.Connection.Close();
                cmd.Dispose();
            }

            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
            return dt;
        }

        public DataTable GetDataTable(string xSPName)
        {
            strErrMsg = "";
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand(xSPName, new SqlConnection(Configuration.Connection));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Connection.Close();
                return dt;
            }
            catch (Exception Ex)
            {
                strErrMsg = Ex.Message;
            }
            return dt;
        }

        public DataTable GetDataTable(string xSPName, SqlParameter xSqlParameter1)
        {
            strErrMsg = "";
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand(xSPName, new SqlConnection(Configuration.Connection));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(xSqlParameter1);
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Connection.Close();
                return dt;
            }
            catch (Exception Ex)
            {
                strErrMsg = Ex.Message;
            }
            return dt;
        }
        public DataTable GetDataTable(string xCmdText, CommandType xCmdType)
        {
            strErrMsg = "";
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand(xCmdText, new SqlConnection(Configuration.Connection));
                cmd.CommandType = xCmdType;
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Connection.Close();
                return dt;
            }
            catch (Exception Ex)
            {
                strErrMsg = Ex.Message;
            }
            return dt;
        }
        public DataTable GetDataTable(SqlCommand xObjCmd)
        {
            strErrMsg = "";
            SqlDataAdapter lDa = new SqlDataAdapter();
            DataTable lDt = new DataTable();
            try
            {
                xObjCmd.Connection = new SqlConnection(Configuration.Connection);
                xObjCmd.Connection.Open();
                lDa = new SqlDataAdapter(xObjCmd);
                lDa.Fill(lDt);
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
            }
            finally
            {
                xObjCmd.Connection.Close();
                xObjCmd.Dispose();
                lDa.Dispose();
            }
            return lDt; ;
        }

        public DataSet GetDataSet(string xSPName, SqlParameter xSqlParameter1)
        {
            strErrMsg = "";
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(xSPName, new SqlConnection(Configuration.Connection));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(xSqlParameter1);
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.Connection.Close();
            }
            catch (Exception Ex)
            {
                strErrMsg = Ex.Message;
            }
            return ds;
        }


        public object GetScalerValue(string xQry)
        {
            strErrMsg = "";
            object lResult;
            try
            {
                SqlCommand lCmd = new SqlCommand();
                lCmd.Connection = new SqlConnection(Configuration.Connection);
                lCmd.Connection.Open();
                lCmd.Parameters.AddWithValue("@SqlQry", xQry);
                lCmd.CommandType = CommandType.StoredProcedure;
                lCmd.CommandText = "sp_ExecuteSql_1";
                lResult = lCmd.ExecuteScalar();
                if (System.Convert.IsDBNull(lResult) == true) lResult = "";
                lCmd = null;
            }
            catch (Exception Ex)
            {
                lResult = null;
                strErrMsg = Ex.Message;
            }
            return lResult;
        }
        public object GetScalerValue(string xSPName, SqlParameter[] xArrPrm)
        {
            strErrMsg = "";
            object lResult;
            try
            {
                SqlCommand cmd = new SqlCommand(xSPName, new SqlConnection(Configuration.Connection));
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in xArrPrm)
                {
                    cmd.Parameters.Add(param);
                }

                cmd.Connection.Open();
                lResult = cmd.ExecuteScalar();
                if (System.Convert.IsDBNull(lResult) == true) lResult = "";
                cmd = null;
            }
            catch (Exception Ex)
            {
                lResult = null;
                strErrMsg = Ex.Message;
            }
            return lResult;
        }
        public bool ExecuteNonQuery(string _CommandText, CommandType _Commandtype)
        {
            strErrMsg = "";
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand(_CommandText, new SqlConnection(Configuration.Connection));
                cmd.Connection.Open();
                cmd.CommandType = _Commandtype;
                cmd.CommandText = _CommandText;
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            finally
            {
                //cmd.Dispose();
            }
        }
        public bool ExecuteNonQuery(string _procedure, params SqlParameter[] objParam)
        {
            strErrMsg = "";
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand(_procedure, new SqlConnection(Configuration.Connection));
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = _procedure;
                for (int lLoop = 0; lLoop <= objParam.GetUpperBound(0); lLoop++)
                {
                    cmd.Parameters.Add(objParam[lLoop]);
                    //string a = objParam[lLoop].Value.ToString();
                }

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                throw;
                return false;

            }
            finally
            {
                //cmd.Dispose();
            }

        }
        public bool ExecuteNonQuery(string xSPName, SqlParameter xSqlParameter1)
        {
            strErrMsg = "";
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand(xSPName, new SqlConnection(Configuration.Connection));
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = xSPName;
                cmd.Parameters.Add(xSqlParameter1);
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            finally
            {
                //cmd.Dispose();
            }

        }
        public bool ExecuteNonQuery(SqlCommand xObjCmd)
        {
            strErrMsg = "";
            int lRecEff = -1;
            try
            {
                xObjCmd.Connection = new SqlConnection(Configuration.Connection);
                xObjCmd.Connection.Open();
                lRecEff = xObjCmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                lRecEff = -1;
            }
            finally
            {
                xObjCmd.Connection.Close();
                xObjCmd.Dispose();
            }
            return (lRecEff > 0) ? true : false;
        }
        public DataSet ExecuteQuery(string Query)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(Configuration.Connection);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(Query, con);

                da.Fill(ds);

            }
            catch (Exception ex)
            {
                con.Close();
                strErrMsg = ex.Message;
            }
            return ds;
        }
        public Boolean IsEmailValid(string EmailAddr)
        {
            try
            {
                if (EmailAddr != null || EmailAddr != "")
                {
                    Regex n = new Regex("(?<user>[^@]+)@(?<host>.+)");
                    Match v = n.Match(EmailAddr);
                    if (!v.Success || EmailAddr.Length != v.Length)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }
        public string getFileExtension(string filePath)
        {
            try
            {
                string FileExtension = System.IO.Path.GetExtension(filePath);
                return FileExtension;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return "";
            }
        }
        public string getValueQuery(string Query)
        {
            SqlConnection con = new SqlConnection(Configuration.Connection);
            try
            {
                string value = "";
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    value = ds.Tables[0].Rows[0][0].ToString();

                }
                return value;
            }
            catch (Exception ex)
            {
                con.Close();
                strErrMsg = ex.Message;
                return "";
            }

        }


        public DataSet GetDataSet(string xSPName, SqlParameter[] xArrPrm, SqlConnection con, SqlTransaction lSqlTran)
        {
            strErrMsg = "";
            DataSet ds = new DataSet();
            try
            {

                SqlCommand cmd = new SqlCommand(xSPName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in xArrPrm)
                {
                    cmd.Parameters.Add(param);
                }


                cmd.Transaction = lSqlTran;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.Transaction = lSqlTran;
                da.Fill(ds);


            }
            catch (Exception Ex)
            {
                strErrMsg = Ex.Message;
                throw;
            }
            return ds;
        }


        public string SendSms(string mobileno, string Msg)
        {

            WebClient client = new WebClient();

            string baseurl = "http://push1.maccesssmspush.com/servlet/com.aclwireless.pushconnectivity.listeners.TextListener?userId=uflexa&pass=uflexa&appid=uflexa&subappid=uflexa&msgtype=1&contenttype=1&selfid=true&to=" + mobileno + "&from=UFLEXL&dlrreq=true&text=" + Msg + "&alert=1";
            //string baseurl = "https://smsgw.sms.gov.in/failsafe/MLink?username=esladl.sms&pin=V8%40mU4%26eN7&message=message&mnumber=919812091685&signature=ITSSMS&dlt_entity_id=1001519990000019834&dlt_template_id=1007159886443600227&amp;data=04|01|bajinder_mann@sislinfotech.com|3a46f8912a2a41a334a208d8c6a0e726|2cf8b7428a284ecc9256f1ccf9a6381b|1|0|637477741692714297|Unknown|TWFpbGZsb3d8eyJWIjoiMC4wLjAwMDAiLCJQIjoiV2luMzIiLCJBTiI6Ik1haWwiLCJXVCI6Mn0=|1000&amp;sdata=YGweNdv5wj272JyFFnKJQxZfCw5OgSJ+TxMv/ReDbUg=&amp;reserved=0";
            Stream data = client.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
            return s;
        }
        public bool SendAuthenticatedMail(string ToEmail, string Subject, string Bodyhtml, string attechfile)
        {



            try
            {

                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@subject1", Subject);
                objSqlParam[1] = new SqlParameter("@body1", Bodyhtml);
                objSqlParam[2] = new SqlParameter("@recipients1", ToEmail);
                GetDataSet("prc_spMail", objSqlParam);
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }



        }

        public string SendMail_New(string From, string To, string Subject, string Detail, string MsgToDisp)
        {
            try
            {



                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(From, To, Subject, Detail);
                msg.IsBodyHtml = true;





                string Body = Detail;



                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("mail.uflexltd.com", 25);

                smtp.Credentials = new System.Net.NetworkCredential("noreply", "flex2145");




                smtp.Send(msg);
                return MsgToDisp;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public bool sendEPAMail(string epa_no, string post, string customer, string date, string mail, string salesperson, string name)
        {


            string sub = "New EPA  ";
            string body = "Dear  " + name + "</br>   New EPA    :     " + epa_no + "  " + "   for the Customer  :    " + customer + "   On   " + date + "</br>    By    " + salesperson + "    Generated Please approve as     " + post + "     ";
            bool str = SendAuthenticatedMail(mail, sub, body, "");
            if (str == true)
            {
                return true;
            }
            return false;
        }

        public void InesrtError(string Error)
        {
            GetDataSet("prc_insError", new SqlParameter("@error", Error));
        }

    }
}
