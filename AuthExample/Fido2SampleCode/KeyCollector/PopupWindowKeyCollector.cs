#if WINDOWS
namespace Yubico.YubiKey.Sample.Fido2SampleCode
{
    // This KeyCollector class is the same as the command-line key collector,
    // except that for PIN, touch, and fingerprint, it pops up windows.
    // This sample key collector is specifically built for FIDO2 only.
    public class PopupWindowKeyCollector : Fido2SampleKeyCollector
    {
        private readonly ParentForm _parentForm;
        private bool _fpTouchLaunched;

        public PopupWindowKeyCollector(ParentForm parentForm)
            : base()
        {
            _parentForm = parentForm;
            _fpTouchLaunched = false;
        }

        public override bool Fido2SampleKeyCollectorDelegate(KeyEntryData keyEntryData)
        {
            if (keyEntryData is null)
            {
                return false;
            }

            switch (keyEntryData.Request)
            {
                default:
                    return base.Fido2SampleKeyCollectorDelegate(keyEntryData);

                case KeyEntryRequest.SetFido2Pin:
                case KeyEntryRequest.VerifyFido2Pin:
                case KeyEntryRequest.ChangeFido2Pin:
                    return _parentForm.LaunchPinPopup(keyEntryData);

                case KeyEntryRequest.Release:
                    if (_fpTouchLaunched)
                    {
                        _parentForm.CloseFpTouchPopup();
                        _fpTouchLaunched = false;
                    }

                    return base.Fido2SampleKeyCollectorDelegate(keyEntryData);

                case KeyEntryRequest.TouchRequest:
                    _parentForm.LaunchFpTouchPopup("Touch the YubiKey's contact to complete the operation.", keyEntryData);
                    _fpTouchLaunched = true;
                    break;

                case KeyEntryRequest.EnrollFingerprint:
                    _parentForm.LaunchFpTouchPopup("Please provide a fingerprint sample.", keyEntryData);
                    _fpTouchLaunched = true;
                    break;

                case KeyEntryRequest.VerifyFido2Uv:
                    _parentForm.LaunchFpTouchPopup("Verify your fingerprint.", keyEntryData);
                    _fpTouchLaunched = true;
                    break;
            }

            return true;
        }
    }
}
#endif