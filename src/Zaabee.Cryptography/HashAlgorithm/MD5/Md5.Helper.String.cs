namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public static partial class Md5Helper
{
    public static string ComputeMd5(
        string str,
        Encoding? encoding = null)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return str.ToHashString(md5, encoding);
    }
}