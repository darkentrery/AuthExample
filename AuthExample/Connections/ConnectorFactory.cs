namespace AuthExample.Connections;

public class ConnectorFactory : IConnectorFactory
{
    public bool isHost = false;
    public string host = "";
    public bool isConnect = true;
    public bool features = false;
    
    public ConnectorFactory(string[] args)
    {
        foreach (string arg in args)
        {
            if (this.isHost && !arg.Contains("--"))
            {
                this.host = arg;
            }
            if (!this.isHost)
            {
                this.isHost = arg.Equals("--host", StringComparison.OrdinalIgnoreCase);
            }
            this.isConnect = !arg.Equals("--fail", StringComparison.OrdinalIgnoreCase);
            this.features = arg.Equals("--features", StringComparison.OrdinalIgnoreCase);
        }
    }
    
    public Connection GetConnection()
    {
        if (!this.features)
        {
            Console.WriteLine("Connection initialization...");
            System.Threading.Thread.Sleep(2000);
        }
        if (this.isHost && this.isConnect && this.host != "")
        {
            Console.WriteLine("Successful connected to host: " + this.host);
            return new Connection(host);
        }
        else if(!this.isHost)
        {
            Console.WriteLine("Connection error. Host not specified! Use flag --host");
        }
        else if(!this.isConnect)
        {
            Console.WriteLine("Connection error.");
        }
        else if(this.host == "")
        {
            Console.WriteLine("Connection error. Host not specified! Write host after flag --host");
        }
        return new Connection();
    }

    public void ShowFeatures()
    {
        Console.WriteLine("Use flag `--host` and write host after that for emulation connect");
        Console.WriteLine("Use flag `--fail` for emulation fail connect");
        Console.WriteLine("Use flag `--features` for show features");
    }
}