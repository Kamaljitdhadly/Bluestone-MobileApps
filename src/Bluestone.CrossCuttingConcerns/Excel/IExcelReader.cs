using System.IO;

namespace Bluestone.CrossCuttingConcerns.Excel
{
    public interface IExcelReader<T>
    {
        T Read(Stream stream);
    }
}
