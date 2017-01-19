using System;
namespace QlikSense
{
    public interface ILocation
    {
        Uri GetIframeBaseUri();
        Uri GetProxyRestUri();
        Uri GetTicketEndpointUri();
        Uri GetQlikSenseRootUri();

        string UserDirectory { get; set; }
        string UserId { get; set; }
        string VirtualProxy { get; set; }
    }
}
