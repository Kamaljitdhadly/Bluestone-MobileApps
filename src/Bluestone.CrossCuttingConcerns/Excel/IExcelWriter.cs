using System.IO;

namespace Bluestone.CrossCuttingConcerns.Excel
{
    public interface IExcelWriter<T>
    {
        void Write(T data, Stream stream);
    }
}
