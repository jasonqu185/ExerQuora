using Zhaoxi.Zhihu.Core.AppUserAggregate.Entites;
using Zhaoxi.Zhihu.SharedKernel.Repository;

namespace Zhaoxi.Zhihu.UseCases.AppUsers.Commands;

public record CreatedAppUserDto(int Id, string Nickname);
public record CreateAppUserCommand(int UserId) : ICommand<Result<CreatedAppUserDto>>;

public class CreateAppUserCommandHandler(
    IRepository<AppUser> userRepo,
    IMapper mapper) : ICommandHandler<CreateAppUserCommand, Result<CreatedAppUserDto>>
{
    public async Task<Result<CreatedAppUserDto>> Handle(CreateAppUserCommand command, CancellationToken cancellationToken)
    {
        var user = userRepo.Add(new AppUser(command.UserId)
        {
            Nickname = $"新用户{command.UserId}"
        });

        await userRepo.SaveChangesAsync(cancellationToken);

        return Result.Success(mapper.Map<CreatedAppUserDto>(user));
    }
}