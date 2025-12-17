using Zhaoxi.Zhihu.Core.AppUserAggregate.Entites;
using Zhaoxi.Zhihu.UseCases.AppUsers.Commands;

namespace Zhaoxi.Zhihu.UseCases.AppUsers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AppUser, CreatedAppUserDto>();
    }
}