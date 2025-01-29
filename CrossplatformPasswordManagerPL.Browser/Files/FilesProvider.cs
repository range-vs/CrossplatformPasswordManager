using PlatformSpecific.Contracts.PSL;
using System.Diagnostics;

namespace CrossplatformPasswordManagerPL.Browser.Files
{
    public class FilesProvider : IFilesProviderPlatformSpecific
    {
        public FilesProvider()
        {
            // разделение - линукс, мак или винда
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
