using Api.DTOs;
using FluentValidation;

namespace Api.FluentValidation;

public class EditPersonalInfoRequestValidator : AbstractValidator<EditPersonalInfoRequest>
{
    public EditPersonalInfoRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(0, 200);
    }
}
