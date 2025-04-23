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
    public class ClsTicketRequestBL
    {
        SqlConnection con = new SqlConnection(Configuration.Connection);
        string err = "";

       
        public DataTable GetPendingTicket(string fromdate, string todate, string status, string Emp_code, string Level)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objSqlParam = new SqlParameter[5];
            objSqlParam[0] = new SqlParameter("@fdate", fromdate);
            objSqlParam[1] = new SqlParameter("@tdate", todate);
            objSqlParam[2] = new SqlParameter("@status", status);
            objSqlParam[3] = new SqlParameter("@AddedBy", Emp_code);
            objSqlParam[4] = new SqlParameter("@Level", Level);

            BaseCommon bc = new BaseCommon();
            dt = bc.GetDatatable("Prc_Get_PendingTicketList_web", CommandType.StoredProcedure, objSqlParam);
            return dt;
        }
        public DataTable GetTicketDetails(string Ticket_id)
        {
            BaseCommon bc = new BaseCommon();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@Ticket_id", Ticket_id);
            return bc.GetDatatable("Prc_Get_Ticket_Detail_web", CommandType.StoredProcedure, objSqlParam);
        }
        public DataTable GetTicketfeedback(string Ticket_id)
        {
            BaseCommon bc = new BaseCommon();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@Ticket_id", Ticket_id);
            return bc.GetDatatable("Prc_Get_Ticket_feedback", CommandType.StoredProcedure, objSqlParam);
        }
        public DataTable GetTicketAttachment(string Ticket_id)
        {
            BaseCommon bc = new BaseCommon();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@Ticket_id", Ticket_id);
            return bc.GetDatatable("prc_getticketAttachments", CommandType.StoredProcedure, objSqlParam);
        }
        public DataTable GetTicketEmail(string Ticket_id)
        {
            BaseCommon bc = new BaseCommon();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@Ticket_id", Ticket_id);
            return bc.GetDatatable("prc_getticketEmail", CommandType.StoredProcedure, objSqlParam);
        }
        public DataTable getticketAttachmentswithID(string id)
        {
            BaseCommon bc = new BaseCommon();
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@id", id);
            return bc.GetDatatable("prc_getticketAttachmentswithID", CommandType.StoredProcedure, objSqlParam);
        }
        public DataTable getticketAssignedEmp()
        {
            BaseCommon bc = new BaseCommon();
          
            return bc.GetDatatable("prc_getticketAssignedEmp", CommandType.StoredProcedure);
        }
        public string InserTicketDetail(ClsTicketRequestML obj)
        {
            string save = "";
            
            try
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Ticket_id", obj.Ticket_id);
                cmd.Parameters.AddWithValue("@Ticket_no", obj.Ticket_no);
                cmd.Parameters.AddWithValue("@Status", obj.Status);
                cmd.Parameters.AddWithValue("@Next_date", obj.Next_date);
                cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);
                cmd.Parameters.AddWithValue("@Notes", obj.Notes);
                cmd.Parameters.AddWithValue("@Added_by", obj.Added_by);
                cmd.Parameters.AddWithValue("@TicketAssigned", obj.TicketAssigned);
                cmd.CommandText = "Prc_Insert_ticket_Details_status_Web";
                if (cmd.ExecuteNonQuery() < 0)
                {
                    return "false";
                }

            }
            catch (Exception ex)
            {
                err = ex.Message;
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                return "false";
            }
            return save;
        }

        public string insert_tblTicketEmail(ClsTicketEmailML obj)
        {
            string save = "";

            try
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Ticket_No", obj.Ticket_No);
                cmd.Parameters.AddWithValue("@email_From", obj.email_From);
                cmd.Parameters.AddWithValue("@email_Subject", obj.email_Subject);
                cmd.Parameters.AddWithValue("@email_BodyHtml", obj.email_BodyHtml);
                cmd.Parameters.AddWithValue("@email_Date", obj.email_Date);
                cmd.Parameters.AddWithValue("@email_DateString", obj.email_DateString);
                cmd.Parameters.AddWithValue("@email_ReceivedDate", obj.email_ReceivedDate);
               
                cmd.CommandText = "prc_insert_tblTicketEmail";
                if (cmd.ExecuteNonQuery() < 0)
                {
                    return "false";
                }
               
            }
            catch (Exception ex)
            {
                err = ex.Message;
                DL.BaseCommon objerr = new DL.BaseCommon();
                objerr.InesrtError("Error IS " + ex.Message + "_" + ex.StackTrace);
                return "false";
            }
            return save;
        }
    }
}
