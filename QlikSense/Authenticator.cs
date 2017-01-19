using System;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using QlikAuthNet;

namespace QlikSense
{
    public class Authenticator : IAuthenticator
    {
        private ILocation Location;

        public string CertificateName { get; set; }
        public StoreLocation CertificateLocation { get; set; }

        public Authenticator(ILocation location)
        {
            Location = location;
            SetConnectionOptions();
        }

        private void SetConnectionOptions()
        {

            ServicePointManager.Expect100Continue = true;

            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls |
                SecurityProtocolType.Ssl3 |
                SecurityProtocolType.Tls11 |
                SecurityProtocolType.Tls12;
        }

        public string GetTicket()
        {
            var ticket = CreateTicketRequest().TicketRequest();

            if (ticket == null)
            {
                throw new Exception("The ticket could not be obtained");
            }

            return ticket.Replace("qlikTicket=", "");
        }

        private Ticket CreateTicketRequest()
        {
            var ticketRequest = new Ticket();

            ticketRequest.UserId = Location.UserId;
            ticketRequest.UserDirectory = Location.UserDirectory;
            ticketRequest.ProxyRestUri = Location.GetProxyRestUri().ToString();

            if (CertificateName != null)
            {
                ticketRequest.CertificateName = CertificateName;
            }

            if (CertificateLocation != 0)
            {
                ticketRequest.CertificateLocation = CertificateLocation;
            }

            return ticketRequest;
        }
    }
}
