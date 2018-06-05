using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB
{
    class Produit
    {
        int id_produit;
        string nom;
        string effet_thera;
        string composition;
        string contre_indication;
        string posologie;
        string famille;
        double cout;

        static int num_id_produit = 0;

        public Produit(string unNom, string unEffet_thera, string uneContre_indication, string uneComposition, string unePosologie, string uneFamille, double unCout)
        {
            num_id_produit++;
            id_produit = num_id_produit;
            nom = unNom;
            effet_thera = unEffet_thera;
            contre_indication = uneContre_indication;
            composition = uneComposition;
            posologie = unePosologie;
            famille = uneFamille;
            cout = unCout;
        }

        public string infosProduit()
        {
            return nom + " : " + effet_thera + " " + composition + " " + posologie + " " + famille + " à: " + cout + id_produit;
        }



        public int num_id_personnel
        {
            get
            {
                return num_id_personnel;
            }

            set
            {
                num_id_personnel = value;
            }
        }

        public int Id_produit
        {
            get
            {
                return id_produit;
            }

            set
            {
                id_produit = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        } 

        public string Effet_thera
        {
            get
            {
                return effet_thera;
            }

            set
            {
                effet_thera = value;
            }
        }

        public string Composition
        {
            get
            {
                return composition;
            }

            set
            {
                composition = value;
            }
        }

        public string Contre_Indication
        {
            get
            {
                return contre_indication; 
            }

            set
            {
                contre_indication = value;
            }
        }

        public string Posologie
        {
            get
            {
                return posologie;
            }

            set
            {
                posologie = value;
            }
        }

        public string Famille
        {
            get
            {
                return famille;
            }

            set
            {
                famille = value;
            }
        }

        public double Cout
        {
            get
            {
                return cout;
            }

            set
            {
                cout = value;
            }
        }


    }
}
