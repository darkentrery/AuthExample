using AuthExample.SharedSampleCode.Menu;
using Yubico.YubiKey;


namespace AuthExample;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        bool useGui = false;

        if (args.Length != 0)
        {
            useGui = args[0].Equals("g", StringComparison.OrdinalIgnoreCase);
        }

        if (useGui)
        {
#if WINDOWS
                using var fido2SampleGui = new Fido2SampleGui();
                fido2SampleGui.RunSample();
#else
            SampleMenu.WriteMessage(
                MessageType.Title, 0,
                "\n---The GUI version of this sample is not available on this plaform---\n");
            // Console.WriteLine("\n---The GUI version of this sample is not available on this plaform---\n");
#endif
        }
        else
        {
            var fido2SampleRun = new Fido2SampleCode.Run.Fido2SampleRun(maxInvalidCount: 2);
#if WINDOWS
                fido2SampleRun.RunSample();
#else
            fido2SampleRun.RunSample(false);
#endif
        }
    }
}