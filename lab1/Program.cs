using System;
using System.Text;

class Program
{
    static void Main()
    {
        string operation = Console.ReadLine();
        int pseudoRandomNumber = int.Parse(Console.ReadLine());

        string[] rotor = new string[3];
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        for (int i = 0; i < 3; i++)
        {
            rotor[i] = Console.ReadLine();
        }

        string message = Console.ReadLine();

        if (operation == "ENCODE")
        {
            StringBuilder encodedMessage = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                int pos = (alphabet.IndexOf(message[i]) + pseudoRandomNumber + i) % 26;
                encodedMessage.Append(alphabet[pos]);
            }

            message = encodedMessage.ToString();
            Encode(ref message, rotor, alphabet);
        }
        else
        {
            Decode(ref message, rotor, alphabet);

            StringBuilder decodedMessage = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                int pos = alphabet.IndexOf(message[i]) - pseudoRandomNumber - i;
                while (pos < 0)
                {
                    pos += 26;
                }
                decodedMessage.Append(alphabet[pos]);
            }

            message = decodedMessage.ToString();
        }

        Console.WriteLine(message);
    }

    static void Encode(ref string message, string[] rotor, string alphabet)
    {
        foreach (string r in rotor)
        {
            message = EncodeAlphabet(message, alphabet, r);
        }
    }

    static void Decode(ref string message, string[] rotor, string alphabet)
    {
        for (int i = rotor.Length - 1; i >= 0; i--)
        {
            message = EncodeAlphabet(message, rotor[i], alphabet);
        }
    }

    static string EncodeAlphabet(string m, string a1, string a2)
    {
        StringBuilder value = new StringBuilder();

        for (int i = 0; i < m.Length; i++)
        {
            int pos = a1.IndexOf(m[i]);
            value.Append(a2[pos]);
        }

        return value.ToString();
    }
}