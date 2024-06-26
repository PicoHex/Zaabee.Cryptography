namespace Aoxe.Cryptography.SymmetricAlgorithm.RC2;

public static partial class Rc2Helper
{
    public static byte[] Encrypt(
        byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode
    )
    {
        using var rc2 = System.Security.Cryptography.RC2.Create();
        return original.Encrypt(rc2, key, vector, cipherMode, paddingMode);
    }

    public static byte[] Decrypt(
        byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode
    )
    {
        using var rc2 = System.Security.Cryptography.RC2.Create();
        return encrypted.Decrypt(rc2, key, vector, cipherMode, paddingMode);
    }
}
