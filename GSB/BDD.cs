using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GSB
{

    class BDD
    {
        private string bdd = @"server=localhost;userid=root;password=;database=gsb";

        private MySqlConnection connexion = null;

        public void ouvrirConnexion()
        {
            connexion = new MySqlConnection(bdd);
            connexion.Open();
        }

        public void fermerConnexion()
        {
            connexion.Close();
        }

        public MySqlCommand executerRequete(string requete)
        {
            if (connexion == null)
            {
                ouvrirConnexion();
            }

            MySqlCommand cmd = new MySqlCommand(requete, connexion);

            return cmd;
        }
    }
}
