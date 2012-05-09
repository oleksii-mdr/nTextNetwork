using System.IO;

namespace nText.Core.Interface
{
    internal interface IStreamConverter
    {
        string ToText(Stream stream);
    }
}