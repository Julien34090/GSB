using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GSB
{
    public partial class Interface : System.Windows.Forms.Form
    {
        BDD BDD;
        Personnel unPersonnel;
        List<Personnel> lesPersonnels;
        Visiteur unVisiteur;
        List<Visiteur> lesVisiteurs;
        Technicien unTechnicien;
        List<Technicien> lesTechniciens;
        Produit unProduit;
        List<Produit> lesProduits;
        MySqlDataReader rdr;


        public Interface()
        {
            InitializeComponent();
        }

        private void clôreUnTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBoxAjouterPersonnel_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void personnel_Click(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {

        }

        private void label76_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void visite_Click(object sender, EventArgs e)
        {

        }

        // ******************************************************* //

        private void Interface_Load(object sender, EventArgs e)
        {
            BDD = new BDD();
            lesPersonnels = new List<Personnel>();
            lesVisiteurs = new List<Visiteur>();
            lesTechniciens = new List<Technicien>();
            lesProduits = new List<Produit>();

            actualiserListeProduitOngletProduit();
        }

        private void actualiserListeProduitOngletProduit()
        {
            listeProduits.Items.Clear();

            string requete = "SELECT * FROM PRODUIT;";

            MySqlCommand cmd = BDD.executerRequete(requete);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listeProduits.Items.Add(rdr.GetInt32(0) + " Le produit: " + rdr.GetString(1) + " Effet: " + rdr.GetString(2) + " CI: " + rdr.GetString(3) + " Compo: " + rdr.GetString(4) + " Poso: " + rdr.GetString(5) + " Coût: " + rdr.GetDouble(7));
            }

            rdr.Close();
        }

        private void actualiserListePersonnelOngletPersonnel()
        {
            listePersonnel.Items.Clear();

            foreach (Personnel Per in lesPersonnels)
            {
                listePersonnel.Items.Add(Per.infos());
            }

            foreach (Visiteur Vis in lesVisiteurs)
            {
                listePersonnel.Items.Add(Vis.infos());
            }

            foreach (Technicien Tec in lesTechniciens)
            {
                listePersonnel.Items.Add(Tec.infos());
            }
        }

        private void majStatsPersonnel()
        {
            int VisiteurMédical = 0;
            int DéléguéRégional = 0;
            int ResponsableRégion = 0;
            int Technicien = 0;
            int TechnicienSupérieur = 0;
            int Autre = 0;

            foreach (Personnel Per in lesPersonnels)
            {
                if (Per.Role == "Responsable région")
                {
                    ResponsableRégion++;
                }
                else
                {
                    Autre++;
                }
            }

            foreach (Visiteur Vis in lesVisiteurs)
            {
                if (Vis.Role == "Visiteur médical")
                {
                    VisiteurMédical++;
                }
                else
                {
                    DéléguéRégional++;
                }
            }

            foreach (Technicien Tec in lesTechniciens)
            {
                if (Tec.Role == "Technicien")
                {
                    Technicien++;
                }
                else
                {
                    TechnicienSupérieur++;
                }
            }

            nbVisiteurMédical.Text = VisiteurMédical.ToString();
            nbDéléguéRégional.Text = DéléguéRégional.ToString();
            nbResponsableRégion.Text = ResponsableRégion.ToString();
            nbTechnicien.Text = Technicien.ToString();
            nbTechnicienSupérieur.Text = TechnicienSupérieur.ToString();
            nbAutre.Text = Autre.ToString();
        }

        private void btAjouterPersonnel_Click(object sender, EventArgs e)
        {
            if (rbVisiteur.Checked)
            {
                unVisiteur = new Visiteur(tbObjectifVisiteur.Text, Convert.ToInt32(tbPrimeVisiteur.Text), tbAvantagesVisiteur.Text, Convert.ToInt32(tbBudgetVisiteur.Text), tbNomPersonnel.Text, tbPrénomPersonnel.Text, tbDateEmbauchePersonnel.Text, tbRégionPersonnel.Text, tbMailPersonnel.Text, "Visiteur médical");
                lesVisiteurs.Add(unVisiteur);
            }

            else if (rbDéléguéRégional.Checked)
            {
                unVisiteur = new Visiteur(tbObjectifVisiteur.Text, Convert.ToInt32(tbPrimeVisiteur.Text), tbAvantagesVisiteur.Text, Convert.ToInt32(tbBudgetVisiteur.Text), tbNomPersonnel.Text, tbPrénomPersonnel.Text, tbDateEmbauchePersonnel.Text, tbRégionPersonnel.Text, tbMailPersonnel.Text, "Délégué régional");
                lesVisiteurs.Add(unVisiteur);
            }

            else if (rbTechnicien.Checked)
            {
                unTechnicien = new Technicien(Convert.ToInt32(tbNiveauInterventionTechnicien.Text), tbFormationTechnicien.Text, tbCompetencesTechnicien.Text, tbNomPersonnel.Text, tbPrénomPersonnel.Text, tbDateEmbauchePersonnel.Text, tbRégionPersonnel.Text, tbMailPersonnel.Text, "Technicien");
                lesTechniciens.Add(unTechnicien);
            }

            else if (rbTechnicienSupérieur.Checked)
            {
                unTechnicien = new Technicien(Convert.ToInt32(tbNiveauInterventionTechnicien.Text), tbFormationTechnicien.Text, tbCompetencesTechnicien.Text, tbNomPersonnel.Text, tbPrénomPersonnel.Text, tbDateEmbauchePersonnel.Text, tbRégionPersonnel.Text, tbMailPersonnel.Text, "Technicien supérieur");
                lesTechniciens.Add(unTechnicien);
            }

            else if (rbResponsableRégion.Checked)
            {
                unPersonnel = new Personnel(tbNomPersonnel.Text, tbPrénomPersonnel.Text, tbDateEmbauchePersonnel.Text, tbRégionPersonnel.Text, tbMailPersonnel.Text, "Responsable région");
                lesPersonnels.Add(unPersonnel);
            }

            else
            {
                unPersonnel = new Personnel(tbNomPersonnel.Text, tbPrénomPersonnel.Text, tbDateEmbauchePersonnel.Text, tbRégionPersonnel.Text, tbMailPersonnel.Text, "Autre");
                lesPersonnels.Add(unPersonnel);

                string requete = "INSERT INTO Personnel (nom, prenom, date_embauche, region_carriere, mail)" +
                    " VALUES ('" + tbNomPersonnel.Text + "', '" + tbPrénomPersonnel.Text + "', '" + tbDateEmbauchePersonnel.Text + "', '" + tbRégionPersonnel.Text + "', '" + tbMailPersonnel.Text + "');";
                MySqlCommand cmd = BDD.executerRequete(requete);
                rdr = cmd.ExecuteReader();



            }

            actualiserListePersonnelOngletPersonnel();
            majStatsPersonnel();
        }

        private void btModifierPersonnel_Click(object sender, EventArgs e)
        {
            bool trouvé = false;

            foreach (Personnel Per in lesPersonnels)
            {
                // Si l'ID correspond à celui trouvé dans la liste lesPersonnels
                if (Per.Id_personnel == Convert.ToInt16(tbIDPersonnelModifier.Text))
                {
                    Per.Nom = tbNomPersonnel.Text;
                    Per.Prenom = tbPrénomPersonnel.Text;
                    Per.Date_embauche = tbDateEmbauchePersonnel.Text;
                    if (Per.Region_carriere != tbRégionPersonnel.Text)
                    {
                        Per.Region_carriere = Per.Region_carriere + " - " + tbRégionPersonnel.Text;
                    }
                    Per.Mail = tbMailPersonnel.Text + "@swiss-galaxy.com";

                    trouvé = true;
                }
            }

            if (trouvé == false)
            {
                foreach (Visiteur Vis in lesVisiteurs)
                {
                    if (Vis.Id_personnel == Convert.ToInt16(tbIDPersonnelModifier.Text))
                    {
                        Vis.Nom = tbNomPersonnel.Text;
                        Vis.Prenom = tbPrénomPersonnel.Text;
                        Vis.Date_embauche = tbDateEmbauchePersonnel.Text;
                        if (Vis.Region_carriere != tbRégionPersonnel.Text)
                        {
                            Vis.Region_carriere = Vis.Region_carriere + " - " + tbRégionPersonnel.Text;
                        }
                        Vis.Mail = tbMailPersonnel.Text + "@swiss-galaxy.com";
                        Vis.Objectif = tbObjectifVisiteur.Text;
                        Vis.Prime = Convert.ToInt32(tbPrimeVisiteur.Text);
                        Vis.Avantages = tbAvantagesVisiteur.Text;
                        Vis.Budget = Convert.ToInt32(tbBudgetVisiteur.Text);

                        trouvé = true;
                    }
                }
            }

            if (trouvé == false)
            {
                foreach (Technicien Tec in lesTechniciens)
                {
                    if (Tec.Id_personnel == Convert.ToInt16(tbIDPersonnelModifier.Text))
                    {
                        Tec.Nom = tbNomPersonnel.Text;
                        Tec.Prenom = tbPrénomPersonnel.Text;
                        Tec.Date_embauche = tbDateEmbauchePersonnel.Text;
                        if (Tec.Region_carriere != tbRégionPersonnel.Text)
                        {
                            Tec.Region_carriere = Tec.Region_carriere + " - " + tbRégionPersonnel.Text;
                        }
                        Tec.Mail = tbMailPersonnel.Text + "@swiss-galaxy.com";
                        Tec.Niveau_intervention = Convert.ToInt32(tbNiveauInterventionTechnicien.Text);
                        Tec.Formation = tbFormationTechnicien.Text;
                        Tec.Competences = tbCompetencesTechnicien.Text;

                        trouvé = true;
                    }
                }
            }

            if (trouvé == false)
            {
                MessageBox.Show("Aucun personnel avec l'ID " + tbIDPersonnelModifier.Text + " n'a été trouvé");
            }
            else
            {
                actualiserListePersonnelOngletPersonnel();
                majStatsPersonnel();

                MessageBox.Show("Personnel " + tbIDPersonnelModifier.Text + " modifié avec succés");
            }
        }

        private void btSupprimerPersonnel_Click(object sender, EventArgs e)
        {
            bool trouvé = false;
            Personnel PersonnelSupprimer = null;
            Visiteur VisiteurSupprimer = null;
            Technicien TechnicienSupprimer = null;

            foreach (Personnel Per in lesPersonnels)
            {
                // Si l'ID correspond à celui trouvé dans la liste lesPersonnels
                if (Per.Id_personnel == Convert.ToInt16(tbIDPersonnelSupprimer.Text))
                {
                    PersonnelSupprimer = Per;

                    trouvé = true;
                }
            }

            if (trouvé)
            {
                lesPersonnels.Remove(PersonnelSupprimer);
            }
            else
            {
                foreach (Visiteur Vis in lesVisiteurs)
                {
                    if (Vis.Id_personnel == Convert.ToInt16(tbIDPersonnelSupprimer.Text))
                    {
                        VisiteurSupprimer = Vis;

                        trouvé = true;
                    }
                }

                if (trouvé)
                {
                    lesVisiteurs.Remove(VisiteurSupprimer);
                }
                else
                {
                    foreach (Technicien Tec in lesTechniciens)
                    {
                        if (Tec.Id_personnel == Convert.ToInt16(tbIDPersonnelSupprimer.Text))
                        {
                            TechnicienSupprimer = Tec;

                            trouvé = true;
                        }
                    }

                    if (trouvé)
                    {
                        lesTechniciens.Remove(TechnicienSupprimer);
                    }
                }
            }

            if (trouvé == false)
            {
                MessageBox.Show("Aucun personnel avec l'ID " + tbIDPersonnelSupprimer.Text + " n'a été trouvé");
            }
            else
            {
                actualiserListePersonnelOngletPersonnel();
                majStatsPersonnel();

                MessageBox.Show("Personnel " + tbIDPersonnelSupprimer.Text + " supprimé avec succés");
            }
        }

        private void label61_Click_1(object sender, EventArgs e)
        {

        }

        private void btAjouterProduit_Click(object sender, EventArgs e)
        {
            string requete = "INSERT INTO PRODUIT (nom, effet_therapeutique, contre_indication, composition, posologie, famille, cout)" + "VALUES ('" + tbNomProduit.Text + "', '" + tbEffetTheraProduit.Text + "', '" + tbContreIndicationProduit.Text + "', '" + tbCompositionProduit.Text + "' , '" + tbPosologieProduit.Text + "', '" + tbFamilleProduit.Text + "', " + Convert.ToDouble(tbCoutProduit.Text) + ");";

            MySqlCommand cmd = BDD.executerRequete(requete);
            cmd.ExecuteNonQuery();

            actualiserListeProduitOngletProduit();
        }

        private void textBox51_TextChanged(object sender, EventArgs e)
        {

        }

        private void btSupprimerProduit_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = BDD.executerRequete("DELETE FROM PRODUIT WHERE id_produit = " + Convert.ToInt32(tbSupprimerProduit.Text));
            int resultat = cmd.ExecuteNonQuery();

            if (resultat == 1)
            {
                actualiserListeProduitOngletProduit();
                MessageBox.Show("Le produit n°" + tbSupprimerProduit.Text + " a bien été supprimé");
            }
            else
            {
                MessageBox.Show("Le produit n°" + tbSupprimerProduit.Text + " n'existe pas ou a déjà été supprimé");
            }
        }

        private void btModifierProduit_Click(object sender, EventArgs e)
        {
            {
        
                MySqlCommand cmd = BDD.executerRequete("UPDATE PRODUIT SET nom = '" + tbNomProduit.Text + "', effet_therapeutique = '" + tbEffetTheraProduit.Text + "', contre_indication = '" + tbContreIndicationProduit.Text + "', composition = '" + tbCompositionProduit.Text + "', posologie = '" + tbPosologieProduit.Text + "', famille = '" + tbFamilleProduit.Text + "', cout = " + Convert.ToDouble(tbCoutProduit.Text) + 
                " WHERE id_produit = " + Convert.ToInt32(tbIdProduitModifier.Text) + ";");
                int resultat = cmd.ExecuteNonQuery();

                if (resultat == 1)
                {
                    actualiserListeProduitOngletProduit();
                    MessageBox.Show("Le produit n°" + tbIdProduitModifier.Text + " a bien été modifié");
                }
                else
                {
                    MessageBox.Show("Impossible de trouver le personnel n°" + tbIdProduitModifier.Text);
                }
            }
        }

        private void tbPosologieProduit_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string requete = "INSERT INTO praticien (nom, libelle)" + "VALUES ('" + tbNomPraticien.Text + "', '" + tbLibellePraticien + ");";

            MySqlCommand cmd = BDD.executerRequete(requete);
            cmd.ExecuteNonQuery();

            actualiserListeProduitOngletProduit();
        }
    }
}
