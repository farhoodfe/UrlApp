using AutoMapper;
using UrlApp.Service.Dtos;
using UrlApp.WebAPI.Models;

namespace UrlApp.WebAPI
{
    public class UrlProfile : Profile
    {
        public UrlProfile()
        {
            CreateMap<UrlModel, UrlDto>();
            CreateMap<UrlDto, UrlModel>();
        }
    }
}
