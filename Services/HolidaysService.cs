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
    public class HolidaysService
    {
        public Events getHolidaysCalendar(string applicationName, UserCredential googCalCred)
        {
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = googCalCred,
                ApplicationName = applicationName,
            });

            EventsResource.ListRequest request = service.Events.List("nt35marqs4qsfsrd49l612ac7tsifpik@import.calendar.google.com");
            request.TimeMin = DateTime.Today.Date;
            //request.TimeMax = DateTime.Today.Date.AddDays(30).AddSeconds(-1);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 1;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            Events events = request.Execute();
            return events;

        }
    }
}
