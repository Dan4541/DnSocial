using Dn.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnSocial.Application.UserProfiles.Queries
{
    public class GetAllUserProfiles : IRequest<IEnumerable<UserProfile>>
    {

    }
}
