using AutoMapper;
using Blog.API.DTOs;
using Blog.Domain.Models;

namespace Blog.API.Mappings
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostDTO, Post>();

            CreateMap<Post, PostDTO>()
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
        }
    }
}
