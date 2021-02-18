using System;

namespace Sakura.EmailContact.Features.Campaigns.Dtos
{
    public class AddEventDto
    {
        public DateTime Date { get; set; }
    }

    public class EventDto
    {
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
    }
}
