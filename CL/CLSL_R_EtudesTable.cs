using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleve_Book.CL
{
    class CLSL_R_EtudesTable
    {
        private Db_EleveBookEntities4 db = new Db_EleveBookEntities4();
        public LR_EtudesTable REt; //table eleve rens.elementaire


        #region AJOUTER ELEVE A LA BASE DE DONNEE
        public bool Ajouter_Et(String Nom,string Prenom, string classe, String option, String filiere, String sousOption,string note1A, string note2A, string note3A, string note4A, string note5A, string noteGlobale, String anneeBac, String filiereBac, String noteBac, String lycee,string Autres)
        {
            REt = new LR_EtudesTable();
            REt.Nom_Eleve = Nom;
            REt.Prenom_Eleve = Prenom;
            REt.classe_Eleve = classe;
            REt.Option_Eleve = option;
            REt.Filiere_Eleve = filiere;
            REt.SousOption_Eleve = sousOption;
            REt.Note_1A_Eleve = note1A;
            REt.Note_2A_Eleve = note2A;
            REt.Note_3A_Eleve = note3A;
            REt.Note_4A_Eleve = note4A;
            REt.Note_5A_Eleve = note5A;
            REt.Note_Globale_Eleve = noteGlobale;
            REt.AnneeBac_Eleve = anneeBac;
            REt.FiliereBac_Eleve = filiereBac;
            REt.NoteBac_Eleve = noteBac;
            REt.Lycee_Eleve = lycee;
            REt.Autres = Autres;      

            
            //vérifier si le nom et prenomm existe deja dans la table
            if (db.LR_EtudesTable.SingleOrDefault(s => s.Nom_Eleve == Nom ) == null) //verifier s'il existe
            {
                db.LR_EtudesTable.Add(REt); //ajouter C a table
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
        public void Modifier_Et(int idE, String Nom,string Prenom, string classe, String option, String filiere, String sousOption, string note1A, string note2A, string note3A, string note4A, string note5A, string noteGlobale, String anneeBac, String filiereBac, String noteBac, String lycee,string Autres)
        {


            REt = new LR_EtudesTable();

            //check if id of Eleve if it exists
            //RE = db.R_ElementairesTable.SingleOrDefault(s => s.ID_Eleve == idE);
            REt = db.LR_EtudesTable.SingleOrDefault(s => s.Id == idE);
            if (REt != null)
            {

                REt.Nom_Eleve = Nom;
                REt.Prenom_Eleve = Prenom;
                REt.classe_Eleve = classe;
                REt.Option_Eleve = option;
                REt.Filiere_Eleve = filiere;
                REt.SousOption_Eleve = sousOption;
                REt.Note_1A_Eleve = note1A;
                REt.Note_2A_Eleve = note2A;
                REt.Note_3A_Eleve = note3A;
                REt.Note_4A_Eleve = note4A;
                REt.Note_5A_Eleve = note5A;
                REt.Note_Globale_Eleve = noteGlobale;
                REt.AnneeBac_Eleve = anneeBac;
                REt.FiliereBac_Eleve = filiereBac;
                REt.NoteBac_Eleve = noteBac;
                REt.Lycee_Eleve = lycee;
                REt.Autres = Autres;



                db.SaveChanges();

            }
        }
        #endregion



        #region SUPPRIMER UN ELEVE A LA BASE DE DONNE
        public void supprimer_Et(int id)
        {
            REt = new LR_EtudesTable();
            REt = db.LR_EtudesTable.SingleOrDefault(s => s.Id == id);
            if (REt != null)  //if existe
            {
                db.LR_EtudesTable.Remove(REt);
                db.SaveChanges();
            }
        }
        #endregion

    }
}
