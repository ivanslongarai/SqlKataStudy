using System;
using SqlKataStudy.Models.Enums;

namespace SqlKataStudy.Models
{
    public class Author
    {
        public Author()
        {
        }

        public Author(string name, string title, string image, string bio, string url, string email, EAuthorType type)
        {
            AuthorId = Guid.NewGuid();
            Name = name;
            Title = title;
            Image = image;
            Bio = bio;
            Url = url;
            Email = email;
            Type = type;
        }

        public Guid AuthorId { get; private set; }
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Image { get; private set; }
        public string Bio { get; private set; }
        public string Url { get; private set; }
        public string Email { get; private set; }
        public EAuthorType Type { get; private set; }
    }
}