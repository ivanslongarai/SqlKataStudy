using System;
using SqlKataStudy.Models.Enums;

namespace SqlKataStudy.Models
{

    public class Course
    {
        public Course()
        {
        }

        public Course(string title, string tag, string summary, string url, ECourseLevel level, int durationInMinutes, DateTime createDate, DateTime lastUpdateDate, bool active, bool free, bool featured, Guid authorId, Guid categoryId, string tags)
        {
            CourseId = Guid.NewGuid();
            Title = title;
            Tag = tag;
            Summary = summary;
            Url = url;
            Level = level;
            DurationInMinutes = durationInMinutes;
            CreateDate = createDate;
            LastUpdateDate = lastUpdateDate;
            Active = active;
            Free = free;
            Featured = featured;
            AuthorId = authorId;
            CategoryId = categoryId;
            Tags = tags;
        }
        public Guid CourseId { get; private set; }
        public string Title { get; private set; }
        public string Tag { get; private set; }
        public string Summary { get; private set; }
        public string Url { get; private set; }
        public ECourseLevel Level { get; private set; }
        public int DurationInMinutes { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public bool Active { get; private set; }
        public bool Free { get; private set; }
        public bool Featured { get; private set; }
        public Guid AuthorId { get; private set; }
        public Guid CategoryId { get; private set; }
        public string Tags { get; private set; }

    }

}