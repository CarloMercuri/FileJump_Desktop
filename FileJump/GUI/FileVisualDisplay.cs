using FileJump.GUI;
using FileJump.Network;
using FileJump_Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump
{
    public class FileVisualDisplay
    {
        /// <summary>
        /// The local ID of the transfer.
        /// </summary>
        public int ID { get; set; }

        public FileUploadVisual MainVisualForm { get; set; }

        /// <summary>
        /// The OnlineFileStructure containing all the file's information
        /// </summary>
        public OnlineFileStructure FileStructOnline { get; set; }

        /// <summary>
        /// The LocalFileStructure containing all the file's information
        /// </summary>
        public LocalFileStructure FileStructLocal { get; set; }

        /// <summary>
        /// The Parent panel. Everything else goes under it
        /// </summary>
        public Panel panel_Parent { get; set; }

       /// <summary>
       /// The TransparentControl that lays on top of every other control to intercept mouse events
       /// </summary>
        public TransparentControl panel_MouseEvents { get; set; }

        /// <summary>
        /// The panel that shows the thumbnail
        /// </summary>
        public Panel panel_Thumbnail { get; set; }

        /// <summary>
        /// The PictureBox for showing the icon preview
        /// </summary>
        public PictureBox pBox_Icon { get; set; }

        /// <summary>
        /// The PictureBox for showing the success or fail checkmark
        /// </summary>
        public PictureBox pBox_Checkmark { get; set; }

        /// <summary>
        /// The panel to show a success checkmark
        /// </summary>
        public TransparentControl panel_CheckMark { get; set; }

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
        public FileStatus CurrentState { get; set; }

        /// <summary>
        /// Wether the file is selected or not
        /// </summary>
        public bool IsSelected { get; set; }

        public ProgressBar progress_Download { get; set; }

        public void UpdateProgress(int percent)
        {
            if(progress_Download != null)
            {
                progress_Download.Value = percent;
            }
            
        }
    }
}
