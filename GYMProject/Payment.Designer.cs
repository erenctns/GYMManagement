namespace GYMProject
{
    partial class Payment
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
            tickButton = new Button();
            label1 = new Label();
            amountLabel1 = new Label();
            panelPaymentDetail = new Panel();
            panelPaymentDetailMain = new Panel();
            membershipTypeLabelValue = new Label();
            amountLabelVaule1 = new Label();
            emailValueLabel = new Label();
            paymentDateLabelValue = new Label();
            fullnameLabelValue = new Label();
            label3 = new Label();
            paymentDateLabel = new Label();
            membershipTypeLabel = new Label();
            emailLabel = new Label();
            fullNameLabel = new Label();
            label2 = new Label();
            panelPaymentDetail.SuspendLayout();
            panelPaymentDetailMain.SuspendLayout();
            SuspendLayout();
            // 
            // tickButton
            // 
            tickButton.Location = new Point(124, 349);
            tickButton.Margin = new Padding(3, 4, 3, 4);
            tickButton.Name = "tickButton";
            tickButton.Size = new Size(86, 31);
            tickButton.TabIndex = 2;
            tickButton.Text = "Confirm";
            tickButton.UseVisualStyleBackColor = true;
            tickButton.Click += tickButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(400, 216);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 3;
            // 
            // amountLabel1
            // 
            amountLabel1.AutoSize = true;
            amountLabel1.Location = new Point(3, 200);
            amountLabel1.Name = "amountLabel1";
            amountLabel1.Size = new Size(50, 20);
            amountLabel1.TabIndex = 4;
            amountLabel1.Text = "label2";
            // 
            // panelPaymentDetail
            // 
            panelPaymentDetail.BackColor = SystemColors.Window;
            panelPaymentDetail.BorderStyle = BorderStyle.FixedSingle;
            panelPaymentDetail.Controls.Add(panelPaymentDetailMain);
            panelPaymentDetail.Controls.Add(label2);
            panelPaymentDetail.Controls.Add(tickButton);
            panelPaymentDetail.Location = new Point(295, 69);
            panelPaymentDetail.Name = "panelPaymentDetail";
            panelPaymentDetail.Size = new Size(337, 384);
            panelPaymentDetail.TabIndex = 5;
            // 
            // panelPaymentDetailMain
            // 
            panelPaymentDetailMain.BackColor = SystemColors.Control;
            panelPaymentDetailMain.Controls.Add(membershipTypeLabelValue);
            panelPaymentDetailMain.Controls.Add(amountLabelVaule1);
            panelPaymentDetailMain.Controls.Add(emailValueLabel);
            panelPaymentDetailMain.Controls.Add(paymentDateLabelValue);
            panelPaymentDetailMain.Controls.Add(fullnameLabelValue);
            panelPaymentDetailMain.Controls.Add(label3);
            panelPaymentDetailMain.Controls.Add(paymentDateLabel);
            panelPaymentDetailMain.Controls.Add(membershipTypeLabel);
            panelPaymentDetailMain.Controls.Add(emailLabel);
            panelPaymentDetailMain.Controls.Add(fullNameLabel);
            panelPaymentDetailMain.Controls.Add(amountLabel1);
            panelPaymentDetailMain.Location = new Point(31, 57);
            panelPaymentDetailMain.Name = "panelPaymentDetailMain";
            panelPaymentDetailMain.Size = new Size(271, 246);
            panelPaymentDetailMain.TabIndex = 6;
            // 
            // membershipTypeLabelValue
            // 
            membershipTypeLabelValue.AutoSize = true;
            membershipTypeLabelValue.Location = new Point(149, 157);
            membershipTypeLabelValue.Name = "membershipTypeLabelValue";
            membershipTypeLabelValue.Size = new Size(50, 20);
            membershipTypeLabelValue.TabIndex = 14;
            membershipTypeLabelValue.Text = "label5";
            // 
            // amountLabelVaule1
            // 
            amountLabelVaule1.AutoSize = true;
            amountLabelVaule1.Location = new Point(149, 200);
            amountLabelVaule1.Name = "amountLabelVaule1";
            amountLabelVaule1.Size = new Size(50, 20);
            amountLabelVaule1.TabIndex = 13;
            amountLabelVaule1.Text = "label5";
            // 
            // emailValueLabel
            // 
            emailValueLabel.AutoSize = true;
            emailValueLabel.Location = new Point(129, 115);
            emailValueLabel.Name = "emailValueLabel";
            emailValueLabel.Size = new Size(50, 20);
            emailValueLabel.TabIndex = 12;
            emailValueLabel.Text = "label5";
            // 
            // paymentDateLabelValue
            // 
            paymentDateLabelValue.AutoSize = true;
            paymentDateLabelValue.Location = new Point(149, 25);
            paymentDateLabelValue.Name = "paymentDateLabelValue";
            paymentDateLabelValue.Size = new Size(50, 20);
            paymentDateLabelValue.TabIndex = 11;
            paymentDateLabelValue.Text = "label4";
            // 
            // fullnameLabelValue
            // 
            fullnameLabelValue.AutoSize = true;
            fullnameLabelValue.Location = new Point(149, 71);
            fullnameLabelValue.Name = "fullnameLabelValue";
            fullnameLabelValue.Size = new Size(50, 20);
            fullnameLabelValue.TabIndex = 10;
            fullnameLabelValue.Text = "label4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 180);
            label3.Name = "label3";
            label3.Size = new Size(267, 20);
            label3.TabIndex = 9;
            label3.Text = "-------------------------------------------";
            // 
            // paymentDateLabel
            // 
            paymentDateLabel.AutoSize = true;
            paymentDateLabel.Location = new Point(3, 25);
            paymentDateLabel.Name = "paymentDateLabel";
            paymentDateLabel.Size = new Size(50, 20);
            paymentDateLabel.TabIndex = 8;
            paymentDateLabel.Text = "label3";
            // 
            // membershipTypeLabel
            // 
            membershipTypeLabel.AutoSize = true;
            membershipTypeLabel.Location = new Point(3, 157);
            membershipTypeLabel.Name = "membershipTypeLabel";
            membershipTypeLabel.Size = new Size(50, 20);
            membershipTypeLabel.TabIndex = 7;
            membershipTypeLabel.Text = "label3";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(3, 115);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(50, 20);
            emailLabel.TabIndex = 6;
            emailLabel.Text = "label3";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new Point(3, 71);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new Size(50, 20);
            fullNameLabel.TabIndex = 5;
            fullNameLabel.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(15, 13);
            label2.Name = "label2";
            label2.Size = new Size(158, 28);
            label2.TabIndex = 5;
            label2.Text = "Payment Detail";
            // 
            // Payment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(914, 600);
            Controls.Add(panelPaymentDetail);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Payment";
            Text = "Payment";
            Load += Payment_Load_1;
            panelPaymentDetail.ResumeLayout(false);
            panelPaymentDetail.PerformLayout();
            panelPaymentDetailMain.ResumeLayout(false);
            panelPaymentDetailMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label amountLabel;
        private Button tickButton;
        private Label label1;
        private Label amountLabel1;
        private Panel panelPaymentDetail;
        private Panel panelPaymentDetailMain;
        private Label label2;
        private Label membershipTypeLabel;
        private Label emailLabel;
        private Label fullNameLabel;
        private Label paymentDateLabel;
        private Label label3;
        private Label fullnameLabelValue;
        private Label paymentDateLabelValue;
        private Label emailValueLabel;
        private Label amountLabelVaule1;
        private Label membershipTypeLabelValue;
    }
}