namespace ParticleSystem
{
    partial class CanvasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CanvasForm));
            timer1 = new System.Windows.Forms.Timer(components);
            picDisplay = new PictureBox();
            DebugNextStep_Button = new Button();
            DebugMode_CheckBox = new CheckBox();
            Debug_Group = new GroupBox();
            DebugMaxFPS_NumericUpDown = new NumericUpDown();
            CurrentFPS_TextBox = new TextBox();
            CurrentFPS_Label = new Label();
            ShowSpeedVectors_CheckBox = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            DebugPreviousStep_Button = new Button();
            DebugSpeed_TrackBar = new TrackBar();
            DebugTooltip = new ToolTip(components);
            DebugInfo_Label = new Label();
            menuStrip1 = new MenuStrip();
            debugToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            Debug_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DebugMaxFPS_NumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DebugSpeed_TrackBar).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 17;
            timer1.Tick += timer1_Tick;
            // 
            // picDisplay
            // 
            picDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picDisplay.Location = new Point(0, 27);
            picDisplay.Name = "picDisplay";
            picDisplay.Size = new Size(1034, 464);
            picDisplay.TabIndex = 0;
            picDisplay.TabStop = false;
            picDisplay.MouseMove += picDisplay_MouseMove;
            // 
            // DebugNextStep_Button
            // 
            DebugNextStep_Button.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            DebugNextStep_Button.Location = new Point(163, 147);
            DebugNextStep_Button.Name = "DebugNextStep_Button";
            DebugNextStep_Button.Size = new Size(112, 32);
            DebugNextStep_Button.TabIndex = 5;
            DebugNextStep_Button.Text = "Next step";
            DebugNextStep_Button.UseVisualStyleBackColor = true;
            DebugNextStep_Button.Visible = false;
            DebugNextStep_Button.Click += DebugNextStep_Button_Click;
            // 
            // DebugMode_CheckBox
            // 
            DebugMode_CheckBox.AutoSize = true;
            DebugMode_CheckBox.Location = new Point(12, 497);
            DebugMode_CheckBox.Name = "DebugMode_CheckBox";
            DebugMode_CheckBox.Size = new Size(95, 19);
            DebugMode_CheckBox.TabIndex = 6;
            DebugMode_CheckBox.Text = "Debug mode";
            DebugMode_CheckBox.UseVisualStyleBackColor = true;
            DebugMode_CheckBox.CheckedChanged += DebugMode_CheckBox_CheckedChanged;
            // 
            // Debug_Group
            // 
            Debug_Group.Controls.Add(DebugMaxFPS_NumericUpDown);
            Debug_Group.Controls.Add(CurrentFPS_TextBox);
            Debug_Group.Controls.Add(CurrentFPS_Label);
            Debug_Group.Controls.Add(ShowSpeedVectors_CheckBox);
            Debug_Group.Controls.Add(label4);
            Debug_Group.Controls.Add(label3);
            Debug_Group.Controls.Add(label2);
            Debug_Group.Controls.Add(label1);
            Debug_Group.Controls.Add(DebugPreviousStep_Button);
            Debug_Group.Controls.Add(DebugSpeed_TrackBar);
            Debug_Group.Controls.Add(DebugNextStep_Button);
            Debug_Group.Location = new Point(12, 522);
            Debug_Group.Name = "Debug_Group";
            Debug_Group.Size = new Size(289, 185);
            Debug_Group.TabIndex = 7;
            Debug_Group.TabStop = false;
            Debug_Group.Text = "Debug";
            Debug_Group.Visible = false;
            // 
            // DebugMaxFPS_NumericUpDown
            // 
            DebugMaxFPS_NumericUpDown.Location = new Point(223, 24);
            DebugMaxFPS_NumericUpDown.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            DebugMaxFPS_NumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            DebugMaxFPS_NumericUpDown.Name = "DebugMaxFPS_NumericUpDown";
            DebugMaxFPS_NumericUpDown.Size = new Size(47, 23);
            DebugMaxFPS_NumericUpDown.TabIndex = 8;
            DebugMaxFPS_NumericUpDown.TextAlign = HorizontalAlignment.Center;
            DebugMaxFPS_NumericUpDown.Value = new decimal(new int[] { 60, 0, 0, 0 });
            DebugMaxFPS_NumericUpDown.ValueChanged += DebugMaxFPS_NumericUpDown_ValueChanged;
            // 
            // CurrentFPS_TextBox
            // 
            CurrentFPS_TextBox.Location = new Point(223, 67);
            CurrentFPS_TextBox.Name = "CurrentFPS_TextBox";
            CurrentFPS_TextBox.ReadOnly = true;
            CurrentFPS_TextBox.Size = new Size(47, 23);
            CurrentFPS_TextBox.TabIndex = 16;
            CurrentFPS_TextBox.Text = "60";
            CurrentFPS_TextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // CurrentFPS_Label
            // 
            CurrentFPS_Label.AutoSize = true;
            CurrentFPS_Label.Location = new Point(148, 70);
            CurrentFPS_Label.Name = "CurrentFPS_Label";
            CurrentFPS_Label.Size = new Size(69, 15);
            CurrentFPS_Label.TabIndex = 15;
            CurrentFPS_Label.Text = "Current FPS";
            // 
            // ShowSpeedVectors_CheckBox
            // 
            ShowSpeedVectors_CheckBox.AutoSize = true;
            ShowSpeedVectors_CheckBox.Location = new Point(6, 25);
            ShowSpeedVectors_CheckBox.Name = "ShowSpeedVectors_CheckBox";
            ShowSpeedVectors_CheckBox.Size = new Size(130, 19);
            ShowSpeedVectors_CheckBox.TabIndex = 14;
            ShowSpeedVectors_CheckBox.Text = "Show speed vectors";
            ShowSpeedVectors_CheckBox.UseVisualStyleBackColor = true;
            ShowSpeedVectors_CheckBox.CheckedChanged += ShowSpeedVectors_CheckBox_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(165, 27);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 13;
            label4.Text = "Max FPS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(250, 126);
            label3.Name = "label3";
            label3.Size = new Size(25, 15);
            label3.TabIndex = 11;
            label3.Text = "100";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 126);
            label2.Name = "label2";
            label2.Size = new Size(13, 15);
            label2.TabIndex = 10;
            label2.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 70);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 9;
            label1.Text = "Speed %";
            // 
            // DebugPreviousStep_Button
            // 
            DebugPreviousStep_Button.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            DebugPreviousStep_Button.Location = new Point(6, 147);
            DebugPreviousStep_Button.Name = "DebugPreviousStep_Button";
            DebugPreviousStep_Button.Size = new Size(116, 32);
            DebugPreviousStep_Button.TabIndex = 8;
            DebugPreviousStep_Button.Text = "Previous Step (10)";
            DebugPreviousStep_Button.UseVisualStyleBackColor = true;
            DebugPreviousStep_Button.Visible = false;
            DebugPreviousStep_Button.Click += DebugPreviousStep_Button_Click;
            // 
            // DebugSpeed_TrackBar
            // 
            DebugSpeed_TrackBar.Anchor = AnchorStyles.Left;
            DebugSpeed_TrackBar.BackColor = SystemColors.Control;
            DebugSpeed_TrackBar.Location = new Point(6, 96);
            DebugSpeed_TrackBar.Maximum = 100;
            DebugSpeed_TrackBar.Name = "DebugSpeed_TrackBar";
            DebugSpeed_TrackBar.Size = new Size(269, 45);
            DebugSpeed_TrackBar.TabIndex = 6;
            DebugSpeed_TrackBar.TickStyle = TickStyle.None;
            DebugSpeed_TrackBar.Value = 100;
            DebugSpeed_TrackBar.Scroll += DebugSpeed_TrackBar_Scroll;
            // 
            // DebugInfo_Label
            // 
            DebugInfo_Label.AutoSize = true;
            DebugInfo_Label.Location = new Point(325, 532);
            DebugInfo_Label.Name = "DebugInfo_Label";
            DebugInfo_Label.Size = new Size(38, 15);
            DebugInfo_Label.TabIndex = 8;
            DebugInfo_Label.Text = "label5";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { debugToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1034, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // debugToolStripMenuItem
            // 
            debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            debugToolStripMenuItem.Size = new Size(54, 20);
            debugToolStripMenuItem.Text = "Debug";
            // 
            // CanvasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 711);
            Controls.Add(DebugInfo_Label);
            Controls.Add(Debug_Group);
            Controls.Add(DebugMode_CheckBox);
            Controls.Add(picDisplay);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "CanvasForm";
            Text = "Particle system";
            SizeChanged += Form1_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)picDisplay).EndInit();
            Debug_Group.ResumeLayout(false);
            Debug_Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DebugMaxFPS_NumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)DebugSpeed_TrackBar).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private PictureBox picDisplay;
        private Button DebugNextStep_Button;
        private CheckBox DebugMode_CheckBox;
        private GroupBox Debug_Group;
        private TrackBar DebugSpeed_TrackBar;
        private Button DebugPreviousStep_Button;
        private Label label1;
        private Label label2;
        private Label label3;
        private CheckBox ShowSpeedVectors_CheckBox;
        private Label label4;
        private Label CurrentFPS_Label;
        private NumericUpDown DebugMaxFPS_NumericUpDown;
        private TextBox CurrentFPS_TextBox;
        private ToolTip DebugTooltip;
        private Label DebugInfo_Label;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem debugToolStripMenuItem;
    }
}