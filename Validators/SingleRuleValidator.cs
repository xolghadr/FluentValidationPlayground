using FluentValidation;
using FluentValidationPlayground.Dtos;

namespace FluentValidationPlayground.Validators;
public class SingleRuleValidator : AbstractValidator<SingleRuleDto>
{
    public SingleRuleValidator()
    {
        RuleFor(model => model).MustAsync(WaitForValidationAsync);
    }
    private async Task<bool> WaitForValidationAsync(SingleRuleDto model, CancellationToken cancellationToken)
    {
        var task1 = Task.Delay(model.FirstTaskDelay, cancellationToken);
        var task2 = Task.Delay(model.SecondTaskDelay, cancellationToken);
        var task3 = Task.Delay(model.ThirdTaskDelay, cancellationToken);
        await Task.WhenAll(task1, task2, task3);
        return false;
    }
}