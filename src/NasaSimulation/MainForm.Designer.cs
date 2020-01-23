namespace Simulation
{
    partial class MainForm
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
            this.guiOpenGLFrame = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButtonSH = new System.Windows.Forms.RadioButton();
            this.radioButtonSO = new System.Windows.Forms.RadioButton();
            this.radioButtonSP = new System.Windows.Forms.RadioButton();
            this.radioButtonSC = new System.Windows.Forms.RadioButton();
            this.checkBoxOurs = new System.Windows.Forms.CheckBox();
            this.lblAdapting = new System.Windows.Forms.Label();
            this.lblOptimizing = new System.Windows.Forms.Label();
            this.labelAdapting = new System.Windows.Forms.Label();
            this.lableOptimizing = new System.Windows.Forms.Label();
            this.checkBoxMultiOff = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // guiOpenGLFrame
            // 
            this.guiOpenGLFrame.AccumBits = ((byte)(0));
            this.guiOpenGLFrame.AutoCheckErrors = false;
            this.guiOpenGLFrame.AutoFinish = false;
            this.guiOpenGLFrame.AutoMakeCurrent = true;
            this.guiOpenGLFrame.AutoSwapBuffers = true;
            this.guiOpenGLFrame.BackColor = System.Drawing.Color.Black;
            this.guiOpenGLFrame.ColorBits = ((byte)(32));
            this.guiOpenGLFrame.DepthBits = ((byte)(16));
            this.guiOpenGLFrame.Location = new System.Drawing.Point(155, 12);
            this.guiOpenGLFrame.Name = "guiOpenGLFrame";
            this.guiOpenGLFrame.Size = new System.Drawing.Size(500, 492);
            this.guiOpenGLFrame.StencilBits = ((byte)(0));
            this.guiOpenGLFrame.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.button1.Location = new System.Drawing.Point(7, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 51);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButtonSH
            // 
            this.radioButtonSH.AutoSize = true;
            this.radioButtonSH.Location = new System.Drawing.Point(7, 215);
            this.radioButtonSH.Name = "radioButtonSH";
            this.radioButtonSH.Size = new System.Drawing.Size(124, 17);
            this.radioButtonSH.TabIndex = 51;
            this.radioButtonSH.TabStop = true;
            this.radioButtonSH.Text = "Self-Healing Scenaio";
            this.radioButtonSH.UseVisualStyleBackColor = true;
            // 
            // radioButtonSO
            // 
            this.radioButtonSO.AutoSize = true;
            this.radioButtonSO.Location = new System.Drawing.Point(7, 238);
            this.radioButtonSO.Name = "radioButtonSO";
            this.radioButtonSO.Size = new System.Drawing.Size(139, 17);
            this.radioButtonSO.TabIndex = 52;
            this.radioButtonSO.TabStop = true;
            this.radioButtonSO.Text = "Self-Optimizing Scenario";
            this.radioButtonSO.UseVisualStyleBackColor = true;
            // 
            // radioButtonSP
            // 
            this.radioButtonSP.AutoSize = true;
            this.radioButtonSP.Location = new System.Drawing.Point(7, 261);
            this.radioButtonSP.Name = "radioButtonSP";
            this.radioButtonSP.Size = new System.Drawing.Size(139, 17);
            this.radioButtonSP.TabIndex = 53;
            this.radioButtonSP.TabStop = true;
            this.radioButtonSP.Text = "Self-Protecting Scenario";
            this.radioButtonSP.UseVisualStyleBackColor = true;
            // 
            // radioButtonSC
            // 
            this.radioButtonSC.AutoSize = true;
            this.radioButtonSC.Location = new System.Drawing.Point(7, 284);
            this.radioButtonSC.Name = "radioButtonSC";
            this.radioButtonSC.Size = new System.Drawing.Size(144, 17);
            this.radioButtonSC.TabIndex = 54;
            this.radioButtonSC.TabStop = true;
            this.radioButtonSC.Text = "Self-Configuring Scenario";
            this.radioButtonSC.UseVisualStyleBackColor = true;
            // 
            // checkBoxOurs
            // 
            this.checkBoxOurs.AutoSize = true;
            this.checkBoxOurs.Location = new System.Drawing.Point(26, 424);
            this.checkBoxOurs.Name = "checkBoxOurs";
            this.checkBoxOurs.Size = new System.Drawing.Size(79, 17);
            this.checkBoxOurs.TabIndex = 56;
            this.checkBoxOurs.Text = "OurMethod";
            this.checkBoxOurs.UseVisualStyleBackColor = true;
            this.checkBoxOurs.CheckedChanged += new System.EventHandler(this.checkBoxOurs_CheckedChanged);
            // 
            // lblAdapting
            // 
            this.lblAdapting.AutoSize = true;
            this.lblAdapting.Location = new System.Drawing.Point(23, 318);
            this.lblAdapting.Name = "lblAdapting";
            this.lblAdapting.Size = new System.Drawing.Size(76, 13);
            this.lblAdapting.TabIndex = 57;
            this.lblAdapting.Text = "adapting time: ";
            // 
            // lblOptimizing
            // 
            this.lblOptimizing.AutoSize = true;
            this.lblOptimizing.Location = new System.Drawing.Point(23, 341);
            this.lblOptimizing.Name = "lblOptimizing";
            this.lblOptimizing.Size = new System.Drawing.Size(86, 13);
            this.lblOptimizing.TabIndex = 58;
            this.lblOptimizing.Text = "Message count: ";
            // 
            // labelAdapting
            // 
            this.labelAdapting.AutoSize = true;
            this.labelAdapting.Location = new System.Drawing.Point(111, 318);
            this.labelAdapting.Name = "labelAdapting";
            this.labelAdapting.Size = new System.Drawing.Size(0, 13);
            this.labelAdapting.TabIndex = 59;
            // 
            // lableOptimizing
            // 
            this.lableOptimizing.AutoSize = true;
            this.lableOptimizing.Location = new System.Drawing.Point(111, 341);
            this.lableOptimizing.Name = "lableOptimizing";
            this.lableOptimizing.Size = new System.Drawing.Size(0, 13);
            this.lableOptimizing.TabIndex = 60;
            // 
            // checkBoxMultiOff
            // 
            this.checkBoxMultiOff.AutoSize = true;
            this.checkBoxMultiOff.Location = new System.Drawing.Point(24, 401);
            this.checkBoxMultiOff.Name = "checkBoxMultiOff";
            this.checkBoxMultiOff.Size = new System.Drawing.Size(61, 17);
            this.checkBoxMultiOff.TabIndex = 61;
            this.checkBoxMultiOff.Text = "multiOff";
            this.checkBoxMultiOff.UseVisualStyleBackColor = true;
            this.checkBoxMultiOff.CheckedChanged += new System.EventHandler(this.checkBoxMultiOff_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 519);
            this.Controls.Add(this.checkBoxMultiOff);
            this.Controls.Add(this.lableOptimizing);
            this.Controls.Add(this.labelAdapting);
            this.Controls.Add(this.lblOptimizing);
            this.Controls.Add(this.lblAdapting);
            this.Controls.Add(this.checkBoxOurs);
            this.Controls.Add(this.radioButtonSC);
            this.Controls.Add(this.radioButtonSP);
            this.Controls.Add(this.radioButtonSO);
            this.Controls.Add(this.radioButtonSH);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.guiOpenGLFrame);
            this.Name = "MainForm";
            this.Text = "NASA ANTS Simulation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl guiOpenGLFrame;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButtonSH;
        private System.Windows.Forms.RadioButton radioButtonSO;
        private System.Windows.Forms.RadioButton radioButtonSP;
        private System.Windows.Forms.RadioButton radioButtonSC;
        private System.Windows.Forms.CheckBox checkBoxOurs;
        private System.Windows.Forms.Label lblAdapting;
        private System.Windows.Forms.Label lblOptimizing;
        public System.Windows.Forms.Label labelAdapting;
        public System.Windows.Forms.Label lableOptimizing;
        private System.Windows.Forms.CheckBox checkBoxMultiOff;
    }
}