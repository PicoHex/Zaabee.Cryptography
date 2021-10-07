using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace Zaabee.Cryptographic.UnitTest
{
    public class RsaTest
    {
        [Fact]
        public void Test()
        {
            RsaHelper.Encoding = Encoding.UTF8;
            RsaHelper.Padding = RSAEncryptionPadding.OaepSHA256;
            Assert.Equal(RsaHelper.Encoding, Encoding.UTF8);
            Assert.Equal(RsaHelper.Padding, RSAEncryptionPadding.OaepSHA256);
        }

        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void BytesPkcs1Test(string original)
        {
            var (privateKey, publicKey) = RsaHelper.GenerateParameters();
            var originalBytes = RsaHelper.Encoding.GetBytes(original);
            var encryptBytes = originalBytes.EncryptByRsa(publicKey, RSAEncryptionPadding.Pkcs1);
            var decryptBytes = encryptBytes.DecryptByRsa(privateKey, RSAEncryptionPadding.Pkcs1);
            Assert.True(Equal(originalBytes, decryptBytes));
        }

        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void StringPkcs1Test(string original)
        {
            var (privateKey, publicKey) = RsaHelper.GenerateParameters();
            var encryptBytes = original.EncryptByRsa(publicKey, RSAEncryptionPadding.Pkcs1);
            var decrypt = encryptBytes.DecryptToStringByRsa(privateKey, RSAEncryptionPadding.Pkcs1);
            Assert.Equal(original, decrypt);
        }

        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void BytesSha1Test(string original)
        {
            var (privateKey, publicKey) = RsaHelper.GenerateParameters();
            var originalBytes = RsaHelper.Encoding.GetBytes(original);
            var encryptBytes = originalBytes.EncryptByRsa(publicKey, RSAEncryptionPadding.OaepSHA1);
            var decryptBytes = encryptBytes.DecryptByRsa(privateKey, RSAEncryptionPadding.OaepSHA1);
            Assert.True(Equal(originalBytes, decryptBytes));
        }

        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void StringSha1Test(string original)
        {
            var (privateKey, publicKey) = RsaHelper.GenerateParameters();
            var encryptBytes = original.EncryptByRsa(publicKey, RSAEncryptionPadding.OaepSHA1);
            var decrypt = encryptBytes.DecryptToStringByRsa(privateKey, RSAEncryptionPadding.OaepSHA1);
            Assert.Equal(original, decrypt);
        }

#if !NET48

        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void BytesSha256Test(string original)
        {
            var (privateKey, publicKey) = RsaHelper.GenerateParameters();
            var originalBytes = RsaHelper.Encoding.GetBytes(original);
            var encryptBytes = originalBytes.EncryptByRsa(publicKey, RSAEncryptionPadding.OaepSHA256);
            var decryptBytes = encryptBytes.DecryptByRsa(privateKey, RSAEncryptionPadding.OaepSHA256);
            Assert.True(Equal(originalBytes, decryptBytes));
        }

        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void StringSha256Test(string original)
        {
            var (privateKey, publicKey) = RsaHelper.GenerateParameters();
            var encryptBytes = original.EncryptByRsa(publicKey, RSAEncryptionPadding.OaepSHA256);
            var decrypt = encryptBytes.DecryptToStringByRsa(privateKey, RSAEncryptionPadding.OaepSHA256);
            Assert.Equal(original, decrypt);
        }

        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void BytesSha384Test(string original)
        {
            var (privateKey, publicKey) = RsaHelper.GenerateParameters();
            var originalBytes = RsaHelper.Encoding.GetBytes(original);
            var encryptBytes = originalBytes.EncryptByRsa(publicKey, RSAEncryptionPadding.OaepSHA384);
            var decryptBytes = encryptBytes.DecryptByRsa(privateKey, RSAEncryptionPadding.OaepSHA384);
            Assert.True(Equal(originalBytes, decryptBytes));
        }

        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void StringSha384Test(string original)
        {
            var (privateKey, publicKey) = RsaHelper.GenerateParameters();
            var encryptBytes = original.EncryptByRsa(publicKey, RSAEncryptionPadding.OaepSHA384);
            var decrypt = encryptBytes.DecryptToStringByRsa(privateKey, RSAEncryptionPadding.OaepSHA384);
            Assert.Equal(original, decrypt);
        }

        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void BytesSha512Test(string original)
        {
            var (privateKey, publicKey) = RsaHelper.GenerateParameters();
            var originalBytes = RsaHelper.Encoding.GetBytes(original);
            var encryptBytes = originalBytes.EncryptByRsa(publicKey, RSAEncryptionPadding.OaepSHA512);
            var decryptBytes = encryptBytes.DecryptByRsa(privateKey, RSAEncryptionPadding.OaepSHA512);
            Assert.True(Equal(originalBytes, decryptBytes));
        }

        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void StringSha512Test(string original)
        {
            var (privateKey, publicKey) = RsaHelper.GenerateParameters();
            var encryptBytes = original.EncryptByRsa(publicKey, RSAEncryptionPadding.OaepSHA512);
            var decrypt = encryptBytes.DecryptToStringByRsa(privateKey, RSAEncryptionPadding.OaepSHA512);
            Assert.Equal(original, decrypt);
        }

#endif

        private static bool Equal(byte[] first, byte[] second)
        {
            if (first is null || second is null) return false;
            if (first.Length != second.Length) return false;
            return !first.Where((t, i) => t != second[i]).Any();
        }
    }
}