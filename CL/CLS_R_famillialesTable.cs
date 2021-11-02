using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleve_Book.CL
{
    class CLS_R_famillialesTable
    {
        private Db_EleveBookEntities4 db = new Db_EleveBookEntities4();
        public R_famillialesTable RF; //table eleve rens.elementaire


        #region AJOUTER ELEVE A LA BASE DE DONNEE
        public bool Ajouter_RF(String Nom, string Prenom, string prenomPere, String prenomMere, String nomMere, string nbreFrere, string nbreSoeur, String fonctionPere, String fonctionMere, String adressePrent, String telephonePre, string personneAContacter,string Autres)
        {
            RF = new R_famillialesTable();
            RF.Nom_Eleve = Nom;
            RF.Prenom_Eleve = Prenom;
            RF.Prenom_Pere = prenomPere;
            RF.Prenom_Mere = prenomMere;
            RF.Nom_Mere = nomMere;
            RF.N_Frere =nbreFrere;
            RF.N_Soeur = nbreSoeur;
            RF.Fonction_Pere = fonctionPere;
            RF.Fonction_Mere = fonctionMere;
            RF.Adresse_Parent = adressePrent;
            RF.Telephone_Pere = telephonePre;
            RF.Personne_Acontacter = personneAContacter;
            RF.Autres = Autres;


            //vérifier si le nom et prenomm existe deja dans la table
            if (db.R_famillialesTable.SingleOrDefault(s => s.Nom_Eleve == Nom) == null) //verifier s'il existe
            {
                db.R_famillialesTable.Add(RF); //ajouter C a table
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
        public void Modifier_RF(int idE, String Nom,string Prenom, string prenomPere, String prenomMere, String nomMere, string nbreFrere, string nbreSoeur, String fonctionPere, String fonctionMere, String adressePrent, String telephonePre, string personneAContacter,string Autres)
        {


            RF = new R_famillialesTable();

            //check if id of Eleve if it exists
            //RE = db.R_ElementairesTable.SingleOrDefault(s => s.ID_Eleve == idE);
            RF = db.R_famillialesTable.SingleOrDefault(s => s.Id == idE);
            if (RF != null)
            {

                RF.Nom_Eleve = Nom;
                RF.Prenom_Eleve = Prenom;
                RF.Prenom_Pere = prenomPere;
                RF.Prenom_Mere = prenomMere;
                RF.Nom_Mere = nomMere;
                RF.N_Frere = nbreFrere;
                RF.N_Soeur = nbreSoeur;
                RF.Fonction_Pere = fonctionPere;
                RF.Fonction_Mere = fonctionMere;
                RF.Adresse_Parent = adressePrent;
                RF.Telephone_Pere = telephonePre;
                RF.Personne_Acontacter = personneAContacter;
                RF.Autres = Autres;


                db.SaveChanges();

            }
        }
        #endregion



        #region SUPPRIMER UN ELEVE A LA BASE DE DONNE
        public void supprimer_RF(int id)
        {
            RF = new R_famillialesTable();
            RF = db.R_famillialesTable.SingleOrDefault(s => s.Id == id);
            if (RF != null)  //if existe
            {
                db.R_famillialesTable.Remove(RF);
                db.SaveChanges();
            }
        }
        #endregion

    }
}
