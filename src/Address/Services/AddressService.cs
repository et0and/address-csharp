using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Address.Core;
using Address.Exceptions;
using Address.Models.Addresses;

namespace Address.Services;

/// <inheritdoc/>
public sealed class AddressService : IAddressService
{
    readonly Lazy<IAddressServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAddressServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAddressClient _client;

    /// <inheritdoc/>
    public IAddressService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AddressService(this._client.WithOptions(modifier));
    }

    public AddressService(IAddressClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AddressServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AddressRetrieveResponse> Retrieve(
        AddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AddressRetrieveResponse> Retrieve(
        string id,
        AddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<AddressListResponse>> List(
        AddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AddressServiceWithRawResponse : IAddressServiceWithRawResponse
{
    readonly IAddressClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAddressServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AddressServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AddressServiceWithRawResponse(IAddressClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddressRetrieveResponse>> Retrieve(
        AddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new AddressInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddressRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var address = await response
                    .Deserialize<AddressRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    address.Validate();
                }
                return address;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AddressRetrieveResponse>> Retrieve(
        string id,
        AddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AddressListResponse>>> List(
        AddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AddressListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var addresses = await response
                    .Deserialize<List<AddressListResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in addresses)
                    {
                        item.Validate();
                    }
                }
                return addresses;
            }
        );
    }
}
