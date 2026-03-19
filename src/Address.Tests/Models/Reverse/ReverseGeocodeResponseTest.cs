using System.Text.Json;
using Address.Core;
using Address.Models.Reverse;

namespace Address.Tests.Models.Reverse;

public class ReverseGeocodeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReverseGeocodeResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
            FullAddressRoad = "fullAddressRoad",
            Postcode = "postcode",
            Region = "region",
        };

        double expectedAddressID = 0;
        string expectedFullAddress = "fullAddress";
        string expectedFullAddressNumber = "fullAddressNumber";
        double expectedLatitude = 0;
        double expectedLongitude = 0;
        string expectedSuburb = "suburb";
        string expectedTerritorialAuthority = "territorialAuthority";
        string expectedTownCity = "townCity";
        string expectedFullAddressRoad = "fullAddressRoad";
        string expectedPostcode = "postcode";
        string expectedRegion = "region";

        Assert.Equal(expectedAddressID, model.AddressID);
        Assert.Equal(expectedFullAddress, model.FullAddress);
        Assert.Equal(expectedFullAddressNumber, model.FullAddressNumber);
        Assert.Equal(expectedLatitude, model.Latitude);
        Assert.Equal(expectedLongitude, model.Longitude);
        Assert.Equal(expectedSuburb, model.Suburb);
        Assert.Equal(expectedTerritorialAuthority, model.TerritorialAuthority);
        Assert.Equal(expectedTownCity, model.TownCity);
        Assert.Equal(expectedFullAddressRoad, model.FullAddressRoad);
        Assert.Equal(expectedPostcode, model.Postcode);
        Assert.Equal(expectedRegion, model.Region);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReverseGeocodeResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
            FullAddressRoad = "fullAddressRoad",
            Postcode = "postcode",
            Region = "region",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReverseGeocodeResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReverseGeocodeResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
            FullAddressRoad = "fullAddressRoad",
            Postcode = "postcode",
            Region = "region",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReverseGeocodeResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAddressID = 0;
        string expectedFullAddress = "fullAddress";
        string expectedFullAddressNumber = "fullAddressNumber";
        double expectedLatitude = 0;
        double expectedLongitude = 0;
        string expectedSuburb = "suburb";
        string expectedTerritorialAuthority = "territorialAuthority";
        string expectedTownCity = "townCity";
        string expectedFullAddressRoad = "fullAddressRoad";
        string expectedPostcode = "postcode";
        string expectedRegion = "region";

        Assert.Equal(expectedAddressID, deserialized.AddressID);
        Assert.Equal(expectedFullAddress, deserialized.FullAddress);
        Assert.Equal(expectedFullAddressNumber, deserialized.FullAddressNumber);
        Assert.Equal(expectedLatitude, deserialized.Latitude);
        Assert.Equal(expectedLongitude, deserialized.Longitude);
        Assert.Equal(expectedSuburb, deserialized.Suburb);
        Assert.Equal(expectedTerritorialAuthority, deserialized.TerritorialAuthority);
        Assert.Equal(expectedTownCity, deserialized.TownCity);
        Assert.Equal(expectedFullAddressRoad, deserialized.FullAddressRoad);
        Assert.Equal(expectedPostcode, deserialized.Postcode);
        Assert.Equal(expectedRegion, deserialized.Region);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReverseGeocodeResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
            FullAddressRoad = "fullAddressRoad",
            Postcode = "postcode",
            Region = "region",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReverseGeocodeResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
        };

        Assert.Null(model.FullAddressRoad);
        Assert.False(model.RawData.ContainsKey("fullAddressRoad"));
        Assert.Null(model.Postcode);
        Assert.False(model.RawData.ContainsKey("postcode"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReverseGeocodeResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReverseGeocodeResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",

            FullAddressRoad = null,
            Postcode = null,
            Region = null,
        };

        Assert.Null(model.FullAddressRoad);
        Assert.True(model.RawData.ContainsKey("fullAddressRoad"));
        Assert.Null(model.Postcode);
        Assert.True(model.RawData.ContainsKey("postcode"));
        Assert.Null(model.Region);
        Assert.True(model.RawData.ContainsKey("region"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReverseGeocodeResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",

            FullAddressRoad = null,
            Postcode = null,
            Region = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReverseGeocodeResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
            FullAddressRoad = "fullAddressRoad",
            Postcode = "postcode",
            Region = "region",
        };

        ReverseGeocodeResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
