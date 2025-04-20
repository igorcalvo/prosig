using AutoMapper;
using Blog.API.DTOs;
using Blog.Domain.Models;

namespace Blog.API.Mappings
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentDTO, Comment>();

            CreateMap<Comment, CommentDTO>()
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId));
        }
    }
}
