
namespace FileJump.Forms
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Paint = new System.Windows.Forms.Panel();
            this.StartAngleInput = new System.Windows.Forms.NumericUpDown();
            this.SweepAngleInput = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btn_ColorPicker = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel_TestShadow = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.StartAngleInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SweepAngleInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Paint
            // 
            this.panel_Paint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel_Paint.Location = new System.Drawing.Point(16, 3);
            this.panel_Paint.Name = "panel_Paint";
            this.panel_Paint.Size = new System.Drawing.Size(46, 38);
            this.panel_Paint.TabIndex = 0;
            this.panel_Paint.Paint += new System.Windows.Forms.PaintEventHandler(this.TestPaint);
            // 
            // StartAngleInput
            // 
            this.StartAngleInput.Location = new System.Drawing.Point(580, 74);
            this.StartAngleInput.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.StartAngleInput.Name = "StartAngleInput";
            this.StartAngleInput.Size = new System.Drawing.Size(156, 22);
            this.StartAngleInput.TabIndex = 1;
            this.StartAngleInput.ValueChanged += new System.EventHandler(this.StartAngle_ValueChange);
            // 
            // SweepAngleInput
            // 
            this.SweepAngleInput.Location = new System.Drawing.Point(580, 144);
            this.SweepAngleInput.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.SweepAngleInput.Name = "SweepAngleInput";
            this.SweepAngleInput.Size = new System.Drawing.Size(156, 22);
            this.SweepAngleInput.TabIndex = 2;
            this.SweepAngleInput.ValueChanged += new System.EventHandler(this.SweepAngle_ValueChange);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(580, 244);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(156, 22);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.percentchange);
            // 
            // btn_ColorPicker
            // 
            this.btn_ColorPicker.Location = new System.Drawing.Point(392, 234);
            this.btn_ColorPicker.Name = "btn_ColorPicker";
            this.btn_ColorPicker.Size = new System.Drawing.Size(126, 64);
            this.btn_ColorPicker.TabIndex = 4;
            this.btn_ColorPicker.Text = "Change color";
            this.btn_ColorPicker.UseVisualStyleBackColor = true;
            this.btn_ColorPicker.Click += new System.EventHandler(this.btn_ColorPicker_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel_Paint);
            this.panel1.Location = new System.Drawing.Point(315, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(76, 76);
            this.panel1.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar1.Location = new System.Drawing.Point(315, 303);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(76, 13);
            this.progressBar1.TabIndex = 6;
            // 
            // panel_TestShadow
            // 
            this.panel_TestShadow.Location = new System.Drawing.Point(123, 131);
            this.panel_TestShadow.Name = "panel_TestShadow";
            this.panel_TestShadow.Size = new System.Drawing.Size(105, 105);
            this.panel_TestShadow.TabIndex = 7;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_TestShadow);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_ColorPicker);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.SweepAngleInput);
            this.Controls.Add(this.StartAngleInput);
            this.Name = "TestForm";
            this.Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.StartAngleInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SweepAngleInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Paint;
        private System.Windows.Forms.NumericUpDown StartAngleInput;
        private System.Windows.Forms.NumericUpDown SweepAngleInput;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btn_ColorPicker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel_TestShadow;
    }
}