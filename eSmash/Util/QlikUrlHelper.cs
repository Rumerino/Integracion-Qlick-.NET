using System;
using System.Threading;
using QlikSense;

using System.Security.Cryptography.X509Certificates;
using eSmash.Models.dto;
using eSmash.Util;

namespace eSmash.Util
{
    public class QlikUrlHelper
    {
        private QlikDto qlikDto;
        private string AppId;
        private string Protocol = "https";
        private string ProtocolTicket = "https";

        public QlikUrlHelper() {
            qlikDto = GetQlikDto();
            AppId = ConfigReader.getQlikConfigValue("appId");
        }

        public Uri GetTicketUrl() {
            return  GetServerLocation(qlikDto, ProtocolTicket).GetTicketEndpointUri();
        }

        public Uri GetIframeSheetUri()
        {
            return GetIframeUri(AppId, "sheet", ConfigReader.getQlikConfigValue("sheetId"));
        }

        public Uri GetIframeObjectUri()
        {
            return GetIframeUri(AppId, "obj", ConfigReader.getQlikConfigValue("objectId"));
        }

        private Uri GetIframeUri(string AppId, string key, string value)
        {
            string query = string.Format("/?appid={0}&lang={1}&{2}={3}", AppId, qlikDto.Language, key, value);
            ILocation location = GetServerLocation(qlikDto);
            return new Uri(location.GetIframeBaseUri() + query);
        }

        //private IAuthenticator GetAuthenticator(QlikDto appConfig)
        //{
        //    var location = GetServerLocation(appConfig, ProtocolTicket);

        //    var authenticator = new Authenticator(location);
        //    authenticator.CertificateName = appConfig.CertificateName;
        //    authenticator.CertificateLocation = StoreLocation.LocalMachine;

        //    return authenticator;
        //}
        
        private ILocation GetServerLocation(QlikDto appConfig)
        {
            return GetServerLocation(appConfig, Protocol);
        }

        private ILocation GetServerLocation(QlikDto appConfig, string protocol)
        {
            var location = new Location(GetUri(protocol, appConfig.Server));

            location.UserId = appConfig.UserName;
            location.UserDirectory = appConfig.UserDirectory;
            location.VirtualProxy = appConfig.VirtualProxy;

            return location;
        }

        private ILocation GetWebLocation(QlikDto appConfig)
        {
            string path = string.IsNullOrWhiteSpace(appConfig.WebBIPath)
                ? string.Empty
                : "/" + appConfig.WebBIPath;

            var location = new Location(GetUri(Protocol, appConfig.WebDomain, path));

            location.VirtualProxy = appConfig.VirtualProxy;

            return location;
        }



        private Uri GetUri(string protocol, string host, string path = "")
        {
            return new Uri(new Uri(protocol + "://" + host), path);
        }

        //public Uri getIframeUri() {

        //}

        private QlikDto GetQlikDto()
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
    }
}