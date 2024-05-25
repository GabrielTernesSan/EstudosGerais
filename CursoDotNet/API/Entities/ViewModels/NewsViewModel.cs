using API.Entities.Enums;

namespace API.Entities.ViewModels
{
    public class NewsViewModel
    {
        public string Id { get; set; } = null!;
        public string Hat { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Img { get; set; } = null!;
        public string Link { get; set; } = null!;
        public Status Status { get; set; }
    }
}
