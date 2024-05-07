using System.Globalization;
using AuthExample.SharedSampleCode.Menu;
using Yubico.YubiKey;

namespace AuthExample.SharedSampleCode.YubiKeyOperations
{
    public static class ListYubiKeys
    {
        // List all the YubiKeys. If there ar none to be found, report that.
        // Always return true, even if there are no YubiKeys. After all, this
        // method is just determining which YubiKeys are available, and finding
        // none available is a successful completion of its task.
        public static bool RunListYubiKeys(Transport transport)
        {
            IEnumerable<IYubiKeyDevice> yubiKeyEnumerable = YubiKeyDevice.FindByTransport(transport);

            ReportResult(yubiKeyEnumerable);

            return true;
        }

        private static void ReportResult(IEnumerable<IYubiKeyDevice> yubiKeyEnumerable)
        {
            IEnumerable<IYubiKeyDevice> yubiKeyDevices = yubiKeyEnumerable as IYubiKeyDevice[] ?? yubiKeyEnumerable.ToArray();

            // Are there any?
            string outputList = "No YubiKeys found";
            if (yubiKeyDevices.Any())
            {
                outputList = "\n   YubiKeys:";
                foreach (IYubiKeyDevice current in yubiKeyDevices)
                {
                    int serial = 0;
                    if (!(current.SerialNumber is null))
                    {
                        serial = (int)current.SerialNumber;
                    }
                    string serialNumber = serial.ToString(CultureInfo.InvariantCulture);

                    string versionNumber = current.FirmwareVersion.ToString();
                    outputList += "\n   " + serialNumber + " : " + versionNumber;
                }
                outputList += "\n";
            }

            SampleMenu.WriteMessage(MessageType.Special, 0, outputList);
        }
    }
}