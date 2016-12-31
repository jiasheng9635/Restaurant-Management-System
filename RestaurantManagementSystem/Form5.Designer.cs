namespace RestaurantManagementSystem
{
    partial class Form5
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
            this.label3 = new System.Windows.Forms.Label();
            this.TableNoCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemNameCB = new System.Windows.Forms.ComboBox();
            this.DoneButton = new System.Windows.Forms.Button();
            this.deleteAll = new System.Windows.Forms.Button();
            this.deleteOne = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.QuantityCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ItemTypeCB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Table No.  :";
            // 
            // TableNoCB
            // 
            this.TableNoCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableNoCB.FormattingEnabled = true;
            this.TableNoCB.Location = new System.Drawing.Point(152, 56);
            this.TableNoCB.Name = "TableNoCB";
            this.TableNoCB.Size = new System.Drawing.Size(124, 28);
            this.TableNoCB.TabIndex = 13;
            this.TableNoCB.SelectedIndexChanged += new System.EventHandler(this.TableNoCB_SelectedIndexChanged);
            this.TableNoCB.TextUpdate += new System.EventHandler(this.TableNoCB_TextUpdate);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Item Name :";
            // 
            // ItemNameCB
            // 
            this.ItemNameCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemNameCB.FormattingEnabled = true;
            this.ItemNameCB.Location = new System.Drawing.Point(152, 133);
            this.ItemNameCB.Name = "ItemNameCB";
            this.ItemNameCB.Size = new System.Drawing.Size(380, 28);
            this.ItemNameCB.TabIndex = 11;
            this.ItemNameCB.SelectedIndexChanged += new System.EventHandler(this.ItemNameCB_SelectedIndexChanged);
            this.ItemNameCB.TextUpdate += new System.EventHandler(this.ItemNameCB_TextUpdate);
            // 
            // DoneButton
            // 
            this.DoneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneButton.Location = new System.Drawing.Point(384, 262);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(106, 58);
            this.DoneButton.TabIndex = 18;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // deleteAll
            // 
            this.deleteAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAll.Location = new System.Drawing.Point(238, 262);
            this.deleteAll.Name = "deleteAll";
            this.deleteAll.Size = new System.Drawing.Size(106, 58);
            this.deleteAll.TabIndex = 17;
            this.deleteAll.Text = "Delete All Item";
            this.deleteAll.UseVisualStyleBackColor = true;
            this.deleteAll.Click += new System.EventHandler(this.deleteAll_Click);
            // 
            // deleteOne
            // 
            this.deleteOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteOne.Location = new System.Drawing.Point(94, 262);
            this.deleteOne.Name = "deleteOne";
            this.deleteOne.Size = new System.Drawing.Size(106, 58);
            this.deleteOne.TabIndex = 19;
            this.deleteOne.Text = "Delete Item";
            this.deleteOne.UseVisualStyleBackColor = true;
            this.deleteOne.Click += new System.EventHandler(this.deleteOne_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Quantity    :";
            // 
            // QuantityCB
            // 
            this.QuantityCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityCB.FormattingEnabled = true;
            this.QuantityCB.Location = new System.Drawing.Point(152, 171);
            this.QuantityCB.Name = "QuantityCB";
            this.QuantityCB.Size = new System.Drawing.Size(124, 28);
            this.QuantityCB.TabIndex = 20;
            this.QuantityCB.SelectedIndexChanged += new System.EventHandler(this.QuantityCB_SelectedIndexChanged);
            this.QuantityCB.TextUpdate += new System.EventHandler(this.QuantityCB_TextUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Item Type  :";
            // 
            // ItemTypeCB
            // 
            this.ItemTypeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemTypeCB.FormattingEnabled = true;
            this.ItemTypeCB.Location = new System.Drawing.Point(152, 94);
            this.ItemTypeCB.Name = "ItemTypeCB";
            this.ItemTypeCB.Size = new System.Drawing.Size(380, 28);
            this.ItemTypeCB.TabIndex = 22;
            this.ItemTypeCB.SelectedIndexChanged += new System.EventHandler(this.ItemTypeCB_SelectedIndexChanged);
            this.ItemTypeCB.TextUpdate += new System.EventHandler(this.ItemTypeCB_TextUpdate);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(184, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Cancel Item from Menu";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ItemTypeCB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.QuantityCB);
            this.Controls.Add(this.deleteOne);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.deleteAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TableNoCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ItemNameCB);
            this.Name = "Form5";
            this.Text = "Cancel Item";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TableNoCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ItemNameCB;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Button deleteAll;
        private System.Windows.Forms.Button deleteOne;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox QuantityCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ItemTypeCB;
        private System.Windows.Forms.Label label6;
    }
}