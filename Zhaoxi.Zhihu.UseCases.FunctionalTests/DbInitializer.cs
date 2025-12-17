using Bogus;
using Microsoft.EntityFrameworkCore;
using Zhaoxi.Zhihu.Core.AppUserAggregate.Entites;
using Zhaoxi.Zhihu.Core.QuestionAggregate.Entites;
using Zhaoxi.Zhihu.Infrastructure.Data;
using Zhaoxi.Zhihu.UseCases.Common.Interfaces;

namespace Zhaoxi.Zhihu.UseCases.FunctionalTests;

public class DbInitializer(AppDbContext dbContext, IUser user) : IDisposable
{
    public void Dispose()
    {
        dbContext.Database.CloseConnection();
        dbContext.Dispose();
    }

    public void InitialCreate()
    {
        dbContext.Database.OpenConnection();

        dbContext.Database.EnsureCreated();

        var appUser = new AppUser(user.Id!.Value) { Nickname = "zilor", Bio = "这个家伙很懒没有留下任何信息" };
        dbContext.AppUsers.Add(appUser);

        if (dbContext.Questions.Any()) return;

        var answerFaker = new Faker<Answer>("zh_CN")
            .RuleFor(a => a.Content, f => f.Lorem.Paragraphs())
            .RuleFor(a => a.CreatedBy, user.Id!.Value);

        var quesionsFaker = new Faker<Question>("zh_CN")
            .RuleFor(q => q.Title, f => f.Lorem.Sentence(10))
            .RuleFor(q => q.Description, f => f.Lorem.Paragraphs())
            .RuleFor(q => q.ViewCount, f => f.Random.Number(99999))
            .RuleFor(q => q.Answers, _ => answerFaker.GenerateBetween(1, 30))
            .RuleFor(q => q.CreatedBy, user.Id!.Value);

        var questions = quesionsFaker.Generate(10);

        dbContext.Questions.AddRange(questions);
        dbContext.SaveChanges();
    }
}