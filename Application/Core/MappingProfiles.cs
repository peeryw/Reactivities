using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // profiles
            // where do we want to go from
            // where do we want to go to
            // looks at Activity Class inorder to match feilds
            CreateMap<Activity, Activity>();
        }
    }
}