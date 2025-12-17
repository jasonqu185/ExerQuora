using MediatR;
using Zhaoxi.Zhihu.Core.AppUserAggregate.Events;
using Zhaoxi.Zhihu.Core.QuestionAggregate.Entites;
using Zhaoxi.Zhihu.SharedKernel.Repository;

namespace Zhaoxi.Zhihu.Core.QuestionAggregate.Handlers;

internal class FollowQuestionAddedEventHandler(IRepository<Question> questions)
    : INotificationHandler<FollowQuestionAddedEvent>
{
    public async Task Handle(FollowQuestionAddedEvent notification, CancellationToken cancellationToken)
    {
        var question = await questions.GetByIdAsync(notification.FollowQuestion.QuestionId, cancellationToken);
        if (question == null) return;

        question.FollowerCount += 1;

        await questions.SaveChangesAsync(cancellationToken);
    }
}