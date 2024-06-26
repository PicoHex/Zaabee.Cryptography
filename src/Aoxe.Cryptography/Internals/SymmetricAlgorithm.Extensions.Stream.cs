namespace Aoxe.Cryptography.Internals;

internal static partial class SymmetricAlgorithmExtensions
{
    internal static void Encrypt(
        this Stream original,
        System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm,
        Stream encrypted,
        byte[]? key = null,
        byte[]? vector = null,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode
    )
    {
        symmetricAlgorithm.Mode = cipherMode;
        symmetricAlgorithm.Padding = paddingMode;
        using (
            var encryptor =
                key is not null && vector is not null
                    ? symmetricAlgorithm.CreateEncryptor(key, vector)
                    : symmetricAlgorithm.CreateEncryptor()
        )
        {
#if NETSTANDARD2_0
            var ms = new MemoryStream();
            using (var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                original.CopyTo(cryptoStream);
                cryptoStream.FlushFinalBlock();
                ms.Seek(0, SeekOrigin.Begin);
                ms.CopyTo(encrypted);
            }
#else
            using (
                var cryptoStream = new CryptoStream(
                    encrypted,
                    encryptor,
                    CryptoStreamMode.Write,
                    true
                )
            )
                original.CopyTo(cryptoStream);
#endif
        }
        original.TrySeek(0, SeekOrigin.Begin);
        encrypted.TrySeek(0, SeekOrigin.Begin);
    }

    internal static void Decrypt(
        this Stream encrypted,
        System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm,
        Stream decrypted,
        byte[]? key = null,
        byte[]? vector = null,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode
    )
    {
        symmetricAlgorithm.Mode = cipherMode;
        symmetricAlgorithm.Padding = paddingMode;
        using (
            var decryptor =
                key is not null && vector is not null
                    ? symmetricAlgorithm.CreateDecryptor(key, vector)
                    : symmetricAlgorithm.CreateDecryptor()
        )
        {
#if NETSTANDARD2_0
            var ms = new MemoryStream();
            encrypted.CopyTo(ms);
            ms.Seek(0, SeekOrigin.Begin);
            using (var csDecrypt = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                csDecrypt.CopyTo(decrypted);
#else
            using (
                var csDecrypt = new CryptoStream(encrypted, decryptor, CryptoStreamMode.Read, true)
            )
                csDecrypt.CopyTo(decrypted);
#endif
        }
        encrypted.TrySeek(0, SeekOrigin.Begin);
        decrypted.TrySeek(0, SeekOrigin.Begin);
    }
}
