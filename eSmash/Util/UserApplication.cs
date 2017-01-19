using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QlikSense;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using eSmash.Models.dto;

namespace eSmash.Util
{
    public class UserApplication
    {
        private QlikDto AppConfig;
        private IAuthenticator Authenticator;
        private Application QlikApplication;

        private string Protocol = "https";

        public string serverRootUrl { get; set; }

        public UserApplication()
        {
            AppConfig = GetApplicationConfig();
            Authenticator = GetAuthenticator(AppConfig);
            QlikApplication = GetQlikApplication(AppConfig);
        }

        public Application Start()
        {
            var ticket = Authenticator.GetTicket();
            QlikApplication.Ticket = ticket;

            return QlikApplication;
        }

        private QlikDto GetApplicationConfig()
        {
            return new QlikDto()
            {
                Server = ConfigReader.getQlikConfigValue("uriBase"),
                VirtualProxy = ConfigReader.getQlikConfigValue("virtualProxy"),
                Language = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName,
                UserDirectory = ConfigReader.getQlikConfigValue("userDirectory"),
                UserName = ConfigReader.getQlikConfigValue("userName"),
                CertificateName = ConfigReader.getQlikConfigValue("certificateName"),
                WebBIPath = ConfigReader.getQlikConfigValue("webBIPath"),
                WebDomain = ConfigReader.getQlikConfigValue("webDomain"),
                WebPath = ConfigReader.getQlikConfigValue("webPath")
            };
        }

        private IAuthenticator GetAuthenticator(QlikDto appConfig)
        {
            var location = GetServerLocation(appConfig);

            var authenticator = new Authenticator(location);
            authenticator.CertificateName = appConfig.CertificateName;
            authenticator.CertificateLocation = StoreLocation.LocalMachine;
            //authenticator.CertificateLocation = StoreLocation.CurrentUser;

            return authenticator;
        }

        private ILocation GetServerLocation(QlikDto appConfig)
        {
            var location = new Location(GetUri(Protocol, appConfig.Server));

            location.UserId = appConfig.UserName;
            location.UserDirectory = appConfig.UserDirectory;
            location.VirtualProxy = appConfig.VirtualProxy;

            return location;
        }

        private Uri GetUri(string protocol, string host, string path = "")
        {
            return new Uri(new Uri(protocol + "://" + host), path);
        }

        private Application GetQlikApplication(QlikDto appConfig)
        {
            var location = GetWebLocation(appConfig);
            var application = new Application(location);
            serverRootUrl = location.GetQlikSenseRootUri().ToString();
            return application;
        }

        private ILocation GetWebLocation(QlikDto appConfig)
        {
            string path = string.IsNullOrWhiteSpace(appConfig.WebBIPath)
                ? string.Empty
                : "/" + appConfig.WebBIPath;

            var location = new Location(GetUri(Protocol, appConfig.WebDomain, path));
            //var location = new Location(GetUri("http", appConfig.WebDomain, path));

            location.VirtualProxy = appConfig.VirtualProxy;

            return location;
        }
    }    
}