using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcul_prêt_C
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            double restant = Convert.ToDouble(Principal.somme_travaux);
            double durée = Convert.ToDouble(Principal.durée_travaux);
            double mensualités = Convert.ToDouble(Principal.mensualités_travaux);
            double taux = Convert.ToDouble(Principal.taux_travaux);
            double intérêts = 0;
            double capital = 0;
            DateTime mois = Convert.ToDateTime(Principal.mois + " " + Principal.année);

            int i = 0;
            for (i = 1; i <= durée; i++)
            {
                intérêts = System.Math.Round((restant / 12 / 100 * taux), 2);
                if (i == durée)
                {
                    capital = restant;
                    mensualités = capital + intérêts;
                }
                else
                {
                    capital = mensualités - intérêts;
                }
                restant = System.Math.Round(restant, 2) - capital;
                Tableau1.Items.Add(i + "\t" + mois.ToString("MMMM yyyy  ") + "\t" + "\t" + mensualités.ToString("0.00") + "\t" + "\t" + capital.ToString("0.00") + "\t" + "\t" + intérêts.ToString("0.00") + "\t" + "\t" + restant.ToString("0.00"));
                mois = mois.AddMonths(1);
            }
        }


        private void Tableau1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Affichage des lignes horizontales de couleur dans la colonne "Nom" (une sur 2)

            {
                if (e.Index % 2 == 0)
                {
                    e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                }
                if (Tableau1.SelectedIndex == e.Index)
                {
                    e.Graphics.FillRectangle(Brushes.Blue, e.Bounds);
                    e.Graphics.DrawString(Tableau1.Items[e.Index].ToString(), this.Font, Brushes.White, 0, e.Bounds.Y + 2);
                }
                else
                {
                    e.Graphics.DrawString(Tableau1.Items[e.Index].ToString(), this.Font, Brushes.Black, 0, e.Bounds.Y + 2);
                }
            }
        }

    }

}

