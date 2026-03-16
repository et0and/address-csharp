using System;
using Address;

namespace Address.Tests;

public class TestBase
{
    protected IAddressClient client;

    public TestBase()
    {
        client = new AddressClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "My API Key",
        };
    }
}
