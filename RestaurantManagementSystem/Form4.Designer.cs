namespace RestaurantManagementSystem
{
    partial class Form4
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
            this.ItemTypeCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemNameCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TableNoCB = new System.Windows.Forms.ComboBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.DoneButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.QuantityCB = new System.Windows.Forms.ComboBox();
            this.PriceTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ItemTypeCB
            // 
            this.ItemTypeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemTypeCB.FormattingEnabled = true;
            this.ItemTypeCB.Location = new System.Drawing.Point(152, 94);
            this.ItemTypeCB.Name = "ItemTypeCB";
            this.ItemTypeCB.Size = new System.Drawing.Size(380, 28);
            this.ItemTypeCB.TabIndex = 0;
            this.ItemTypeCB.SelectedIndexChanged += new System.EventHandler(this.ItemTypeCB_SelectedIndexChanged);
            this.ItemTypeCB.TextUpdate += new System.EventHandler(this.ItemTypeCB_TextUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item Type  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Item Name :";
            // 
            // ItemNameCB
            // 
            this.ItemNameCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemNameCB.FormattingEnabled = true;
            this.ItemNameCB.Location = new System.Drawing.Point(152, 133);
            this.ItemNameCB.Name = "ItemNameCB";
            this.ItemNameCB.Size = new System.Drawing.Size(380, 28);
            this.ItemNameCB.TabIndex = 2;
            this.ItemNameCB.SelectedIndexChanged += new System.EventHandler(this.ItemNameCB_SelectedIndexChanged);
            this.ItemNameCB.TextUpdate += new System.EventHandler(this.ItemNameCB_TextUpdate);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Table No.  :";
            // 
            // TableNoCB
            // 
            this.TableNoCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableNoCB.FormattingEnabled = true;
            this.TableNoCB.Location = new System.Drawing.Point(152, 56);
            this.TableNoCB.Name = "TableNoCB";
            this.TableNoCB.Size = new System.Drawing.Size(124, 28);
            this.TableNoCB.TabIndex = 4;
            this.TableNoCB.SelectedIndexChanged += new System.EventHandler(this.TableNoCB_SelectedIndexChanged);
            this.TableNoCB.TextUpdate += new System.EventHandler(this.TableNoCB_TextUpdate);
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(170, 262);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(106, 58);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Add Item";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DoneButton
            // 
            this.DoneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneButton.Location = new System.Drawing.Point(316, 262);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(106, 58);
            this.DoneButton.TabIndex = 7;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Item Price  : RM";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Quantity    :";
            // 
            // QuantityCB
            // 
            this.QuantityCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityCB.FormattingEnabled = true;
            this.QuantityCB.Location = new System.Drawing.Point(152, 171);
            this.QuantityCB.Name = "QuantityCB";
            this.QuantityCB.Size = new System.Drawing.Size(124, 28);
            this.QuantityCB.TabIndex = 9;
            this.QuantityCB.SelectedIndexChanged += new System.EventHandler(this.QuantityCB_SelectedIndexChanged);
            this.QuantityCB.TextUpdate += new System.EventHandler(this.QuantityCB_TextUpdate);
            // 
            // PriceTB
            // 
            this.PriceTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceTB.Location = new System.Drawing.Point(183, 211);
            this.PriceTB.Name = "PriceTB";
            this.PriceTB.Size = new System.Drawing.Size(100, 27);
            this.PriceTB.TabIndex = 11;
            this.PriceTB.TextChanged += new System.EventHandler(this.PriceTB_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(190, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Add New Item to Menu";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PriceTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.QuantityCB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TableNoCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ItemNameCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ItemTypeCB);
            this.Name = "Form4";
            this.Text = "New Item";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ItemTypeCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ItemNameCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TableNoCB;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox QuantityCB;
        private System.Windows.Forms.TextBox PriceTB;
        private System.Windows.Forms.Label label6;
    }
}