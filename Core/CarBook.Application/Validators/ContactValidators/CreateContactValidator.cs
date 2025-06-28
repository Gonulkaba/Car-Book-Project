using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using FluentValidation;

namespace CarBook.Application.Validators.ContactValidators
{
	public class CreateContactValidator : AbstractValidator<CreateContactCommand>
	{
		public CreateContactValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresi boş geçilemez!")
                             .EmailAddress().WithMessage("Geçerli bir email adresi girin.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez!").MinimumLength(5).WithMessage("Lütfen en az 5 karakter konu giriniz!");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanı boş geçilemez!").MinimumLength(15).WithMessage("Lütfen en az 15 karakter mesaj giriniz!");
		}
	}
}
