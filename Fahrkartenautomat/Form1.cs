using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahrkartenautomat
{
    public partial class Form1 : Form
    {
        private double preis = 0;
        private double eingezahlt = 0;
        private Logik logik = new Logik();

        public Form1()
        {
            InitializeComponent();
            linke_Seite_anzeigen();
        }

        private void listeAnzeigen(string item)
        {
            button_bezahlen.Enabled = true;
            button_reset.Enabled = true;
            listBox_ausgaben.Items.Add(item);
        }

        //--------------------------- Auswahl ---------------------------//

        //Fahrkarte auswählen
        private void Fahrkarten_Click(object sender, EventArgs e)
        {
            preis = logik.Fahrkarten_click(sender, preis);
            label_fahrkartenkosten.Text = preis.ToString() + " Euro";
            listeAnzeigen(logik.Fahrkarten_Name);
        }

        //Fahrkarten löschen
        private void reset_Click(object sender, EventArgs e)
        {
            linke_Seite_anzeigen();
        }

        //Zur Bezahlung
        private void bezahlen_Click(object sender, EventArgs e)
        {
            rechte_Seite_anzeigen();
        }

        //--------------------------- Bezahlung ----------------------------//

        //Geld in den Automaten stecken
        private void Einzahlen_Click(object sender, EventArgs e)
        {
            eingezahlt = logik.Einzahlen(sender, eingezahlt);
            label_eingezahlt.Text = eingezahlt.ToString() + " Euro";

            string auszahlen = logik.Auzahlen(preis, eingezahlt);
            if (!auszahlen.Equals(""))
            {
                listBox_ausgaben.Items.Clear();
                listBox_ausgaben.Items.Add("Die Fahrkarte wird ausgedruckt und das Wechselgeld wird ausgezahlt.");
                listBox_ausgaben.Items.Add(auszahlen);
                listBox_ausgaben.Items.Add("Bitte warten. (5 Sekunden)");
                System.Windows.Forms.Application.DoEvents();
                Thread.Sleep(5000);
                linke_Seite_anzeigen();
            }
        }

        //Bezahlung abbrechen
        private void abbrechen_Click(object sender, EventArgs e)
        {
            linke_Seite_anzeigen();
        }


        //--------------------------- Anzeige ---------------------------//

        private void rechte_Seite_anzeigen()
        {
            button_10_cent.Enabled = true;
            button_20_cent.Enabled = true;
            button_50_cent.Enabled = true;
            button_1_euro.Enabled = true;
            button_2_euro.Enabled = true;
            button_5_euro.Enabled = true;
            button_10_euro.Enabled = true;
            button_20_euro.Enabled = true;
            button_50_euro.Enabled = true;
            button_abbrechen.Enabled = true;
            label_eingezahlt.Enabled = true;
            button_bezahlen.Enabled = true;
            button_reset.Enabled = true;

            button_A.Enabled = false;
            button_AB.Enabled = false;
            button_AC.Enabled = false;
            button_ABC.Enabled = false;
            label_fahrkartenkosten.Enabled = false;
            label_preis.Enabled = false;
        }

        private void linke_Seite_anzeigen()
        {
            button_10_cent.Enabled = false;
            button_20_cent.Enabled = false;
            button_50_cent.Enabled = false;
            button_1_euro.Enabled = false;
            button_2_euro.Enabled = false;
            button_5_euro.Enabled = false;
            button_10_euro.Enabled = false;
            button_20_euro.Enabled = false;
            button_50_euro.Enabled = false;
            button_abbrechen.Enabled = false;
            label_eingezahlt.Enabled = false;
            button_bezahlen.Enabled = false;
            button_reset.Enabled = false;

            button_A.Enabled = true;
            button_AB.Enabled = true;
            button_AC.Enabled = true;
            button_ABC.Enabled = true;
            label_fahrkartenkosten.Enabled = true;
            label_preis.Enabled = true;

            preis = 0;
            eingezahlt = 0;
            label_fahrkartenkosten.Text = preis.ToString() + " Euro";
            label_eingezahlt.Text = eingezahlt.ToString() + " Euro";
            listBox_ausgaben.Items.Clear();
        }
    }
}
