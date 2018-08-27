using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using System.Runtime.InteropServices;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(SocialNetwork.Web.Startup))]

namespace SocialNetwork.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId= "socialnetwork_implicit",
                Authority= "http://localhost:3863/",
                RedirectUri= "http://localhost:14069/",
                ResponseType="token id_token",
                Scope="openid profile",
                SignInAsAuthenticationType =DefaultAuthenticationTypes.ApplicationCookie
            });

        }
    }
}
