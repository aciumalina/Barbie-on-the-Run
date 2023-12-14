using System;
using System.Security.Cryptography;
using System.Text;

public class PasswordHasher
{
    // Genereaz? un salt aleatoriu
    private static string GenerateSalt()
    {
        byte[] saltBytes = new byte[32];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }

    // Hash-uieste parola folosind SHA-256 ?i salt
    public static string HashPassword(string password)
    {
        // Genereaz? un salt nou pentru fiecare parol?
        string salt = GenerateSalt();

        // Concateneaz? parola ?i salt-ul
        string combined = password + salt;

        // Converteste la bytes
        byte[] combinedBytes = Encoding.UTF8.GetBytes(combined);

        // Creeaz? un obiect de hash folosind SHA-256
        using (var sha256 = SHA256.Create())
        {
            // Calculeaz? hash-ul
            byte[] hashBytes = sha256.ComputeHash(combinedBytes);

            // Converteste hash-ul la string
            string hashedPassword = Convert.ToBase64String(hashBytes);

            // Concateneaz? salt-ul cu hash-ul ?i returneaz? rezultatul final
            return $"{salt}${hashedPassword}";
        }
    }

    // Verific? dac? parola introdus? se potrive?te cu hash-ul stocat
    public static bool VerifyPassword(string enteredPassword, string storedHash)
    {
        // Descompune hash-ul stocat în salt ?i hash-ul efectiv
        string[] parts = storedHash.Split('$');
        if (parts.Length != 2)
        {
            // Hash-ul stocat nu are formatul corect
            return false;
        }

        string salt = parts[0];
        string storedHashPart = parts[1];

        // Concateneaz? parola introdus? cu salt-ul
        string combined = enteredPassword + salt;

        // Converteste la bytes
        byte[] combinedBytes = Encoding.UTF8.GetBytes(combined);

        // Creeaz? un obiect de hash folosind SHA-256
        using (var sha256 = SHA256.Create())
        {
            // Calculeaz? hash-ul
            byte[] hashBytes = sha256.ComputeHash(combinedBytes);

            // Converteste hash-ul la string
            string enteredHashedPassword = Convert.ToBase64String(hashBytes);

            // Verific? dac? hash-ul introdus se potrive?te cu cel stocat
            return string.Equals(enteredHashedPassword, storedHashPart);
        }
    }
}
