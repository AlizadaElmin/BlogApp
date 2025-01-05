using BlogApp.BL.DTOs.UserDtos;
using BlogApp.Core.Repositories;
using FluentValidation;

namespace BlogApp.BL.Validators.UserValidators;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    private readonly IUserRepository _repo;

    public RegisterDtoValidator(IUserRepository repo)
    {
        _repo = repo;

        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress();

        RuleFor(x => x.Username)
            .NotNull()
            .NotEmpty()
            .WithMessage("Username is required");
        // .Must(x => _repo.GetByUserNameAsync(x).Result == null)
        // .WithMessage("Username is exists");
    }
}