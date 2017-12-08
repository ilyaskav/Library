using AutoMapper;
using Business.ViewModels;
using Entity;
using System.Linq;

namespace Business
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            CreateMap<Book, BookModel>();
            CreateMap<BookModel, Book>()
                .ForMember(dest => dest.Author, opt => opt.Ignore())
                .AfterMap((dest, src) => AddOrUpdateAuthor(dest, src));

            CreateMap<Author, AuthorModel>().ReverseMap();
        }

        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookModel>();
                cfg.CreateMap<BookModel, Book>()
                    .ForMember(dest => dest.Author, opt => opt.Ignore())
                    .AfterMap((dest, src) => AddOrUpdateAuthor(dest, src));

                cfg.CreateMap<Author, AuthorModel>()
                .ReverseMap();
            });

            return config.CreateMapper();
        }

        private static void AddOrUpdateAuthor(BookModel model, Book book)
        {
            if (model.Author == null || model.Author.Id == 0)
            {
                book.Author = Mapper.Map<Author>(model.Author);
            }
            else
            {
                Mapper.Map(model.Author, book.Author);
            }
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
