using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eSmash.Models.dto
{
    public class QlikDto
    {
        public QlikDto()
        {
            Language = "en";
        }

        public string Server { get; set; }
        public string WebDomain { get; set; }
        public string VirtualProxy { get; set; }
        public string UserDirectory { get; set; }
        public string UserName { get; set; }
        public string CertificateName { get; set; }
        public string WebPath { get; set; }
        public string WebBIPath { get; set; }

        public string URL { get; set; }
        public string Language { get; set; }
        public string TicketCode { get; set; }

    }

}