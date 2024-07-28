using OtpNet;
using QRCoder;
using System;
using System.Drawing;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Generate a new secret key
        var secret = "JBSWY3DPEHPK3PXP";

        //var totp = new Totp(bytes, step: 300);
        string user = "user@example.com";  // Replace with your user's identifier
        string issuer = "MyApp";  // Replace with your app's name
        string totpUri = $"otpauth://totp/{issuer}:{user}?secret={secret}&issuer={issuer}";

        // Generate QR code
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(totpUri, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new PngByteQRCode(qrCodeData);
        var qrCodeImage = qrCode.GetGraphic(20);

        // Save the QR code as an image
        string filePath = "C:\\Users\\ASUS\\Desktop\\Qr\\qr_code.png";
        File.WriteAllBytes(filePath, qrCodeImage);
        Console.WriteLine($"QR Code saved to {filePath}");
    }
}
