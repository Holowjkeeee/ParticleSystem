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
            DebugNextStep_Button = new Button();
            DebugMode_CheckBox = new CheckBox();
            Debug_Group = new GroupBox();
            ShowSpeedVectors_CheckBox = new CheckBox();
            label4 = new Label();
            DebugMaxSpeed_TextBox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            DebugPreviousStep_Button = new Button();
            DebugSpeed_TrackBar = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton2).BeginInit();
            Debug_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DebugSpeed_TrackBar).BeginInit();
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
            picDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picDisplay.Location = new Point(48, 28);
            picDisplay.Name = "picDisplay";
            picDisplay.Size = new Size(929, 326);
            picDisplay.TabIndex = 0;
            picDisplay.TabStop = false;
            picDisplay.MouseMove += picDisplay_MouseMove;
            // 
            // tbDirection
            // 
            tbDirection.Location = new Point(37, 417);
            tbDirection.Maximum = 359;
            tbDirection.Name = "tbDirection";
            tbDirection.Size = new Size(237, 45);
            tbDirection.TabIndex = 1;
            tbDirection.TickStyle = TickStyle.None;
            tbDirection.Scroll += tbDirection_Scroll;
            // 
            // lblDirection
            // 
            lblDirection.AutoSize = true;
            lblDirection.Location = new Point(272, 417);
            lblDirection.Name = "lblDirection";
            lblDirection.Size = new Size(13, 15);
            lblDirection.TabIndex = 2;
            lblDirection.Text = "0";
            // 
            // tbGraviton1
            // 
            tbGraviton1.Location = new Point(329, 417);
            tbGraviton1.Maximum = 100;
            tbGraviton1.Name = "tbGraviton1";
            tbGraviton1.Size = new Size(173, 45);
            tbGraviton1.TabIndex = 3;
            tbGraviton1.TickStyle = TickStyle.None;
            tbGraviton1.Scroll += tbGraviton_Scroll;
            // 
            // tbGraviton2
            // 
            tbGraviton2.Location = new Point(549, 417);
            tbGraviton2.Maximum = 100;
            tbGraviton2.Name = "tbGraviton2";
            tbGraviton2.Size = new Size(128, 45);
            tbGraviton2.TabIndex = 4;
            tbGraviton2.TickStyle = TickStyle.None;
            tbGraviton2.Scroll += tbGraviton2_Scroll;
            // 
            // DebugNextStep_Button
            // 
            DebugNextStep_Button.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            DebugNextStep_Button.Location = new Point(136, 147);
            DebugNextStep_Button.Name = "DebugNextStep_Button";
            DebugNextStep_Button.Size = new Size(112, 32);
            DebugNextStep_Button.TabIndex = 5;
            DebugNextStep_Button.Text = "Next step";
            DebugNextStep_Button.UseVisualStyleBackColor = true;
            DebugNextStep_Button.Visible = false;
            // 
            // DebugMode_CheckBox
            // 
            DebugMode_CheckBox.AutoSize = true;
            DebugMode_CheckBox.Location = new Point(35, 468);
            DebugMode_CheckBox.Name = "DebugMode_CheckBox";
            DebugMode_CheckBox.Size = new Size(95, 19);
            DebugMode_CheckBox.TabIndex = 6;
            DebugMode_CheckBox.Text = "Debug mode";
            DebugMode_CheckBox.UseVisualStyleBackColor = true;
            DebugMode_CheckBox.CheckedChanged += DebugMode_CheckBox_CheckedChanged;
            // 
            // Debug_Group
            // 
            Debug_Group.Controls.Add(ShowSpeedVectors_CheckBox);
            Debug_Group.Controls.Add(label4);
            Debug_Group.Controls.Add(DebugMaxSpeed_TextBox);
            Debug_Group.Controls.Add(label3);
            Debug_Group.Controls.Add(label2);
            Debug_Group.Controls.Add(label1);
            Debug_Group.Controls.Add(DebugPreviousStep_Button);
            Debug_Group.Controls.Add(DebugSpeed_TrackBar);
            Debug_Group.Controls.Add(DebugNextStep_Button);
            Debug_Group.Location = new Point(37, 493);
            Debug_Group.Name = "Debug_Group";
            Debug_Group.Size = new Size(432, 185);
            Debug_Group.TabIndex = 7;
            Debug_Group.TabStop = false;
            Debug_Group.Text = "Debug";
            Debug_Group.Visible = false;
            // 
            // ShowSpeedVectors_CheckBox
            // 
            ShowSpeedVectors_CheckBox.AutoSize = true;
            ShowSpeedVectors_CheckBox.Location = new Point(6, 22);
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
            label4.Location = new Point(121, 70);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 13;
            label4.Text = "Max speed";
            // 
            // DebugMaxSpeed_TextBox
            // 
            DebugMaxSpeed_TextBox.Location = new Point(191, 67);
            DebugMaxSpeed_TextBox.Name = "DebugMaxSpeed_TextBox";
            DebugMaxSpeed_TextBox.Size = new Size(52, 23);
            DebugMaxSpeed_TextBox.TabIndex = 12;
            DebugMaxSpeed_TextBox.Text = "40";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(217, 126);
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
            // 
            // DebugSpeed_TrackBar
            // 
            DebugSpeed_TrackBar.Anchor = AnchorStyles.Left;
            DebugSpeed_TrackBar.BackColor = SystemColors.Control;
            DebugSpeed_TrackBar.Location = new Point(6, 96);
            DebugSpeed_TrackBar.Maximum = 100;
            DebugSpeed_TrackBar.Name = "DebugSpeed_TrackBar";
            DebugSpeed_TrackBar.Size = new Size(242, 45);
            DebugSpeed_TrackBar.TabIndex = 6;
            DebugSpeed_TrackBar.TickStyle = TickStyle.None;
            DebugSpeed_TrackBar.Value = 100;
            DebugSpeed_TrackBar.Scroll += DebugSpeed_TrackBar_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 711);
            Controls.Add(Debug_Group);
            Controls.Add(DebugMode_CheckBox);
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
            Debug_Group.ResumeLayout(false);
            Debug_Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DebugSpeed_TrackBar).EndInit();
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
        private TextBox DebugMaxSpeed_TextBox;
    }
}