using System.Collections.Generic;
using System.IO;

namespace Bluestone.CrossCuttingConcerns.Csv
{
    public interface ICsvReader<T>
    {
        IEnumerable<T> Read(Stream stream);
    }
}
