using Microsoft.AspNetCore.DataProtection;

public class DataProtectionService
{
    private readonly IDataProtector _protector;

    public DataProtectionService(IDataProtectionProvider dataProtectionProvider)
    {
        // Create a protector with a unique purpose string
        _protector = dataProtectionProvider.CreateProtector("UserPasswordProtector");
    }

    // Encrypts a plain password
    public string Protect(string plainPassword)
    {
        return _protector.Protect(plainPassword);
    }

    // Decrypts an encrypted password
    public string Unprotect(string encryptedPassword)
    {
        return _protector.Unprotect(encryptedPassword);
    }
}
