﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JumpLineUp.Dtos;
using JumpLineUp.Models;

namespace JumpLineUp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CfsWorker, CfsWorkerDto>();
            Mapper.CreateMap<CfsWorkerDto, CfsWorker>();

            Mapper.CreateMap<FosterParent, FosterParentDto>();
            Mapper.CreateMap<FosterParentDto, FosterParent>();

            Mapper.CreateMap<GuardiansDto, Guardian>();
            Mapper.CreateMap<Guardian, GuardiansDto>();

            Mapper.CreateMap<YouthDto, Youth>();
            Mapper.CreateMap<Youth, YouthDto>();

            Mapper.CreateMap<BlcsOfficeDto, BlcsOffice>();
            Mapper.CreateMap<BlcsOffice, BlcsOfficeDto>();


        }
    }
}