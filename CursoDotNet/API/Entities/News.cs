using API.Entities.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Entities
{
    public class News : BaseEntity
    {
        [BsonElement("hat")]
        public string Hat { get; private set; }

        [BsonElement("title")]
        public string Title { get; private set; }

        [BsonElement("text")]
        public string Text { get; private set; }

        [BsonElement("author")]
        public string Author { get; private set; }

        [BsonElement("img")]
        public string Img { get; private set; }

        [BsonElement("link")]
        public string Link { get; private set; }

        [BsonElement("publishDate")]
        public DateTime PublishDate { get; private set; }

        [BsonElement("status")]
        public Status Status { get; private set; }

        public News(string hat, string title, string text, string author, string img, string link, Status active)
        {
            Hat = hat;
            Title = title;
            Text = text;
            Author = author;
            Img = img;
            Link = link;
            PublishDate = DateTime.Now;
            Status = ChangeStatus(active);
        }

        public News(string id, string hat, string title, string text, string author, string img, string link, Status active) : this(hat, title, text, author, img, link, active)
        {
            Id = id;
        }

        private Status ChangeStatus(Status status)
        {
            switch (status)
            {
                case Status.Active:
                    status = Status.Active;
                    break;
                case Status.Inactive:
                    status = Status.Inactive;
                    break;
                case Status.Draft:
                    status = Status.Draft;
                    break;
            }

            return status;
        }
    }
}
