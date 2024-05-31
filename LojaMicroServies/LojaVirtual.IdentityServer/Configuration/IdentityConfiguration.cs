using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System.Collections.Specialized;

namespace LojaVirtual.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const String Admin = "Admin";
        public const String Client = "Client";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("lojavirtual","LojaVirtual Server"),
                new ApiScope(name: "read","Read data."),
                new ApiScope(name: "write","Write data."),
                new ApiScope(name: "delete","Delete data."),
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("chaves_chaves_chaves".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read", "write", "profile"}
                },
                new Client
                {
                    ClientId = "lojavirtual",
                    ClientSecrets = { new Secret("chaves_chaves_chaves".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"https://localhost:4430/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:4430/signout-callback-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "lojavirtual"
                    }
                }
            };
    }
}
