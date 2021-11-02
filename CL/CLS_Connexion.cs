using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleve_Book.CL
{
    class CLS_Connexion
    {
        public bool ConnexionValide(Db_EleveBookEntities4 db, string Nom, string Mot_de_passe)
        {
            Utilisateur u = new Utilisateur();
            u.Username_Utilisateur = Nom;
            u.password_Utilisateur = Mot_de_passe;

            if (db.Utilisateurs.SingleOrDefault(s => s.Username_Utilisateur == Nom && s.password_Utilisateur == Mot_de_passe) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
