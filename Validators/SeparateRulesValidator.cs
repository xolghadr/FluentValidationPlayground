using FluentValidation;
using FluentValidationPlayground.Dtos;

namespace FluentValidationPlayground.Validators;
public class SeparateRulesValidator : AbstractValidator<SeparateRulesDto>
{
    public SeparateRulesValidator()
    {
        RuleFor(model => model.FirstTaskDelay).MustAsync(WaitForValidationAsync);
        RuleFor(model => model.SecondTaskDelay).MustAsync(WaitForValidationAsync);
        RuleFor(model => model.ThirdTaskDelay).MustAsync(WaitForValidationAsync);
    }
    private async Task<bool> WaitForValidationAsync(int delay, CancellationToken cancellationToken)
    {
        await Task.Delay(delay, cancellationToken);
        return false;
    }
}