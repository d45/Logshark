using System.Collections.Generic;
using System.IO;
using LogShark.Shared.LogReading.Containers;

namespace LogShark.Shared.LogReading.Readers
{
    public class SimpleLinePerLineReader : ILogReader
    {
        private readonly Stream _stream;

        public SimpleLinePerLineReader(Stream stream)
        {
            _stream = stream;
        }

        public IEnumerable<ReadLogLineResult> ReadLines()
        {
            using var reader = new StreamReader(_stream);
            
            var lineNumber = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                ++lineNumber;
                if (line != null)
                {
                    yield return new ReadLogLineResult(lineNumber, line);
                }
            }
        }
    }
}