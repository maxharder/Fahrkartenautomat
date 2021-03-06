﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahrkartenautomat
{
    class Logik
    {
        private string fahrkarten_Name;
        private List<double> eingezahlt_List = new List<double>() { 0.10, 0.20, 0.50, 1.00, 2.00, 5.00, 10.00, 20.00, 50.00 };

        public string Fahrkarten_Name
        {
            get { return fahrkarten_Name; }
        }

        public double Fahrkarten_click(object sender, double preis)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "button_A":
                    preis += 2.00;
                    fahrkarten_Name = "A";
                    break;
                case "button_AB":
                    preis += 2.90;
                    fahrkarten_Name = "AB";
                    break;
                case "button_BC":
                    preis += 3.30;
                    fahrkarten_Name = "BC";
                    break;
                case "button_ABC":
                    preis += 3.60;
                    fahrkarten_Name = "ABC";
                    break;
            }
            return Math.Round(preis, 2);
        }

        public double Einzahlen(object sender, double eingezahlt)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "button_10_cent":
                    eingezahlt += eingezahlt_List[0];
                    break;
                case "button_20_cent":
                    eingezahlt += eingezahlt_List[1];
                    break;
                case "button_50_cent":
                    eingezahlt += eingezahlt_List[2];
                    break;
                case "button_1_euro":
                    eingezahlt += eingezahlt_List[3];
                    break;
                case "button_2_euro":
                    eingezahlt += eingezahlt_List[4];
                    break;
                case "button_5_euro":
                    eingezahlt += eingezahlt_List[5];
                    break;
                case "button_10_euro":
                    eingezahlt += eingezahlt_List[6];
                    break;
                case "button_20_euro":
                    eingezahlt += eingezahlt_List[7];
                    break;
                case "button_50_euro":
                    eingezahlt += eingezahlt_List[8];
                    break;
            }
            return Math.Round(eingezahlt,2);
        }

        public string Auzahlen(double preis, double eingezahlt)
        {
            string auszahlen_Text = "Wechselgeld: ";
            //Prüft ob genug Geld eingezahlt wurde
            if (preis <= eingezahlt)
            {
                double auszahlen_Geld = Math.Round(eingezahlt - preis,2);
                //Prüft das Wechselgeld
                for (int i = eingezahlt_List.Count -1; i >= 0; i--)
                {
                    //Einzelner Betrag kann öfters ausgezahlt werden
                    while (true)
                    {
                        if (eingezahlt_List[i] <= auszahlen_Geld)
                        {                        
                            auszahlen_Geld = Math.Round(auszahlen_Geld - eingezahlt_List[i], 2);
                            auszahlen_Text += $"{eingezahlt_List[i]} Euro, ";
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                return auszahlen_Text;
            }
            return "";
        }
    }
}
