namespace AuthExample.Fido2SampleCode.KeyCollector;

public class User
{
    public string name;
    public string lastName;
    // public string password;

    public User(string name, string lastName)
    {
        this.name = name;
        this.lastName = lastName;
    }
    public string Password { get; set; }

    public void PrintUser()
    {
        Console.WriteLine("Name: " + this.name);
        Console.WriteLine("Last Name: " + this.lastName);
        Console.WriteLine("Password: " + this.Password);
    }
}