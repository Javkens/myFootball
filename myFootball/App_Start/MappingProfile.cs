using AutoMapper;
using myFootball.Dtos;
using myFootball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFootball.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //domain to dto
            Mapper.CreateMap<Player, PlayerDto>();
            Mapper.CreateMap<Group, GroupDto>();
            Mapper.CreateMap<Test, TestDto>();

            //Dto to domain
            Mapper.CreateMap<TestDto, Test>()
                .ForMember(t => t.Id, opt => opt.Ignore());

        }
    }
}