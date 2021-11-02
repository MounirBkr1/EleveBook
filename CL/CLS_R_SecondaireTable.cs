using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleve_Book.CL
{
    class CLS_R_SecondaireTable
    {

        private Db_EleveBookEntities4 db = new Db_EleveBookEntities4();
        public R_SecondairesTable RS; //table eleve rens.elementaire


        #region AJOUTER ELEVE A LA BASE DE DONNEE
        public bool Ajouter_RS(String NomS, string Prenom, String RegionS, String VilleS, String DateNaissanceS, String LieuNaissanceS, String groupeSanguinS, String SommeS, String CINS, String CCPS, string CMS,String Autres)
        {
            RS = new R_SecondairesTable();
            RS.Nom_Eleve = NomS;
            RS.Prenom_Eleve = Prenom;
            RS.Region_Eleve = RegionS;
            RS.ville_Eleve = VilleS;
            RS.DateNaissance_Eleve = DateNaissanceS;
            RS.LieuNaissance_Eleve = LieuNaissanceS;
            RS.groupeSanguin_Eleve = groupeSanguinS;
            RS.Somme_Eleve = SommeS;
            RS.Cin_Eleve = CINS;
            RS.Ccp_Eleve = CCPS;
            RS.CM_Eleve = CMS;
            RS.Autres = Autres;





            //vérifier si le nom et prenomm existe deja dans la table
            if (db.R_SecondairesTable.SingleOrDefault(s => s.Nom_Eleve == NomS ) == null) //verifier s'il existe
            {
                db.R_SecondairesTable.Add(RS); //ajouter C a table
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
        public void Modifier_RS(int idE, String NomS,string Prenom, String RegionS, String VilleS, String DateNaissanceS, String LieuNaissanceS, String groupeSanguinS, String SommeS, String CINS, String CCPS, string CMS,String Autres)
        {


            RS = new R_SecondairesTable();

            //check if id of Eleve if it exists
            //RE = db.R_ElementairesTable.SingleOrDefault(s => s.ID_Eleve == idE);
            RS = db.R_SecondairesTable.SingleOrDefault(s => s.Id == idE);
            if (RS != null)
            {

                RS.Nom_Eleve = NomS;
                RS.Prenom_Eleve = Prenom;
                RS.Region_Eleve = RegionS;
                RS.ville_Eleve = VilleS;
                RS.DateNaissance_Eleve = DateNaissanceS;
                RS.LieuNaissance_Eleve = LieuNaissanceS;
                RS.groupeSanguin_Eleve = groupeSanguinS;
                RS.Somme_Eleve = SommeS;
                RS.Cin_Eleve = CINS;
                RS.Ccp_Eleve = CCPS;
                RS.CM_Eleve = CMS;
                RS.Autres = Autres;

                db.SaveChanges();
               
            }
        }
        #endregion



        #region SUPPRIMER UN ELEVE A LA BASE DE DONNE
        public void supprimer_RS(int id)
        {
            RS = new R_SecondairesTable();
            RS = db.R_SecondairesTable.SingleOrDefault(s => s.Id == id);
            if (RS != null)  //if existe
            {
                db.R_SecondairesTable.Remove(RS);
                db.SaveChanges();
            }
        }
        #endregion

    }
}
