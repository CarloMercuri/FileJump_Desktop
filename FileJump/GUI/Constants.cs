﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileJump
{
    class Constants
    {
    }

    public enum GUIState
    {
        TransfersRunning = 1,
        WaitingForInput = 2,
        NoFilesSelected = 3,
        FilesSelected = 4,
        TransfersFinished = 5,
        NoDeviceSelected = 6,

        
    }
}
