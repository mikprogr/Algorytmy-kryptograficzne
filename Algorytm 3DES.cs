using System;
using System.Security.Cryptography;
using System.Text;

public class TripleDESEncryptor
{
    private byte[] key;
    private byte[] iv;

    public TripleDESEncryptor()
    {
        using (TripleDES tripleDES = TripleDES.Create())
        {
            tripleDES.KeySize = 192;
            tripleDES.GenerateKey();
            tripleDES.GenerateIV();
            key = tripleDES.Key;
            iv = tripleDES.IV;
        }
    }
    public byte[] Encrypt(string plaintext)
    {
        using (TripleDES tripleDES = TripleDES.Create())
        {
            tripleDES.Key = key;
            tripleDES.IV = iv;
            tripleDES.Mode = CipherMode.CBC;
            tripleDES.Padding = PaddingMode.PKCS7;

            using (ICryptoTransform encryptor = tripleDES.CreateEncryptor())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(plaintext);
                return encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            }
        }
    }
}