using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace SocialNetwork.OAuth
{
    public class InMemoryManager
    {
        public List<InMemoryUser> GetUsers()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject="onioyewole1910@gmail.com",
                    Username="onioyewole1910@gmail.com",
                    Password="password",
                    Claims = new []
                    {
                        new Claim(Constants.ClaimTypes.Name,"Oyewole Oni")
                    }
                }
            };
        }

        public IEnumerable<Scope> GetScopes()
        {
            return new[]
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.OfflineAccess,
                new Scope
                {
                    Name="read",
                    DisplayName="Read User Data"
                }
            };

        }

        public IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId="socialnetwork",
                    ClientSecrets= new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientName="SocialNetwork",
                    Flow=Flows.ResourceOwner,
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        "read",
                    },
                    Enabled=true
                    
                }
            };
        }
    }
}