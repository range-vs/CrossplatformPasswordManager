using PlatformSpecific.Contracts.PSL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossplatformPasswordManagerPL.Desktop.Files
{
    public class FilesProvider : IFilesProviderPlatformSpecific
    {
        public FilesProvider()
        {
            // разделение - линукс, мак или винда
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
