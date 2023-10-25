namespace ParticleSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            timer1 = new System.Windows.Forms.Timer(components);
            picDisplay = new PictureBox();
            tbDirection = new TrackBar();
            lblDirection = new Label();
            tbGraviton1 = new TrackBar();
            tbGraviton2 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton2).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // picDisplay
            // 
            picDisplay.Anchor = AnchorStyles.None;
            picDisplay.Location = new Point(12, 12);
            picDisplay.Name = "picDisplay";
            picDisplay.Size = new Size(747, 373);
            picDisplay.TabIndex = 0;
            picDisplay.TabStop = false;
            picDisplay.MouseMove += picDisplay_MouseMove;
            // 
            // tbDirection
            // 
            tbDirection.Location = new Point(35, 405);
            tbDirection.Maximum = 359;
            tbDirection.Name = "tbDirection";
            tbDirection.Size = new Size(237, 45);
            tbDirection.TabIndex = 1;
            tbDirection.Scroll += tbDirection_Scroll;
            // 
            // lblDirection
            // 
            lblDirection.AutoSize = true;
            lblDirection.Location = new Point(278, 405);
            lblDirection.Name = "lblDirection";
            lblDirection.Size = new Size(13, 15);
            lblDirection.TabIndex = 2;
            lblDirection.Text = "0";
            // 
            // tbGraviton1
            // 
            tbGraviton1.Location = new Point(329, 405);
            tbGraviton1.Maximum = 100;
            tbGraviton1.Name = "tbGraviton1";
            tbGraviton1.Size = new Size(173, 45);
            tbGraviton1.TabIndex = 3;
            tbGraviton1.Scroll += tbGraviton_Scroll;
            // 
            // tbGraviton2
            // 
            tbGraviton2.Location = new Point(532, 405);
            tbGraviton2.Maximum = 100;
            tbGraviton2.Name = "tbGraviton2";
            tbGraviton2.Size = new Size(128, 45);
            tbGraviton2.TabIndex = 4;
            tbGraviton2.Scroll += tbGraviton2_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbGraviton2);
            Controls.Add(tbGraviton1);
            Controls.Add(lblDirection);
            Controls.Add(tbDirection);
            Controls.Add(picDisplay);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Particle system";
            ((System.ComponentModel.ISupportInitialize)picDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private PictureBox picDisplay;
        private TrackBar tbDirection;
        private Label lblDirection;
        private TrackBar tbGraviton1;
        private TrackBar tbGraviton2;
    }
}