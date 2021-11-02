using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleve_Book.CL
{
    class CLS__R_EncadrantTable
    {
        private Db_EleveBookEntities4 db = new Db_EleveBookEntities4();
        public EncadrantTable REn; //table eleve rens.elementaire


        #region AJOUTER ELEVE A LA BASE DE DONNEE
        public bool Ajouter_REn(string gradeEn,String NomEn, string prenomEn, String telephoenEn, String emailEn, Byte[] photoEn,string Autres)
        {
            REn = new EncadrantTable();
            REn.Grade_ENCADRANT = gradeEn;
            REn.Nom_ENCADRANT = NomEn;
            REn.Prenom_ENCADRANT = prenomEn;
            REn.Telephone_ENCADRANT = telephoenEn;
            REn.Email_ENCADRANT = emailEn;
            REn.Photo_Prof = photoEn;
            REn.Autres = Autres;
           

            //vérifier si le nom et prenomm existe deja dans la table
            if (db.EncadrantTables.SingleOrDefault(s => s.Nom_ENCADRANT == NomEn) == null) //verifier s'il existe
            {
                db.EncadrantTables.Add(REn); //ajouter C a table
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
        public void Modifier_REn(int idE, string gradeEn,String NomEn, string prenomEn, String telephoenEn, String emailEn, Byte[] photoEn,string Autres)
        {


            REn = new EncadrantTable();

            //check if id of Eleve if it exists
            //RE = db.R_ElementairesTable.SingleOrDefault(s => s.ID_Eleve == idE);
            REn = db.EncadrantTables.SingleOrDefault(s => s.Id == idE);
            if (REn != null)
            {

                REn.Grade_ENCADRANT = gradeEn;
                REn.Nom_ENCADRANT = NomEn;
                REn.Prenom_ENCADRANT = prenomEn;
                REn.Telephone_ENCADRANT = telephoenEn;
                REn.Email_ENCADRANT = emailEn;
                REn.Photo_Prof = photoEn;
                REn.Autres = Autres;

                db.SaveChanges();

            }
        }
        #endregion



        #region SUPPRIMER UN ELEVE A LA BASE DE DONNE
        public void supprimer_REn(int id)
        {
            REn = new EncadrantTable();
            REn = db.EncadrantTables.SingleOrDefault(s => s.Id == id);
            if (REn != null)  //if existe
            {
                db.EncadrantTables.Remove(REn);
                db.SaveChanges();
            }
        }
        #endregion

    }
}
