namespace ParticleSystem
{
    partial class DebugForm
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
            DebugInfo_Label = new Label();
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
            DebugNextStep_Button = new Button();
            groupBox1 = new GroupBox();
            label5 = new Label();
            MouseY_TextBox = new TextBox();
            MouseX_TextBox = new TextBox();
            Debug_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DebugMaxFPS_NumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DebugSpeed_TrackBar).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // DebugInfo_Label
            // 
            DebugInfo_Label.AutoSize = true;
            DebugInfo_Label.Location = new Point(18, 25);
            DebugInfo_Label.Name = "DebugInfo_Label";
            DebugInfo_Label.Size = new Size(14, 15);
            DebugInfo_Label.TabIndex = 10;
            DebugInfo_Label.Text = "X";
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
            Debug_Group.Location = new Point(12, 12);
            Debug_Group.Name = "Debug_Group";
            Debug_Group.Size = new Size(353, 192);
            Debug_Group.TabIndex = 9;
            Debug_Group.TabStop = false;
            Debug_Group.Text = "Execution control";
            // 
            // DebugMaxFPS_NumericUpDown
            // 
            DebugMaxFPS_NumericUpDown.Location = new Point(298, 25);
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
            CurrentFPS_TextBox.Enabled = false;
            CurrentFPS_TextBox.Location = new Point(298, 67);
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
            CurrentFPS_Label.Location = new Point(223, 70);
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
            label4.Location = new Point(240, 28);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 13;
            label4.Text = "Max FPS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(320, 126);
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
            DebugPreviousStep_Button.Anchor = AnchorStyles.None;
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
            DebugSpeed_TrackBar.Anchor = AnchorStyles.None;
            DebugSpeed_TrackBar.BackColor = SystemColors.Control;
            DebugSpeed_TrackBar.Location = new Point(8, 96);
            DebugSpeed_TrackBar.Maximum = 100;
            DebugSpeed_TrackBar.Name = "DebugSpeed_TrackBar";
            DebugSpeed_TrackBar.Size = new Size(339, 45);
            DebugSpeed_TrackBar.TabIndex = 6;
            DebugSpeed_TrackBar.TickStyle = TickStyle.None;
            DebugSpeed_TrackBar.Value = 100;
            DebugSpeed_TrackBar.Scroll += DebugSpeed_TrackBar_Scroll;
            // 
            // DebugNextStep_Button
            // 
            DebugNextStep_Button.Anchor = AnchorStyles.None;
            DebugNextStep_Button.Location = new Point(235, 147);
            DebugNextStep_Button.Name = "DebugNextStep_Button";
            DebugNextStep_Button.Size = new Size(112, 32);
            DebugNextStep_Button.TabIndex = 5;
            DebugNextStep_Button.Text = "Next step";
            DebugNextStep_Button.UseVisualStyleBackColor = true;
            DebugNextStep_Button.Visible = false;
            DebugNextStep_Button.Click += DebugNextStep_Button_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(MouseY_TextBox);
            groupBox1.Controls.Add(MouseX_TextBox);
            groupBox1.Controls.Add(DebugInfo_Label);
            groupBox1.Location = new Point(371, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(103, 85);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "MousePosition";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 51);
            label5.Name = "label5";
            label5.Size = new Size(14, 15);
            label5.TabIndex = 19;
            label5.Text = "Y";
            // 
            // MouseY_TextBox
            // 
            MouseY_TextBox.Enabled = false;
            MouseY_TextBox.Location = new Point(38, 48);
            MouseY_TextBox.Name = "MouseY_TextBox";
            MouseY_TextBox.ReadOnly = true;
            MouseY_TextBox.Size = new Size(47, 23);
            MouseY_TextBox.TabIndex = 17;
            MouseY_TextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // MouseX_TextBox
            // 
            MouseX_TextBox.Enabled = false;
            MouseX_TextBox.Location = new Point(38, 21);
            MouseX_TextBox.Name = "MouseX_TextBox";
            MouseX_TextBox.ReadOnly = true;
            MouseX_TextBox.Size = new Size(47, 23);
            MouseX_TextBox.TabIndex = 18;
            MouseX_TextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // DebugForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 215);
            Controls.Add(groupBox1);
            Controls.Add(Debug_Group);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "DebugForm";
            Text = "Debug";
            FormClosed += DebugForm_FormClosed;
            Debug_Group.ResumeLayout(false);
            Debug_Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DebugMaxFPS_NumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)DebugSpeed_TrackBar).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label DebugInfo_Label;
        private GroupBox Debug_Group;
        private NumericUpDown DebugMaxFPS_NumericUpDown;
        private TextBox CurrentFPS_TextBox;
        private Label CurrentFPS_Label;
        private CheckBox ShowSpeedVectors_CheckBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button DebugPreviousStep_Button;
        private TrackBar DebugSpeed_TrackBar;
        private Button DebugNextStep_Button;
        private GroupBox groupBox1;
        private TextBox MouseY_TextBox;
        private Label label5;
        private TextBox MouseX_TextBox;
    }
}