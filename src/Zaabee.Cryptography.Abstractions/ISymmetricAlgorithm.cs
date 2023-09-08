namespace Zaabee.Cryptography.Abstractions;

public interface ISymmetricAlgorithm
{
    byte[] Encrypt(byte[] bytes, byte[] key, byte[] iv);
    MemoryStream Encrypt(Stream inputStream, byte[] key, byte[] iv);
    Task<MemoryStream> EncryptAsync(Stream inputStream, byte[] key, byte[] iv);
    byte[] Decrypt(byte[] bytes, byte[] key, byte[] iv);
    MemoryStream Decrypt(Stream inputStream, byte[] key, byte[] iv);
    Task<MemoryStream> DecryptAsync(Stream inputStream, byte[] key, byte[] iv);
}