using API.Entities;
using API.Entities.ViewModels;
using AutoMapper;

namespace API.Mappers
{
    public class ViewModelToEntityMapping : Profile
    {
        public ViewModelToEntityMapping()
        {
            CreateMap<NewsViewModel, News>().ConstructUsing(x => new News(x.Id, x.Hat, x.Title, x.Text, x.Author, x.Img, x.Link, x.Status));
        }
    }
}
