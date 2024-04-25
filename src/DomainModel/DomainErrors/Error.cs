using System.Collections.Generic;
using DomainModel.Common;

namespace DomainModel.DomainErrors;

public class Error : ValueObject
{
    public string ErrorCode { get; private set; }
    public string ErrorMessage { get; private set; }
    public IDictionary<string, object?> Details;

    public Error(
        string errorCode,
        string errorMessage,
        IDictionary<string, object?>? details = null
    )
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
        Details = details ?? new Dictionary<string, object?>();
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return ErrorCode;
    }
}