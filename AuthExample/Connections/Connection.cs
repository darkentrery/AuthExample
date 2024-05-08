using AuthExample.Fido2SampleCode.KeyCollector;

namespace AuthExample.Connections;

public class Connection : IConnection
{
    private bool _isConnect;

    public Connection(string host)
    {
        this._isConnect = true;
    }

    public Connection()
    {
        this._isConnect = false;
    }
    
    public UserInfo GetUserInfo()
    {
        if (this._isConnect)
        {
            Console.WriteLine("Getting user info...");
            System.Threading.Thread.Sleep(2000);
            return new UserInfo("John", "Duglas");
        }
        else
        {
            throw new Exception();
        }
    }

    public void Disconnect()
    {
        this._isConnect = false;
        Console.WriteLine("Disconnect");
    }
}