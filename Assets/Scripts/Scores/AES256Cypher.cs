using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows.WebCam;

/// <summary>
/// https://learn.microsoft.com/en-us/answers/questions/1291569/how-to-implement-a-c-aes-256-encrypt-and-decrypt-f
/// </summary>
public class AES256Cypher
{
    public string Encrypt(string text)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = new byte[32];
            aesAlg.IV = new byte[16];
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            byte[] encryptedBytes;
            using (var msEncrypt = new System.IO.MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(text);
                    csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                }

                encryptedBytes = msEncrypt.ToArray();
            }
            return Convert.ToBase64String(encryptedBytes);
        }
    }

    public string Decrypt(string text)
    {
        using (Aes aesAlg = Aes.Create())
        {
            byte[] ciphertext = Convert.FromBase64String(text);
            aesAlg.Key = new byte[32];
            aesAlg.IV = new byte[16];
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            byte[] decryptedBytes;
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
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
