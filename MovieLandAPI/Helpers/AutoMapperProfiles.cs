using AutoMapper;
using MovieLandAPI.DTOs;
using MovieLandAPI.Models;

namespace MovieLandAPI.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            // Genders
            CreateMap<Gender, GenderDTO>().ReverseMap();
            CreateMap<CreationGenderDTO, Gender>();
        }
    }
}
