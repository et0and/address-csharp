using System.Text.Json;
using Address.Core;
using Address.Models.Addresses;

namespace Address.Tests.Models.Addresses;

public class AddressListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddressListResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Postcode = "postcode",
            Region = "region",
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
            FullAddressRoad = "fullAddressRoad",
        };

        double expectedAddressID = 0;
        string expectedFullAddress = "fullAddress";
        string expectedFullAddressNumber = "fullAddressNumber";
        double expectedLatitude = 0;
        double expectedLongitude = 0;
        string expectedPostcode = "postcode";
        string expectedRegion = "region";
        string expectedSuburb = "suburb";
        string expectedTerritorialAuthority = "territorialAuthority";
        string expectedTownCity = "townCity";
        string expectedFullAddressRoad = "fullAddressRoad";

        Assert.Equal(expectedAddressID, model.AddressID);
        Assert.Equal(expectedFullAddress, model.FullAddress);
        Assert.Equal(expectedFullAddressNumber, model.FullAddressNumber);
        Assert.Equal(expectedLatitude, model.Latitude);
        Assert.Equal(expectedLongitude, model.Longitude);
        Assert.Equal(expectedPostcode, model.Postcode);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedSuburb, model.Suburb);
        Assert.Equal(expectedTerritorialAuthority, model.TerritorialAuthority);
        Assert.Equal(expectedTownCity, model.TownCity);
        Assert.Equal(expectedFullAddressRoad, model.FullAddressRoad);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddressListResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Postcode = "postcode",
            Region = "region",
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
            FullAddressRoad = "fullAddressRoad",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddressListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddressListResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Postcode = "postcode",
            Region = "region",
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
            FullAddressRoad = "fullAddressRoad",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddressListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAddressID = 0;
        string expectedFullAddress = "fullAddress";
        string expectedFullAddressNumber = "fullAddressNumber";
        double expectedLatitude = 0;
        double expectedLongitude = 0;
        string expectedPostcode = "postcode";
        string expectedRegion = "region";
        string expectedSuburb = "suburb";
        string expectedTerritorialAuthority = "territorialAuthority";
        string expectedTownCity = "townCity";
        string expectedFullAddressRoad = "fullAddressRoad";

        Assert.Equal(expectedAddressID, deserialized.AddressID);
        Assert.Equal(expectedFullAddress, deserialized.FullAddress);
        Assert.Equal(expectedFullAddressNumber, deserialized.FullAddressNumber);
        Assert.Equal(expectedLatitude, deserialized.Latitude);
        Assert.Equal(expectedLongitude, deserialized.Longitude);
        Assert.Equal(expectedPostcode, deserialized.Postcode);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedSuburb, deserialized.Suburb);
        Assert.Equal(expectedTerritorialAuthority, deserialized.TerritorialAuthority);
        Assert.Equal(expectedTownCity, deserialized.TownCity);
        Assert.Equal(expectedFullAddressRoad, deserialized.FullAddressRoad);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddressListResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Postcode = "postcode",
            Region = "region",
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
            FullAddressRoad = "fullAddressRoad",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AddressListResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Postcode = "postcode",
            Region = "region",
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
        };

        Assert.Null(model.FullAddressRoad);
        Assert.False(model.RawData.ContainsKey("fullAddressRoad"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AddressListResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Postcode = "postcode",
            Region = "region",
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AddressListResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Postcode = "postcode",
            Region = "region",
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",

            FullAddressRoad = null,
        };

        Assert.Null(model.FullAddressRoad);
        Assert.True(model.RawData.ContainsKey("fullAddressRoad"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AddressListResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Postcode = "postcode",
            Region = "region",
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",

            FullAddressRoad = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddressListResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            Latitude = 0,
            Longitude = 0,
            Postcode = "postcode",
            Region = "region",
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
            FullAddressRoad = "fullAddressRoad",
        };

        AddressListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
