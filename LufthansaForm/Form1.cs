using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LufthansaForm
{
    public partial class Form1 : Form
    {

        public Lufthansa lf;
        public Form1()
        {
            InitializeComponent();
            lf = new Lufthansa();
            //ucitavanje letova iz XML-a na datagridview

            if(File.Exists("lufthansa.xml"))
            {
                lf.letovi = XMLSerialization.ReadXML<List<UneseniLet>>();
                foreach (UneseniLet ul in lf.letovi)
                {
                    dodajNaDataGridView(ul);
                }
            }
        }

        private void podaciOLetuGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void izracunajCijenuLetaButton_Click(object sender, EventArgs e)
        {
            IzracunajCijenuLeta();
        }

        private Let IzracunajCijenuLeta()
        {
            Let l = new Let();
            double distanca = 0;
            int prtljag = 0;
            int klasa;
            double taksa;
            double konacnaCijena;

            //prtljag se mora unijeti
            try
            {
                l.prtljag = Convert.ToInt32(prtljagTextBox.Text);
                errorProvider1.Clear();
            }
            catch (Exception)
            {
                errorProvider1.SetError(prtljagTextBox, "Prtljag se mora unijeti");
                return null;
            }

            try
            {
                l._od = odComboBox.SelectedItem.ToString();
                l._do = doComboBox.SelectedItem.ToString();
            }
            catch (Exception)
            {
                errorProvider1.SetError(doComboBox, "Nevalidne destinacije");
                return null;
            }

            //distanca se mora unijeti 
            try
            {
                l.distanca = Convert.ToDouble(distancaTextBox.Text);
                errorProvider1.Clear();
            }
            catch (Exception)
            {
                errorProvider1.SetError(distancaTextBox, "Distanca se mora unijeti");
                return null;
            }


            //nije unesena cijena
            if (cijenaLetaTextBox.Text == "")
            {
                try
                {
                    taksa = Convert.ToDouble(takseTextBox.Text);
                    errorProvider1.Clear();
                }
                catch (Exception)
                {
                    errorProvider1.SetError(takseTextBox, "Unesite taksu");
                    return null;
                }

                klasa = trackBar1.Value;
                l.klasa = klasa;
                l.taksa = taksa;
                //MessageBox.Show(klasa.ToString());
                konacnaCijena = l.izracunajCijenu();
                cijenaLetaTextBox.Text = konacnaCijena.ToString();
            }
            //nije unesena taksa
            else if (takseTextBox.Text == "")
            {
                try
                {
                    konacnaCijena = Convert.ToDouble(cijenaLetaTextBox.Text);
                    errorProvider1.Clear();
                }
                catch (Exception)
                {
                    errorProvider1.SetError(cijenaLetaTextBox, "Unesite cijenu");
                    return null;
                }
                
                klasa = trackBar1.Value;
                l.klasa = klasa;
                taksa = l.izracunajTaksu(konacnaCijena, l.prtljag, l.distanca, l.klasa);
                taksa = Math.Round(taksa, 4);
                takseTextBox.Text = taksa.ToString();
                l.taksa = taksa;
                return l;
            }

            klasa = trackBar1.Value;
            l.klasa = klasa;
            taksa = Convert.ToDouble(takseTextBox.Text);
            l.taksa = taksa;
            konacnaCijena = l.izracunajCijenu();
            cijenaLetaTextBox.Text = konacnaCijena.ToString();

            return l;
        }

        private void rezervisiLetButton_Click(object sender, EventArgs e)
        {
            //posiljaoc
            string ime = imeTextBox.Text;
            string prezime = prezimeTextBox.Text;
            string jmbg = JMBGTextBox.Text;
            string telefon = telefonTextBox.Text;
            string komentar = komentarRichTextBox.Text;
            Posiljaoc p = new Posiljaoc();
            try
            {
                p.ime = ime;
                errorProvider1.Clear();
            }
            catch (Exception)
            {
                errorProvider1.SetError(imeTextBox, "unesite ime");
                return;
            }

            try
            {
                p.prezime = prezime;
                errorProvider1.Clear();
            }
            catch (Exception)
            {
                errorProvider1.SetError(prezimeTextBox, "unesite prezime");
                return;
            }

            try
            {
                p.JMBG = jmbg;
                errorProvider1.Clear();
            }
            catch (Exception)
            {
                errorProvider1.SetError(JMBGTextBox, "unesite ispravan jmbg");
                return;
            }

            try
            {
                p.kontakt = telefon;
                errorProvider1.Clear();
            }
            catch (Exception)
            {
                errorProvider1.SetError(telefonTextBox, "unesite ispravan telefon");
                return;
            }
            //Posiljaoc p = new Posiljaoc(ime, prezime, jmbg, telefon, komentar);
            //let

            Let l = IzracunajCijenuLeta();
            int id = 0;
            if(lf.letovi != null)
                id = lf.letovi.Count() + 1;
            //uneseni let
            double cijena = Convert.ToDouble(cijenaLetaTextBox.Text);
            UneseniLet ul = new UneseniLet(p, l, id, cijena);
            //dodavanje
            if (ul != null)
            {
                lf.letovi.Add(ul);
                dodajNaDataGridView(ul);
                //serijalizacija
                XMLSerialization.WriteXML<List<UneseniLet>>(lf.letovi);
            }
        }

        private void dodajNaDataGridView(UneseniLet ul)
        {
            dataGridView1.Rows.Add(ul.ID, ul.let.distanca, ul.let.prtljag, ul.let.taksa,
                ul.let.klasa, ul.posiljaoc.ToString(), ul.posiljaoc.JMBG, ul.posiljaoc.kontakt, ul.posiljaoc.komentar);
        }

        private void izbrisiUneseniLetButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                //brisanje iz dgv
                lf.letovi.Remove(lf.letovi.Find(x => x.ID == Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value)));
                //ponovna serijalizacija
                XMLSerialization.WriteXML<List<UneseniLet>>(lf.letovi);
                dataGridView1.Rows.Clear();
                foreach (UneseniLet ul in lf.letovi)
                {
                    dodajNaDataGridView(ul);
                }
            }
            
        }
    }
}
