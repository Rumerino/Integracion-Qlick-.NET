using System;
using System.Security.Cryptography.X509Certificates;

namespace QlikSense
{
    public interface IAuthenticator
    {
        StoreLocation CertificateLocation { get; set; }
        string CertificateName { get; set; }
        string GetTicket();
    }
}
