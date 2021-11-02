using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eleve_Book.FM
{
    public partial class FRML_ActiviteAjouterModifier : Form
    {
      
        private UserControl usEleve;  //pr le remplacer par USER_List_Client
        CL.CLSL_ActivitesTable classRA = new CL.CLSL_ActivitesTable();
        UCL_Activite_List userAct = new UCL_Activite_List();
        public int IDEleve;

        



        public FRML_ActiviteAjouterModifier(UserControl userC)
        {
            InitializeComponent();
            this.usEleve = userC;           

        }

        private Db_EleveBookEntities4 db;
        private void FRML_ActiviteAjouterModifier_Load(object sender, EventArgs e)
        {
           

            if (lblTitre.Text == "AJOUTER UNE ACTIVITE")
            {
                db = new Db_EleveBookEntities4();
                this.cmbNom.DataSource = null;  //pour eviter l exception (Items collection cannot be modified when the DataSource property is set.')
                this.cmbNom.DataSource = null;
                cmbNom.DataSource = db.LR_ElementairesTable.ToList();  //display all data
                cmbNom.DisplayMember = "Nom_Eleve"; //display only name
                cmbNom.ValueMember = "Id"; //display who has this id

                cmbPrenom.DataSource = db.LR_ElementairesTable.ToList();  //display all data
                cmbPrenom.DisplayMember = "Prenom_Eleve"; //display only name
                cmbPrenom.ValueMember = "Nom_Eleve"; //display who has this id

                cmbNom.Text = "-- choisir Elève --";
                cmbPrenom.Text = "-- choisir Prénom --";
            }

            else
            {
                cmbNom.Enabled = false;
                cmbPrenom.Enabled = false;
            }
            
        }

        String testObligatoire()
        {
            if (cmbNom.Text == "" || cmbNom.Text == "-- Choisir Nom --")
                return "Entrer le Nom de l'élève";
            if (cmbPrenom.Text == "" || cmbPrenom.Text == "-- Choisir Prénom --")
                return "Entrer le Prénom de l'élève";
            
            return null;
        }


        string para, aguerrissement, corveteEte, semaineEleve, gantBlanc, permisConduire, najeur, fumeur = "";

    

        private void btnEnregistry_Click(object sender, EventArgs e)
        {
            

            if (testObligatoire() != null)  //un champ vide ou données incompatible
            {
                MessageBox.Show(testObligatoire(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

            else if (lblTitre.Text == "AJOUTER UNE ACTIVITE") //tous les champs remplis
            {

                if (cbPara.Checked == true)
                    para = "X";
                else
                    para = "";

                if (cbAguerissement.Checked == true)
                    aguerrissement = "X";
                else
                    aguerrissement = "";

                if (cbCorvetteEte.Checked == true)
                    corveteEte = "X";
                else
                    corveteEte = "";

                if (cbSemaineEleve.Checked == true)
                    semaineEleve = "X";
                else
                    semaineEleve = "";

                if (cbGuantsBlancs.Checked == true)
                    gantBlanc = "X";
                else
                    gantBlanc = "";

                if (cbPermisConduire.Checked == true)
                    permisConduire = "X";
                else
                    permisConduire = "";

                if (cbNajeur.Checked == true)
                    najeur = "X";
                else
                    najeur = "";

                if (cbFumeur.Checked == true)
                    fumeur = "X";
                else
                    fumeur = "";



                //if (classRA.Ajouter_Eleve(cmbNom.Text,cmbPrenom.Text, "+para+", "+aguerrissement+", "+corveteEte+", "+semaineEleve+", "+gantBlanc+", "+permisConduire+", "+najeur+", "+fumeur+", txtAutres.Text) == true)

                if (classRA.Ajouter_Eleve(cmbNom.Text, cmbPrenom.Text, para, aguerrissement, corveteEte, semaineEleve, gantBlanc, permisConduire, najeur, fumeur, txtAutres.Text) == true)
                {
                    DialogResult d = MessageBox.Show("Elève ajouté avec succés !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (d == DialogResult.OK)
                        btnActualiser_Click(sender, e);  //vider tous les champs
                    (usEleve as FM.UCL_Activite_List).ActualiserDataGridViewAct();
                   
                }
                else
                {
                    MessageBox.Show("Ce nom et Prénom existent déja; \n Veuillez Ajouter un neauveau Elève !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


            // ATTENTION : c'est ce qui devrait faire le bouton modifier 
            else  //si lblTitre  == modifier eleve
            {
                
                DialogResult dr = MessageBox.Show("Voulez-vous vraiment modifier", "MODIFICATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    classRA.Modifier_Eleve(UCL_Activite_List.IDselect, cmbNom.Text, cmbPrenom.Text,  para, aguerrissement, corveteEte, semaineEleve, gantBlanc, permisConduire, najeur, fumeur, txtAutres.Text);
                    MessageBox.Show("Elève modifié avec succes", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    (usEleve as FM.UCL_Activite_List).ActualiserDataGridViewAct();  //actualiser dataGridView
                    Close();
                
                }
                else
                {
                    MessageBox.Show("Modification annulée", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void btnActualiser_Click(object sender, EventArgs e)
        {
            
            if (lblTitre.Text == "AJOUTER UNE ACTIVITE")
            {
                cmbNom.Text = "-- Choisir Nom --";
                cmbNom.ForeColor = Color.DimGray;
                cmbPrenom.Text = "-- Choisir Prénom --";
                cmbPrenom.ForeColor = Color.Gray;
            }

            cbPara.Checked = false; 
            cbAguerissement.Checked = false;
            cbCorvetteEte.Checked = false; 
            cbSemaineEleve.Checked = false; 
            cbGuantsBlancs.Checked = false; 
            cbPermisConduire.Checked = false;
            cbNajeur.Checked = false;
            cbFumeur.Checked = false;
            txtAutres.Text = "Autres....."; 

        }

        #region TEXT ENTER AND LEAVE
        private void cmbPrenom_Enter(object sender, EventArgs e)
        {
            cmbPrenom.ForeColor = Color.Black;
        }

        private void cmbNom_Enter(object sender, EventArgs e)
        {
            cmbNom.ForeColor = Color.Black;

        }

        private void txtAutres_Leave(object sender, EventArgs e)
        {
            if (txtAutres.Text == "")
            {
                txtAutres.Text = "Autres.....";
                txtAutres.ForeColor = Color.Black;
            }
        }

        private void txtAutres_Enter(object sender, EventArgs e)
        {
            if (txtAutres.Text == "Autres.....")
            {
                txtAutres.Text = "";
                txtAutres.ForeColor = Color.Silver;
            }
        }
        #endregion
    }
}
