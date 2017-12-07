using AutoMapper;
using Business.ViewModels;
using Entity;

namespace Business
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            CreateMap<Book, BookModel>();
            CreateMap<BookModel, Book>()
                .ForMember(dest => dest.Author, opt => opt.Ignore());

            CreateMap<Author, AuthorModel>()
                .ReverseMap();
        }

        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookModel>();
                cfg.CreateMap<BookModel, Book>()
                    .ForMember(dest => dest.Author, opt => opt.Ignore());

                cfg.CreateMap<Author, AuthorModel>()
                .ReverseMap();
            });

            return config.CreateMapper();
        }
    }

    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<EntityMapper>();
            });
        }
    }
}
