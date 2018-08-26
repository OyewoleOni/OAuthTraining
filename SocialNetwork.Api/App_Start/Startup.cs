using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.IdentityModel.Tokens;
using Autofac;
using Autofac.Integration.WebApi;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Jwt;
using SocialNetwork.Api.Autofac.Modules;
//using Microsoft.Owin.Security.Jwt;
//using Microsoft.IdentityModel.Tokens;

[assembly: OwinStartup(typeof(SocialNetwork.Api.Startup))]
namespace SocialNetwork.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = GlobalConfiguration.Configuration;

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<SocialNetworkModule>();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            //{
            //    AllowedAudiences= new[] { "http://localhost:3863/resources" },
            //    TokenValidationParameters = new TokenValidationParameters
            //    {

            //    }
            //});

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServer3.AccessTokenValidation.IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:3863/"
            });
                
            

           
            app.UseWebApi(config);
        }
    }
}
