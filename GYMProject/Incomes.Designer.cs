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
            panel1 = new Panel();
            label4 = new Label();
            button3 = new Button();
            label3 = new Label();
            button2 = new Button();
            label2 = new Label();
            button1 = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // formsPlot2
            // 
            formsPlot2.DisplayScale = 1.25F;
            formsPlot2.Location = new Point(110, 35);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(436, 378);
            formsPlot2.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(548, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(172, 378);
            panel1.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(87, 145);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 6;
            label4.Text = "Yearly";
            // 
            // button3
            // 
            button3.BackColor = Color.DarkOrange;
            button3.Enabled = false;
            button3.Location = new Point(4, 141);
            button3.Name = "button3";
            button3.Size = new Size(77, 29);
            button3.TabIndex = 5;
            button3.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(87, 96);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 4;
            label3.Text = "Products";
            // 
            // button2
            // 
            button2.BackColor = Color.MediumSeaGreen;
            button2.Enabled = false;
            button2.Location = new Point(4, 92);
            button2.Name = "button2";
            button2.Size = new Size(77, 29);
            button2.TabIndex = 3;
            button2.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 48);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 2;
            label2.Text = "Monthly";
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.Enabled = false;
            button1.Location = new Point(4, 44);
            button1.Name = "button1";
            button1.Size = new Size(77, 29);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Blue;
            label1.Location = new Point(19, 32);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            // 
            // Incomes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(formsPlot2);
            Name = "Incomes";
            Text = "Incomes";
            Load += Incomes_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ScottPlot.WinForms.FormsPlot formsPlot2;
        private Panel panel1;
        private Label label1;
        private Label label4;
        private Button button3;
        private Label label3;
        private Button button2;
        private Label label2;
        private Button button1;
    }
}