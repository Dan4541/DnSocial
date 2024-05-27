using AutoMapper;
using Dn.Domain.Aggregates.UserProfileAggregate;
using DnSocial.Application.UserProfiles.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnSocial.Application.MappingProfiles
{
    internal class UserProfileMap : Profile
    {
        public UserProfileMap() 
        {
            CreateMap<CreateUserCommand, BasicInfo>();
        }
    }
}
