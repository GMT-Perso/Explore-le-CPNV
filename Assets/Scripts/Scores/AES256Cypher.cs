using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows.WebCam;

/// <summary>
/// This class is used to encrypt and decrypt data with AES256.
/// https://learn.microsoft.com/en-us/answers/questions/1291569/how-to-implement-a-c-aes-256-encrypt-and-decrypt-f
/// </summary>
public class AES256Cypher
{
    /// <summary>
    /// It encrypts the data with AES256 to base 64 text.
    /// </summary>
    /// <param name="text"> The text that have to be encrypted. </param>
    /// <returns> Returns the encrypted text in a base 64 string. </returns>
    public string Encrypt(string text)
    {
        using (Aes aesAlg = Aes.Create())
        {
            // Create keys needed for encryption
            aesAlg.Key = new byte[32];
            aesAlg.IV = new byte[16];
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            byte[] encryptedBytes;

            // Encrypts the text and return a bytes array.
            using (var msEncrypt = new System.IO.MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(text);
                    csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                }

                encryptedBytes = msEncrypt.ToArray();
            }

            // Convert the bytes in a base 64 string when the data is returned.
            return Convert.ToBase64String(encryptedBytes);
        }
    }

    /// <summary>
    /// Decrypts the text encrypted in AES 256.
    /// </summary>
    /// <param name="text"> The text that need to be decrypted. </param>
    /// <returns> Returns the string of the text decrypted. </returns>
    public string Decrypt(string text)
    {
        using (Aes aesAlg = Aes.Create())
        {
            // Convert the base 64 text in bytes.
            byte[] ciphertext = Convert.FromBase64String(text);

            // Create keys needed for encryption
            aesAlg.Key = new byte[32];
            aesAlg.IV = new byte[16];
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            byte[] decryptedBytes;

            // Decrypts the text and return it decrypted in bytes.
            using (var msDecrypt = new System.IO.MemoryStream(ciphertext))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var msPlain = new System.IO.MemoryStream())
                    {
                        csDecrypt.CopyTo(msPlain);
                        decryptedBytes = msPlain.ToArray();
                    }
                }
            }

            // Convert the bytes in a string to be able to reade it when the data is returned.
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
