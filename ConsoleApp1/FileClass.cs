using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FileClass 
    {
        public FileClass()
        {
        }

       public Uri Uri { get; set; }

        public bool Exists { get; set; }

        public DateTime LastWriteTimeUtc { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public string Extension { get; set; }

        public string ContentType { get; set; }

        public long Length { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
