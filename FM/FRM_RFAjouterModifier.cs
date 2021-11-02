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
    public partial class FRM_RFAjouterModifier : Form
    {
        private UserControl usEleve;  //pr le remplacer par USER_List_Client
        CL.CLS_R_famillialesTable classRF = new CL.CLS_R_famillialesTable();
        UC_RS_List userRS = new UC_RS_List();
        private Db_EleveBookEntities4 db;

        public FRM_RFAjouterModifier(UserControl userC)
        {
            InitializeComponent();
            this.usEleve = userC;
        }

        private void FRM_RFAjouterModifier_Load(object sender, EventArgs e)
        {
            if (lblTitre.Text == "AJOUTER  DONNEES  FAMILIALES")
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

                cmbNom.Text = "-- choisir Nom --";
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
            if (cmbNom.Text == "-- choisir Nom --")
                return "Veuillez choisir le Nom de l'élève parmis la liste ci dessous";
            if (cmbNom.Text == "-- choisir Prénom --")
                return "Veuillez choisir le Prénom de l'élève parmis la liste ci dessous";
            return null;
        }


        #region TEXT ENTER AND LEAVE

        private void txtPrenomPere_Enter(object sender, EventArgs e)
        {
            if (txtPrenomPere.Text == "Prénom Père")
            {
                txtPrenomPere.Text = "";
                txtPrenomPere.ForeColor = Color.Black;
            }
        }

        private void txtPrenomMere_Enter(object sender, EventArgs e)
        {
            if (txtPrenomMere.Text == "Prénom Mère")
            {
                txtPrenomMere.Text = "";
                txtPrenomMere.ForeColor = Color.Black;
            }
        }

        private void txtNomMere_Enter(object sender, EventArgs e)
        {
            
                 if (txtNomMere.Text == "Nom Mère")
            {
                txtNomMere.Text = "";
                txtNomMere.ForeColor = Color.Black;
            }


        }

        private void txtFonctionPere_Enter(object sender, EventArgs e)
        {
            
                  if (txtFonctionPere.Text == "Fonction Père")
            {
                txtFonctionPere.Text = "";
                txtFonctionPere.ForeColor = Color.Black;
            }
        }

        private void txtFonctionMere_Enter(object sender, EventArgs e)
        {
            
                       if (txtFonctionMere.Text == "Fonction Mère")
            {
                txtFonctionMere.Text = "";
                txtFonctionMere.ForeColor = Color.Black;
            }
        }

        private void txtTelephoneParents_Enter(object sender, EventArgs e)
        {
            
             if (txtTelephoneParents.Text == "Téléphone Parents")
            {
                txtTelephoneParents.Text = "";
                txtTelephoneParents.ForeColor = Color.Black;
            }
        }

        private void txtPersonneAContacter_Enter(object sender, EventArgs e)
        {
            
            if (txtPersonneAContacter.Text == "Tél.Personne A Contacter")
            {
                txtPersonneAContacter.Text = "";
                txtPersonneAContacter.ForeColor = Color.Black;
            }
        }

        private void txtAdresseParents_Enter(object sender, EventArgs e)
        {
            
                 if (txtAdresseParents.Text == "Adresse des Parents")
            {
                txtAdresseParents.Text = "";
                txtAdresseParents.ForeColor = Color.Black;
            }
        }

        private void txtPrenomPere_Leave(object sender, EventArgs e)
        {
            if (txtPrenomPere.Text == "")
            {
                txtPrenomPere.Text = "Prénom Père";
                txtPrenomPere.ForeColor = Color.Silver;
            }
        }

        private void txtPrenomMere_Leave(object sender, EventArgs e)
        {
            if (txtPrenomMere.Text == "")
            {
                txtPrenomMere.Text = "Prénom Mère";
                txtPrenomMere.ForeColor = Color.Silver;
            }
        }

        private void txtNomMere_Leave(object sender, EventArgs e)
        {
            if (txtNomMere.Text == "")
            {
                txtPrenomMere.Text = "Nom Mère";
                txtNomMere.ForeColor = Color.Silver;
            }
        }

        private void txtFonctionPere_Leave(object sender, EventArgs e)
        {
            if (txtFonctionPere.Text == "")
            {
                txtFonctionPere.Text = "Fonction Père";
                txtFonctionPere.ForeColor = Color.Silver;
            }
        }

        private void txtFonctionMere_Leave(object sender, EventArgs e)
        {
            if (txtFonctionMere.Text == "")
            {
                txtFonctionMere.Text = "Fonction Mère";
                txtFonctionMere.ForeColor = Color.Silver;
            }
        }

        private void txtTelephoneParents_Leave(object sender, EventArgs e)
        {
            if (txtTelephoneParents.Text == "")
            {
                txtTelephoneParents.Text = "Téléphone Parents";
                txtTelephoneParents.ForeColor = Color.Silver;
            }
        }

        private void txtPersonneAContacter_Leave(object sender, EventArgs e)
        {
            if (txtPersonneAContacter.Text == "")
            {
                txtPersonneAContacter.Text = "Tél.Personne A Contacter";
                txtPersonneAContacter.ForeColor = Color.Silver;
            }
        }

        private void txtAdresseParents_Leave(object sender, EventArgs e)
        {
            if (txtAdresseParents.Text == "")
            {
                txtAdresseParents.Text = "Adresse des Parents";
                txtAdresseParents.ForeColor = Color.Silver;
            }
        }

        private void txtAutres_Enter(object sender, EventArgs e)
        {
            if (txtAutres.Text == "Autres.....")
            {
                txtAutres.Text = "";
                txtAutres.ForeColor = Color.Black;
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


        private void btnEnregistrer_Click_1(object sender, EventArgs e)
        {
            if (testObligatoire() != null)  //un champ vide ou données incompatible
            {
                MessageBox.Show(testObligatoire(), "Champs Obligatoires", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

            else if (lblTitre.Text == "AJOUTER  DONNEES  FAMILIALES") //tous les champs remplis
            {

                if (classRF.Ajouter_RF(cmbNom.Text, cmbPrenom.Text, txtPrenomPere.Text, txtPrenomMere.Text, txtNomMere.Text, cmbNbreFreres.Text, cmbNbreSoeurs.Text, txtFonctionPere.Text, txtFonctionMere.Text, txtAdresseParents.Text, txtTelephoneParents.Text, txtPersonneAContacter.Text, txtAutres.Text) == true)
                {
                    DialogResult d = MessageBox.Show("Données ajoutées avec succés !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (d == DialogResult.OK)
                        btnActualiser_Click(sender, e);  //vider tous les champs
                    (usEleve as FM.UC_RF_List).ActualiserDataGridViewRF();

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
                    classRF.Modifier_RF(UC_RF_List.IDselectRF, cmbNom.Text, cmbPrenom.Text, txtPrenomPere.Text, txtPrenomMere.Text, txtNomMere.Text, cmbNbreFreres.Text, cmbNbreSoeurs.Text, txtFonctionPere.Text, txtFonctionMere.Text, txtAdresseParents.Text, txtTelephoneParents.Text, txtPersonneAContacter.Text, txtAutres.Text);
                    MessageBox.Show("Données modifiés avec succès", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    (usEleve as UC_RF_List).ActualiserDataGridViewRF();  //actualiser dataGridView
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
            if (lblTitre.Text == "AJOUTER  DONNEES  FAMILIALES")
            {
                cmbNom.Text = "-- Choisir Nom --";
                cmbNom.ForeColor = Color.Gray;
                cmbPrenom.Text = "-- Choisir Prénom --";
                cmbPrenom.ForeColor = Color.Gray;
            }

            txtPrenomPere.Text = "Prénom Père"; txtPrenomPere.ForeColor = Color.Silver;
            txtPrenomMere.Text = "Prénom Mère"; txtPrenomMere.ForeColor = Color.Silver;
            txtNomMere.Text = "Nom Mère"; txtNomMere.ForeColor = Color.Silver;

            cmbNbreFreres.SelectedIndex = 0; cmbNbreFreres.ForeColor = Color.Silver;
            cmbNbreSoeurs.SelectedIndex = 0; cmbNbreSoeurs.ForeColor = Color.Silver;

            txtFonctionPere.Text = "Fonction Père"; txtFonctionPere.ForeColor = Color.Silver;
            txtFonctionMere.Text = "Fonction Mère"; txtFonctionMere.ForeColor = Color.Silver;
            txtAdresseParents.Text = "Adresse des Parents"; txtAdresseParents.ForeColor = Color.Silver;
            txtTelephoneParents.Text = "Téléphone Parents"; txtTelephoneParents.ForeColor = Color.Silver;
            txtPersonneAContacter.Text = "Tél.Personne A Contacter"; txtPersonneAContacter.ForeColor = Color.Silver;
            txtAutres.Text = "Autres....."; txtAutres.ForeColor = Color.Silver;
        }

        private void cmbNom_Enter(object sender, EventArgs e)
        {
            cmbNom.ForeColor = Color.Black;
        }

        private void cmbPrenom_Enter(object sender, EventArgs e)
        {
            cmbPrenom.ForeColor = Color.Black;
        }

        private void cmbNbreFreres_Enter(object sender, EventArgs e)
        {
            cmbNbreFreres.ForeColor = Color.Black;
        }

        private void cmbNbreSoeurs_Enter(object sender, EventArgs e)
        {
            cmbNbreSoeurs.ForeColor = Color.Black;
        }
    }
}
