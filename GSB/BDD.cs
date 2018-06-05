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
        private string bdd = @"server=localhost;userid=root;password=;database=gsb;SslMode=none";
        private MySqlConnection connexion = null;

        public BDD()
        {
            connexion = new MySqlConnection(bdd);
            connexion.Open();
        }

        public MySqlCommand executerRequete(string requete)
        {
            MySqlCommand cmd = new MySqlCommand(requete, connexion);

            return cmd;
        }
    }
}