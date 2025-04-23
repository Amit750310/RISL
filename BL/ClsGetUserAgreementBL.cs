

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;
using DL;
using System.Data.SqlClient;
using System.Data;

namespace BL
{
    public class ClsGetUserAgreementBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        public DataTable getProductCodeofProduct(string BrandID, string ProductId)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[2];
            objSqlParam[0] = new SqlParameter("@BrandID", BrandID);
            objSqlParam[1] = new SqlParameter("@ProductId", ProductId);
           BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("prc_getProductCodeofProduct", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
       
    }
}
