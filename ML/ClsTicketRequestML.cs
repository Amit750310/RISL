using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class ClsTicketRequestML
    {
        public string ID { get; set; }
        public string Ticket_id { get; set; }
        public string Ticket_no { get; set; }
        public string Status { get; set; }
        public string Next_date { get; set; }
        public string Remarks { get; set; }
        public string Notes { get; set; }
        public string Added { get; set; }
        public string Added_by { get; set; }
        public string TicketAssigned { get; set; }
        
    }
    public class ClsTicketEmailML
    {
             public string Ticket_No { get; set; }
        public string email_From { get; set; }
        public string email_Subject { get; set; }
        public string email_BodyHtml { get; set; }
        public string email_Date { get; set; }
        public string email_DateString { get; set; }
        public string email_ReceivedDate { get; set; }
      
    }
}
