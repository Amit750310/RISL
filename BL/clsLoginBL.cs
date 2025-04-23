using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;
using System.Data.SqlClient;
using ML;
using BL;
using DL;
namespace BL
{ 
    
    public class clsLoginBL
    {
        BaseCommon common = new BaseCommon();
         [DataMember]
        public int code { set; get; }
        [DataMember]
        public string message { set; get; }
        [DataMember]
        public string data;
        [DataMember]
        public virtual clsLoginML[] dataArray { get; set; }
        public clsLoginBL()
        {
            this.code = 1;
            this.message = " Invalid request";
            dataArray = new clsLoginML[0];
            data = string.Empty;

        }

        public clsLoginBL Login(clsLoginML prp)
        {

            clsLoginBL obj = new clsLoginBL();
            try
            {
            
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@UserId", prp.EmailID);
                objSqlParam[1] = new SqlParameter("@Pswrd", prp.pswrd);
             DataSet ds=common.GetDataSet("CheckAdminValidation", objSqlParam);
             DataTable dt=new DataTable ();
             if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
             {
                 dt = ds.Tables[0];
             }
                obj.dataArray = new clsLoginML[dt.Rows.Count];
                 int i = 0;
                 foreach (DataRow r in dt.Rows)
                 {
                     obj.dataArray[i] = new clsLoginML();
                     obj.dataArray[i].roleId = dt.Rows[i]["role_Id"].ToString();
                     obj.dataArray[i].userName = dt.Rows[i]["First_Name"].ToString() +" "+ dt.Rows[i]["Last_Name"].ToString();
                     obj.dataArray[i].loginId = dt.Rows[i]["emp_Id"].ToString();
                     obj.dataArray[i].EmailID = dt.Rows[i]["email_Id"].ToString();
                     obj.dataArray[i].pswrd = dt.Rows[i]["password"].ToString();
                     obj.dataArray[i].mobileno = dt.Rows[i]["mobile"].ToString();
                     ++i;
                 }
                obj.code = 0;
                obj.message = "Ok";

            }
            catch (Exception ex)
            {
                obj.code = 2;
                obj.data = null;
                obj.dataArray = null;
                obj.message = "Error=" + ex.Message + "Stack Trace=" + ex.StackTrace;

            }
            return obj;
        }

        public string ResetPassword(string username, string oldpaswd, string newpaswd)
        {
            string msg = "";
            try
            {

                oldpaswd = common.Base64Encode(oldpaswd);
                newpaswd = common.Base64Encode(newpaswd);
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@username", username);
                objSqlParam[1] = new SqlParameter("@oldpaswd", oldpaswd);
                objSqlParam[2] = new SqlParameter("@newpaswd", newpaswd);
                objSqlParam[3] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                objSqlParam[3].Direction = ParameterDirection.Output;
                common.GetDataSet("IMS_Check_Password", objSqlParam);
                msg = Convert.ToString(objSqlParam[3].Value);
            }
            catch (Exception ex)
            {

                //throw;
                string MSG = ex.Message + ex.StackTrace;

            }
            finally
            {

            }
            return msg;
        }
        
       
    }
}
