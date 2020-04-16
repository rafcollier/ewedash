using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

namespace EweDash.Services
{
    public class RaptorsService
    {
        public Events getRaptorsCalendar(string applicationName, UserCredential googCalCred)
        {
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = googCalCred,
                ApplicationName = applicationName,
            });

            EventsResource.ListRequest request = service.Events.List("nba_28_%54oronto+%52aptors#sports@group.v.calendar.google.com");
            request.TimeMin = DateTime.Today.Date.AddDays(-30);
            //request.TimeMin = DateTime.Today.Date;
            //request.TimeMax = DateTime.Today.Date.AddDays(1).AddSeconds(-1);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            Events events = request.Execute();
            return events;
        }
    }
}
