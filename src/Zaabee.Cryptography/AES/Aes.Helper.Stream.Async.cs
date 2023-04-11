namespace Zaabee.Cryptography.AES;

public static partial class AesHelper
{
    public static async Task<MemoryStream> EncryptAsync(
        Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        CancellationToken cancellationToken = default)
    {
        var encrypted = new MemoryStream();
        await EncryptAsync(original, encrypted, key, vector, cipherMode, paddingMode, cancellationToken);
        return encrypted;
    }

    public static async Task EncryptAsync(
        Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        CancellationToken cancellationToken = default)
    {
        using (var aes = Aes.Create())
            await aes.EncryptAsync(original, encrypted, key, vector, cipherMode, paddingMode, cancellationToken);
        original.TrySeek(0, SeekOrigin.Begin);
        encrypted.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task<MemoryStream> DecryptAsync(
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        CancellationToken cancellationToken = default)
    {
        var decrypted = new MemoryStream();
        await DecryptAsync(encrypted, decrypted, key, vector, cipherMode, paddingMode, cancellationToken);
        return decrypted;
    }

    public static async Task DecryptAsync(
        Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        CancellationToken cancellationToken = default)
    {
        using var aes = Aes.Create();
        await aes.DecryptAsync(encrypted, decrypted, key, vector, cipherMode, paddingMode, cancellationToken);
    }
}