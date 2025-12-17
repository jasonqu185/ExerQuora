namespace Zhaoxi.Zhihu.UseCases.AppUsers.Queries;

[Authorize]
public record GetUserInfo(int Id) : IQuery<Result<UserInfoDto>>;

public class GetUserInfoQueryHandler
    (IDataQueryService queryService) : IQueryHandler<GetUserInfo, Result<UserInfoDto>>
{
    public async Task<Result<UserInfoDto>> Handle(GetUserInfo request, CancellationToken cancellationToken)
    {
        var queryable = queryService.AppUsers
            .Where(u => u.Id == request.Id)
            .Select(u => new UserInfoDto
            {
                Id = u.Id,
                Nickname = u.Nickname,
                Avatar = u.Avatar,
                Bio = u.Bio,
                FolloweesCount = u.Followees.Count,
                FollowersCount = u.Followers.Count
            });

        var appUserInfo = await queryService.FirstOrDefaultAsync(queryable);

        return appUserInfo is null ? Result.NotFound() : Result.Success(appUserInfo);
    }
}