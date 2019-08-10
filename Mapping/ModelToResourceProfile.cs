using AutoMapper;
using HelloAspNet.Domain.Models;
using HelloAspNet.Resources;

namespace HelloAspNet.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
        }
    }
}