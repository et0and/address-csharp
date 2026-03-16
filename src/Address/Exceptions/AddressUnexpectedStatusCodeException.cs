using System.Net.Http;

namespace Address.Exceptions;

public class AddressUnexpectedStatusCodeException : AddressApiException
{
    public AddressUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
