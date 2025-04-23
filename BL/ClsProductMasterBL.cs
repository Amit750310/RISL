using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;
using DL;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace BL
{
    public class ClsProductMasterBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

        public DataTable GetallProduct()
        {
            DataTable dt = new DataTable();
            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_select_all_Productmaster", CommandType.StoredProcedure);
            return dt;
        }

        public DataTable GetSelectedProduct(string prodid)
        {

            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@ProductId", prodid);
            BaseCommon bc = new BaseCommon();
            return bc.GetDatatable("Prc_select_Single_Productmaster", CommandType.StoredProcedure, objSqlParam);
        }


        public void fill_brand_Drop(ref DropDownList Xddl)
        {
            BaseCommon.FillDropDown(ref Xddl, "Prc_Fill_dropdown_Brand_Master", CommandType.Text);
        }
        public string InsertproductMaster(ClsProductmasterML obj)
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mode", obj.mode);
            cmd.Parameters.AddWithValue("@Id", obj.Id);
            cmd.Parameters.AddWithValue("@ProductCode", obj.ProductCode);
            cmd.Parameters.AddWithValue("@ProductName", obj.ProductName);
            cmd.Parameters.AddWithValue("@ShortDescription", obj.ShortDescription);
            cmd.Parameters.AddWithValue("@FullDescription", obj.FullDescription);
            cmd.Parameters.AddWithValue("@DisplayOrder", obj.DisplayOrder);
            cmd.Parameters.AddWithValue("@BrandID", obj.BrandID);
            cmd.Parameters.AddWithValue("@ProductBrand", obj.ProductBrand);
            cmd.Parameters.AddWithValue("@ProductGroup", obj.ProductGroup);
            cmd.Parameters.AddWithValue("@ProductType", obj.ProductType);
            cmd.Parameters.AddWithValue("@ValidityPeriod", obj.ValidityPeriod);
            cmd.Parameters.AddWithValue("@UnitPrice", obj.UnitPrice);
            cmd.Parameters.AddWithValue("@SecondYearPrice", obj.SecondYearPrice);
            cmd.Parameters.AddWithValue("@ThirdYearPrice", obj.ThirdYearPrice);
            cmd.Parameters.AddWithValue("@Issuance", obj.Issuance);
            cmd.Parameters.AddWithValue("@SGC", obj.SGC);
            cmd.Parameters.AddWithValue("@SanName", obj.SanName);
            cmd.Parameters.AddWithValue("@approved", obj.approved);
            cmd.Parameters.AddWithValue("@CodeSigner", obj.CodeSigner);
            cmd.Parameters.AddWithValue("@San_Name", obj.San_Name);
            cmd.Parameters.AddWithValue("@San_Price", obj.San_Price);
            cmd.Parameters.AddWithValue("@ReIssue", obj.ReIssue);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            cmd.Parameters.AddWithValue("@AddedBy", obj.AddedBy);
            cmd.Parameters.AddWithValue("@Site_Seal", obj.Site_Seal);
            cmd.Parameters.AddWithValue("@Product_Specification", obj.Product_Specification);
            
            cmd.CommandText = "Prc_Insert_product_master";
            if (cmd.ExecuteNonQuery() < 0)
            {
                return "false";
            }

            return err;
        }
    }
}
