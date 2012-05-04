using System.IO;

namespace nText.Core
{
    public interface IStreamConverter
    {
        string ToText(Stream stream);
    }
}