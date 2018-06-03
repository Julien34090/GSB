using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB
{
    class Technicien : Personnel
    {
        int niveau_intervention;
        string formation;
        string competences;

        public Technicien(int unNiveau_intervention, string uneFormation, string desCompetences, string unNom, string unPrenom, string uneDate_embauche, string uneRegion_carriere, string unMail, string unRole) : base(unNom, unPrenom, uneDate_embauche, uneRegion_carriere, unMail, unRole)
        {
            niveau_intervention = unNiveau_intervention;
            formation = uneFormation;
            competences = desCompetences;
        }

        public new string infos()
        {
            return base.Id_personnel + " : " + base.Nom + " " + base.Prenom + " (" + base.Matricule + ") - " + base.Mail + " : Embauché le " + base.Date_embauche + " à: " + base.Region_carriere + ". Niveau d'intervention: " + niveau_intervention + " - Formation: " + formation + " - Compétences: " + competences;
        }

        public int Niveau_intervention
        {
            get
            {
                return niveau_intervention;
            }

            set
            {
                niveau_intervention = value;
            }
        }

        public string Formation
        {
            get
            {
                return formation;
            }

            set
            {
                formation = value;
            }
        }

        public string Competences
        {
            get
            {
                return competences;
            }

            set
            {
                competences = value;
            }
        }
    }
}
