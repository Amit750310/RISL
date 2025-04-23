using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DL;
using ML;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace BL
{
    public class ClsvendorsSearchProductBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        CommonConnection cc = new CommonConnection();
        SqlCommand cmd;
        SqlTransaction lSqlTran;
        BaseCommon common = new BaseCommon();
       
        public DataTable GetvendorsProductSearchLIST(ClsvendorsSearchProductML prp)
        {
            DataTable dt = new DataTable();

            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@fdate", prp.fdate);
            objSqlParam[1] = new SqlParameter("@tdate", prp.tdate);
          
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_GetvendorsProductSearchLIST", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
   
       

    }
  
}
