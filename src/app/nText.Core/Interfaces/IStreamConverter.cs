using System.IO;

namespace nText.Core.Interfaces
{
    /// <summary>
    /// Reads stream to the end and returns a string from it 
    /// </summary>
    //NOTE  This interface shall be removed as it kills the whole 
    //      spirit of Streams
    internal interface IStreamConverter
    {
        string ToText(Stream stream);
    }
}