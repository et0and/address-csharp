using System.Net.Http;

namespace Address.Exceptions;

public class AddressUnprocessableEntityException : Address4xxException
{
    public AddressUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
