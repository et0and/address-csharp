using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Address.Core;
using Address.Models.Health;

namespace Address.Services;

/// <inheritdoc/>
public sealed class HealthService : IHealthService
{
    readonly Lazy<IHealthServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IHealthServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAddressClient _client;

    /// <inheritdoc/>
    public IHealthService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HealthService(this._client.WithOptions(modifier));
    }

    public HealthService(IAddressClient client)
    {
        _client = client;

        _withRawResponse = new(() => new HealthServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<HealthCheckResponse> Check(
        HealthCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Check(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class HealthServiceWithRawResponse : IHealthServiceWithRawResponse
{
    readonly IAddressClientWithRawResponse _client;

    /// <inheritdoc/>
    public IHealthServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new HealthServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public HealthServiceWithRawResponse(IAddressClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<HealthCheckResponse>> Check(
        HealthCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<HealthCheckParams> request = new()
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
                    .Deserialize<HealthCheckResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
