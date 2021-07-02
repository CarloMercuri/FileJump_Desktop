using FileJump.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileJump.GUI
{
    public class FileUploadInstance
    {
        public int FileID { get; set; }

        public LocalFileStructure LocalFileStruct { get; set; }
        public FileUploadVisual VisualPanel { get; set; }
    }
}
