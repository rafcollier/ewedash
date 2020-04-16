using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

namespace EweDash.Services
{
    public class GoogleCalendarService
    {
        public UserCredential getGoogleCalCred()
        {
            string[] Scopes = { CalendarService.Scope.CalendarReadonly };
            UserCredential credential;

            using (var stream = new FileStream("credentialsGoogleCalendar.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "tokenGoogleCalendar.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            return credential;

        }

        public Events getCalendarData(string applicationName, UserCredential googCalCred)
        {
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = googCalCred,
                ApplicationName = applicationName,
            });

            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Today.Date;
            request.TimeMax = DateTime.Today.Date.AddDays(1).AddSeconds(-1);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 3;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            Events events = request.Execute();
            return events;
        }
    }
}
