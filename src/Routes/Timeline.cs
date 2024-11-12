using LilyFNServer.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LilyFNServer.Routes
{
    public class Timeline
    {
        struct Event
        {
            public Event(string eventType, string activeUntil, string activeSince)
            {
                this.eventTpye = eventType;
                this.activeUntil = activeUntil;
                this.activeSince = activeSince;
            }

            public string eventTpye;
            public string activeUntil;
            public string activeSince;
        }

        [ApiController]
        [Route("[controller]")]
        public class TimelineController : ControllerBase
        {
            [HttpGet]
            public IActionResult Get()
            {
                return Ok("hello");
            }
        }

        public static void SetupTimelineRoutes()
        {
            LilyFNServer.app.MapGet("/fortnite/api/calendar/v1/timeline", (HttpRequest request, HttpResponse response) =>
            {
                FortniteVersionInfo info = Functions.GetVersionInfo(request);

                Event[] activeEvents = [
                    new Event(
                        string.Format("EventFlag.Season{0}", info.season),
                        "9999-01-01T00:00:00.000Z",
                        "2020-01-01T00:00:00.000Z"),
                    new Event(
                         string.Format("EventFlag.{0}", info.lobby),
                         "9999-01-01T00:00:00.000Z",
                         "2020-01-01T00:00:00.000Z")
                ];

                string jsonOutput = string.Format(@"
                    {
                        'channels': 
                    }
                ");
            });
        }
    }
}
