﻿using AutoMapper;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.BusinessLogicLayer.Configurations
{
    public class AutoMapperProfile : Profile
    {
        private void CreateUserMaps()
        {
            CreateMap<UserSignUpRequest, User>();
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>().ForMember(
                response => response.FullName,
                options => options.MapFrom(team => $"{team.FirstName} {team.LastName}"));
        }

        private void CreateTicketsMaps()
        {
            CreateMap<TicketRequest, Ticket>();
            CreateMap<Ticket, TicketResponse>();
        }

        private void CreateTeamsMaps()
        {
            CreateMap<TeamRequest, Team>();
            CreateMap<Team, TeamResponse>();
        }

        private void CreateProjectsMaps()
        {
            CreateMap<ProjectRequest, Project>();
            CreateMap<Project, ProjectResponse>();
        }

        private void CreateRatingsMaps()
        {
            CreateMap<RatingRequest, Rating>();
            CreateMap<Rating, RatingResponse>();
        }

        public AutoMapperProfile()
        {
            CreateUserMaps();
            CreateTicketsMaps();
            CreateTeamsMaps();
            CreateProjectsMaps();
            CreateRatingsMaps();
        }
    }
}
