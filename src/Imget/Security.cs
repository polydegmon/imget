using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imget
{
    /// <summary>
    /// OAuth2 terminology.
    ///     Resource.Some piece of data that can be protected.
    ///     Resource server.The server that hosts the resource.
    ///     Resource owner. The entity that can grant permission to access a resource. (Typically the user.)
    ///     Client: The app that wants access to the resource.In this article, the client is a web browser.
    ///     Access token. A token that grants access to a resource.
    ///     Bearer token. A particular type of access token, with the property that anyone can use the token. 
    ///                     In other words, a client doesn’t need a cryptographic key or other secret to use a bearer token. 
    ///                     For that reason, bearer tokens should only be used over a HTTPS, and should have relatively short 
    ///                     expiration times. Authorization server. A server that gives out access tokens.
    ///                     
    /// HTTP Message Handlers for Authentication
    ///     Instead of using the host for authentication, you can put authentication logic into an HTTP message handler.In that case, 
    ///     the message handler examines the HTTP request and sets the principal.
    /// 
    /// 
    ///     When should you use message handlers for authentication? Here are some tradeoffs:
    /// 
    ///     An HTTP module sees all requests that go through the ASP.NET pipeline. A message handler only sees requests that are 
    ///     routed to Web API.
    ///     You can set per-route message handlers, which lets you apply an authentication scheme to a specific route.
    ///     HTTP modules are specific to IIS. Message handlers are host-agnostic, so they can be used with both web-hosting and 
    ///     self-hosting.
    ///     HTTP modules participate in IIS logging, auditing, and so on.
    ///     HTTP modules run earlier in the pipeline. If you handle authentication in a message handler, the principal does not 
    ///     get set until the handler runs. Moreover, the principal reverts back to the previous principal when the response 
    ///     leaves the message handler.
    ///     Generally, if you don't need to support self-hosting, an HTTP module is a better option. If you need to support 
    ///     self-hosting, consider a message handler.
    /// ************************************************************************************************
    /// 
    /// 
    /// In the WebApiConfig.Register method, the following code sets up authentication for the Web API pipeline:
    ///     config.SuppressDefaultHostAuthentication();
    ///     config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
    ///     
    ///     The HostAuthenticationFilter class enables authentication using bearer tokens. The SuppressDefaultHostAuthentication 
    ///     method tells Web API to ignore any authentication that happens before the request reaches the Web API pipeline, either 
    ///     by IIS or by OWIN middleware.That way, we can restrict Web API to authenticate only using bearer tokens.
    ///     
    /// 
    /// </summary>
    /// 
    public class Security
    {
        //private void SetPrincipal(IPrincipal principal)
        //{
        //    Thread.CurrentPrincipal = principal;
        //    if (HttpContext.Current != null)
        //    {
        //        HttpContext.Current.User = principal;
        //    }
        //}
    }
}
