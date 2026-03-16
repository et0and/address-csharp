using System;
using Address.Models.Addresses;

namespace Address.Tests.Models.Addresses;

public class AddressListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddressListParams
        {
            Bbox = "bbox",
            Format = "format",
            Limit = "limit",
            Offset = "offset",
            RoadName = "road_name",
            SuburbLocality = "suburb_locality",
            TownCity = "town_city",
        };

        string expectedBbox = "bbox";
        string expectedFormat = "format";
        string expectedLimit = "limit";
        string expectedOffset = "offset";
        string expectedRoadName = "road_name";
        string expectedSuburbLocality = "suburb_locality";
        string expectedTownCity = "town_city";

        Assert.Equal(expectedBbox, parameters.Bbox);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedRoadName, parameters.RoadName);
        Assert.Equal(expectedSuburbLocality, parameters.SuburbLocality);
        Assert.Equal(expectedTownCity, parameters.TownCity);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AddressListParams { };

        Assert.Null(parameters.Bbox);
        Assert.False(parameters.RawQueryData.ContainsKey("bbox"));
        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.RoadName);
        Assert.False(parameters.RawQueryData.ContainsKey("road_name"));
        Assert.Null(parameters.SuburbLocality);
        Assert.False(parameters.RawQueryData.ContainsKey("suburb_locality"));
        Assert.Null(parameters.TownCity);
        Assert.False(parameters.RawQueryData.ContainsKey("town_city"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AddressListParams
        {
            // Null should be interpreted as omitted for these properties
            Bbox = null,
            Format = null,
            Limit = null,
            Offset = null,
            RoadName = null,
            SuburbLocality = null,
            TownCity = null,
        };

        Assert.Null(parameters.Bbox);
        Assert.False(parameters.RawQueryData.ContainsKey("bbox"));
        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.RoadName);
        Assert.False(parameters.RawQueryData.ContainsKey("road_name"));
        Assert.Null(parameters.SuburbLocality);
        Assert.False(parameters.RawQueryData.ContainsKey("suburb_locality"));
        Assert.Null(parameters.TownCity);
        Assert.False(parameters.RawQueryData.ContainsKey("town_city"));
    }

    [Fact]
    public void Url_Works()
    {
        AddressListParams parameters = new()
        {
            Bbox = "bbox",
            Format = "format",
            Limit = "limit",
            Offset = "offset",
            RoadName = "road_name",
            SuburbLocality = "suburb_locality",
            TownCity = "town_city",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://address.tom.so/v1/addresses?bbox=bbox&format=format&limit=limit&offset=offset&road_name=road_name&suburb_locality=suburb_locality&town_city=town_city"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AddressListParams
        {
            Bbox = "bbox",
            Format = "format",
            Limit = "limit",
            Offset = "offset",
            RoadName = "road_name",
            SuburbLocality = "suburb_locality",
            TownCity = "town_city",
        };

        AddressListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
