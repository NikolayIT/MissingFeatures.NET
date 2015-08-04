namespace MissingFeatures
{
    using System;
    using System.Security.Cryptography;

    public class RandomGenerator
    {
        private readonly RandomNumberGenerator randomGenerator;

        public RandomGenerator()
        {
            this.randomGenerator = RandomNumberGenerator.Create();
        }

        public int NextInt32()
        {
            var bytes = this.GetRandomBytes(sizeof(int));

            var value = BitConverter.ToInt32(bytes, 0);

            return value;
        }

        public long NextInt64()
        {
            var bytes = this.GetRandomBytes(sizeof(long));

            var value = BitConverter.ToInt64(bytes, 0);

            return value;
        }

        public float NextSingle()
        {
            var bytes = this.GetRandomBytes(sizeof(float));

            var value = BitConverter.ToSingle(bytes, 0);

            return value;
        }

        public double NextDouble()
        {
            var bytes = this.GetRandomBytes(sizeof(double));

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

        public char NextChar()
        {
            var bytes = this.GetRandomBytes(sizeof(char));

            var value = BitConverter.ToChar(bytes, 0);

            return value;
        }

        public string NextHexString(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", "String length cannot be negative.");
            }

            var bytes = this.GetRandomBytes(length);

            var value = BitConverter.ToString(bytes);

            return value;
        }

        private byte[] GetRandomBytes(int count)
        {
            var bytes = new byte[count];

            this.randomGenerator.GetBytes(bytes);

            return bytes;
        }
    }
}
