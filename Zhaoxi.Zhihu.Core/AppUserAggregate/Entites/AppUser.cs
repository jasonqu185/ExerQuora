using Zhaoxi.Zhihu.Core.AppUserAggregate.Events;
using Zhaoxi.Zhihu.Core.Common;
using Zhaoxi.Zhihu.SharedKernel.Domain;
using Zhaoxi.Zhihu.SharedKernel.Result;

namespace Zhaoxi.Zhihu.Core.AppUserAggregate.Entites;

public class AppUser : BaseAuditEntity, IAggregateRoot
{
    protected AppUser()
    {
    }

    public AppUser(int userId)
    {
        Id = userId;
    }

    public string? Nickname { get; set; }

    public string? Avatar { get; set; }

    public string? Bio { get; set; }


    /// <summary>
    ///     关注列表
    /// </summary>
    public ICollection<FollowUser> Followees { get; set; } = new List<FollowUser>();

    /// <summary>
    ///     粉丝列表
    /// </summary>
    public ICollection<FollowUser> Followers { get; set; } = new List<FollowUser>();

    /// <summary>
    ///     关注问题列表
    /// </summary>
    private readonly List<FollowQuestion> _followQuestions = [];

    public IEnumerable<FollowQuestion> FollowQuestions => _followQuestions;

    /// <summary>
    ///     添加关注问题
    /// </summary>
    /// <param name="questionId"></param>
    /// <returns></returns>
    public IResult AddFollowQuestion(int questionId)
    {
        if (FollowQuestions.Any(fq => fq.QuestionId == questionId)) return Result.Invalid("问题已关注");

        var followQuestion = new FollowQuestion
        {
            UserId = Id,
            QuestionId = questionId,
            FollowDate = DateTimeOffset.Now
        };

        _followQuestions.Add(followQuestion);

        AddDomainEvent(new FollowQuestionAddedEvent(followQuestion));

        return Result.Success();
    }

    /// <summary>
    ///     移除关注问题
    /// </summary>
    /// <param name="questionId"></param>
    public void RemoveFollowQuestion(int questionId)
    {
        var followQuestion = FollowQuestions.FirstOrDefault(fq => fq.QuestionId == questionId);
        if (followQuestion == null) return;

        _followQuestions.Remove(followQuestion);

        AddDomainEvent(new FollowQuestionRemovedEvent(followQuestion));
    }
}
