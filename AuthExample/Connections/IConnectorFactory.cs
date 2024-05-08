namespace AuthExample.Connections;

public interface IConnectorFactory
{
    public Connection GetConnection();
    public void ShowFeatures();
}