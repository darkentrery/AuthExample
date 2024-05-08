using AuthExample.Fido2SampleCode.KeyCollector;

namespace AuthExample.Connections;

public interface IConnection
{
    public UserInfo GetUserInfo();
    public void Disconnect();
}