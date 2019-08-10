using AutoMapper;
using HelloAspNet.Domain.Models;
using HelloAspNet.Resources;

namespace HelloAspNet.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
        }
    }
}