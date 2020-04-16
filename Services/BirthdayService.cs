using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

namespace EweDash.Services
{
    public class BirthdayService
    {
        public Events getBirthdaysCalendar(string applicationName, UserCredential googCalCred)
        {
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = googCalCred,
                ApplicationName = applicationName,
            });

            EventsResource.ListRequest request = service.Events.List("addressbook#contacts@group.v.calendar.google.com");
            request.TimeMin = DateTime.Today.Date;
           // request.TimeMax = DateTime.Today.Date.AddDays(14).AddSeconds(-1);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 3;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            Events events = request.Execute();
            return events;

        }
    }
}
