using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Common;

public class BaseEntity : IComparable<BaseEntity>
{
    public Guid Id { get; set; }

    public Task<IEnumerable<ValidationErrorDetail>> ValidateAsync()
    {
        return Validator.ValidateAsync(this);
    }

    public ValidationResultDetail ValidationResultDetail { get; set; } = new();
    public void AddValidationError(List<ValidationErrorDetail> errors)
    {
        ValidationResultDetail.Errors = ValidationResultDetail.Errors.Concat(errors).ToList();
    }

    public int CompareTo(BaseEntity? other)
    {
        if (other == null)
        {
            return 1;
        }

        return other!.Id.CompareTo(Id);
    }
}
