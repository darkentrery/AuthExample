namespace AuthExample.Fido2SampleCode.KeyCollector
{
    public enum Fido2KeyCollectorOperation
    {
        None = 0,
        MakeCredential = 1,
        GetAssertion = 2,
        Reset = 3,
        Verify = 4,
    }
}