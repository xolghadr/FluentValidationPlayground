using FluentValidation;
using FluentValidationPlayground.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationPlayground.Controllers;

[ApiController]
[Route("[controller]")]
public class ValidatedController : ControllerBase
{
    private readonly ILogger<ValidatedController> _logger;
    private readonly IValidator<SingleRuleDto> _singleRuleValidator;
    private readonly IValidator<SeparateRulesDto> _separateValidator;

    public ValidatedController(ILogger<ValidatedController> logger, IValidator<SingleRuleDto> singleRuleValidator, IValidator<SeparateRulesDto> separateValidator)
    {
        _separateValidator = separateValidator ?? throw new ArgumentNullException(nameof(separateValidator));

        _singleRuleValidator = singleRuleValidator ?? throw new ArgumentNullException(nameof(singleRuleValidator));

        _logger = logger;
    }

    [HttpGet("GetSingleRule")]
    public async Task<IActionResult> GetSingle([FromQuery]SingleRuleDto dto)
    {
        await _singleRuleValidator.ValidateAsync(dto);
        return NoContent();
    }

    [HttpGet("GetSeparateRules")]
    public async Task<IActionResult> GetSeparate([FromQuery]SeparateRulesDto dto)
    {
        await _separateValidator.ValidateAsync(dto);
        return NoContent();
    }
}
