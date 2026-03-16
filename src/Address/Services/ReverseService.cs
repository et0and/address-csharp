using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Address.Core;
using Address.Models.Reverse;

namespace Address.Services;

/// <inheritdoc/>
public sealed class ReverseService : IReverseService
{
    readonly Lazy<IReverseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReverseServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAddressClient _client;

    /// <inheritdoc/>
    public IReverseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReverseService(this._client.WithOptions(modifier));
    }

    public ReverseService(IAddressClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ReverseServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<ReverseGeocodeResponse>> Geocode(
        ReverseGeocodeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Geocode(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ReverseServiceWithRawResponse : IReverseServiceWithRawResponse
{
    readonly IAddressClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReverseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReverseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReverseServiceWithRawResponse(IAddressClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<ReverseGeocodeResponse>>> Geocode(
        ReverseGeocodeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ReverseGeocodeParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<ReverseGeocodeResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }
}
