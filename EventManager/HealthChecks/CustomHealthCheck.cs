using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EventManager.HealthChecks
{
    public class CustomHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult>
            CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                return Task.FromResult(HealthCheckResult.Healthy("Ok"));
            }
            catch (Exception)
            {

                return Task.FromResult(HealthCheckResult.Unhealthy("Not Ok"));
            }
        }
    }
}
