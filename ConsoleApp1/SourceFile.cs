using System;
using Greenhouse.Utilities;

namespace Greenhouse.Data.Model.Setup
{
    [Serializable]
    public class SourceFile : BasePOCO
    {
        
        public int SourceFileID { get; set; }
        public string SourceFileName { get; set; }
        public string RegexMask { get; set; }
        public int SourceID { get; set; }
        public bool IsActive { get; set; }
        public int DeliveryOffsetOverride { get; set; }

        public string PartitionColumn { get; set; }
        public string FileDelimiter { get; set; }

        public int? PartitionCount { get; set; } = 12;
        public bool HasHeader { get; set; }

        private RegexCodec _fileRegexCodec;
        
        public RegexCodec FileRegexCodec
        {
            get
            {
                if (_fileRegexCodec == null)
                {
                    _fileRegexCodec = new RegexCodec(this.RegexMask);
                }
                return _fileRegexCodec;
            }
        }
    }
}
