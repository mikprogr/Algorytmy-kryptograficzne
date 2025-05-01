using System;
using System.Security.Cryptography;
using System.Text;

public class RSAEncryptor
{
    private RSA rsa;
    public RSAEncryptor()
    {
        rsa = RSA.Create(); // Tworzenie nowej instancji RSA
        rsa.KeySize = 2048; // Ustawienie klucza na 2048 bitów (zalecane minimum)
    }

    // Pobieranie klucza publicznego (do szyfrowania)
    public string GetPublicKey()
    {
        return Convert.ToBase64String(rsa.ExportRSAPublicKey());
    }

    // Pobieranie klucza prywatnego (do deszyfrowania)
    public string GetPrivateKey()
    {
        return Convert.ToBase64String(rsa.ExportRSAPrivateKey());
    }

    // Szyfrowanie tekstu kluczem publicznym
    public byte[] Encrypt(string text2)
    {
        byte[] data = Encoding.UTF8.GetBytes(text2);
        return rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
    }
}