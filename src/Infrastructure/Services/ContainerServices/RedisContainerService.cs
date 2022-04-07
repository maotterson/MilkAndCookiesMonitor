using System.Net.NetworkInformation;

public class RedisContainerService : IContainerService
{
    public RedisContainerSettings ContainerSettings { get; init; } = null!;

    public RedisContainerService(IContainerSettings settings)
    {
        ContainerSettings = (RedisContainerSettings)settings;
    }
    IContainerSettings IContainerService.GetSettings() => ContainerSettings;

    public EContainerStatus GetStatus()
    {
        try
        {
            var connectionString = ContainerSettings.ConnectionString.Value;
            var pingSender = new Ping();
            var reply = pingSender.Send(connectionString);
            var isSuccess = reply.Status == IPStatus.Success;

            return isSuccess ? EContainerStatus.Reachable : throw new();
        }
        catch (Exception ex)
        {
            return EContainerStatus.Unreachable;
        }
    }
}
