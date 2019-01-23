using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IFile
    {

        Uri Uri { get; }
        bool Exists { get; }
        DateTime LastWriteTimeUtc { get; }
        string Name { get; }
        string FullName { get; }
        string Extension { get; }
        string ContentType { get; }
        long Length { get; }

    }
}



