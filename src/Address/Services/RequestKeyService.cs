using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Address.Core;
using Address.Models.RequestKey;

namespace Address.Services;

/// <inheritdoc/>
public sealed class RequestKeyService : IRequestKeyService
{
    readonly Lazy<IRequestKeyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRequestKeyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAddressClient _client;

    /// <inheritdoc/>
    public IRequestKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RequestKeyService(this._client.WithOptions(modifier));
    }

    public RequestKeyService(IAddressClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RequestKeyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<RequestKeyCreateResponse> Create(
        RequestKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RequestKeyServiceWithRawResponse : IRequestKeyServiceWithRawResponse
{
    readonly IAddressClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRequestKeyServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RequestKeyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RequestKeyServiceWithRawResponse(IAddressClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RequestKeyCreateResponse>> Create(
        RequestKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RequestKeyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var requestKey = await response
                    .Deserialize<RequestKeyCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    requestKey.Validate();
                }
                return requestKey;
            }
        );
    }
}
