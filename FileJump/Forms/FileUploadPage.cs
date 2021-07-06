using FileJump.CustomControls;
using FileJump.GUI;
using FileJump.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.Forms
{
    public partial class FileUploadPage : Form
    {
        RoundedCornersPanel MainPanel;
        Panel DragDropPanelBG;
        Panel DragDropPanel;

        // top bar hack
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]

        public static extern bool ReleaseCapture();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private FlowLayoutPanel panel_FlowLayout;
        private List<FileUploadInstance> CurrentFiles = new List<FileUploadInstance>();

        // Test

        private bool DrawMainPanelHighlight { get; set; }

        // Form references
        private MainPage _mainPage;

        public FileUploadPage()
        {
            InitializeComponent();
            InitializeTopBar();



            CreateMainPanel();
            //Test();
        }

        public FileUploadPage(MainPage mainPage)
        {
            _mainPage = mainPage;

            InitializeComponent();
            InitializeForm();

            CreateMainPanel();
            CreateDragDropPanel();

            RoundedButton btn = new RoundedButton(60, 30);
            btn.Location = new Point(500, 150);
            btn.Size = new Size(100, 50);
            

            this.Controls.Add(btn);

            
            //Test();
        }

        private void InitializeForm()
        {
            InitializeTopBar();
            this.FormClosing += FormClosingEvent;
            
        }



        private void Test()
        {
            for (int i = 0; i < 7; i++)
            {
                string file = "C:/back/test.jpeg";

                LocalFileStructure fStruct = new LocalFileStructure();

                FileInfo fInfo = new FileInfo(file);
                fStruct.FilePath = file;
                fStruct.FileExtension = Path.GetExtension(file);
                fStruct.FileName = Path.GetFileNameWithoutExtension(file);
                fStruct.FileSize = fInfo.Length;
                fStruct.FullName = fInfo.Name;

                AddFileVisual(fStruct, 50);

                string file2 = "C:/back/carlo_and_tanja.jpg";

                LocalFileStructure fStruct2 = new LocalFileStructure();

                FileInfo fInfo2 = new FileInfo(file2);
                fStruct2.FilePath = file2;
                fStruct2.FileExtension = Path.GetExtension(file2);
                fStruct2.FileName = Path.GetFileNameWithoutExtension(file2);
                fStruct2.FileSize = fInfo2.Length;
                fStruct2.FullName = fInfo2.Name;

                AddFileVisual(fStruct2, 50 + 70 + 20);
            }
            

        }

        private void AddFileVisual(LocalFileStructure fileStruct, int y)
        {

            FileUploadInstance instance = new FileUploadInstance()
            {
            };

            FileUploadVisual visual = new FileUploadVisual(20, y, panel_FlowLayout.Width - 25, 70, fileStruct);

            //visual.AddToControl(MainPanel);
            visual.AddToControl(panel_FlowLayout);

        }

        private void CreateMainPanel()
        {
            MainPanel = new RoundedCornersPanel();
            MainPanel.BorderRadius = 15;
            MainPanel.Location = new Point(20, 40);
            MainPanel.Size = new Size(400, 500);

            //MainPanel.Paint += MainPanelPaint;

            this.Controls.Add(MainPanel);



            Label lbl_Header = new Label()
            {
                Location = new Point(MainPanel.Width / 2 - 60, 15),
                ForeColor = Color.FromArgb(255, 120, 120, 120),
                BackColor = Color.Transparent,
                Font = new Font("Bahnschrift", 14),
                Text = "File Upload",
                Width = 200
            };

            MainPanel.Controls.Add(lbl_Header);

            MainPanel.DrawDivider();

            //
            // Flow panel
            //

            int flow_left_offset = 20;
            int flow_top_offset = 60;

            panel_FlowLayout = new CustomFlowLayoutPanel()
            {
                Size = new Size(MainPanel.Width - flow_left_offset - 22, MainPanel.Height - flow_top_offset - 30),
                Location = new Point(flow_left_offset, flow_top_offset),
                BackColor = Color.Transparent,
                //BackColor = Color.FromArgb(255, 183, 210, 197),
                AutoScroll = true,
                BorderStyle = BorderStyle.None
            };

            panel_FlowLayout.AutoScrollMargin = new Size(100, 20);
            //panel_FlowLayout.AutoScroll = false;
            //panel_FlowLayout.HorizontalScroll.Enabled = false;
            //panel_FlowLayout.AutoScroll = true;
            panel_FlowLayout.VerticalScroll.Enabled = true;

            //panel_FlowLayout.BackgroundImage = Properties.Resources.BG2;
            panel_FlowLayout.BackgroundImageLayout = ImageLayout.Zoom;

            MainPanel.Controls.Add(panel_FlowLayout);
        }

        private void MainPanelPaint(object sender, PaintEventArgs e)
        {

            int _dividerHeight = 50;
            int _shadowThickness = 10;
            Rectangle DropInRectangle = new Rectangle(11, _dividerHeight + 1, this.Width - _shadowThickness - 20, this.Height - _shadowThickness - _dividerHeight - 1);

            //LinearGradientBrush brush = new LinearGradientBrush(new Point())

            LinearGradientBrush grad_brush = new LinearGradientBrush(DropInRectangle,
                   Color.FromArgb(100, 0, 250, 250),
                   Color.FromArgb(0, 0, 250, 250),
                   LinearGradientMode.Vertical);

            if (DrawMainPanelHighlight)
            {
                e.Graphics.FillHalfRoundedRectangle(grad_brush, DropInRectangle.X, DropInRectangle.Y, DropInRectangle.Width, DropInRectangle.Height - 10, 15);
            }
        }

        

        private void CreateFileQueueVisual(string[] files)
        {
            DeleteDragDropVisual();

            int id = 0;

            foreach (string file in files)
            {
                LocalFileStructure fStruct = new LocalFileStructure();
                try
                {
                    FileInfo fInfo = new FileInfo(file);
                    fStruct.FilePath = file;
                    fStruct.FileExtension = Path.GetExtension(file);
                    fStruct.FileName = Path.GetFileNameWithoutExtension(file);
                    fStruct.FileSize = fInfo.Length;
                    fStruct.FullName = fInfo.Name;
                    AddFileVisual(fStruct, 50);
                    id++;
                }
                catch (Exception e)
                {
                    Debugger.AddErrorMessage(e.Message);
                    throw;
                }

            }
        }

        private void btn_ChooseFromDevice_Click(object sender, EventArgs e)
        {
            dialog_OpenFiles.Multiselect = true;
            DialogResult dr = dialog_OpenFiles.ShowDialog();

            if (dr == DialogResult.OK)
            {
                CreateFileQueueVisual(dialog_OpenFiles.FileNames);
            }

        }

        //
        // DRAG DROP
        //

        private void CreateDragDropPanel()
        {
            int size = MainPanel.Width / 2;


            // This is only for grouping

            DragDropPanelBG = new Panel()
            {
                Size = MainPanel.Size,
                Location = new Point(0, 0),
                BackColor = Color.Transparent,

            };

            MainPanel.Controls.Add(DragDropPanelBG);
            DragDropPanelBG.BringToFront();

            DragDropPanel = new Panel()
            {
                //Size = new Size((int)((decimal)MainPanel.Width / 1.1M), (int)((decimal)MainPanel.Height / 1.2M)),
                Size = new Size(size, size),
                Location = new Point((DragDropPanelBG.Width / 2) - size / 2, (int)((decimal)DragDropPanelBG.Height / 4.5M)),
                BackColor = Color.Transparent,
                BackgroundImage = Properties.Resources.drag_drop_BG_Icon,
                BackgroundImageLayout = ImageLayout.Zoom,
                AllowDrop = true,
            };

            DragDropPanelBG.Controls.Add(DragDropPanel);

            Button btn_FromDevice = new Button()
            {
                Location = new Point((DragDropPanelBG.Width / 2) - 110, DragDropPanel.Location.Y + DragDropPanel.Height + 20),
                Size = new Size(221, 32),
                BackColor = Color.FromArgb(100, 0, 190, 115),
                Text = "Or choose from your device",
            };

            btn_FromDevice.Click += btn_ChooseFromDevice_Click;

            DragDropPanelBG.Controls.Add(btn_FromDevice);


            DragDropPanel.DragEnter += new DragEventHandler(DragDrop_Enter);
            DragDropPanel.DragLeave += new EventHandler(DragDrop_Leave);
            DragDropPanel.DragDrop += new DragEventHandler(DragDrop_Drop);
            DragDropPanel.Paint += new PaintEventHandler(DragDrop_Paint);


            DragDropPanel.BringToFront();
        }



        private void DeleteDragDropVisual()
        {
            DragDropPanelBG.Dispose();
        }

        private void DragDrop_Enter(object sender, DragEventArgs de)
        {
            if (de.Data.GetDataPresent(DataFormats.FileDrop)) de.Effect = DragDropEffects.Copy;
            //MainPanel.DrawDropInHighlight = true;
            DrawMainPanelHighlight = true;
            DragDropPanel.Invalidate();
            //MainPanel.Invalidate();

        }

        private void DragDrop_Leave(object sender, EventArgs de)
        {
           // MainPanel.DrawDropInHighlight = false;
            DrawMainPanelHighlight = false;
            DragDropPanel.Invalidate();
            //MainPanel.Invalidate();
        }

        private void DragDrop_Drop(object sender, DragEventArgs de)
        {
            MainPanel.DrawDropInHighlight = false;

            string[] files = (string[])de.Data.GetData(DataFormats.FileDrop);

            if (files == null || files.Length < 1)
            {
                return;
            }

            CreateFileQueueVisual(files);

        }

        //private void DragDrop_Paint(object sender, PaintEventArgs e)
        //{
        //    Panel pb = (Panel)sender;

        //    if (pb == null) return;

        //    Rectangle rect = new Rectangle(0,
        //                                   0,
        //                                   pb.Width,
        //                                   pb.Height);

        //    LinearGradientBrush grad_brush = new LinearGradientBrush(rect,
        //           Color.FromArgb(100, 0, 250, 250),
        //           Color.FromArgb(0, 0, 250, 250),
        //           LinearGradientMode.BackwardDiagonal);

        //    if (DrawMainPanelHighlight)
        //    {
        //        e.Graphics.FillRectangle(grad_brush, rect);
        //    }

        //}

        private void DragDrop_Paint(object sender, PaintEventArgs e)
        {
            Panel pb = (Panel)sender;

            if (pb == null) return;

            int startx = this.Width / 2;
            int starty = 0;

            Rectangle rect = new Rectangle(0,
                                           0,
                                           this.Width,
                                           this.Height);

            LinearGradientBrush grad_brush = new LinearGradientBrush(rect,
                   Color.FromArgb(255, 0, 250, 250),
                   Color.FromArgb(255, 255, 0, 250),
                   LinearGradientMode.Vertical);



            if (DrawMainPanelHighlight)
            {
                e.Graphics.FillRectangle(grad_brush, rect);
            }

        }


        //
        // FORM EVENTS
        //

        private void FormClosingEvent(object sender, FormClosingEventArgs e)
        {
            _mainPage.Show();
        }

        //
        // TOP BAR
        //

        private void InitializeTopBar()
        {
            panel_TopBar.Location = new Point(1, 1);
            panel_TopBar.Size = new Size(this.Size.Width - 2, 23);
            panel_TopBar.MouseMove += TopBarMouseMove;
            btn_Topbar_Close.Location = new Point(btn_Topbar_Close.Parent.Width - btn_Topbar_Close.Size.Width, 0);
            btn_Topbar_Minimize.Location = new Point(btn_Topbar_Close.Location.X - btn_Topbar_Minimize.Size.Width, 0);

            btn_Topbar_Close.Click += btn_Topbar_Close_Click;
            btn_Topbar_Minimize.Click += btn_Topbar_Minimize_Click;

            btn_Topbar_Close.MouseEnter += OnTopBarButtonEnter;
            btn_Topbar_Close.MouseLeave += OnTopBarButtonLeave;

            btn_Topbar_Minimize.MouseEnter += OnTopBarButtonEnter;
            btn_Topbar_Minimize.MouseLeave += OnTopBarButtonLeave;

        }

        private void TopBarMouseMove(object sender, MouseEventArgs e)
        {
            // Top panel hack
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btn_Topbar_Close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_Topbar_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void OnTopBarButtonEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn == null)
            {
                return;
            }

            btn.BackColor = Color.FromArgb(255, 183, 210, 197);
        }

        private void OnTopBarButtonLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn == null)
            {
                return;
            }

            btn.BackColor = Color.Transparent;
        }

    }
}
