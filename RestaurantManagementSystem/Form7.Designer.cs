namespace RestaurantManagementSystem
{
    partial class Form7
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
            this.tableNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.totalDue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DoneButton = new System.Windows.Forms.Button();
            this.CardNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BankName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.loadingBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.CardStatus = new System.Windows.Forms.TextBox();
            this.ScanningLabel = new System.Windows.Forms.Label();
            this.ReadCard = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // tableNo
            // 
            this.tableNo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableNo.Location = new System.Drawing.Point(315, 14);
            this.tableNo.Name = "tableNo";
            this.tableNo.ReadOnly = true;
            this.tableNo.Size = new System.Drawing.Size(40, 30);
            this.tableNo.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(215, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 84;
            this.label4.Text = "Table No.";
            // 
            // totalDue
            // 
            this.totalDue.Cursor = System.Windows.Forms.Cursors.Default;
            this.totalDue.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDue.Location = new System.Drawing.Point(240, 76);
            this.totalDue.Name = "totalDue";
            this.totalDue.ReadOnly = true;
            this.totalDue.Size = new System.Drawing.Size(116, 31);
            this.totalDue.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 22);
            this.label3.TabIndex = 86;
            this.label3.Text = "Due                   : RM";
            // 
            // DoneButton
            // 
            this.DoneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneButton.Location = new System.Drawing.Point(384, 262);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(106, 58);
            this.DoneButton.TabIndex = 92;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // CardNo
            // 
            this.CardNo.Cursor = System.Windows.Forms.Cursors.Default;
            this.CardNo.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CardNo.Location = new System.Drawing.Point(204, 116);
            this.CardNo.Name = "CardNo";
            this.CardNo.ReadOnly = true;
            this.CardNo.Size = new System.Drawing.Size(329, 31);
            this.CardNo.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 22);
            this.label1.TabIndex = 93;
            this.label1.Text = "Card Number :";
            // 
            // BankName
            // 
            this.BankName.Cursor = System.Windows.Forms.Cursors.Default;
            this.BankName.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BankName.Location = new System.Drawing.Point(204, 156);
            this.BankName.Name = "BankName";
            this.BankName.ReadOnly = true;
            this.BankName.Size = new System.Drawing.Size(329, 31);
            this.BankName.TabIndex = 96;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 22);
            this.label2.TabIndex = 95;
            this.label2.Text = "Bank Name     :";
            // 
            // loadingBar
            // 
            this.loadingBar.Location = new System.Drawing.Point(384, 76);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(149, 19);
            this.loadingBar.Step = 1;
            this.loadingBar.TabIndex = 97;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 22);
            this.label5.TabIndex = 98;
            this.label5.Text = "Card Status     :";
            // 
            // CardStatus
            // 
            this.CardStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.CardStatus.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CardStatus.Location = new System.Drawing.Point(204, 199);
            this.CardStatus.Name = "CardStatus";
            this.CardStatus.ReadOnly = true;
            this.CardStatus.Size = new System.Drawing.Size(329, 31);
            this.CardStatus.TabIndex = 99;
            // 
            // ScanningLabel
            // 
            this.ScanningLabel.AutoSize = true;
            this.ScanningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScanningLabel.Location = new System.Drawing.Point(422, 48);
            this.ScanningLabel.Name = "ScanningLabel";
            this.ScanningLabel.Size = new System.Drawing.Size(79, 17);
            this.ScanningLabel.TabIndex = 100;
            this.ScanningLabel.Text = "Scanning...";
            // 
            // ReadCard
            // 
            this.ReadCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadCard.Location = new System.Drawing.Point(107, 262);
            this.ReadCard.Name = "ReadCard";
            this.ReadCard.Size = new System.Drawing.Size(106, 58);
            this.ReadCard.TabIndex = 101;
            this.ReadCard.Text = "Read Card";
            this.ReadCard.UseVisualStyleBackColor = true;
            this.ReadCard.Click += new System.EventHandler(this.ReadCard_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.ReadCard);
            this.Controls.Add(this.ScanningLabel);
            this.Controls.Add(this.CardStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.loadingBar);
            this.Controls.Add(this.BankName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CardNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.totalDue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableNo);
            this.Controls.Add(this.label4);
            this.Name = "Form7";
            this.Text = "Card Payment";
            this.Load += new System.EventHandler(this.Form7_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tableNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox totalDue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.TextBox CardNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BankName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar loadingBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CardStatus;
        private System.Windows.Forms.Label ScanningLabel;
        private System.Windows.Forms.Button ReadCard;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}