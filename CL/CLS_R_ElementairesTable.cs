using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Eleve_Book.CL
{
    class CLS_R_ElementairesTable
    {
        private Db_EleveBookEntities4 db = new Db_EleveBookEntities4();
        public R_ElementairesTable RE; //table eleve rens.elementaire


        #region AJOUTER ELEVE A LA BASE DE DONNEE
        public bool Ajouter_Eleve(String Nom, String Prenom, String Telephone, String Email, String Genre, String Nationalité, String Religion, String Adresse, Byte[] imageEleve,String Autres)
        {
            RE = new R_ElementairesTable();
            RE.Nom_Eleve = Nom;
            RE.Prenom_Eleve = Prenom;
            RE.Telephone_Eleve = Telephone;
            RE.Email_Eleve = Email;
            RE.Genre_Eleve = Genre;
            RE.Nationalite_Eleve = Nationalité;
            RE.Religion_Eleve = Religion;
            RE.Adresse_Eleve = Adresse;
            RE.Photo_Eleve = imageEleve;
            RE.Autres = Autres;


            //vérifier si le nom et prenomm existe deja dans la table
            if (db.R_ElementairesTable.SingleOrDefault(s => s.Nom_Eleve == Nom && RE.Prenom_Eleve == Prenom) == null) //verifier s'il existe
            {
               
                db.R_ElementairesTable.Add(RE); //ajouter C a table
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
        public void Modifier_Eleve(int idE,String NomE, String PrenomE, String TelephoneE, String EmailE, String GenreE, String NationaliteE, String ReligionE, String AdresseE, Byte[] ImageE,String Autres)
        {
            
            
            RE = new R_ElementairesTable();
            
            //check if id of Eleve if it exists
            //RE = db.R_ElementairesTable.SingleOrDefault(s => s.ID_Eleve == idE);
            RE = db.R_ElementairesTable.SingleOrDefault(s => s.Id == idE);
            if (RE != null)
            {
               
              
                RE.Nom_Eleve = NomE;
                RE.Prenom_Eleve = PrenomE;
                RE.Telephone_Eleve = TelephoneE;
                RE.Email_Eleve = EmailE;
                RE.Genre_Eleve = GenreE;
                RE.Nationalite_Eleve = NationaliteE;
                RE.Religion_Eleve = ReligionE;
                RE.Adresse_Eleve = AdresseE;
                RE.Photo_Eleve = ImageE;
                RE.Autres = Autres;

                db.SaveChanges();             
            }
        }
        #endregion

     
        
        #region SUPPRIMER UN ELEVE A LA BASE DE DONNE
        public void supprimer_Eleve(int id)
        {
            RE = new R_ElementairesTable();
            RE = db.R_ElementairesTable.SingleOrDefault(s => s.Id == id);
            if (RE != null)  //if existe
            {
                db.R_ElementairesTable.Remove(RE);
                db.SaveChanges();
            }
        }
        #endregion

    }
}
