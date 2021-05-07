// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("api1", "Frands API") // If you will be using this in production it is important to give your API a logical name. Developers will be using this to connect to your api though your Identity server. It should describe your api in simple terms to both developers and users.
            };

        public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "client", // You can think of the ClientId and the ClientSecret as the login and password for your application itself

                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                // secret for authentication
                ClientSecrets =
                {
                    new Secret("secret".Sha256()) // This secret should be stored a better place
                },

                // scopes that client has access to
                AllowedScopes = { "api1" }
            }
        };
    }
}