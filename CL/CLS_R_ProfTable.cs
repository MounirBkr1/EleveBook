using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleve_Book.CL
{
    class CLS_R_ProfTable
    {
        private Db_EleveBookEntities4 db = new Db_EleveBookEntities4();
        public R_ProfTable RPr; //table eleve rens.elementaire


        #region AJOUTER ELEVE A LA BASE DE DONNEE
        public bool Ajouter_RPr(String NomPr, string prenomPr, String matierePr, String telephonePr, String emailPr, String adressePr, Byte[] photoPr,string Autres)
        {
            RPr = new R_ProfTable();
            RPr.Nom_Prof = NomPr;
            RPr.Prenom_Prof = prenomPr;
            RPr.Matiere_Prof = matierePr;
            RPr.Telephone_Prof = telephonePr;
            RPr.Email_Prof = emailPr;
            RPr.Adresse_Prof = adressePr;
            RPr.Photo_Prof = photoPr;
            RPr.Autres = Autres;       

            //vérifier si le nom et prenomm existe deja dans la table
            if (db.R_ProfTable.SingleOrDefault(s => s.Nom_Prof == NomPr) == null) //verifier s'il existe
            {
                db.R_ProfTable.Add(RPr); //ajouter C a table
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
        public void Modifier_RPr(int idE, String NomPr, string prenomPr, String matierePr, String telephonePr, String emailPr, String adressePr, Byte[] photoPr,string Autres)
        {


            RPr = new R_ProfTable();

            //check if id of Eleve if it exists
            //RE = db.R_ElementairesTable.SingleOrDefault(s => s.ID_Eleve == idE);
            RPr = db.R_ProfTable.SingleOrDefault(s => s.Id == idE);
            if (RPr != null)
            {

                RPr = new R_ProfTable();
                RPr.Nom_Prof = NomPr;
                RPr.Prenom_Prof = prenomPr;
                RPr.Matiere_Prof = matierePr;
                RPr.Telephone_Prof = telephonePr;
                RPr.Email_Prof = emailPr;
                RPr.Adresse_Prof = adressePr;
                RPr.Photo_Prof = photoPr;
                RPr.Autres = Autres;

                db.SaveChanges();

            }
        }
        #endregion



        #region SUPPRIMER UN ELEVE A LA BASE DE DONNE
        public void supprimer_RPr(int id)
        {
            RPr = new R_ProfTable();
            RPr = db.R_ProfTable.SingleOrDefault(s => s.Id == id);
            if (RPr != null)  //if existe
            {
                db.R_ProfTable.Remove(RPr);
                db.SaveChanges();
            }
        }
        #endregion

    }
}
