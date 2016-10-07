namespace LaptopListingSystem.Web.ViewModels.Comments
{
    using AutoMapper;

    using LaptopListingSystem.Data.Models;

    using Suls.Common.Mapping;
    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string Author { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(e => e.User.UserName));
        }
    }
}
