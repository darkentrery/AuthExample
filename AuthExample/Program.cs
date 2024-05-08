using AuthExample.SharedSampleCode.Menu;
using Yubico.YubiKey;


namespace AuthExample;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        bool useGui = false;
        foreach (var arg in args)
        {
            Console.WriteLine(arg);
        }

        if (args.Length != 0)
        {
            useGui = args[0].Equals("g", StringComparison.OrdinalIgnoreCase);
        }

        if (useGui)
        {
            // using var fido2SampleGui = new Fido2SampleGui();
            // fido2SampleGui.RunSample();
#if WINDOWS
                using var fido2SampleGui = new Fido2SampleGui();
                fido2SampleGui.RunSample();
#else
            SampleMenu.WriteMessage(
                MessageType.Title, 0,
                "\n---The GUI version of this sample is not available on this plaform---\n");
#endif
        }
        else
        {
            var fido2SampleRun = new Fido2SampleCode.Run.Fido2SampleRun(maxInvalidCount: 2);
            fido2SampleRun.RunSample();
// #if WINDOWS
// Console.WriteLine("Hello, World!");
//                 fido2SampleRun.RunSample();
// #else
//             Console.WriteLine("Hello, World!1");
//             fido2SampleRun.RunSample(false);
// #endif
        }
    }
}