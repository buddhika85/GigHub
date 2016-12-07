using AutoMapper;
using GigHub.Models;
using GigHub.ViewModels;

namespace GigHub.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain model to view model
            Mapper.CreateMap<Gig, GigFormViewModel>();
            //Mapper.CreateMap<Movie, MovieDto>();
            //Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            //Mapper.CreateMap<Genre, GenreDto>();


            // View model to the domain model
            Mapper.CreateMap<GigFormViewModel, Gig>();

            //Mapper.CreateMap<MovieDto, Movie>()
            //    .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}