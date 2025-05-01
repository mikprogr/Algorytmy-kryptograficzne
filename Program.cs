using System;
using System.Diagnostics;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Menu wyboru algorytmu");
        Console.WriteLine("1. Algorytm AES.");
        Console.WriteLine("2. Algorytm RSA.");
        Console.WriteLine("3. Algorytm 3DES. ");
        Console.WriteLine("4. Algorytm MD5.");
        Console.WriteLine();
        Console.Write("Wybierz cyfrę 1-4: ");
        int cyfra = int.Parse(Console.ReadLine());

        switch (cyfra)
        {
            case 1:
                AESEncryptor aesEncryptor = new AESEncryptor(); // Inicjalizacja szyfrowania

                Console.Write("Podaj tekst do zaszyfrowania: ");
                string tekst1 = Console.ReadLine(); // Pobranie tekstu od użytkownika

                Stopwatch swAES = Stopwatch.StartNew();
                byte[] szyfr = aesEncryptor.Encrypt(tekst1); // Szyfrowanie tekstu
                swAES.Stop();

                Console.WriteLine($"Zaszyfrowany tekst: {Convert.ToBase64String(szyfr)}");
                Console.WriteLine($"Czas potrzebny na zaszyfrowanie algorytmem AES wynosi: {swAES.Elapsed.TotalSeconds:F3} s"); //dokładność do 3 miejsc po przecinku

                break;
            case 2:
                RSAEncryptor rsaEncryptor = new RSAEncryptor();

                Console.Write("Podaj tekst do zaszyfrownaia: ");
                string tekst2 = Console.ReadLine();

                Stopwatch swRSA = Stopwatch.StartNew();
                byte[] zaszyfrowanytekst = rsaEncryptor.Encrypt(tekst2);
                swRSA.Stop();

                Console.WriteLine($"Zaszyfrowany tekst: {Convert.ToBase64String(zaszyfrowanytekst)}");
                Console.WriteLine($"Czas potrzebny na zaszyfrowanie algorytmem RSA wynosi: {swRSA.Elapsed.TotalSeconds:F3} s"); //dokładność do 3 miejsc po przecinku
                break;
            case 3:
                TripleDESEncryptor tripleDESEncryptor = new TripleDESEncryptor();

                Console.Write("Podaj tekst do zaszyfrowania: ");
                string tekst3 = Console.ReadLine();

                Stopwatch sw3DES = Stopwatch.StartNew();
                byte[] encryptedData = tripleDESEncryptor.Encrypt(tekst3);
                sw3DES.Stop();

                Console.WriteLine("Zaszyfrowany tekst: " + Convert.ToBase64String(encryptedData));
                Console.WriteLine($"Czas potrzebny na zaszyfrowanie algorytmem 3DES wynosi: {sw3DES.Elapsed.TotalSeconds:F3} s"); //dokładność do 3 miejsc po przecinku
                break;
            case 4:
                Console.Write("Podaj tekst do zahashowania: ");
                string input = Console.ReadLine();

                Stopwatch swMD5 = Stopwatch.StartNew();
                string hash = MD5Hasher.ComputeHash(input);
                swMD5.Stop();

                Console.WriteLine($"MD5 hash: {hash}");
                Console.WriteLine($"Czas potrzebny na utworzenie hashu algorytmem MD5 wynosi: {swMD5.Elapsed.TotalSeconds:F3} s"); //dokładność do 3 miejsc po przecinku
                break;
            default:
                Console.WriteLine("Nie wybrano żadnego algorytmu");
                break;
        }
    }
}