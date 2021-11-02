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
    public partial class FRML_PTC_AjouterModifier : Form
    {
        private UserControl usEleve;  //pr le remplacer par USER_List_Client
        CL.CLSL_PtcTable classPTC = new CL.CLSL_PtcTable();
        UCL_PTC_List userRArret = new UCL_PTC_List();
        private Db_EleveBookEntities4 db;

        public FRML_PTC_AjouterModifier(UserControl user)
        {
            InitializeComponent();
            this.usEleve = user;
        }

        private void FRML_PTC_AjouterModifier_Load(object sender, EventArgs e)
        {
            if (lblTitre.Text == "AJOUTER   PTC")
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

                cmbNom.Text = "-- Choisir Elève --";
                cmbPrenom.Text = "-- Choisir Prénom --";
                
            }

            else
            {
                cmbNom.Enabled = false;
                cmbPrenom.Enabled = false;
            }
                    
        }

        String testObligatoire()
        {
            if (cmbNom.Text == "choisir Elève")
                return "Veuillez choisir le Nom de l'élève parmis la liste ci dessous";
            return null;
        }

      

       
        private void btnEnregistry_Click(object sender, EventArgs e)
        {
            if (testObligatoire() != null)  //un champ vide ou données incompatible
            {
                MessageBox.Show(testObligatoire(), "Champs Obligatoires", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

            else if (lblTitre.Text == "AJOUTER   PTC") //tous les champs remplis
            {
                             
                if (classPTC.Ajouter_PTC(cmbNom.Text, cmbPrenom.Text, cmbPTCExemption.Text, cmbNbreJours.Text, txtMotifPTC.Text, txtDate.Text, txtAutres.Text) == true)
                {
                    DialogResult d = MessageBox.Show("Données ajoutées avec succés !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (d == DialogResult.OK)
                        this.Close();
                    (usEleve as FM.UCL_PTC_List).ActualiserDataGridView();

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
                    classPTC.Modifier_PTC(UCL_PTC_List.IDselect, cmbNom.Text, cmbPrenom.Text, cmbPTCExemption.Text, cmbNbreJours.Text, txtMotifPTC.Text, txtDate.Text, txtAutres.Text);
                    MessageBox.Show("Données modifiés avec succès", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    (usEleve as UCL_PTC_List).ActualiserDataGridView();  //actualiser dataGridView
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Modification annulée", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void btnActualiser_Click(object sender, EventArgs e)
        {
            if (lblTitre.Text == "AJOUTER   PTC")
            {
                cmbNom.Text = "-- Choisir Nom --";
                cmbNom.ForeColor = Color.Gray;
                cmbPrenom.Text = "-- Choisir Prénom --";
                cmbPrenom.ForeColor = Color.Gray;
            }


            cmbPTCExemption.SelectedIndex = 0; cmbPTCExemption.ForeColor = Color.Gray;
            cmbNbreJours.SelectedIndex = 0; cmbPTCExemption.ForeColor = Color.Gray;
            txtMotifPTC.Text = "Motif du PTC"; txtMotifPTC.ForeColor = Color.Silver;
            txtDate.Text = "Date"; txtDate.ForeColor = Color.Silver;
            txtAutres.Text = "Autres....."; txtAutres.ForeColor = Color.Silver;
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

        private void cmbPTCExemption_Enter(object sender, EventArgs e)
        {
            cmbPTCExemption.ForeColor = Color.Black;
        }

        private void cmbNbreJours_Enter(object sender, EventArgs e)
        {
            cmbNbreJours.ForeColor = Color.Black;
        }

        private void txtDate_Enter(object sender, EventArgs e)
        {
            if (txtDate.Text == "Date")
            {
                txtDate.Text = "";
                txtDate.ForeColor = Color.Black;
            }
                  
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            if (txtDate.Text == "")
            {
                txtDate.Text = "Date";
                txtDate.ForeColor = Color.Silver;
            }
        }

        private void txtMotifPTC_Enter(object sender, EventArgs e)
        {
            if (txtMotifPTC.Text == "Motif du PTC")
            {
                txtMotifPTC.Text = "";
                txtMotifPTC.ForeColor = Color.Black;
            }
        }

        private void txtMotifPTC_Leave(object sender, EventArgs e)
        {
            if (txtMotifPTC.Text == "")
            {
                txtMotifPTC.Text = "Motif du PTC";
                txtMotifPTC.ForeColor = Color.Silver;
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
    }
}
