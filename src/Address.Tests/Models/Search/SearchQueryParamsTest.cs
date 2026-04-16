using System;
using Address.Models.Search;

namespace Address.Tests.Models.Search;

public class SearchQueryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SearchQueryParams
        {
            Q = "q",
            Bbox = "bbox",
            Format = "format",
            Limit = "limit",
            Polygon = "polygon",
        };

        string expectedQ = "q";
        string expectedBbox = "bbox";
        string expectedFormat = "format";
        string expectedLimit = "limit";
        string expectedPolygon = "polygon";

        Assert.Equal(expectedQ, parameters.Q);
        Assert.Equal(expectedBbox, parameters.Bbox);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPolygon, parameters.Polygon);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SearchQueryParams { Q = "q" };

        Assert.Null(parameters.Bbox);
        Assert.False(parameters.RawQueryData.ContainsKey("bbox"));
        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Polygon);
        Assert.False(parameters.RawQueryData.ContainsKey("polygon"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SearchQueryParams
        {
            Q = "q",

            // Null should be interpreted as omitted for these properties
            Bbox = null,
            Format = null,
            Limit = null,
            Polygon = null,
        };

        Assert.Null(parameters.Bbox);
        Assert.False(parameters.RawQueryData.ContainsKey("bbox"));
        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Polygon);
        Assert.False(parameters.RawQueryData.ContainsKey("polygon"));
    }

    [Fact]
    public void Url_Works()
    {
        SearchQueryParams parameters = new()
        {
            Q = "q",
            Bbox = "bbox",
            Format = "format",
            Limit = "limit",
            Polygon = "polygon",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://address.tom.so/v1/search?q=q&bbox=bbox&format=format&limit=limit&polygon=polygon"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SearchQueryParams
        {
            Q = "q",
            Bbox = "bbox",
            Format = "format",
            Limit = "limit",
            Polygon = "polygon",
        };

        SearchQueryParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
