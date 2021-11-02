using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleve_Book.CL
{
    class CLSL_PtcTable
    {
        private Db_EleveBookEntities4 db = new Db_EleveBookEntities4();
        public LR_PtcTable RP; //table eleve rens.elementaire


        #region AJOUTER ELEVE A LA BASE DE DONNEE
        public bool Ajouter_PTC(String Nom,string Prenom, string PTCExemption,string ptcNbreJours, String motif, String date,string Autres)
        {
            RP = new LR_PtcTable();
            RP.Nom_Eleve = Nom;
            RP.Prenom_Eleve = Prenom;
            RP.PtcExemption = PTCExemption;
            RP.PtcJr_Eleve = ptcNbreJours;
            RP.motifPtc_Eleve = motif;
            RP.DatePtc_Eleve = date;
            RP.Autres = Autres;


            //vérifier si le nom et prenomm existe deja dans la table
            /* if (db.R_PtcTable.SingleOrDefault(s => s.Nom_Eleve == Nom) == null) //verifier s'il existe
             {
                 db.R_PtcTable.Add(RP); //ajouter C a table
                 db.SaveChanges();  //enregistrer sur base de données
                 return true;

             }
             else
             {
                 return false;
             }*/

            
                db.LR_PtcTable.Add(RP); //ajouter C a table
                db.SaveChanges();  //enregistrer sur base de données
                return true;
                        
        }

        #endregion


        #region MODIFIER ELEVE DANS LA BASE DE DONNE
        public void Modifier_PTC(int idE, String Nom,string Prenom,string PTCExemption ,string ptcNbreJours, String motif, String date,string Autres)
        {


            RP = new LR_PtcTable();

            //check if id of Eleve if it exists
            //RE = db.R_ElementairesTable.SingleOrDefault(s => s.ID_Eleve == idE);
            RP = db.LR_PtcTable.SingleOrDefault(s => s.Id == idE);
            if (RP != null)
            {

                RP.Nom_Eleve = Nom;
                RP.Prenom_Eleve = Prenom;
                RP.PtcExemption = PTCExemption;
                RP.PtcJr_Eleve = ptcNbreJours;
                RP.motifPtc_Eleve = motif;
                RP.DatePtc_Eleve = date;
                RP.Autres = Autres;

                db.SaveChanges();

            }
        }
        #endregion



        #region SUPPRIMER UN ELEVE A LA BASE DE DONNE
        public void supprimer_PTC(int id)
        {
            RP = new LR_PtcTable();
            RP = db.LR_PtcTable.SingleOrDefault(s => s.Id == id);
            if (RP != null)  //if existe
            {
                db.LR_PtcTable.Remove(RP);
                db.SaveChanges();
            }
        }
        #endregion

    }
}
