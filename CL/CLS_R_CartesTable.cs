using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Eleve_Book.CL
{
    class CLS_R_CartesTable
    {
        private Db_EleveBookEntities4 db = new Db_EleveBookEntities4();
        public R_CartesTable RC; //table eleve rens.elementaire


        #region AJOUTER ELEVE A LA BASE DE DONNEE
        public bool Ajouter_RC(String NomC,string Prenom, Byte[] CIN1, Byte[] CIN2, Byte[] CMIL1, Byte[] CMIL2, Byte[] CMUT1, Byte[] CMUT2, Byte[] Passeport,string Autres)
        {
            RC = new R_CartesTable();
            RC.Nom_Eleve = NomC;
            RC.Prenom_Eleve = Prenom;
            RC.CIN1_Eleve = CIN1;
            RC.CIN2_Eleve = CIN2;
            RC.CMIL1_Eleve = CMIL1;
            RC.CMIL2_Eleve = CMIL2;
            RC.CMUT1_Eleve = CMUT1;
            RC.CMUT2_Eleve = CMUT2;
            RC.Passeport_Eleve = Passeport;
            RC.Autres = Autres;

         
            //vérifier si le nom et prenomm existe deja dans la table
            if (db.R_CartesTable.SingleOrDefault(s => s.Nom_Eleve == NomC) == null) //verifier s'il existe
            {
                db.R_CartesTable.Add(RC); //ajouter C a table
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
        public void Modifier_RC(int idE, String Nom,string Prenom, Byte[] CIN1, Byte[] CIN2, Byte[] CMIL1, Byte[] CMIL2, Byte[] CMUT1, Byte[] CMUT2, Byte[] Passeport,string Autres)
        {


            RC = new R_CartesTable();

            //check if id of Eleve if it exists
            //RE = db.R_ElementairesTable.SingleOrDefault(s => s.ID_Eleve == idE);
            RC = db.R_CartesTable.SingleOrDefault(s => s.Id == idE);
            if (RC != null)
            {               
                RC.Nom_Eleve = Nom;
                RC.Prenom_Eleve = Prenom;
                RC.CIN1_Eleve = CIN1;
                RC.CIN2_Eleve = CIN2;
                RC.CMIL1_Eleve = CMIL1;
                RC.CMIL2_Eleve = CMIL2;
                RC.CMUT1_Eleve = CMUT1;
                RC.CMUT2_Eleve = CMUT2;
                RC.Passeport_Eleve = Passeport;
                RC.Autres = Autres;

                db.SaveChanges();
            }
        }
        #endregion



        #region SUPPRIMER UN ELEVE A LA BASE DE DONNE
        public void supprimer_RC(int id)
        {
            RC = new R_CartesTable();
            RC = db.R_CartesTable.SingleOrDefault(s => s.Id == id);
            if (RC != null)  //if existe
            {
                db.R_CartesTable.Remove(RC);
                db.SaveChanges();
            }
        }
        #endregion

    }
}
