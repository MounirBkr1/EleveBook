using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleve_Book.CL
{
    class CLSL_ArretTable
    {
        private Db_EleveBookEntities4 db = new Db_EleveBookEntities4();
        public LR_ArretTable RA; //table eleve rens.elementaire


        #region AJOUTER ELEVE A LA BASE DE DONNEE
        public bool Ajouter_RArret(String NomA,string Prenom, string punition, String motif, String date, String autorite,string Autres)
        {
            RA = new LR_ArretTable();
            RA.Nom_Eleve = NomA;
            RA.Prenom_Eleve = Prenom;
            RA.Punition_Eleve = punition;
            RA.motifArret_Eleve = motif;
            RA.DateArret_Eleve = date;
            RA.AutoriteArret_Eleve = autorite;
            RA.Autres = Autres;

            /*
               //vérifier si le nom et prenomm existe deja dans la table
               if (db.R_ArretTable.SingleOrDefault(s => s.Nom_Eleve == NomA) == null) //verifier s'il existe
               {
                   db.R_ArretTable.Add(RA); //ajouter C a table
                   db.SaveChanges();  //enregistrer sur base de données
                   return true;

               }
               else
               {
                   return false;
               }*/

            //vérifier si le nom et prenomm existe deja dans la table
            
                db.LR_ArretTable.Add(RA); //ajouter C a table
                db.SaveChanges();  //enregistrer sur base de données
                return true;

        }

        #endregion


        #region MODIFIER ELEVE DANS LA BASE DE DONNE
        public void Modifier_RArret(int idE, String Nom,string Prenom ,string punition, String motif, String date, String autorite,string Autres)
        {


            RA = new LR_ArretTable();

            //check if id of Eleve if it exists
            //RE = db.R_ElementairesTable.SingleOrDefault(s => s.ID_Eleve == idE);
            RA = db.LR_ArretTable.SingleOrDefault(s => s.Id == idE);
            if (RA != null)
            {

                RA.Nom_Eleve = Nom;
                RA.Prenom_Eleve = Prenom;
                RA.Punition_Eleve = punition;
                RA.motifArret_Eleve = motif;
                RA.DateArret_Eleve = date;
                RA.AutoriteArret_Eleve = autorite;
                RA.Autres = Autres;


                db.SaveChanges();

            }
        }
        #endregion



        #region SUPPRIMER UN ELEVE A LA BASE DE DONNE
        public void supprimer_RArret(int id)
        {
            RA = new LR_ArretTable();
            RA = db.LR_ArretTable.SingleOrDefault(s => s.Id == id);
            if (RA != null)  //if existe
            {
                db.LR_ArretTable.Remove(RA);
                db.SaveChanges();
            }
        }
        #endregion

    }
}
