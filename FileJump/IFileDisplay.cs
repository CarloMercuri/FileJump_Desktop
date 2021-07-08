using FileJump_Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileJump
{
    public interface IFileDisplay
    {
        IFileStructure FileStructure { get; set; }
    }
}
