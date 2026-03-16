using System;
using Address.Models.Reverse;

namespace Address.Tests.Models.Reverse;

public class ReverseGeocodeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReverseGeocodeParams
        {
            Point = "point",
            Format = "format",
            Limit = "limit",
        };

        string expectedPoint = "point";
        string expectedFormat = "format";
        string expectedLimit = "limit";

        Assert.Equal(expectedPoint, parameters.Point);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ReverseGeocodeParams { Point = "point" };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ReverseGeocodeParams
        {
            Point = "point",

            // Null should be interpreted as omitted for these properties
            Format = null,
            Limit = null,
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        ReverseGeocodeParams parameters = new()
        {
            Point = "point",
            Format = "format",
            Limit = "limit",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://address.tom.so/v1/reverse?point=point&format=format&limit=limit"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ReverseGeocodeParams
        {
            Point = "point",
            Format = "format",
            Limit = "limit",
        };

        ReverseGeocodeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
