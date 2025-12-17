using Zhaoxi.Zhihu.Core.AppUserAggregate.Entites;
using Zhaoxi.Zhihu.Core.AppUserAggregate.Specifications;

namespace Zhaoxi.Zhihu.UseCases.AppUsers.Commands;

[Authorize]
public record DeleteFollowQuestionCommand(int QuestionId) : ICommand<IResult>;

public class RemoveFollowQuestionCommandHanlder(
    IRepository<AppUser> userRepo,
    IUser user) : ICommandHandler<DeleteFollowQuestionCommand, IResult>
{
    public async Task<IResult> Handle(DeleteFollowQuestionCommand request, CancellationToken cancellationToken)
    {
        var spec = new FollowQuestionByIdSpec(user.Id!.Value, request.QuestionId);
        var appuser = await userRepo.GetSingleOrDefaultAsync(spec, cancellationToken);
        if (appuser == null) return Result.NotFound("用户不存在");

        appuser.RemoveFollowQuestion(request.QuestionId);

        await userRepo.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
