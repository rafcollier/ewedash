using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using System.Collections.Generic;


namespace EweDash.Services
{
    public class GoogleMailService
    {
        string[] Scopes = { GmailService.Scope.GmailReadonly };
        UserCredential credential;

        public UserCredential getGmailCred()
        {
            using (var stream = new FileStream("credentialsGmail.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "tokenGmail.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            return credential;

        }

        public int getGmailData(string applicationName, UserCredential googGmailCred)
        {
            var messageCount = 0;

            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = googGmailCred,
                ApplicationName = applicationName
            });

            UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List("me");
            request.MaxResults = 100;
            request.Q = "category:primary is:unread newer_than:1d";

            IList<Message> messages = request.Execute().Messages;

            if (messages != null && messages.Count > 0)
            {
                messageCount = messages.Count;
            }

            return messageCount;

        }
    }
}
