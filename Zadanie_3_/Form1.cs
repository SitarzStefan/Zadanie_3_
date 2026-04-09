using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Xml.Serialization;

namespace Zadanie_3_
{
    public partial class Form1 : Form
    {
        int currentID = 1;

        public Form1()
        {
            InitializeComponent();

            btnDodaj.Click += btnDodaj_Click;
            btnUsun.Click += btnUsun_Click;
            btnZapis.Click += btnZapis_Click;
            btnOdczyt.Click += btnOdczyt_Click;
            btnXML.Click += btnXML_Click;

            SetupGrid();
        }

        // ================= GRID SETUP =================
        private void SetupGrid()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Imie", "Imiê");
            dataGridView1.Columns.Add("Nazwisko", "Nazwisko");
            dataGridView1.Columns.Add("Wiek", "Wiek");
            dataGridView1.Columns.Add("Stanowisko", "Stanowisko");

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
        }

        // ================= DODAJ =================
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FormDodaj form = new FormDodaj();

            if (form.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Add(
                    currentID++,
                    form.Imie,
                    form.Nazwisko,
                    form.Wiek,
                    form.Stanowisko
                );
            }
        }

        // ================= USUÑ =================
        private void btnUsun_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow)
                    dataGridView1.Rows.Remove(row);
            }
        }

        // ================= CSV ZAPIS =================
        private void btnZapis_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToCSV(sfd.FileName);
            }
        }

        private void ExportToCSV(string path)
        {
            var csv = "";

            var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
            csv += string.Join(",", headers.Select(c => c.HeaderText)) + Environment.NewLine;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    var values = row.Cells.Cast<DataGridViewCell>()
                        .Select(c =>
                        {
                            string val = c.Value?.ToString() ?? "";
                            if (val.Contains(",") || val.Contains("\""))
                                val = "\"" + val.Replace("\"", "\"\"") + "\"";
                            return val;
                        });

                    csv += string.Join(",", values) + Environment.NewLine;
                }
            }

            File.WriteAllText(path, csv);
        }

        // ================= CSV ODCZYT =================
        private void btnOdczyt_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadCSV(ofd.FileName);
            }
        }

        private void LoadCSV(string path)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                string[] headers = parser.ReadFields();

                foreach (var h in headers)
                    dataGridView1.Columns.Add(h, h);

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    dataGridView1.Rows.Add(fields);
                }
            }

            // ID reset
            try
            {
                currentID = dataGridView1.Rows.Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow && r.Cells["ID"].Value != null)
                    .Max(r => int.Parse(r.Cells["ID"].Value.ToString())) + 1;
            }
            catch
            {
                currentID = 1;
            }
        }

        // ================= XML =================
        private List<Pracownik> PobierzZGridu()
        {
            List<Pracownik> lista = new List<Pracownik>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells[0].Value == null) continue;

                lista.Add(new Pracownik
                {
                    Id = Convert.ToInt32(row.Cells[0].Value),
                    Imie = row.Cells[1].Value?.ToString(),
                    Nazwisko = row.Cells[2].Value?.ToString(),
                    Wiek = Convert.ToInt32(row.Cells[3].Value),
                    Stanowisko = row.Cells[4].Value?.ToString()
                });
            }

            return lista;
        }

        private void ZapisXML(List<Pracownik> lista)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Pracownik>));

            using (FileStream fs = new FileStream("pracownicy.xml", FileMode.Create))
            {
                serializer.Serialize(fs, lista);
            }
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            var lista = PobierzZGridu();
            ZapisXML(lista);

            MessageBox.Show("Zapis XML wykonany!");
        }
    }
}