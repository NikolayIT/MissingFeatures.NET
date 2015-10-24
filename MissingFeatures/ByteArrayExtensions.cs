namespace MissingFeatures
{
    using System.IO;

    public static class ByteArrayExtensions
    {
        // http://stackoverflow.com/questions/4736155/how-do-i-convert-byte-to-stream-in-c
        public static Stream ToStream(this byte[] input)
        {
            var fileStream = new MemoryStream(input) { Position = 0 };
            return fileStream;
        }
    }
}
