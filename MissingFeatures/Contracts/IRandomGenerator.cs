namespace MissingFeatures.Contracts
{
    public interface IRandomGenerator
    {
        int NextInt32();

        long NextInt64();

        float NextSingle();

        double NextDouble();

        byte[] NextBytes(int count);

        char NextChar();

        string NextHexString(int length);
    }
}
