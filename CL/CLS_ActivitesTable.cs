using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleve_Book.CL
{
    class CLS_ActivitesTable
    {
        private Db_EleveBookEntities4 db = new Db_EleveBookEntities4();
        public R_Activites RA; //table eleve rens.elementaire


        #region AJOUTER ELEVE A LA BASE DE DONNEE
        public bool Ajouter_Eleve(String Nom,String Prenom, String parachutisme, String aguerissement, String corvetteEte, String semaineEleve, String gantsBlanc, String permisConduire,String Najeur,String Fumeur, String Autres)
        {
            RA = new R_Activites();
            RA.Nom_Eleve = Nom;
            RA.Prenom_Eleve = Prenom;
            RA.Parachutisme = parachutisme;
            RA.Aguerissement_marin = aguerissement;
            RA.Corvette_ete = corvetteEte;
            RA.Semaine_eleve = semaineEleve;
            RA.Gant_blanc =gantsBlanc;
            RA.Permis_conduire =permisConduire;
            RA.Najeur = Najeur;
            RA.Fumeur = Fumeur;
            RA.Autres = Autres;


            //vérifier si le nom et prenomm existe deja dans la table
            if (db.R_Activites.SingleOrDefault(s => s.Nom_Eleve == Nom && RA.Prenom_Eleve == Prenom) == null) //verifier s'il existe
            {
                db.R_Activites.Add(RA); //ajouter C a table
                db.SaveChanges();  //enregistrer sur base de données
                return true;

            }
            else
            {
                return false;
            }
        }

        #endregion


        #region MODIFIER ELEVE DANS LA BASE DE DONNE
        public void Modifier_Eleve(int idE,String Nom, String Prenom, String parachutisme, String aguerissement, String corvetteEte, String semaineEleve, String gantsBlanc, String permisConduire, string Najeur, string Fumeur, String Autres)
        {


            RA = new R_Activites();

            //check if id of Eleve if it exists
            //RE = db.R_ElementairesTable.SingleOrDefault(s => s.ID_Eleve == idE);
            RA = db.R_Activites.SingleOrDefault(s => s.Id == idE);
            if (RA != null)
            {


                RA = new R_Activites();
                RA.Nom_Eleve = Nom;
                RA.Prenom_Eleve = Prenom;
                RA.Parachutisme = parachutisme;
                RA.Aguerissement_marin = aguerissement;
                RA.Corvette_ete = corvetteEte;
                RA.Semaine_eleve = semaineEleve;
                RA.Gant_blanc = gantsBlanc;
                RA.Permis_conduire = permisConduire;
                RA.Najeur = Najeur;
                RA.Fumeur = Fumeur;
                RA.Autres = Autres;

                db.SaveChanges();
            }
        }
        #endregion



        #region SUPPRIMER UN ELEVE A LA BASE DE DONNE
        public void supprimer_Eleve(int id)
        {
            RA = new R_Activites();
            RA = db.R_Activites.SingleOrDefault(s => s.Id == id);
            if (RA != null)  //if existe
            {
                db.R_Activites.Remove(RA);
                db.SaveChanges();
            }
        }
        #endregion
    }
}
