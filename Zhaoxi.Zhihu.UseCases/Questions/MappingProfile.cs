using Zhaoxi.Zhihu.Core.QuestionAggregate.Entites;
using Zhaoxi.Zhihu.UseCases.Questions.Commands;

namespace Zhaoxi.Zhihu.UseCases.Questions;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateQuestionCommand, Question>();
        CreateMap<UpdateQuestionCommand, Question>();
    }
}
