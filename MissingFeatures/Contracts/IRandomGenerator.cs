namespace MissingFeatures.Contracts
{
    using System.Text;

    public interface IRandomGenerator
    {
        int NextInt32();

        long NextInt64();

        float NextSingle();

        double NextDouble();

        byte[] NextBytes(int count);

        char NextChar();

        string NextHexString(int length);

        string NextString(int maxLength, Encoding encoding = null);
    }
}
