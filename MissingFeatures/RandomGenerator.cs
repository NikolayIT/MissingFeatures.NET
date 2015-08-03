namespace MissingFeatures
{
    using System;
    using System.Security.Cryptography;

    public class RandomGenerator
    {
        private const int Int32BytesCount = 4;
        private const int Int64BytesCount = 8;
        private const int SingleBytesCount = 4;
        private const int DoubleBytesCount = 8;

        private readonly RandomNumberGenerator randomGenerator;

        public RandomGenerator()
        {
            this.randomGenerator = RandomNumberGenerator.Create();
        }

        public int NextInt32()
        {
            var bytes = this.GetRandomBytes(Int32BytesCount);

            var value = BitConverter.ToInt32(bytes, 0);

            return value;
        }

        public long NextInt64()
        {
            var bytes = this.GetRandomBytes(Int64BytesCount);

            var value = BitConverter.ToInt64(bytes, 0);

            return value;
        }

        public float NextSingle()
        {
            var bytes = this.GetRandomBytes(SingleBytesCount);

            var value = BitConverter.ToSingle(bytes, 0);

            return value;
        }

        public double NextDouble()
        {
            var bytes = this.GetRandomBytes(DoubleBytesCount);

            var value = BitConverter.ToDouble(bytes, 0);

            return value;
        }

        public byte[] NextBytes(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "Bytes count cannot be negative.");
            }

            var bytes = this.GetRandomBytes(count);

            return bytes;
        }

        private byte[] GetRandomBytes(int count)
        {
            var bytes = new byte[count];

            this.randomGenerator.GetBytes(bytes);

            return bytes;
        }
    }
}
