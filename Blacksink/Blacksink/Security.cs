using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blacksink
{
    /// <summary>
    /// Allows Black-Sink to securely store stuff (such as the user's Username and Password).
    /// </summary>
    public static class Security
    {
        // Please Note:
        // We could also use an empty byte[] and this code would still be secure, because 'ProtectedData' does not rely on this variable to do its job.
        private static byte[] randomness = Encoding.Unicode.GetBytes("0bv0f<k10d87y[p5-;'98y^%REch(B]mn3Dl[3");

        /// <summary>
        /// Encrypts a string using the 'System.Security.Cryptography.ProtectedData' class
        /// </summary>
        /// <param name="input">The string to encrypt</param>
        /// <returns>The encrypted string in base64 format</returns>
        public static string EncryptString(string input) {
            byte[] encrypted_bytes = ProtectedData.Protect(Encoding.Unicode.GetBytes(input), randomness, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encrypted_bytes);
        }

        /// <summary>
        /// Decrypts a base64 string using the 'System.Security.Cryptography.ProtectedData' class
        /// </summary>
        /// <param name="encrypted_string">The data to decrypt</param>
        /// <returns>The decrypted string</returns>
        public static string DecryptString(string encrypted_string) {
            try {
                byte[] decrypted_bytes = ProtectedData.Unprotect(Convert.FromBase64String(encrypted_string), randomness, DataProtectionScope.CurrentUser);
                return Encoding.Unicode.GetString(decrypted_bytes);
            } catch { return ""; }
        }
    }
}
