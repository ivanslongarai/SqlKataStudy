using System;

namespace SqlKataStudy.Models
{
    public class CareerItem
    {
        public CareerItem()
        {
        }

        public CareerItem(string title, string description, int order, Guid courseId, Guid careerId)
        {
            Title = title;
            Description = description;
            Order = order;
            CourseId = courseId;
            CareerId = careerId;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Order { get; private set; }
        public Guid CourseId { get; private set; }
        public Guid CareerId { get; private set; }

    }
}