namespace GYMProject
{
    partial class Incomes
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
            formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            SuspendLayout();
            // 
            // formsPlot2
            // 
            formsPlot2.DisplayScale = 1.25F;
            formsPlot2.Location = new Point(178, 26);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(436, 378);
            formsPlot2.TabIndex = 3;
            // 
            // Incomes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(formsPlot2);
            Name = "Incomes";
            Text = "Incomes";
            Load += Incomes_Load;
            ResumeLayout(false);
        }

        #endregion
        private ScottPlot.WinForms.FormsPlot formsPlot2;
    }
}