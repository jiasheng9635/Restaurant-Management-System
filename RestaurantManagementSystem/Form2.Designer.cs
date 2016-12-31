namespace RestaurantManagementSystem
{
    partial class Form2
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
            this.label2 = new System.Windows.Forms.Label();
            this.DoneButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.VoidButton = new System.Windows.Forms.Button();
            this.KitchenLV = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(267, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Item queue list";
            // 
            // DoneButton
            // 
            this.DoneButton.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneButton.Location = new System.Drawing.Point(660, 28);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(87, 87);
            this.DoneButton.TabIndex = 3;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(106, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Welcome back, Chef";
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(12, 12);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(87, 29);
            this.QuitButton.TabIndex = 16;
            this.QuitButton.Text = "Log Out";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // VoidButton
            // 
            this.VoidButton.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoidButton.Location = new System.Drawing.Point(567, 28);
            this.VoidButton.Name = "VoidButton";
            this.VoidButton.Size = new System.Drawing.Size(87, 87);
            this.VoidButton.TabIndex = 18;
            this.VoidButton.Text = "Void";
            this.VoidButton.UseVisualStyleBackColor = true;
            this.VoidButton.Click += new System.EventHandler(this.VoidButton_Click);
            // 
            // KitchenLV
            // 
            this.KitchenLV.Location = new System.Drawing.Point(29, 121);
            this.KitchenLV.Name = "KitchenLV";
            this.KitchenLV.Size = new System.Drawing.Size(718, 404);
            this.KitchenLV.TabIndex = 19;
            this.KitchenLV.UseCompatibleStateImageBehavior = false;
            // 
            // chef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.KitchenLV);
            this.Controls.Add(this.VoidButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.label2);
            this.Name = "chef";
            this.Text = "Restaurant Management System";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button VoidButton;
        private System.Windows.Forms.ListView KitchenLV;
    }
}