namespace Zaabee.Cryptography.Abstractions;

public interface IHashAlgorithm
{
    byte[] ComputeHash(byte[] bytes);
    byte[] ComputeHash(Stream inputStream);
    byte[] ComputeHash(string str);
    string ComputeHashString(byte[] bytes);
    string ComputeHashString(Stream inputStream);
    string ComputeHashString(string str);

#if !NETSTANDARD2_0
    ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    );
    ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    );
#endif
}
