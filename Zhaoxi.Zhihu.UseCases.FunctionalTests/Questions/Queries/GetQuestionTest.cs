using FluentAssertions;
using Zhaoxi.Zhihu.SharedKernel.Result;
using Zhaoxi.Zhihu.UseCases.Questions.Queries;

namespace Zhaoxi.Zhihu.UseCases.FunctionalTests.Questions.Queries;

public class GetQuestionTest(IServiceProvider serviceProvider) : TestBase(serviceProvider)
{
    [Fact]
    public async Task ShouldSuccess()
    {
        var result = await Sender.Send(new GetQuestionQuery(1));
        result.Value.Should().NotBeNull();
        result.Status.Should().Be(ResultStatus.Ok);
    }

    [Fact]
    public async Task ShouldQuestionNoExists()
    {
        var result = await Sender.Send(new GetQuestionQuery(99));
        result.Status.Should().Be(ResultStatus.NotFound);
        result.Errors.Should().Contain("问题不存在");
    }
}
    [Fact]
    public async Task ShouldReturnCorrectFields()
    {
        var result = await Sender.Send(new GetQuestionQuery(1));
        result.Status.Should().Be(ResultStatus.Ok);

        var q = result.Value!;
        q.Id.Should().Be(1);
        q.Title.Should().NotBeNullOrWhiteSpace();
        q.Description.Should().NotBeNull();
        q.AnswerCount.Should().BeGreaterOrEqualTo(0);
        q.FollowerCount.Should().BeGreaterOrEqualTo(0);
        q.ViewCount.Should().BeGreaterOrEqualTo(0);
    }
