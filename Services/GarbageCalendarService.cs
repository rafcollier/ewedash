using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System.Threading.Tasks;

namespace EweDash.Services
{
    public class GarbageCalendarService
    {
        public Events getGarbageCalendar(string applicationName, UserCredential googCalCred)
        {
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = googCalCred,
                ApplicationName = applicationName,
            });

            EventsResource.ListRequest request = service.Events.List("4b684foji94ra5r93sjs5s7emb1q151r@import.calendar.google.com");
            request.TimeMin = DateTime.Today.Date;
            //request.TimeMax = DateTime.Today.Date.AddDays(2).AddSeconds(-1);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 1;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            Events events = request.Execute();
            return events;
        }
    }
}
