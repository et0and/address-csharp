using System;
using Address.Models.Addresses;

namespace Address.Tests.Models.Addresses;

public class AddressRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddressRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        AddressRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://address.tom.so/v1/addresses/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AddressRetrieveParams { ID = "id" };

        AddressRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
