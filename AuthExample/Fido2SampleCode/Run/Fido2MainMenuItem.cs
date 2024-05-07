namespace AuthExample.Fido2SampleCode.Run
{
    public enum Fido2MainMenuItem
    {
        ListYubiKeys = 0,
        ChooseYubiKey = 1,
        SetPin = 4,
        ChangePin = 5,
        VerifyPin = 6,
        VerifyUv = 7,

        MakeCredential = 10,
        GetAssertion = 11,

        ListCredentials = 12,
        UpdateCredentialUserInfo = 13,
        DeleteCredential = 14,

        RetrieveLargeBlobData = 15,
        StoreLargeBlobData = 16,
        DeleteLargeBlobData = 17,

        GetBioInfo = 18,
        EnrollFingerprint = 19,
        SetBioTemplateFriendlyName = 21,
        RemoveBioEnrollment = 22,

        EnableEnterpriseAttestation = 23,
        ToggleAlwaysUv = 24,
        SetPinConfig = 25,

        Reset = 26,

        Exit = 27,
    }
}