using System.Threading.Tasks;

namespace Bluestone.CrossCuttingConcerns.HtmlGenerator
{
    public interface IHtmlGenerator
    {
        Task<string> GenerateAsync(string template, object model);
    }
}
