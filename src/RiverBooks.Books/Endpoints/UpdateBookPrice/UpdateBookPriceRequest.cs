using FastEndpoints;
using FluentValidation;

namespace RiverBooks.Books.Endpoints.UpdateBookPrice;

public record UpdateBookPriceRequest(Guid Id, decimal Price);

public class UpdateBookPriceRequestValidator : Validator<UpdateBookPriceRequest>
{
    public UpdateBookPriceRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEqual(Guid.Empty)
            .WithMessage("Id must not be empty.");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price must be greater than or equal to 0.");
    }
}
