using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Nop.Core.Domain.Customers;
using Nop.Core.Infrastructure;
using Nop.Services.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Other.Client.OAuth.Providers
{
    public class AuthorisationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var customerRegistrationService = EngineContext.Current.Resolve<CustomerRegistrationService>();

            var loginResult =
                   customerRegistrationService.ValidateCustomer(context.UserName, context.Password);

            switch (loginResult)
                {
                    case CustomerLoginResults.Successful:
                    {
                        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                        identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                        identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                        identity.AddClaim(new Claim("sub", context.UserName));

                        var props = new AuthenticationProperties(new Dictionary<string, string>
                                {
                                    {
                                        "as:client_id", context.ClientId ?? string.Empty
                                    },
                                    {
                                        "userName", context.UserName
                                    }
                                });

                         var ticket = new AuthenticationTicket(identity, props);
                         context.Validated(ticket);
                    }
                    break;
                    case CustomerLoginResults.CustomerNotExist:
                    case CustomerLoginResults.Deleted:
                    case CustomerLoginResults.NotActive:
                    case CustomerLoginResults.NotRegistered:
                    case CustomerLoginResults.LockedOut:
                    case CustomerLoginResults.WrongPassword:
                    default:
                        context.SetError("invalid_grant", "The user name or password is incorrect.");
                    break;
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            // Change auth ticket for refresh token requests
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

            var newClaim = newIdentity.Claims.Where(c => c.Type == "newClaim").FirstOrDefault();
            if (newClaim != null)
            {
                newIdentity.RemoveClaim(newClaim);
            }
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }
    }
}
