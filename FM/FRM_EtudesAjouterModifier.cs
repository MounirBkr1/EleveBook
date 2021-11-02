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
    public partial class FRM_EtudesAjouterModifier : Form
    {
        private UserControl usEleve;  //pr le remplacer par USER_List_Client
        CL.CLS_R_EtudesTable classEt = new CL.CLS_R_EtudesTable();
        UC_Etudes_List userRS = new UC_Etudes_List();
        private Db_EleveBookEntities4 db;

        public FRM_EtudesAjouterModifier(UserControl userC)
        {
            InitializeComponent();
            this.usEleve = userC;

        }

        private void FRM_EtudesAjouterModifier_Load(object sender, EventArgs e)
        {
            
            if (lblTitreREtudes.Text == "AJOUTER DES DONNEES D'ETUDES")
            {
                db = new Db_EleveBookEntities4();
                this.cmbNom.DataSource = null;  //pour eviter l exception (Items collection cannot be modified when the DataSource property is set.')
                this.cmbNom.DataSource = null;
                cmbNom.DataSource = db.R_ElementairesTable.ToList();  //display all data
                cmbNom.DisplayMember = "Nom_Eleve"; //display only name
                cmbNom.ValueMember = "Id"; //display who has this id

                cmbPrenom.DataSource = db.R_ElementairesTable.ToList();  //display all data
                cmbPrenom.DisplayMember = "Prenom_Eleve"; //display only name
                cmbPrenom.ValueMember = "Nom_Eleve"; //display who has this id

                cmbNom.Text = "-- Choisir Nom --";
                cmbPrenom.Text = "-- Choisir Prénom --";
            }

            else
            {
                cmbNom.Enabled = false;
                cmbPrenom.Enabled = false;
            }

            cmbFiliere.SelectedIndex = 0;
            cmbOption.Enabled = false;
        }

        String testObligatoire()
        {
            if (cmbNom.Text == "choisir Elève")
                return "Veuillez choisir le Nom de l'élève parmis la liste ci dessous";
            return null;
        }

     

       

        public void btnActualiser_Click(object sender, EventArgs e)
        {
            if (lblTitreREtudes.Text == "AJOUTER DES DONNEES D'ETUDES")
            {
                cmbNom.Text = "-- Choisir Nom --";
                cmbNom.ForeColor = Color.Gray;
                cmbPrenom.Text = "-- Choisir Prénom --";
                cmbPrenom.ForeColor = Color.Gray;
            }

            //txtPrenom.Text = "Prénom"; txtPrenom.ForeColor = Color.DimGray

            cmbClassEleve.SelectedIndex = 0; cmbClassEleve.ForeColor = Color.Gray;
            cmbFiliere.SelectedIndex = 0; cmbFiliere.ForeColor = Color.Gray;
            cmbOption.SelectedIndex = 0; cmbOption.ForeColor = Color.Gray;
            cmbSousOption.SelectedIndex = 0; cmbSousOption.ForeColor = Color.Gray;
            cmbAnneeBac.SelectedIndex = 0; cmbAnneeBac.ForeColor = Color.Gray;
            cmbFilereBac.SelectedIndex = 0; cmbFilereBac.ForeColor = Color.Gray;

            txtNoteBac.Text = "Note Bac"; txtNoteBac.ForeColor = Color.Silver;
            txtLycee.Text = "Lycee / Ville"; txtLycee.ForeColor = Color.Silver;
            txtAutres.Text = "Autres....."; txtAutres.ForeColor = Color.Silver;
        }

        private void btnEnregistry_Click(object sender, EventArgs e)
        {
            if (testObligatoire() != null)  //un champ vide ou données incompatible
            {
                MessageBox.Show(testObligatoire(), "Champs Obligatoires", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

            else if (lblTitreREtudes.Text == "AJOUTER DES DONNEES D'ETUDES") // winform ajouter
            {

                if (classEt.Ajouter_Et(cmbNom.Text, cmbPrenom.Text, cmbClassEleve.Text, cmbFiliere.Text, cmbOption.Text, cmbSousOption.Text, txtNote1A.Text, txtNote2A.Text, txtNote3A.Text, txtNote4A.Text, txtNote5A.Text, txtNoteGlobale.Text, cmbAnneeBac.Text, cmbFilereBac.Text, txtNoteBac.Text, txtLycee.Text, txtAutres.Text) == true)
                {
                    DialogResult d = MessageBox.Show("Données ajoutées avec succés !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (d == DialogResult.OK)
                        btnActualiser_Click(sender, e);  //vider tous les champs
                    (usEleve as FM.UC_Etudes_List).ActualiserDataGridViewEtudes();

                }
                else
                {
                    MessageBox.Show("Ces données existent déja; \n Veuillez Ajouter un neauveau Elève !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


            // ATTENTION : c'est ce qui devrait faire le bouton modifier 
            else  //si lblTitre  == modifier eleve
            {

                DialogResult dr = MessageBox.Show("Voulez-vous vraiment modifier ces données", "MODIFICATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    MessageBox.Show("id =  " + UC_Etudes_List.IDselectREt);
                    classEt.Modifier_Et(UC_Etudes_List.IDselectREt, cmbNom.Text, cmbPrenom.Text, cmbClassEleve.Text, cmbFiliere.Text, txtNote1A.Text, txtNote2A.Text, txtNote3A.Text, txtNote4A.Text, txtNote5A.Text, txtNoteGlobale.Text, cmbOption.Text, cmbSousOption.Text, cmbAnneeBac.Text, cmbFilereBac.Text, txtNoteBac.Text, txtLycee.Text, txtAutres.Text);
                    MessageBox.Show("Données modifiés avec succès", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    (usEleve as UC_Etudes_List).ActualiserDataGridViewEtudes();  //actualiser dataGridView
                    Close();
                   
                }
                else
                {
                    MessageBox.Show("Modification annulée", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #region TEXT ENTER AND LEAVE
        private void cmbNom_Enter(object sender, EventArgs e)
        {
            cmbNom.ForeColor = Color.Black;
        }

        private void cmbPrenom_Enter(object sender, EventArgs e)
        {
            cmbPrenom.ForeColor = Color.Black;
        }

        private void cmbClassEleve_Enter(object sender, EventArgs e)
        {
            cmbClassEleve.ForeColor = Color.Black;
        }

        private void cmbOption_Enter(object sender, EventArgs e)
        {
            cmbFiliere.ForeColor = Color.Black;
        }

        private void cmbFiliere_Enter(object sender, EventArgs e)
        {
            cmbOption.ForeColor = Color.Black;
        }

        private void cmbSousOption_Enter(object sender, EventArgs e)
        {
            cmbSousOption.ForeColor = Color.Black;
        }

        private void cmbAnneeBac_Enter(object sender, EventArgs e)
        {
            cmbAnneeBac.ForeColor = Color.Black;
        }

        private void cmbFilereBac_Enter(object sender, EventArgs e)
        {
            cmbFilereBac.ForeColor = Color.Black;
        }

        private void txtNoteBac_Enter(object sender, EventArgs e)
        {
            if(txtNoteBac.Text == "Note Bac")
            {
                txtNoteBac.Text = "";
                txtNoteBac.ForeColor = Color.Black;
            }
        }

        private void txtLycee_Enter(object sender, EventArgs e)
        {
            if(txtLycee.Text == "Lycee / Ville")
            {
                txtLycee.Text = "";
                txtLycee.ForeColor = Color.Black;
            }
        }
             
        private void txtAutres_Enter(object sender, EventArgs e)
        {
            if(txtAutres.Text== "Autres.....")
            {
                txtAutres.Text = "";
                txtAutres.ForeColor = Color.Black;
            }
        }
       

        private void txtNoteBac_Leave(object sender, EventArgs e)
        {
            if (txtNoteBac.Text == "")
            {
                txtNoteBac.Text = "Note Bac";
                txtNoteBac.ForeColor = Color.Silver;
            }
        }

        private void txtLycee_Leave(object sender, EventArgs e)
        {
            if (txtLycee.Text == "")
            {
                txtLycee.Text = "Lycee / Ville";
                txtLycee.ForeColor = Color.Silver;
            }
        }

        private void txtAutres_Leave(object sender, EventArgs e)
        {
            if (txtAutres.Text == "")
            {
                txtAutres.Text = "Autres.....";
                txtAutres.ForeColor = Color.Silver;
            }
        }

        #endregion

        private void cmbFiliere_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbOption.Items.Clear();

            int selectedIndex = cmbFiliere.SelectedIndex;

            if (selectedIndex == 0)
            {
                cmbOption.Items.Add(" -- Option --");
                cmbOption.Enabled = false;
            }

             else if (selectedIndex == 1)
            {
                cmbOption.Items.Clear();
                cmbOption.Enabled = true;
                cmbOption.Items.Add(" -- Option --");
                cmbOption.Items.Add("TELECOM");
                cmbOption.Items.Add("S.RADAR");
                cmbOption.Items.Add("INFORMATIQUE");
                cmbOption.Items.Add("S.D'ARME");
            }

            else if (selectedIndex == 2)
            {
                cmbOption.Items.Clear();
                cmbOption.Enabled = true;
                cmbOption.Items.Add(" -- Option --");
                cmbOption.Items.Add("THERMIQUE");
                cmbOption.Items.Add("ELECTRIQUE");
            }
                
        }

    }
}
