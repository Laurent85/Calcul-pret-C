using System;

using System.Windows.Forms;

namespace Calcul_prêt_C
{
        public partial class Principal : Form
    {
        public static string somme_principal = "";
        public static string durée_principal = "";
        public static string taux_principal = "";
        public static string mensualités_principal = "";
        public static string somme_travaux = "";
        public static string durée_travaux = "";
        public static string taux_travaux = "";
        public static string mensualités_travaux = "";
        public static string mois = "";
        public static string année = "";

        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                        
        }

        private double Calcul_Durée(TextBox Somme, TextBox Taux, TextBox Mensualités)
        {
            double somme = Convert.ToDouble(Somme.Text);
            double taux = Convert.ToDouble(Taux.Text) / 100 / 12;
            double mensualités = Convert.ToDouble(Mensualités.Text);
            double durée = -(Math.Round((Math.Log10(-(somme * taux / (mensualités)) + 1)) / (Math.Log10(taux + 1)), 0));
            return durée;
        }

        private double Calcul_Mensualités(TextBox Somme, TextBox Taux, TextBox Durée)
        {
            double somme = Convert.ToDouble(Somme.Text);
            double taux = Convert.ToDouble(Taux.Text) / 100 / 12;
            double durée = Convert.ToDouble(Durée.Text);
            double mensualités = Math.Round(somme * taux / (1 - (Math.Pow(taux + 1, -durée))), 2);
            return mensualités;
        }

        private double Calcul_Capital(TextBox Mensualités, TextBox Taux, TextBox Durée)
        {
            double mensualités = Convert.ToDouble(Mensualités.Text);
            double taux = Convert.ToDouble(Taux.Text) / 100 / 12;
            double durée = Convert.ToDouble(Durée.Text);
            double somme = Math.Round(12 * mensualités * ((Math.Pow(taux + 1, durée) - 1) / (Math.Pow(taux + 1, durée) * taux * 12)), 2);
            return somme;
        }

        private Double Calcul_Assurance(TextBox Laurent, TextBox Fab)
        {
            double assurance_laurent = Convert.ToDouble(TextBox_assurance_laurent.Text);
            double assurance_fab = Convert.ToDouble(TextBox_assurance_fab.Text);
            double assurance_totale = Math.Round(assurance_laurent + assurance_fab, 2);
            return assurance_totale;
        }

        private double Calcul_Total(TextBox principal, TextBox travaux, TextBox assurance)
        {
            double mensualités_principal = Convert.ToDouble(TextBox_Mensualités_principal.Text);
            double mensualités_travaux = Convert.ToDouble(TextBox_Mensualités_travaux.Text);
            double mensualités_assurance = Convert.ToDouble(TextBox_Mensualités_assurance.Text);
            double mensualités_total = Math.Round(mensualités_principal + mensualités_travaux + mensualités_assurance, 2);
            return mensualités_total;
        }

        private void Calculer_mensualités_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_Mensualités_principal.Text = (Calcul_Mensualités(Textbox_Somme_principal, TextBox_Taux_principal, TextBox_Durée_principal)).ToString();
            }
            catch { }
            try
            {
                TextBox_Mensualités_travaux.Text = (Calcul_Mensualités(Textbox_Somme_travaux, TextBox_Taux_travaux, TextBox_Durée_travaux)).ToString();
            }
            catch { }
            try
            {
                TextBox_Mensualités_assurance.Text = (Calcul_Assurance(TextBox_assurance_laurent, TextBox_assurance_fab)).ToString();
            }
            catch { }
            try
            {
                TextBox_mensualités_total.Text = (Calcul_Total(TextBox_Mensualités_principal, TextBox_Mensualités_travaux, TextBox_Mensualités_assurance)).ToString();
            }
            catch { }
            Résumé();
        }

        private void Calculer_durée_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_Durée_principal.Text = (Calcul_Durée(Textbox_Somme_principal, TextBox_Taux_principal, TextBox_Mensualités_principal)).ToString();
            }
            catch { }
            try
            {
                TextBox_Durée_travaux.Text = (Calcul_Durée(Textbox_Somme_travaux, TextBox_Taux_travaux, TextBox_Mensualités_travaux)).ToString();
            }
            catch { }
            try
            {
                TextBox_Mensualités_assurance.Text = (Calcul_Assurance(TextBox_assurance_laurent, TextBox_assurance_fab)).ToString();
            }
            catch { }
            try
            {
                TextBox_mensualités_total.Text = (Calcul_Total(TextBox_Mensualités_principal, TextBox_Mensualités_travaux, TextBox_Mensualités_assurance)).ToString();
            }
            catch { }
            Résumé();
        }

        private void Bouton_Calculer_Capital_Click(object sender, EventArgs e)
        {
            try
            {
                Textbox_Somme_principal.Text = (Calcul_Capital(TextBox_Mensualités_principal, TextBox_Taux_principal, TextBox_Durée_principal)).ToString();
            }
            catch { }
            try
            {
                Textbox_Somme_travaux.Text = (Calcul_Capital(TextBox_Mensualités_travaux, TextBox_Taux_travaux, TextBox_Durée_travaux)).ToString();
            }
            catch { }
            try
            {
                TextBox_Mensualités_assurance.Text = (Calcul_Assurance(TextBox_assurance_laurent, TextBox_assurance_fab)).ToString();
            }
            catch { }
            try
            {
                TextBox_mensualités_total.Text = (Calcul_Total(TextBox_Mensualités_principal, TextBox_Mensualités_travaux, TextBox_Mensualités_assurance)).ToString();
            }
            catch { }
            Résumé();
        }

        private void Résumé()
        {
            if (Textbox_Somme_travaux.Text == "") { Textbox_Somme_travaux.Text = "0"; }
            if (TextBox_Durée_travaux.Text == "") { TextBox_Durée_travaux.Text = "0"; }
            if (TextBox_Mensualités_travaux.Text == "") { TextBox_Mensualités_travaux.Text = "0"; }
            if (TextBox_Taux_travaux.Text == "") { TextBox_Taux_travaux.Text = "0"; }
            if (Textbox_Somme_principal.Text == "") { Textbox_Somme_principal.Text = "0"; }
            if (TextBox_Durée_principal.Text == "") { TextBox_Durée_principal.Text = "0"; }
            if (TextBox_Mensualités_principal.Text == "") { TextBox_Mensualités_principal.Text = "0"; }
            if (TextBox_Taux_principal.Text == "") { TextBox_Taux_principal.Text = "0"; }
            if (TextBox_assurance_laurent.Text == "") { TextBox_assurance_laurent.Text = "0"; }
            if (TextBox_assurance_fab.Text == "") { TextBox_assurance_fab.Text = "0"; }
            if (TextBox_Mensualités_assurance.Text == "") { TextBox_Mensualités_assurance.Text = "0"; }

            Résumé_prêt_total.Text = "Prêt total : "
                + (Convert.ToDouble(Textbox_Somme_principal.Text)
                + Convert.ToDouble(Textbox_Somme_travaux.Text))
                + " €"
                + System.Environment.NewLine
                + "Intérêts à rembourser : "
                + Math.Round((Convert.ToDouble(TextBox_Mensualités_principal.Text)
                * Convert.ToDouble(TextBox_Durée_principal.Text)
                - Convert.ToDouble(Textbox_Somme_principal.Text))
                + (Convert.ToDouble(TextBox_Mensualités_travaux.Text)
                * Convert.ToDouble(TextBox_Durée_travaux.Text)
                - Convert.ToDouble(Textbox_Somme_travaux.Text)), 2)
                + " €"
                + System.Environment.NewLine
                + "Montant total du crédit : "
                + (Math.Round((Convert.ToDouble(TextBox_Mensualités_principal.Text)
                * Convert.ToDouble(TextBox_Durée_principal.Text)), 2)
                + Math.Round((Convert.ToDouble(TextBox_Mensualités_travaux.Text)
                * Convert.ToDouble(TextBox_Durée_travaux.Text)), 2))
                + " €";

            résumé_prêt_principal.Text = "Intérêts à rembourser : " + Math.Round((Convert.ToDouble(TextBox_Mensualités_principal.Text) * Convert.ToDouble(TextBox_Durée_principal.Text) - Convert.ToDouble(Textbox_Somme_principal.Text)), 2) + " €" + System.Environment.NewLine + "Total à rembourser : " + Math.Round((Convert.ToDouble(TextBox_Mensualités_principal.Text) * Convert.ToDouble(TextBox_Durée_principal.Text)), 2) + " €";
            résumé_prêt_travaux.Text = "Intérêts à rembourser : " + Math.Round((Convert.ToDouble(TextBox_Mensualités_travaux.Text) * Convert.ToDouble(TextBox_Durée_travaux.Text) - Convert.ToDouble(Textbox_Somme_travaux.Text)), 2) + " €" + System.Environment.NewLine + "Total à rembourser : " + Math.Round((Convert.ToDouble(TextBox_Mensualités_travaux.Text) * Convert.ToDouble(TextBox_Durée_travaux.Text)), 2) + " €";
            Résumé_assurance.Text = "Coût total assurance : " + (Convert.ToDouble(TextBox_assurance_fab.Text) + Convert.ToDouble(TextBox_assurance_laurent.Text)) * Convert.ToDouble(TextBox_Durée_principal.Text) + " €";
            Mensualités_HA.Text = "Mensualités hors-assurance : " + (Math.Round((Convert.ToDouble(TextBox_Mensualités_principal.Text)), 2) + Math.Round((Convert.ToDouble(TextBox_Mensualités_travaux.Text)), 2)) + " €";
        }

        private void RAZ_Click(object sender, EventArgs e)
        {
            Textbox_Somme_principal.Text = "132655,91";
            Textbox_Somme_travaux.Text = "40379,34";
            TextBox_Durée_principal.Text = "187";
            TextBox_Durée_travaux.Text = "199";
            TextBox_Taux_principal.Text = "2,18";
            TextBox_Taux_travaux.Text = "2,18";
            TextBox_assurance_fab.Text = "45,56";
            TextBox_assurance_laurent.Text = "102,40";
            TextBox_Mensualités_principal.Text = "0";
            TextBox_Mensualités_travaux.Text = "0";
            Combobox_Mois.SelectedItem = "Avril";
            Combobox_Année.SelectedItem = "2017";
        }

        private void Button_Tout_Effacer_Click(object sender, EventArgs e)
        {
            Textbox_Somme_principal.Text = "";
            Textbox_Somme_travaux.Text = "";
            TextBox_Durée_principal.Text = "";
            TextBox_Durée_travaux.Text = "";
            TextBox_Taux_principal.Text = "";
            TextBox_Taux_travaux.Text = "";
            TextBox_assurance_fab.Text = "";
            TextBox_assurance_laurent.Text = "";
            TextBox_Mensualités_principal.Text = "";
            TextBox_Mensualités_travaux.Text = "";
            TextBox_Mensualités_assurance.Text = "";
            TextBox_mensualités_total.Text = "";
            Combobox_Mois.SelectedItem = "";
            Combobox_Année.SelectedItem = "";
            Résumé_prêt_total.Text = "";
            résumé_prêt_principal.Text = "";
            résumé_prêt_travaux.Text = "";
            Résumé_assurance.Text = "";
            Mensualités_HA.Text = "";
        }

        private void Button_Tableau_principal_Click(object sender, EventArgs e)
        {
            somme_principal = Textbox_Somme_principal.Text;
            durée_principal = TextBox_Durée_principal.Text;
            taux_principal = TextBox_Taux_principal.Text;
            mensualités_principal = TextBox_Mensualités_principal.Text;
            mois = Combobox_Mois.Text;
            année = Combobox_Année.Text;
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void Button_Tableau_travaux_Click(object sender, EventArgs e)
        {
            somme_travaux = Textbox_Somme_travaux.Text;
            durée_travaux = TextBox_Durée_travaux.Text;
            taux_travaux = TextBox_Taux_travaux.Text;
            mensualités_travaux = TextBox_Mensualités_travaux.Text;
            mois = Combobox_Mois.Text;
            année = Combobox_Année.Text;
            Form3 frm3 = new Form3();
            frm3.Show();
        }
    }
}