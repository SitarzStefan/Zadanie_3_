namespace Zadanie_3_
{
    partial class FormDodaj
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
            buttonZatwierdz = new Button();
            buttonAnuluj = new Button();
            comboStanowisko = new ComboBox();
            textImie = new TextBox();
            textNazwisko = new TextBox();
            numericWiek = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericWiek).BeginInit();
            SuspendLayout();
            // 
            // buttonZatwierdz
            // 
            buttonZatwierdz.Location = new Point(12, 145);
            buttonZatwierdz.Name = "buttonZatwierdz";
            buttonZatwierdz.Size = new Size(94, 29);
            buttonZatwierdz.TabIndex = 0;
            buttonZatwierdz.Text = "Zatwierdź";
            buttonZatwierdz.UseVisualStyleBackColor = true;
            // 
            // buttonAnuluj
            // 
            buttonAnuluj.Location = new Point(112, 145);
            buttonAnuluj.Name = "buttonAnuluj";
            buttonAnuluj.Size = new Size(94, 29);
            buttonAnuluj.TabIndex = 1;
            buttonAnuluj.Text = "Anuluj";
            buttonAnuluj.UseVisualStyleBackColor = true;
            // 
            // comboStanowisko
            // 
            comboStanowisko.FormattingEnabled = true;
            comboStanowisko.Location = new Point(12, 111);
            comboStanowisko.Name = "comboStanowisko";
            comboStanowisko.Size = new Size(194, 28);
            comboStanowisko.TabIndex = 2;
            // 
            // textImie
            // 
            textImie.Location = new Point(12, 12);
            textImie.Name = "textImie";
            textImie.Size = new Size(194, 27);
            textImie.TabIndex = 3;
            // 
            // textNazwisko
            // 
            textNazwisko.Location = new Point(12, 45);
            textNazwisko.Name = "textNazwisko";
            textNazwisko.Size = new Size(194, 27);
            textNazwisko.TabIndex = 4;
            // 
            // numericWiek
            // 
            numericWiek.Location = new Point(12, 78);
            numericWiek.Name = "numericWiek";
            numericWiek.Size = new Size(194, 27);
            numericWiek.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(212, 19);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 6;
            label1.Text = "Imię";
            
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(212, 48);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 7;
            label2.Text = "Nazwisko";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(212, 85);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 8;
            label3.Text = "Wiek";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(212, 114);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 9;
            label4.Text = "Stanowisko";
            // 
            // FormDodaj
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 233);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericWiek);
            Controls.Add(textNazwisko);
            Controls.Add(textImie);
            Controls.Add(comboStanowisko);
            Controls.Add(buttonAnuluj);
            Controls.Add(buttonZatwierdz);
            Name = "FormDodaj";
            Text = "FormDodaj";
            ((System.ComponentModel.ISupportInitialize)numericWiek).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonZatwierdz;
        private Button buttonAnuluj;
        private ComboBox comboStanowisko;
        private TextBox textImie;
        private TextBox textNazwisko;
        private NumericUpDown numericWiek;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}