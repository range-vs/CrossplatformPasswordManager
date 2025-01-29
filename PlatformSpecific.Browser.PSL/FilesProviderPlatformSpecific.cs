using PlatformSpecific.Contracts.PSL;
using System.Diagnostics;

namespace PlatformSpecific.Browser.PSL
{
    public class FilesProviderPlatformSpecific : IFilesProviderPlatformSpecific
    {
        public FilesProviderPlatformSpecific()
        {
            Debug.WriteLine("Browser!");
        }

        public string GetLocalStoragePath()
        {
            return "";
        }

        public bool WriteFile(string path, string data)
        {
            return true;
        }

        public bool WriteFile(string path, byte[] data)
        {
            return true;
        }

    }
}
