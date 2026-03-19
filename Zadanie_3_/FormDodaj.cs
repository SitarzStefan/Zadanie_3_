using System;
using System.Windows.Forms;

namespace Zadanie_3_
{
    public partial class FormDodaj : Form
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public string Stanowisko { get; set; }

        public FormDodaj()
        {
            InitializeComponent();

            comboStanowisko.Items.Add("Manager");
            comboStanowisko.Items.Add("Programista");
            comboStanowisko.Items.Add("Tester");

            comboStanowisko.SelectedIndex = 0;

            buttonZatwierdz.Click += buttonZatwierdz_Click;
            buttonAnuluj.Click += buttonAnuluj_Click;
        }

        private void buttonZatwierdz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textImie.Text) || string.IsNullOrWhiteSpace(textNazwisko.Text))
            {
                MessageBox.Show("Imię i nazwisko nie mogą być puste!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Imie = textImie.Text;
            Nazwisko = textNazwisko.Text;
            Wiek = (int)numericWiek.Value;
            Stanowisko = comboStanowisko.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}