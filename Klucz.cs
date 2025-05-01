using System;
using System.Text;

public class Klucz
{
    private int KeyLength;
    private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    public Klucz()
    {
        string key = GenerateKey(); // Generowanie klucza w konstruktorze
        /*Console.WriteLine("Wygenerowany klucz AES: " + key);*/ // Bezpośrednie wypisanie klucza
    }

    public string GenerateKey()
    {
        Random random = new Random();
        StringBuilder sb = new StringBuilder(KeyLength);

        for (int i = 0; i <= KeyLength; i++)
        {
            sb.Append(chars[random.Next(chars.Length)]);
        }

        return sb.ToString(); 
    }
}
