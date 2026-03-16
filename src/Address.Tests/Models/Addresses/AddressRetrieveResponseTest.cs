using System.Text.Json;
using Address.Core;
using Address.Models.Addresses;

namespace Address.Tests.Models.Addresses;

public class AddressRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddressRetrieveResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            FullAddressRoad = "fullAddressRoad",
            Latitude = 0,
            Longitude = 0,
            Postcode = "postcode",
            Region = "region",
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
        };

        double expectedAddressID = 0;
        string expectedFullAddress = "fullAddress";
        string expectedFullAddressNumber = "fullAddressNumber";
        string expectedFullAddressRoad = "fullAddressRoad";
        double expectedLatitude = 0;
        double expectedLongitude = 0;
        string expectedPostcode = "postcode";
        string expectedRegion = "region";
        string expectedSuburb = "suburb";
        string expectedTerritorialAuthority = "territorialAuthority";
        string expectedTownCity = "townCity";

        Assert.Equal(expectedAddressID, model.AddressID);
        Assert.Equal(expectedFullAddress, model.FullAddress);
        Assert.Equal(expectedFullAddressNumber, model.FullAddressNumber);
        Assert.Equal(expectedFullAddressRoad, model.FullAddressRoad);
        Assert.Equal(expectedLatitude, model.Latitude);
        Assert.Equal(expectedLongitude, model.Longitude);
        Assert.Equal(expectedPostcode, model.Postcode);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedSuburb, model.Suburb);
        Assert.Equal(expectedTerritorialAuthority, model.TerritorialAuthority);
        Assert.Equal(expectedTownCity, model.TownCity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddressRetrieveResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            FullAddressRoad = "fullAddressRoad",
            Latitude = 0,
            Longitude = 0,
            Postcode = "postcode",
            Region = "region",
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddressRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddressRetrieveResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            FullAddressRoad = "fullAddressRoad",
            Latitude = 0,
            Longitude = 0,
            Postcode = "postcode",
            Region = "region",
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddressRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAddressID = 0;
        string expectedFullAddress = "fullAddress";
        string expectedFullAddressNumber = "fullAddressNumber";
        string expectedFullAddressRoad = "fullAddressRoad";
        double expectedLatitude = 0;
        double expectedLongitude = 0;
        string expectedPostcode = "postcode";
        string expectedRegion = "region";
        string expectedSuburb = "suburb";
        string expectedTerritorialAuthority = "territorialAuthority";
        string expectedTownCity = "townCity";

        Assert.Equal(expectedAddressID, deserialized.AddressID);
        Assert.Equal(expectedFullAddress, deserialized.FullAddress);
        Assert.Equal(expectedFullAddressNumber, deserialized.FullAddressNumber);
        Assert.Equal(expectedFullAddressRoad, deserialized.FullAddressRoad);
        Assert.Equal(expectedLatitude, deserialized.Latitude);
        Assert.Equal(expectedLongitude, deserialized.Longitude);
        Assert.Equal(expectedPostcode, deserialized.Postcode);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedSuburb, deserialized.Suburb);
        Assert.Equal(expectedTerritorialAuthority, deserialized.TerritorialAuthority);
        Assert.Equal(expectedTownCity, deserialized.TownCity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddressRetrieveResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            FullAddressRoad = "fullAddressRoad",
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
    public void CopyConstructor_Works()
    {
        var model = new AddressRetrieveResponse
        {
            AddressID = 0,
            FullAddress = "fullAddress",
            FullAddressNumber = "fullAddressNumber",
            FullAddressRoad = "fullAddressRoad",
            Latitude = 0,
            Longitude = 0,
            Postcode = "postcode",
            Region = "region",
            Suburb = "suburb",
            TerritorialAuthority = "territorialAuthority",
            TownCity = "townCity",
        };

        AddressRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
