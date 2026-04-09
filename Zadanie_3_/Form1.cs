using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace Zadanie_3_
{
    public partial class Form1 : Form
    {
        List<Pracownik> pracownicy = new List<Pracownik>();
        int currentID = 1;

        public Form1()
        {
            InitializeComponent();

            btnDodaj.Click += btnDodaj_Click;
            btnUsun.Click += btnUsun_Click;
            btnZapis.Click += btnZapis_Click;
            btnOdczyt.Click += btnOdczyt_Click;
            buttonJSON.Click += buttonJSON_Click;

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Imie", "Imiê");
            dataGridView1.Columns.Add("Nazwisko", "Nazwisko");
            dataGridView1.Columns.Add("Wiek", "Wiek");
            dataGridView1.Columns.Add("Stanowisko", "Stanowisko");

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
        }

        // ---------------- DODAJ ----------------
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FormDodaj form = new FormDodaj();

            if (form.ShowDialog() == DialogResult.OK)
            {
                Pracownik p = new Pracownik
                {
                    Id = currentID++,
                    Imie = form.Imie,
                    Nazwisko = form.Nazwisko,
                    Wiek = form.Wiek,
                    Stanowisko = form.Stanowisko
                };

                pracownicy.Add(p);
                RefreshGrid();
            }
        }

        // ---------------- REFRESH GRID ----------------
        private void RefreshGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (var p in pracownicy)
            {
                dataGridView1.Rows.Add(p.Id, p.Imie, p.Nazwisko, p.Wiek, p.Stanowisko);
            }
        }

        // ---------------- USUÑ ----------------
        private void btnUsun_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.IsNewRow) continue;

                int id = Convert.ToInt32(row.Cells["ID"].Value);

                var item = pracownicy.FirstOrDefault(x => x.Id == id);
                if (item != null)
                    pracownicy.Remove(item);
            }

            RefreshGrid();
        }

        // ---------------- CSV ZAPIS ----------------
        private void btnZapis_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    sw.WriteLine("ID,Imie,Nazwisko,Wiek,Stanowisko");

                    foreach (var p in pracownicy)
                    {
                        sw.WriteLine($"{p.Id},{p.Imie},{p.Nazwisko},{p.Wiek},{p.Stanowisko}");
                    }
                }

                MessageBox.Show("Zapis CSV OK");
            }
        }

        // ---------------- CSV ODCZYT ----------------
        private void btnOdczyt_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pracownicy.Clear();

                using (TextFieldParser parser = new TextFieldParser(ofd.FileName))
                {
                    parser.SetDelimiters(",");

                    parser.ReadLine(); // nag³ówek

                    while (!parser.EndOfData)
                    {
                        string[] row = parser.ReadFields();

                        pracownicy.Add(new Pracownik
                        {
                            Id = int.Parse(row[0]),
                            Imie = row[1],
                            Nazwisko = row[2],
                            Wiek = int.Parse(row[3]),
                            Stanowisko = row[4]
                        });
                    }
                }

                currentID = pracownicy.Count > 0 ? pracownicy.Max(x => x.Id) + 1 : 1;

                RefreshGrid();
            }
        }

        // ---------------- JSON ZAPIS ----------------
        private void buttonJSON_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JSON (*.json)|*.json";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string json = JsonSerializer.Serialize(pracownicy, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(sfd.FileName, json);

                MessageBox.Show("Zapis JSON OK");
            }
        }

        // ---------------- JSON ODCZYT (opcjonalny jeœli chcesz) ----------------
        private void LoadJSON(string path)
        {
            string json = File.ReadAllText(path);

            pracownicy = JsonSerializer.Deserialize<List<Pracownik>>(json) ?? new List<Pracownik>();

            currentID = pracownicy.Count > 0 ? pracownicy.Max(x => x.Id) + 1 : 1;

            RefreshGrid();
        }
    }
}