using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Address.Core;

namespace Address.Models.Addresses;

[JsonConverter(typeof(JsonModelConverter<AddressListResponse, AddressListResponseFromRaw>))]
public sealed record class AddressListResponse : JsonModel
{
    public required double AddressID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("addressId");
        }
        init { this._rawData.Set("addressId", value); }
    }

    public required string FullAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("fullAddress");
        }
        init { this._rawData.Set("fullAddress", value); }
    }

    public required string FullAddressNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("fullAddressNumber");
        }
        init { this._rawData.Set("fullAddressNumber", value); }
    }

    public required double Latitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("latitude");
        }
        init { this._rawData.Set("latitude", value); }
    }

    public required double Longitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("longitude");
        }
        init { this._rawData.Set("longitude", value); }
    }

    public required string Suburb
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("suburb");
        }
        init { this._rawData.Set("suburb", value); }
    }

    public required string TerritorialAuthority
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("territorialAuthority");
        }
        init { this._rawData.Set("territorialAuthority", value); }
    }

    public required string TownCity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("townCity");
        }
        init { this._rawData.Set("townCity", value); }
    }

    public string? FullAddressRoad
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fullAddressRoad");
        }
        init { this._rawData.Set("fullAddressRoad", value); }
    }

    public string? Postcode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postcode");
        }
        init { this._rawData.Set("postcode", value); }
    }

    public string? Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("region");
        }
        init { this._rawData.Set("region", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddressID;
        _ = this.FullAddress;
        _ = this.FullAddressNumber;
        _ = this.Latitude;
        _ = this.Longitude;
        _ = this.Suburb;
        _ = this.TerritorialAuthority;
        _ = this.TownCity;
        _ = this.FullAddressRoad;
        _ = this.Postcode;
        _ = this.Region;
    }

    public AddressListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddressListResponse(AddressListResponse addressListResponse)
        : base(addressListResponse) { }
#pragma warning restore CS8618

    public AddressListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddressListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressListResponseFromRaw.FromRawUnchecked"/>
    public static AddressListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddressListResponseFromRaw : IFromRawJson<AddressListResponse>
{
    /// <inheritdoc/>
    public AddressListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AddressListResponse.FromRawUnchecked(rawData);
}
