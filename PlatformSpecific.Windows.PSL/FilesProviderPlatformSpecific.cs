using PlatformSpecific.Contracts.PSL;
using System.Diagnostics;

namespace PlatformSpecific.Windows.PSL
{
    public class FilesProviderPlatformSpecific : IFilesProviderPlatformSpecific
    {
        public FilesProviderPlatformSpecific()
        {
            Debug.WriteLine("Windows!");
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
