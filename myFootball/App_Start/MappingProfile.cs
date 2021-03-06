﻿using AutoMapper;
using myFootball.Dtos;
using myFootball.Models;
using myFootball.ViewModels;
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
            Mapper.CreateMap<TestResultForPlayer, TestResultForPlayerDto>();


            //Groups
            Mapper.CreateMap<Group, GroupDto>();
            Mapper.CreateMap<ViewGroupIndex, GroupIndexDto>();
            Mapper.CreateMap<GroupDto, Group>();
            Mapper.CreateMap<GroupIndexDto, ViewGroupIndex>();



            //Dto to domain
            Mapper.CreateMap<TestDto, Test>()
                .ForMember(t => t.Id, opt => opt.Ignore());

            Mapper.CreateMap<TestResultForPlayerDto, TestResultForPlayer>();

        }
    }
}