namespace AuthExample.Connections;

public interface IConnectorFactory
{
    public Connection GetConnection();
    public ConnectionOptions GetFeatures();
}