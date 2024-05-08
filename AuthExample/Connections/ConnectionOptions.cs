using System.Reflection;
using Yubico.YubiKey.Fido2;

namespace AuthExample.Connections;

public class ConnectionOptions
{
    public const string plat = "plat";
    public const string rk = "rk";
    public const string clientPin = "clientPin";
    public const string up = "up";
    public const string uv = "uv";
    public const string pinUvAuthToken = "pinUvAuthToken";
    public const string noMcGaPermissionsWithClientPin = "noMcGaPermissionsWithClientPin";
    public const string largeBlobs = "largeBlobs";
    public const string ep = "ep";
    public const string bioEnroll = "bioEnroll";
    public const string userVerificationMgmtPreview = "userVerificationMgmtPreview";
    public const string uvBioEnroll = "uvBioEnroll";
    public const string authnrCfg = "authnrCfg";
    public const string uvAcfg = "uvAcfg";
    public const string credMgmt = "credMgmt";
    public const string credentialMgmtPreview = "credentialMgmtPreview";
    public const string setMinPINLength = "setMinPINLength";
    public const string makeCredUvNotRqd = "makeCredUvNotRqd";
    public const string alwaysUv = "alwaysUv";

    public List<string> GetOptions()
    {
        // string[] options = new string[]
        // {
        //     plat, 
        //     rk, 
        //     clientPin, 
        //     up, 
        //     uv, 
        //     pinUvAuthToken,
        //     noMcGaPermissionsWithClientPin,
        //     largeBlobs,
        //     ep,
        //     bioEnroll,
        //     userVerificationMgmtPreview,
        //     uvBioEnroll,
        //     authnrCfg,
        //     uvAcfg,
        //     credMgmt,
        //     credentialMgmtPreview,
        //     setMinPINLength,
        //     makeCredUvNotRqd,
        //     alwaysUv
        // }
        List<string> options = new List<string>();
        foreach (FieldInfo field in this.GetType().GetFields())
        {
            options.Add(field.GetRawConstantValue().ToString());
        }
        return options;
    }

    public void PrintOptions()
    {
        foreach (string option in GetOptions())
        {
            Console.WriteLine(option);
        }
    }
    
    public OptionValue GetDefaultOptionValue(string option)
    {
        switch (option)
        {
            case "alwaysUv":
            case "authnrCfg":
            case "bioEnroll":
            case "clientPin":
            case "credMgmt":
            case "credentialMgmtPreview":
            case "ep":
            case "largeBlobs":
            case "pinUvAuthToken":
            case "setMinPINLength":
            case "userVerificationMgmtPreview":
            case "uv":
            case "uvAcfg":
            case "uvBioEnroll":
                return OptionValue.NotSupported;
            case "makeCredUvNotRqd":
            case "noMcGaPermissionsWithClientPin":
            case "plat":
            case "rk":
                return OptionValue.False;
            case "up":
                return OptionValue.True;
            default:
                return OptionValue.Unknown;
        }
    }
}