using FluentValidation;
using Zhaoxi.Zhihu.Core.Data;
using Zhaoxi.Zhihu.Core.QuestionAggregate.Entites;

namespace Zhaoxi.Zhihu.UseCases.Questions.Commands;

public record CreatedQuestionDto(int Id);

[Authorize]
public record CreateQuestionCommand(string Title, string? Description) : ICommand<Result<CreatedQuestionDto>>;

public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    {
        RuleFor(command => command.Title)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Length(6, DataSchemaConstants.DefaultQuestionTitleLength)
            .Must(t => t.EndsWith('?') || t.EndsWith('？')).WithMessage("问题标题必须以问号结尾");

        RuleFor(command => command.Description)
            .MaximumLength(DataSchemaConstants.DefaultDescriptionTitleLength);

        RuleFor(command => command)
            .Must(command => command.Title != command.Description)
            .WithMessage("问题标题和描述不能相同");
    }
}

public class CreateQuestionCommandHandler(
    IRepository<Question> questions,
    IMapper mapper) : ICommandHandler<CreateQuestionCommand, Result<CreatedQuestionDto>>
{
    public async Task<Result<CreatedQuestionDto>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = mapper.Map<Question>(request);

        questions.Add(question);

        await questions.SaveChangesAsync(cancellationToken);

        return Result.Success(new CreatedQuestionDto(question.Id));
    }
}
