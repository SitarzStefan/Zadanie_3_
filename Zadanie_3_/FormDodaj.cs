using System;
using System.Windows.Forms;

namespace Zadanie_3_
{
    public partial class FormDodaj : Form
    {
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public int Wiek { get; private set; }
        public string Stanowisko { get; private set; }

        public FormDodaj()
        {
            InitializeComponent();

            // PODPIĘCIE EVENTÓW
            buttonZatwierdz.Click += buttonZatwierdz_Click;
            buttonAnuluj.Click += buttonAnuluj_Click;

            // opcjonalnie
            comboStanowisko.Items.AddRange(new string[]
            {
                "Programista",
                "Tester",
                "Manager",
                "Analityk"
            });

            comboStanowisko.SelectedIndex = 0;
        }

        private void buttonZatwierdz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textImie.Text) ||
                string.IsNullOrWhiteSpace(textNazwisko.Text))
            {
                MessageBox.Show("Uzupełnij dane!");
                return;
            }

            Imie = textImie.Text;
            Nazwisko = textNazwisko.Text;
            Wiek = (int)numericWiek.Value;
            Stanowisko = comboStanowisko.SelectedItem?.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}