using System;

namespace SqlKataStudy.Models
{
    public class Career
    {
        public Career()
        { }

        public Career(string title, string summary, string url, int durationInMinutes, bool active, bool featured, string tags)
        {
            CareerId = Guid.NewGuid();
            Title = title;
            Summary = summary;
            Url = url;
            DurationInMinutes = durationInMinutes;
            Active = active;
            Featured = featured;
            Tags = tags;
        }

        public Guid CareerId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }
        public int DurationInMinutes { get; set; }
        public bool Active { get; set; }
        public bool Featured { get; set; }
        public string Tags { get; set; }
    }
}