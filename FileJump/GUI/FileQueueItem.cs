using FileJump.Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump
{
    public class FileQueueItem
    {
        /// <summary>
        /// The local ID of the transfer.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The FileStructure containing all the file's information
        /// </summary>
        public FileStructure fileStruct { get; set; }

        /// <summary>
        /// The Parent panel. Everything else goes under it
        /// </summary>
        public Panel panel_Parent { get; set; }

        /// <summary>
        /// The PictureBox for showing the icon preview
        /// </summary>
        public PictureBox pBox_Icon { get; set; }

        /// <summary>
        /// The PictureBox for showing the success or fail checkmark
        /// </summary>
        public PictureBox pBox_Checkmark { get; set; }

        /// <summary>
        /// The delete button.
        /// </summary>
        public Button btn_Delete { get; set; }

        /// <summary>
        /// The text to show the file name under the preview
        /// </summary>
        public Label label_FileName { get; set; }

        /// <summary>
        /// The state of the queue
        /// </summary>
        public FileQueueState CurrentState { get; set; }
    }
}
