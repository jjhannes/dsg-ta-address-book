using AddressBook.Api.Models;
using AddressBook.Data;
using AddressBook.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Areas.Mvc.Sessions
{
    public class UserSession
    {
        private static readonly string _sessionKey = "UserSession";

        public Guid Id { get; private set; }

        public string Email { get; private set; }

        public string Token { get; private set; }

        public bool LogedIn { get; private set; } = false;

        private UserSession()
        {
            Guid sessionGuid = Guid.NewGuid();

            this.Id = sessionGuid;
        }

        private UserSession(string sessionString)
        {
            dynamic sessionObject = JsonConvert.DeserializeObject(sessionString);

            Guid sessionGuid = new Guid(sessionObject.Id.ToString());

            this.Id = sessionGuid;

            if (sessionObject.Email != null && sessionObject.Token != null)
            {
                this.Email = sessionObject.Email;
                this.Token = sessionObject.Token;
                this.LogedIn = true;
            }
        }

        private UserSession(string sessionString, User user, TokenModel token)
        {
            dynamic sessionObject = JsonConvert.DeserializeObject(sessionString);

            Guid sessionGuid = new Guid(sessionObject.Id.ToString());

            this.Id = sessionGuid;
            this.Email = user.Username;
            this.Token = token.AccessToken;
            this.LogedIn = true;
        }

        public static UserSession GetSession(ISession appSession)
        {
            string userSessionString = appSession.GetString(UserSession._sessionKey);

            UserSession userSession;

            if (string.IsNullOrWhiteSpace(userSessionString))
                userSession = new UserSession();

            else
                userSession = new UserSession(userSessionString);

            appSession.SetString(UserSession._sessionKey, JsonConvert.SerializeObject(userSession));

            return userSession;
        }

        public static UserSession CreateAuthenticatedSession(ISession appSession, User user, TokenModel token)
        {
            string userSessionString = appSession.GetString(UserSession._sessionKey);

            UserSession userSession = new UserSession(userSessionString, user, token);

            appSession.SetString(UserSession._sessionKey, JsonConvert.SerializeObject(userSession));

            return userSession;
        }
    }

    // Test
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseCustomSession(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
