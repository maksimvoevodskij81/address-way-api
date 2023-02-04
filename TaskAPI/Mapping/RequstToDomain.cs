﻿using AutoMapper;
using BackendData.DomainModel;
using TaskAPI.Contracts.V1.Requests.Query;

namespace TaskAPI.Mapping
{
    public class RequstToDomain : Profile
    {
        public RequstToDomain() 
        {
            CreateMap<PaginationQuery, PaginationFilter>();
        }
    }
}
