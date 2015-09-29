namespace MissingFeatures
{
    using System.IO;

    public static class StreamExtensions
    {
        // http://stackoverflow.com/questions/221925/creating-a-byte-array-from-a-stream
        public static byte[] ToByteArray(this Stream input)
        {
            using (var memoryStream = new MemoryStream())
            {
                input.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
