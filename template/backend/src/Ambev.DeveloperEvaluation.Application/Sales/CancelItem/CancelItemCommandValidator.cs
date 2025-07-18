using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelItem;

/// <summary>
/// Validator for CancelItemCommand
/// </summary>
public class CancelItemCommandValidator : AbstractValidator<CancelItemCommand>
{
    /// <summary>
    /// Initializes validation rules for CancelItemCommand
    /// </summary>
    public CancelItemCommandValidator()
    {
        RuleFor(x => x.SaleId)
            .NotEmpty()
            .WithMessage("Sale ID is required");

        RuleFor(x => x.ItemId)
            .NotEmpty()
            .WithMessage("Item ID is required");


    }
} 