using PlatformSpecific.Contracts.PSL.Sequrity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace CrossplatformPasswordManagerPL.Desktop.Sequrity
{
    public class OSAuth : IOSAuthPlatformSpecific
    {
        public OSAuth() { }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct CREDUI_INFO
        {
            public int cbSize;
            public IntPtr hwndParent;
            public string pszMessageText;
            public string pszCaptionText;
            public IntPtr hbmBanner;
        }

        // Return codes
        private enum CredUIReturnCodes : uint
        {
            NO_ERROR = 0,
            CANCELLED = 1223
        }

        // Flags
        [Flags]
        private enum PromptForWindowsCredentialsFlags : uint
        {
            GENERIC_CREDENTIALS = 0x1,
            DO_NOT_PERSIST = 0x2,
            REQUEST_ADMINISTRATOR = 0x4,
            EXCLUDE_CERTIFICATES = 0x8,
            REQUIRE_CERTIFICATE = 0x10,
            SHOW_SAVE_CHECK_BOX = 0x40,
            ALWAYS_SHOW_UI = 0x80,
            REQUIRE_SMARTCARD = 0x100,
            PASSWORD_ONLY_OK = 0x200,
            VALIDATE_USERNAME = 0x400,
            COMPLETE_USERNAME = 0x800,
            PERSIST = 0x1000,
            SERVER_CREDENTIAL = 0x4000,
            EXPECT_CONFIRMATION = 0x20000
        }

        [DllImport("credui.dll", CharSet = CharSet.Unicode)]
        private static extern CredUIReturnCodes CredUIPromptForWindowsCredentials(
            ref CREDUI_INFO uiInfo,
            int authError,
            ref uint authPackage,
            IntPtr InAuthBuffer,
            uint InAuthBufferSize,
            out IntPtr refOutAuthBuffer,
            out uint refOutAuthBufferSize,
            ref bool fSave,
            PromptForWindowsCredentialsFlags flags
        );

        [DllImport("credui.dll", CharSet = CharSet.Unicode)]
        private static extern bool CredUnPackAuthenticationBuffer(
            int dwFlags,
            IntPtr pAuthBuffer,
            uint cbAuthBuffer,
            StringBuilder pszUserName,
            ref int pcchMaxUserName,
            StringBuilder pszDomainName,
            ref int pcchMaxDomainame,
            StringBuilder pszPassword,
            ref int pcchMaxPassword
        );

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool LogonUser(
        string lpszUsername,
        string lpszDomain,
        string lpszPassword,
        int dwLogonType,
        int dwLogonProvider,
        out IntPtr phToken
    );

        private bool PromptForWindowsLogin(out string userName, out string password)
        {
            userName = null;
            password = null;

            var credUI = new CREDUI_INFO
            {
                cbSize = Marshal.SizeOf(typeof(CREDUI_INFO)),
                pszCaptionText = "Подтверждение доступа",
                pszMessageText = "Введите учётные данные Windows для продолжения",
                hwndParent = IntPtr.Zero,
                hbmBanner = IntPtr.Zero
            };

            uint authPackage = 0;
            IntPtr outCredBuffer = IntPtr.Zero;
            uint outCredSize;
            bool save = false;

            var result = CredUIPromptForWindowsCredentials(
                ref credUI,
                0,
                ref authPackage,
                IntPtr.Zero,
                0,
                out outCredBuffer,
                out outCredSize,
                ref save,
                PromptForWindowsCredentialsFlags.GENERIC_CREDENTIALS
            );

            if (result == CredUIReturnCodes.NO_ERROR)
            {
                var maxUser = 100;
                var maxDomain = 100;
                var maxPassword = 100;
                var userBuf = new StringBuilder(maxUser);
                var domainBuf = new StringBuilder(maxDomain);
                var passBuf = new StringBuilder(maxPassword);

                bool unpacked = CredUnPackAuthenticationBuffer(
                    0,
                    outCredBuffer,
                    outCredSize,
                    userBuf,
                    ref maxUser,
                    domainBuf,
                    ref maxDomain,
                    passBuf,
                    ref maxPassword
                );

                Marshal.FreeCoTaskMem(outCredBuffer);

                if (unpacked)
                {
                    userName = userBuf.ToString();
                    password = passBuf.ToString();

                    return true; 
                }

                return false; 
            }
            else if (result == CredUIReturnCodes.CANCELLED)
            {
                return false;
            }

            return true;
        }

        private bool ValidateCredentials(string username, string password)
        {
            string domain = null;
            string user = username;

            // Разделяем "DOMAIN\\User" или "User@domain"
            if (username.Contains("\\"))
            {
                var parts = username.Split('\\');
                domain = parts[0];
                user = parts[1];
            }
            else if (username.Contains("@"))
            {
                // UPN — имя в форме email (user@domain.local)
                domain = null;
                user = username;
            }

            const int LOGON32_LOGON_INTERACTIVE = 2;
            const int LOGON32_PROVIDER_DEFAULT = 0;

            return LogonUser(user, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, out var tokenHandle);
        }

        public async Task<bool> RequestAuth()
        {
            return await Task.Run(() =>
            {
                var result = PromptForWindowsLogin(out var user, out var pass);
                if (result)
                {
                    return ValidateCredentials(user, pass);
                }
                return false;
            });
        }
    }
}
