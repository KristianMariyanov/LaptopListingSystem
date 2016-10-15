namespace LaptopListingSystem.Web.Areas.Administration.ViewModels.Comments
{
    using System;

    using AutoMapper;

    using LaptopListingSystem.Data.Models;
    using LaptopListingSystem.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public int LaptopId { get; set; }

        public string LaptopModel { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(e => e.User.UserName));
        }
    }
}
