using System;
using System.Net.Http;

namespace Address.Exceptions;

public class AddressIOException : AddressException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public AddressIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
