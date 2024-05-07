using Yubico.YubiKey;
using Yubico.YubiKey.Fido2;
using Yubico.YubiKey.Fido2.Commands;

namespace AuthExample.Fido2SampleCode.YubiKeyOperations
{
    // This file contains the methods that demonstrate how to perform PIN
    // operations in the FIDO2 application.
    public static class Fido2Pin
    {
        public static bool SetPin(IYubiKeyDevice yubiKey, Func<KeyEntryData, bool> KeyCollectorDelegate)
        {
            using (var fido2Session = new Fido2Session(yubiKey))
            {
                fido2Session.KeyCollector = KeyCollectorDelegate;
                return fido2Session.TrySetPin();
            }
        }

        public static bool ChangePin(IYubiKeyDevice yubiKey, Func<KeyEntryData, bool> KeyCollectorDelegate)
        {
            using (var fido2Session = new Fido2Session(yubiKey))
            {
                fido2Session.KeyCollector = KeyCollectorDelegate;
                return fido2Session.TryChangePin();
            }
        }

        public static bool VerifyPin(
            IYubiKeyDevice yubiKey,
            Func<KeyEntryData, bool> KeyCollectorDelegate,
            PinUvAuthTokenPermissions? permissions,
            string relyingPartyId)
        {
            using (var fido2Session = new Fido2Session(yubiKey))
            {
                fido2Session.KeyCollector = KeyCollectorDelegate;
                return fido2Session.TryVerifyPin(permissions, relyingPartyId);
            }
        }

        public static bool VerifyUv(
            IYubiKeyDevice yubiKey,
            Func<KeyEntryData, bool> KeyCollectorDelegate,
            PinUvAuthTokenPermissions permissions,
            string relyingPartyId)
        {
            using (var fido2Session = new Fido2Session(yubiKey))
            {
                fido2Session.KeyCollector = KeyCollectorDelegate;
                return fido2Session.TryVerifyUv(permissions, relyingPartyId);
            }
        }
    }
}