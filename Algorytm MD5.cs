using System;
using System.Security.Cryptography;
using System.Text;

public class MD5Hasher
{
    public static string ComputeHash(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Konwersja na ciąg hex
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2")); // Konwersja do formatu hex (np. "5d41402abc4b2a76b9719d911017c592")
            }
            return sb.ToString();
        }
    }
}