namespace Zadanie_3_
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
            btnDodaj = new Button();
            btnUsun = new Button();
            btnZapis = new Button();
            btnOdczyt = new Button();
            dataGridView1 = new DataGridView();
            btnXML = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(334, 37);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(94, 48);
            btnDodaj.TabIndex = 1;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // btnUsun
            // 
            btnUsun.Location = new Point(334, 135);
            btnUsun.Name = "btnUsun";
            btnUsun.Size = new Size(94, 48);
            btnUsun.TabIndex = 2;
            btnUsun.Text = "Usuń";
            btnUsun.UseVisualStyleBackColor = true;
            // 
            // btnZapis
            // 
            btnZapis.Location = new Point(12, 206);
            btnZapis.Name = "btnZapis";
            btnZapis.Size = new Size(141, 29);
            btnZapis.TabIndex = 3;
            btnZapis.Text = "Zapis";
            btnZapis.UseVisualStyleBackColor = true;
            // 
            // btnOdczyt
            // 
            btnOdczyt.Location = new Point(159, 206);
            btnOdczyt.Name = "btnOdczyt";
            btnOdczyt.Size = new Size(153, 29);
            btnOdczyt.TabIndex = 4;
            btnOdczyt.Text = "Odczyt";
            btnOdczyt.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(300, 188);
            dataGridView1.TabIndex = 5;
            // 
            // btnXML
            // 
            btnXML.Location = new Point(334, 206);
            btnXML.Name = "btnXML";
            btnXML.Size = new Size(94, 29);
            btnXML.TabIndex = 6;
            btnXML.Text = "Zapis XML";
            btnXML.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 270);
            Controls.Add(btnXML);
            Controls.Add(dataGridView1);
            Controls.Add(btnOdczyt);
            Controls.Add(btnZapis);
            Controls.Add(btnUsun);
            Controls.Add(btnDodaj);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnDodaj;
        private Button btnUsun;
        private Button btnZapis;
        private Button btnOdczyt;
        private DataGridView dataGridView1;
        private Button btnXML;
    }
}
