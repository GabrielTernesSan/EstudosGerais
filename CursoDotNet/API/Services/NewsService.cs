using API.Entities;
using API.Entities.ViewModels;
using API.Infra;
using AutoMapper;

namespace API.Services
{
    public class NewsService
    {
        private readonly IMapper _mapper;
        private readonly IMongoRepository<News> _mongoRepository;

        public NewsService(IMapper mapper, IMongoRepository<News> mongoRepository)
        {
            _mapper = mapper;
            _mongoRepository = mongoRepository;
        }

        public List<NewsViewModel> Get() =>
            _mapper.Map<List<NewsViewModel>>(_mongoRepository.Get().ToList());


        public NewsViewModel Get(string id) =>
           _mapper.Map<NewsViewModel>(_mongoRepository.Get(id));


        public NewsViewModel Create(NewsViewModel news)
        {
            var entity = new News(news.Hat, news.Title, news.Text, news.Author, news.Img, news.Link, news.Status);
            _mongoRepository.Create(entity);

            return Get(entity.Id);
        }

        public void Update(string id, NewsViewModel request)
        {
            var entity = new News(id, request.Hat, request.Title, request.Text, request.Author, request.Img, request.Link, request.Status);
            _mongoRepository.Update(id, _mapper.Map<News>(entity));
        }

        public void Remove(string id) => _mongoRepository.Remove(id);

    }
}
