namespace Aoxe.Cryptography.SymmetricAlgorithm.TripleDES;

public static partial class TripleDesExtensions
{
    public static ValueTask EncryptByTripleDesAsync(
        this Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => TripleDesHelper.EncryptAsync(original, encrypted, key, vector, cipherMode, paddingMode);

    public static ValueTask DecryptByTripleDesAsync(
        this Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => TripleDesHelper.DecryptAsync(encrypted, decrypted, key, vector, cipherMode, paddingMode);

    public static ValueTask<MemoryStream> EncryptByTripleDesAsync(
        this Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => TripleDesHelper.EncryptAsync(original, key, vector, cipherMode, paddingMode);

    public static ValueTask<MemoryStream> DecryptByTripleDesAsync(
        this Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => TripleDesHelper.DecryptAsync(encrypted, key, vector, cipherMode, paddingMode);
}
