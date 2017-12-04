using AutoMapper;
using Business.ViewModels;
using Entity;

namespace Business
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            CreateMap<Book, BookModel>()
                .ForMember(dest => dest.Author, map => map.MapFrom(src => src.Author.Name));

            CreateMap<BookModel, Book>()
                .ForMember(dest => dest.Author, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    dest.Author = new Author() { Name = src.Author };
                });
        }

        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookModel>()
                    .ForMember(dest => dest.Author, map => map.MapFrom(src => src.Author.Name));
                cfg.CreateMap<BookModel, Book>()
                    .ForMember(dest => dest.Author, opt => opt.Ignore())
                    .AfterMap((src, dest) =>
                    {
                        dest.Author = new Author() { Name = src.Author };
                    });
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

            //Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
