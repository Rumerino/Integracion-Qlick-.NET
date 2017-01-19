using System;

namespace QlikSense
{
    public class Location : ILocation
    {
        private Uri LocationUri { get; set; }
        private int ProxyPort { get; set; }

        public string VirtualProxy { get; set; }
        public string UserDirectory { get; set; }
        public string UserId { get; set; }

        public Location(Uri uri)
        {
            LocationUri = uri;
            ProxyPort = 4243;
        }

        public Uri GetProxyRestUri()
        {
            var uriBuilder = new UriBuilder(LocationUri);
            uriBuilder.Port = ProxyPort;
            uriBuilder.Path = "/qps/" + VirtualProxy;

            return uriBuilder.Uri;
        }

        public Uri GetTicketEndpointUri()
        {
            var uriBuilder = new UriBuilder(GetProxyRestUri());
            uriBuilder.Path = uriBuilder.Path + "/ticket";

            return uriBuilder.Uri;
        }

        public Uri GetIframeBaseUri()
        {
            var uriBuilder = new UriBuilder(LocationUri);
            uriBuilder.Path = VirtualProxy + "/single";

            return uriBuilder.Uri;
        }

        public Uri GetQlikSenseRootUri()
        {
            var uriBuilder = new UriBuilder(LocationUri);
            uriBuilder.Path = VirtualProxy;

            return uriBuilder.Uri;
        }

    }
}
