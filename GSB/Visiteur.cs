using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB
{
    class Visiteur : Personnel
    {
        string objectif;
        int prime;
        string avantages;
        int budget;

        public Visiteur(string unObjectif, int unePrime, string desAvantages, int unBudget, string unNom, string unPrenom, string uneDate_embauche, string uneRegion_carriere, string unMail, string unRole) : base(unNom, unPrenom, uneDate_embauche, uneRegion_carriere, unMail, unRole)
        {
            objectif = unObjectif;
            prime = unePrime;
            avantages = desAvantages;
            budget = unBudget;
        }

        public new string infos()
        {
            return base.Id_personnel + " : " + base.Nom + " " + base.Prenom + " (" + base.Matricule + ") - " + base.Mail + " : Embauché le " + base.Date_embauche + " à: " + base.Region_carriere + ". Objectif: " + objectif + " - Prime: " + prime + " - Budget: " + budget + " - Avantages: " + avantages;
        }

        public string Objectif
        {
            get
            {
                return objectif;
            }

            set
            {
                objectif = value;
            }
        }

        public int Prime
        {
            get
            {
                return prime;
            }

            set
            {
                prime = value;
            }
        }

        public string Avantages
        {
            get
            {
                return avantages;
            }

            set
            {
                avantages = value;
            }
        }

        public int Budget
        {
            get
            {
                return budget;
            }

            set
            {
                budget = value;
            }
        }
    }
}
