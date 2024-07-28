using OtpNet;
using System;
using System.Drawing;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Base32 secret key generated in the previous step
        string base32Secret = "JBSWY3DPEHPK3PXP";

        // Decode the base32 secret
        var key = Base32Encoding.ToBytes(base32Secret);

        // Create a TOTP generator
        var totp = new Totp(key);

        // Ask the user to enter a TOTP code
        Console.Write("Enter the TOTP code: ");
        var userInput = Console.ReadLine();

        // Validate the TOTP code
        bool isValid = totp.VerifyTotp(userInput, out long timeStepMatched, VerificationWindow.RfcSpecifiedNetworkDelay);

        if (isValid)
        {
            Console.WriteLine("The TOTP code is valid.");
        }
        else
        {
            Console.WriteLine("The TOTP code is invalid.");
        }
    }
}
