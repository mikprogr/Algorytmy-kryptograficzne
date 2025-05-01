using System;
using System.Security.Cryptography;
using System.Text;

public class AESEncryptor
{
    private byte[] key;
    private byte[] iv;

    public AESEncryptor()
    {
        Klucz klucz = new Klucz();
        key = GenerateFixedKey(klucz.GenerateKey()); //niezbędne do konwersji ze string na byte
        iv = new byte[16]; // IV musi mieć dokładnie 16 bajtów
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(iv); // Generowanie losowego IV
        }
    }

    private byte[] GenerateFixedKey(string inputKey)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputKey));
            Array.Resize(ref hash, 16); // Sprawdzenie, czy klucz na 16 bajtów
            return hash;
        }
    }

    public byte[] Encrypt(string text1)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(text1);
                return encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            }
        }
    }
}